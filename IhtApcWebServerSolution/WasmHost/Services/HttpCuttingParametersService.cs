using System.Net.Http.Json;
using SharedComponents.Models;
using SharedComponents.Services;

namespace WasmHost.Services;

public class HttpCuttingParametersService : ICuttingParametersService
{
	private readonly HttpClient _client;

	public HttpCuttingParametersService(HttpClient client)
	{
		_client = client;
	}

	private HttpClient GetClient() => _client;

	public async Task<PagedResult<CuttingParametersModel>> GetEntriesAsync(int skip, int take, CancellationToken cancellationToken)
	{
		await Task.Delay(TimeSpan.FromSeconds(3));

		var client = GetClient();
		var result = await client.GetFromJsonAsync<PagedResult<CuttingParametersModel>>(
			$"CuttingParameters?skip={skip}&take={take}", cancellationToken);
		return result!;
	}

	public async Task<CuttingParametersModel?> GetEntryByIdAsync(Guid id, CancellationToken cancellationToken)
	{
		var client = GetClient();
		var result = await client.GetFromJsonAsync<CuttingParametersModel>(
			$"CuttingParameters/{id}", cancellationToken);
		return result!;
	}

	public async Task<Guid> AddEntryAsync(CuttingParametersModel model, CancellationToken cancellationToken)
	{
		var client = GetClient();
		var result = await client.PostAsJsonAsync($"CuttingParameters", model, cancellationToken);
		return (await result.Content.ReadFromJsonAsync<IdResult>(cancellationToken: cancellationToken))!.Id;
	}

	private class IdResult
	{
		public Guid Id { get; set; }
	}

	public async Task UpdateEntryAsync(Guid id, CuttingParametersModel newData, CancellationToken cancellationToken)
	{
		var client = GetClient();
		var result = await client.PutAsJsonAsync($"CuttingParameters/{id}", newData, cancellationToken);
		if (!result.IsSuccessStatusCode)
		{
			throw new InvalidOperationException();
		}
	}

	public async Task DeleteEntryAsync(Guid id, CancellationToken cancellationToken)
	{
		var client = GetClient();
		var result = await client.DeleteAsync($"CuttingParameters/{id}", cancellationToken);
		if (!result.IsSuccessStatusCode)
		{
			throw new InvalidOperationException();
		}
	}
}