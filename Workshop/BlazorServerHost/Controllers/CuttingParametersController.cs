 
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SharedComponents.Models;
using SharedComponents.Services;

namespace BlazorServerHost.Controllers
{
	[ApiController]
	[Route("api/v1/[Controller]")]
	public class CuttingParametersController : Controller
	{
		private readonly ICuttingParametersService _scv;

		public CuttingParametersController(ICuttingParametersService scv)
		{
			_scv = scv ?? throw new ArgumentNullException(nameof(scv));
		}

		[HttpGet]
		public async Task<PagedResult<CuttingParametersModel>> GetPagedAsync(
			[FromQuery] int skip,
			[FromQuery] int take,
			CancellationToken cancellationToken)
		{
			return await _scv.GetEntriesAsync(skip, take, cancellationToken);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<CuttingParametersModel>> GetAsync(
			[FromRoute] Guid id,
			CancellationToken cancellationToken)
		{
			var entry = await _scv.GetEntryByIdAsync(id, cancellationToken);
			return (entry == null)
				? NotFound()
				: entry;
		}

		[HttpPost]
		public async Task<IActionResult> AddAsync(
			[FromBody] CuttingParametersModel model,
			CancellationToken cancellationToken)
		{
			var newId = await _scv.AddEntryAsync(model, cancellationToken);
			return Ok(new { Id = newId, });
		}

		[HttpPut("{id}")]
		public async Task<ActionResult<CuttingParametersModel>> UpdateAsync(
			[FromRoute] Guid id,
			[FromBody] CuttingParametersModel model,
			CancellationToken cancellationToken)
		{
			try
			{
				await _scv.UpdateEntryAsync(id, model, cancellationToken);
				return Ok();
			}
			catch
			{
				return NotFound();
			}
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult<CuttingParametersModel>> DeleteAsync(
			[FromRoute] Guid id,
			CancellationToken cancellationToken)
		{
			try
			{
				await _scv.DeleteEntryAsync(id, cancellationToken);
				return Ok();
			}
			catch (DbUpdateConcurrencyException)
			{
				return NotFound();
			}
		}
	}
}
