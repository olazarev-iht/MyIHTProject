using Blazored.LocalStorage;
using IhtApcWebServer;
using IhtApcWebServer.Areas.Identity;
using IhtApcWebServer.Data;
using IhtApcWebServer.Data.DataMapper;
using IhtApcWebServer.Features.HeightControlFeature;
using IhtApcWebServer.Services;
using IhtApcWebServer.Services.APCHardwareDBServices;
using IhtApcWebServer.Services.APCHardwareMockDBServices;
using IhtApcWebServer.Services.APCWorkerService;
using IhtApcWebServer.Services.CuttingDataDBServices;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Hosting.WindowsServices;
using Microsoft.Extensions.Localization;
using MudBlazor.Services;
using IhtApcWebServer.Services.APCCommunic;
using Serilog;
using SharedComponents.APCHardwareManagers;
using SharedComponents.CutDataRepository;
using SharedComponents.IhtData;
using SharedComponents.IhtDev;
using SharedComponents.IhtModbus;
using SharedComponents.Models;
using SharedComponents.Services;
using SharedComponents.Services.APCHardwareDBServices;
using SharedComponents.Services.APCHardwareManagers;
using SharedComponents.Services.APCHardwareMockDBServices;
using SharedComponents.Services.CuttingDataDBServices;
using SharedComponents.Services.APCWorkerService;
using System.Diagnostics;
using System.Net;
using SharedComponents.Helpers;
using SharedComponents.MqttModel;
using Serilog.Context;

var BaseDirectory = WindowsServiceHelpers.IsWindowsService() ? AppContext.BaseDirectory : default;

var options = new WebApplicationOptions
{
	Args = args,
	ContentRootPath = BaseDirectory
};
var builder = WebApplication.CreateBuilder(options);

#region Service, CommandLineParams
var isService = !(Debugger.IsAttached || args.Contains("--console"));

if (isService)
{
	//  Directory.SetCurrentDirectory(Environment.ProcessPath!);
}

IhtCmdLineParams ihtCmdLineParams = IhtCmdLineParams.GetIhtCmdLineParams();

//var ihtCmdParams = IhtCmdLineParams.GetIhtCmdLineParams();
//bool isExhib = ihtCmdParams.IsSimulationExhibiton;

string tcpIpAddrServer = "127.0.0.1";
int tcpIpPortServer = 39419;

string cmdLineTcpIpAddrServer = String.Empty;
if (ihtCmdLineParams.GetParam(IhtCmdLineParams.IdNo.TcpIpAddrServer, ref cmdLineTcpIpAddrServer))
{
	tcpIpAddrServer = cmdLineTcpIpAddrServer;
}

int cmdLineTcpIpPortServer = 0;
if (ihtCmdLineParams.GetParam(IhtCmdLineParams.IdNo.TcpIpPortServer, ref cmdLineTcpIpPortServer))
{
	tcpIpPortServer = cmdLineTcpIpPortServer;
}

IPAddress iPAddress = IPAddress.Parse(tcpIpAddrServer);
builder.WebHost.ConfigureKestrel(serverOptions =>
{
	serverOptions.Listen(iPAddress, tcpIpPortServer);
});

string clientCode = "default";

string cmdLineClientCode = builder.Configuration["client"]; //--client

string cmdInstallationMode = builder.Configuration["m"]; //--m (mode)

if (!string.IsNullOrWhiteSpace(cmdLineClientCode))
{
	clientCode = cmdLineClientCode;
}

IhtModbusCommunic.clientCode = clientCode;
IhtModbusCommunic.installationMode = cmdInstallationMode;

#endregion // Service, CommandLineParams

//builder.Host.ConfigureAppConfiguration((hostingContext, config) =>
//{
//    config.Sources.Clear();

//    var env = hostingContext.HostingEnvironment;

//    config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
//          .AddJsonFile($"appsettings.{env.EnvironmentName}.json",
//                         optional: true, reloadOnChange: true);

//    config.AddEnvironmentVariables();

//    if (args != null)
//    {
//        config.AddCommandLine(args);
//    }
//});

builder.Services.AddOptions();
builder.Services.Configure<Settings>(builder.Configuration.GetSection("Settings"));
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<UnitService>();
builder.Services.AddScoped<HttpClient>();
builder.Services.AddHttpContextAccessor();

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("ApplicationDbContext");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
	options.UseSqlite(connectionString));

builder.Services.AddLocalization(options => options.ResourcesPath = "Cultures");
builder.Services.AddScoped<IStringLocalizer<App>, StringLocalizer<App>>();

builder.Services.AddHostedService<BackgroundHardwareMonitor>();
builder.Services.AddHostedService<APCWorkerBackgroundService>();
builder.Services.AddSingleton<APCWorkerBackgroundService>();
builder.Services.AddSingleton<IHardwareStatusService, FakeHardwareStatusService>();
builder.Services.AddSingleton<IAPCWorkerService, APCWorkerService>();

builder.Services.AddSingleton<IAPCWorker, APCWorker>();

