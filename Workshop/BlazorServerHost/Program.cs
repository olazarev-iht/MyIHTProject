using Blazored.LocalStorage;
using BlazorServerHost;
using BlazorServerHost.Areas.Identity;
using BlazorServerHost.Data;
using BlazorServerHost.Features.HeightControlFeature;
using BlazorServerHost.Services;
using BlazorServerHost.Services.APCWorkerService;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using MudBlazor.Services;
using SharedComponents.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseWindowsService();

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<UnitService>();
builder.Services.AddHttpContextAccessor();

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("ApplicationDbContext");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
	options.UseSqlite(connectionString));

builder.Services.AddLocalization(options => options.ResourcesPath = "Cultures");
builder.Services.AddScoped<IStringLocalizer<App>, StringLocalizer<App>>();

builder.Services.AddHostedService<BackgroundHardwareMonitor>();
builder.Services.AddSingleton<IHardwareStatusService, FakeHardwareStatusService>();
builder.Services.AddSingleton<IAPCWorkerService, APCWorkerService>();

builder.Services.AddCors();
builder.Services.AddMvc();
builder.Services.AddDbContextFactory<CuttingParametersDbContext>(options =>
{
	options.UseSqlite(builder.Configuration.GetConnectionString("CuttingParametersDbContext"));
});
builder.Services.AddDbContextFactory<HardwareAPCDbContext>(options =>
{
	options.UseSqlite(builder.Configuration.GetConnectionString("CuttingParametersDbContext"));
});

builder.Services.AddScoped<ICuttingParametersService, CuttingParametersService>();
builder.Services.AddSingleton<IHardwareAPCServise, HardwareAPCServise>();
builder.Services.AddSingleton<CommunicationsService>();
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddDefaultIdentity<IdentityUser>(options =>
	{
		options.SignIn.RequireConfirmedAccount = false;
		options.Password.RequiredLength = 4;
		options.Password.RequireDigit = false;
		options.Password.RequireLowercase = false;
		options.Password.RequireNonAlphanumeric = false;
		options.Password.RequireUppercase = false;
		options.Password.RequiredUniqueChars = 0;
	})
	.AddRoles<IdentityRole>()
	.AddEntityFrameworkStores<ApplicationDbContext>()
	;

builder.Services.AddHeightControlFeature();
builder.Services.AddLiveAPCParamsDataFeature();
builder.Services.AddDynamicAPCParamsDataFeature();

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();
builder.Services.AddSingleton<WeatherForecastService>();

builder.Services.AddMudServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	// app.UseMigrationsEndPoint();
}
else
{
	app.UseExceptionHandler("/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	// app.UseHsts();
}

app.UseHttpsRedirection();
app.UseCors(pb => pb.AllowAnyHeader().AllowAnyMethod().AllowCredentials().SetIsOriginAllowed(o => true));
app.UseStaticFiles();

app.UseRouting();

var supportedCultures = new[] { "en-US", "de-DE", "ar-SA", "uk" };
var localizationOptions = new RequestLocalizationOptions()
	.SetDefaultCulture(supportedCultures[1])
	.AddSupportedCultures(supportedCultures)
	.AddSupportedUICultures(supportedCultures);

app.UseRequestLocalization(localizationOptions);

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

try
{
	// Do run our migrations here before starting the host
	using (var scope = app.Services.CreateScope())
	{
		using var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
		using var tx = dbContext.Database.BeginTransaction();
		await dbContext.Database.MigrateAsync();

		// todo: add reasonable seeding logic
		var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
		if (! await roleManager.Roles.AnyAsync())
		{
			await roleManager.CreateAsync(new IdentityRole("User"));
			await roleManager.CreateAsync(new IdentityRole("Administrator"));
		}

		// add any users not in the user group to it. This is not the best place to do it,
		// instead registration should be customized
		var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
		foreach (var user in await dbContext.Users.ToArrayAsync())
		{
			if (!await userManager.IsInRoleAsync(user, "User"))
			{
				await userManager.AddToRoleAsync(user, "User");
			}
		}

		await tx.CommitAsync();
	}

	// migrate CuttingParametersDbContext
	using (var ctx = app.Services.GetRequiredService<IDbContextFactory<CuttingParametersDbContext>>().CreateDbContext())
	{
		using var tx = ctx.Database.BeginTransaction();
		await ctx.Database.MigrateAsync();
		await tx.CommitAsync();
	}

	// migrate HardwareAPCDbContext
	using (var ctx = app.Services.GetRequiredService<IDbContextFactory<HardwareAPCDbContext>>().CreateDbContext())
	{
		using var tx = ctx.Database.BeginTransaction();
		await ctx.Database.MigrateAsync();
		await tx.CommitAsync();
	}

	await app.RunAsync();
	return 0;
}
catch (Exception ex)
{
	Console.WriteLine($"A fatal exception caused the service to crash: {ex.Message}");
	return 1;
}
