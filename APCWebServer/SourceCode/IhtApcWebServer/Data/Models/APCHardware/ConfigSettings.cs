namespace IhtApcWebServer.Data.Models.APCHardware
{
    public class ConfigSettings
    {
        public Guid Id { get; set; }
        public int? Mode { get; set; }
        public string? TcpPort { get; set; }
        public string? IpAddr { get; set; }
        public string? ComPort { get; set; }
        public string? Baudrate { get; set; }
        public string? DataBits { get; set; }
        public string? StopBits { get; set; }
        public string? Parity { get; set; }
        public string? Identifier { get; set; }
        public bool? TorchEnabled_01 { get; set; }
        public bool? TorchEnabled_02 { get; set; }
        public bool? TorchEnabled_03 { get; set; }
        public bool? TorchEnabled_04 { get; set; }
        public bool? TorchEnabled_05 { get; set; }
        public bool? TorchEnabled_06 { get; set; }
        public bool? TorchEnabled_07 { get; set; }
        public bool? TorchEnabled_08 { get; set; }
        public bool? TorchEnabled_09 { get; set; }
        public bool? TorchEnabled_10 { get; set; }
        public bool? TorchInstalled_01 { get; set; }
        public bool? TorchInstalled_02 { get; set; }
        public bool? TorchInstalled_03 { get; set; }
        public bool? TorchInstalled_04 { get; set; }
        public bool? TorchInstalled_05 { get; set; }
        public bool? TorchInstalled_06 { get; set; }
        public bool? TorchInstalled_07 { get; set; }
        public bool? TorchInstalled_08 { get; set; }
        public bool? TorchInstalled_09 { get; set; }
        public bool? TorchInstalled_10 { get; set; }
        public int? DataBaseMaterialSelectedIndex { get; set; }
        public int? DataBaseThicknessSelectedIndex { get; set; }
        public int? DataBaseNozzleSelectedIndex { get; set; }
        public Guid? DataBaseGuid { get; set; }
        public int? DataBaseId { get; set; }
        public int? TorchType { get; set; }
        public int? PressureUnit { get; set; }
        public int? LengthUnit { get; set; }
        public string? CultureStr { get; set; }
        public string? ComPortLast { get; set; }
        public bool? ExecReset { get; set; }
    }
}