builder.Services.AddCors();
builder.Services.AddMvc();
builder.Services.AddDbContextFactory<CuttingParametersDbContext>(options =>
{
	options.UseSqlite($"Data Source={BaseDirectory}CuttingParameters.db");
});
builder.Services.AddDbContextFactory<HardwareAPCDbContext>(options =>
{
	options.UseSqlite($"Data Source={BaseDirectory}CuttingParameters.db");
});
builder.Services.AddDbContextFactory<CuttingDataDbContext>(options =>
{
	//options.UseSqlite(builder.Configuration.GetConnectionString("CuttingDataDbContext"));
	options.UseSqlite($"Data Source={BaseDirectory}CuttingData.db");
});
builder.Services.AddDbContextFactory<APCHardwareMockDBContext>(options =>
{
	options.UseSqlite($"Data Source={BaseDirectory}APCHardwareMoq.db");
});
builder.Services.AddDbContextFactory<APCHardwareDBContext>(options =>
{
	options.UseSqlite($"Data Source={BaseDirectory}APCHardware.db");
});

builder.Services.AddScoped<ICuttingParametersService, CuttingParametersService>();

// CuttingData
builder.Services.AddSingleton<ICuttingDataDBService, CuttingDataDBService>();
builder.Services.AddSingleton<IGasDBService, GasDBService>();
builder.Services.AddSingleton<IMaterialDBService, MaterialDBService>();
builder.Services.AddSingleton<INozzleDBService, NozzleDBService>();

// APC DB
builder.Services.AddSingleton<IAPCDeviceDBService, APCDeviceDBService>();
builder.Services.AddSingleton<IConstParamsDBService, ConstParamsDBService>();
builder.Services.AddSingleton<IDynParamsDBService, DynParamsDBService>();
builder.Services.AddSingleton<ILiveParamsDBService, LiveParamsDBService>();
builder.Services.AddSingleton<IParameterDataDBService, ParameterDataDBService>();
builder.Services.AddSingleton<IParameterDataInfoDBService, ParameterDataInfoDBService>();
builder.Services.AddSingleton<IAPCDefaultDataMockDBService, APCDefaultDataMockDBService>();
builder.Services.AddSingleton<IConfigSettingsDBService, ConfigSettingsDBService>();
builder.Services.AddSingleton<IErrorLogDBService, ErrorLogDBService>();

// APC Mock DB
builder.Services.AddSingleton<IAPCDeviceMockDBService, APCDeviceMockDBService>();
builder.Services.AddSingleton<IConstParamsMockDBService, ConstParamsMockDBService>();
builder.Services.AddSingleton<IDynParamsMockDBService, DynParamsMockDBService>();
builder.Services.AddSingleton<ILiveParamsMockDBService, LiveParamsMockDBService>();
builder.Services.AddSingleton<IParameterDataMockDBService, ParameterDataMockDBService>();
builder.Services.AddSingleton<IAPCSimulationDataMockDBService, APCSimulationDataMockDBService>();

// APC Managers
builder.Services.AddSingleton<IParameterDataInfoManager, ParameterDataInfoManager>();

builder.Services.AddSingleton<IHardwareAPCServise, HardwareAPCServise>();
builder.Services.AddSingleton<IhtDevices>();
builder.Services.AddTransient<IhtDevice>(); 
builder.Services.AddTransient<DataProcessInfo>();

builder.Services.AddSingleton<SystemSettings>();
builder.Services.AddSingleton<IhtModbusCommunic>();
builder.Services.AddSingleton<IhtModbusCommunicData>(); 
builder.Services.AddSingleton<APCCommunicManager>();
builder.Services.AddSingleton<CommunicationsService>();
//builder.Services.AddSingleton<DataCommon>();
builder.Services.AddSingleton<IhtCutDataAddressMap>();
builder.Services.AddSingleton<MqttModelFactory>();

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
	.AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddSingleton<DbModelMapper>();

builder.Services.AddHeightControlFeature();
builder.Services.AddLiveAPCParamsDataFeature();
builder.Services.AddDynamicAPCParamsDataFeature();
builder.Services.AddDynDataModificationCNCDisplayFeature();

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();
builder.Services.AddSingleton<WeatherForecastService>();

builder.Services.AddMudServices();

//var logger = new LoggerConfiguration()
//			.WriteTo.Console()
//			.WriteTo.SQLite(Environment.CurrentDirectory + @"\Log.db")
//			.ReadFrom.Configuration(builder.Configuration)
//			.Enrich.FromLogContext()
//			//.Enrich.With<SerilogContextEnricher>()
//			.CreateLogger();

//builder.Logging.ClearProviders();
//builder.Logging.AddSerilog(logger);

builder.Host.UseWindowsService(options =>
{
	options.ServiceName = "IHT APC WebServer Service";
});

//builder.Host.UseSerilog();

//builder.Host.UseSerilog((ctx, lc) => lc
//	.WriteTo.Console()
//	.Enrich.FromLogContext()
//	.WriteTo.SQLite(Environment.CurrentDirectory + @"\Log.db")
//    .ReadFrom.Configuration(ctx.Configuration));

