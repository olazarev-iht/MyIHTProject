using SharedComponents.Models.CuttingData;
using MudBlazor;

namespace BlazorServerHost.Features.HeightControlFeature.Components
{
    //public partial class APCCuttingDataDisplay
    //{
    //    //private PagedResult<CuttingParametersModel>? parameters;

    //    //private IEnumerable<CuttingDataModel>? entries => parameters?.Entries;

    //    //protected override async Task OnInitializedAsync()
    //    //{
    //    //    parameters = await parametersService.GetEntriesAsync(0, 20, CancellationToken.None);
    //    //}

    //    private string searchString = "";
    //    private CuttingDataModel cuttingDataModel = new CuttingDataModel();
    //    private List<CuttingDataModel> cuttingDataModelList = new List<CuttingDataModel>();
    //    protected override async Task OnInitializedAsync()
    //    {
    //        await GetEntriesAsync();
    //    }
    //    private async Task<List<CuttingDataModel>> GetEntriesAsync()
    //    {
    //        cuttingDataModelList = await cuttingDataDBService.GetEntriesAsync(CancellationToken.None);
    //        return cuttingDataModelList;
    //    }
    //    private bool Search(CuttingDataModel cuttingDataModel)
    //    {
    //        if (string.IsNullOrWhiteSpace(searchString)) return true;
    //        if ((cuttingDataModel.Material?.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase) ?? false)
    //            //|| cuttingDataModel.Thickness == (searchString, StringComparison.OrdinalIgnoreCase)
    //            || (cuttingDataModel.Nozzle?.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase) ?? false))
    //        {
    //            return true;
    //        }
    //        return false;
    //    }
    //    private async void Save()
    //    {
    //        await cuttingDataDBService.AddEntryAsync(cuttingDataModel, CancellationToken.None);
    //        cuttingDataModel = new CuttingDataModel();
    //        snackBar.Add("Customer Saved.", Severity.Success);
    //        await GetEntriesAsync();
    //    }
    //    private void Edit(Guid id)
    //    {
    //        cuttingDataModel = cuttingDataModelList.FirstOrDefault(c => c.Id == id) ?? new CuttingDataModel();
    //    }
    //    private async void Delete(Guid id)
    //    {
    //        await cuttingDataDBService.DeleteEntryAsync(id, CancellationToken.None);
    //        snackBar.Add("Customer Deleted.", Severity.Success);
    //        await GetEntriesAsync();
    //    }
    //}
}
