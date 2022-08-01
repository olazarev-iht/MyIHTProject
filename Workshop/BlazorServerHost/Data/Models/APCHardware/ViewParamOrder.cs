namespace BlazorServerHost.Data.Models.APCHardware
{
    public class ViewParamOrder
    {
        public Guid Id { get; set; }
        public string ParamName { get; set; } = string.Empty;
        public Guid ViewParamGroupId { get; set; }
        public ViewParamGroup? ViewParamGroup { get; set; }
        public int ViewItemOrder { get; set; }
    }
}