//LogContext.PushProperty("UserId", 12);
Log.Information("Starting up 1111");

var app = builder.Build();

//#if false
//SharedComponents.MqttModel.Exec.DataBase.ExecDataBaseRequest.
//	CuttingDataDBServiceConfigure(builder.Services.BuildServiceProvider().GetService<ICuttingDataDBService>());
//SharedComponents.MqttModel.Exec.DataBase.ExecDataBaseRequest.
//	IhtDevicesConfigure(builder.Services.BuildServiceProvider().GetService<IhtDevices>());
//SharedComponents.MqttModel.Exec.DataBase.ExecDataBaseRequest.
//  ParameterDataInfoManagerConfigure(builder.Services.BuildServiceProvider().GetService<IParameterDataInfoManager>());
//SharedComponents.MqttModel.Exec.DataBase.ExecDataBaseRequest.
//  APCWorkerConfigure(builder.Services.BuildServiceProvider().GetService<IAPCWorker>());
//#else
//SharedComponents.MqttModel.Exec.DataBase.ExecDataBaseRequest.
//  CuttingDataDBServiceConfigure(app.Services.GetRequiredService<ICuttingDataDBService>());
//SharedComponents.MqttModel.Exec.DataBase.ExecDataBaseRequest.
//  IhtDevicesConfigure(app.Services.GetRequiredService<IhtDevices>());
//SharedComponents.MqttModel.Exec.DataBase.ExecDataBaseRequest.
//  ParameterDataInfoManagerConfigure(app.Services.GetRequiredService<IParameterDataInfoManager>());
//SharedComponents.MqttModel.Exec.DataBase.ExecDataBaseRequest.
//  APCWorkerConfigure(app.Services.GetRequiredService<IAPCWorker>());

//#endif

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

var supportedCultures = new[] { "en-US", "de-DE", "fr-FR", "it-IT", "hu-HU", "nl-NL", "sl-SI", "zH-Hans", "en-GB" };
var localizationOptions = new RequestLocalizationOptions()
	.SetDefaultCulture(supportedCultures[0])
	.AddSupportedCultures(supportedCultures[0])
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

	// migrate CuttingDataDbContext
	using (var ctx = app.Services.GetRequiredService<IDbContextFactory<CuttingDataDbContext>>().CreateDbContext())
	{
		using var tx = ctx.Database.BeginTransaction();
		await ctx.Database.MigrateAsync();
		await tx.CommitAsync();

		//await ctx.Database.ExecuteSqlRawAsync(@"DELETE FROM [sqlite_sequence]; insert into sqlite_sequence(name,seq) values('CuttingData', 50000);");
	}

	// migrate APCHardwareMoqDBContext
	using (var ctx = app.Services.GetRequiredService<IDbContextFactory<APCHardwareMockDBContext>> ().CreateDbContext())
	{
		using var tx = ctx.Database.BeginTransaction();
		await ctx.Database.MigrateAsync();
		await tx.CommitAsync();
	}

	// migrate APCHardwareDBContext
	using (var ctx = app.Services.GetRequiredService<IDbContextFactory<APCHardwareDBContext>>().CreateDbContext())
	{
		using var tx = ctx.Database.BeginTransaction();
		await ctx.Database.MigrateAsync();
		await tx.CommitAsync();
	}

#if false
SharedComponents.MqttModel.Exec.DataBase.ExecDataBaseRequest.
	CuttingDataDBServiceConfigure(builder.Services.BuildServiceProvider().GetService<ICuttingDataDBService>());
SharedComponents.MqttModel.Exec.DataBase.ExecDataBaseRequest.
	IhtDevicesConfigure(builder.Services.BuildServiceProvider().GetService<IhtDevices>());
SharedComponents.MqttModel.Exec.DataBase.ExecDataBaseRequest.
  ParameterDataInfoManagerConfigure(builder.Services.BuildServiceProvider().GetService<IParameterDataInfoManager>());
SharedComponents.MqttModel.Exec.DataBase.ExecDataBaseRequest.
  APCWorkerConfigure(builder.Services.BuildServiceProvider().GetService<IAPCWorker>());
#else
	SharedComponents.MqttModel.Exec.DataBase.ExecDataBaseRequest.
	  CuttingDataDBServiceConfigure(app.Services.GetRequiredService<ICuttingDataDBService>());
	SharedComponents.MqttModel.Exec.DataBase.ExecDataBaseRequest.
	  IhtDevicesConfigure(app.Services.GetRequiredService<IhtDevices>());
	SharedComponents.MqttModel.Exec.DataBase.ExecDataBaseRequest.
	  ParameterDataInfoManagerConfigure(app.Services.GetRequiredService<IParameterDataInfoManager>());
	SharedComponents.MqttModel.Exec.DataBase.ExecDataBaseRequest.
	  APCWorkerConfigure(app.Services.GetRequiredService<IAPCWorker>());

#endif

	await app.RunAsync();
	return 0;
}
catch (Exception ex)
{
	Console.WriteLine($"A fatal exception caused the service to crash: {ex.Message}");
	return 1;
}
