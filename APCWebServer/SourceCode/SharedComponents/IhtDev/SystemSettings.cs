using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedComponents.Models;
using SharedComponents.Services.APCHardwareDBServices;
using Microsoft.Extensions.Options;

namespace SharedComponents.IhtDev
{
    public class SystemSettings
    {
        static bool initialSettings = true;

        private int? _mode;
        public int? Mode 
        {
            get { return _mode; }

            set
            {
                _mode = value;

                var configSettings = _configSettingsDBService.GetEntryAsync(CancellationToken.None).Result;
                if(configSettings != null && !initialSettings)
                {
                    configSettings.Mode = value;
                    _configSettingsDBService.UpdateEntryAsync(configSettings, CancellationToken.None);
                }
            }
        }

        private string? _tcpPort;
        public string? TcpPort
        {
            get { return _tcpPort; }

            set
            {
                _tcpPort = value;

                var configSettings = _configSettingsDBService.GetEntryAsync(CancellationToken.None).Result;
                if (configSettings != null && !initialSettings)
                {
                    configSettings.TcpPort = value;
                    _configSettingsDBService.UpdateEntryAsync(configSettings, CancellationToken.None);
                }
            }
        }

        private string? _ipAddr;
        public string? IpAddr 
        {
            get { return _ipAddr; }

            set
            {
                _ipAddr = value;

                var configSettings = _configSettingsDBService.GetEntryAsync(CancellationToken.None).Result;
                if (configSettings != null && !initialSettings)
                {
                    configSettings.IpAddr = value;
                    _configSettingsDBService.UpdateEntryAsync(configSettings, CancellationToken.None);
                }
            }
        }

        private string? _comPort;
        public string? ComPort
        {
            get { return _comPort; }

            set
            {
                _comPort = value;

                var configSettings = _configSettingsDBService.GetEntryAsync(CancellationToken.None).Result;
                if (configSettings != null && !initialSettings)
                {
                    configSettings.ComPort = value;
                    _configSettingsDBService.UpdateEntryAsync(configSettings, CancellationToken.None);
                }
            }
        }

        private string? _baudrate;
        public string? Baudrate
        {
            get { return _baudrate; }

            set
            {
                _baudrate = value;

                var configSettings = _configSettingsDBService.GetEntryAsync(CancellationToken.None).Result;
                if (configSettings != null && !initialSettings)
                {
                    configSettings.Baudrate = value;
                    _configSettingsDBService.UpdateEntryAsync(configSettings, CancellationToken.None);
                }
            }
        }

        private string? _dataBits;
        public string? DataBits
        {
            get { return _dataBits; }

            set
            {
                _dataBits = value;

                var configSettings = _configSettingsDBService.GetEntryAsync(CancellationToken.None).Result;
                if (configSettings != null && !initialSettings)
                {
                    configSettings.DataBits = value;
                    _configSettingsDBService.UpdateEntryAsync(configSettings, CancellationToken.None);
                }
            }
        }

        private string? _stopBits;
        public string? StopBits
        {
            get { return _stopBits; }

            set
            {
                _stopBits = value;

                var configSettings = _configSettingsDBService.GetEntryAsync(CancellationToken.None).Result;
                if (configSettings != null && !initialSettings)
                {
                    configSettings.StopBits = value;
                    _configSettingsDBService.UpdateEntryAsync(configSettings, CancellationToken.None);
                }
            }
        }

        private string? _parity;
        public string? Parity
        {
            get { return _parity; }

            set
            {
                _parity = value;

                var configSettings = _configSettingsDBService.GetEntryAsync(CancellationToken.None).Result;
                if (configSettings != null && !initialSettings)
                {
                    configSettings.Parity = value;
                    _configSettingsDBService.UpdateEntryAsync(configSettings, CancellationToken.None);
                }
            }
        }

        private string? _identifier;
        public string? Identifier
        {
            get { return _identifier; }

            set
            {
                _identifier = value;

                var configSettings = _configSettingsDBService.GetEntryAsync(CancellationToken.None).Result;
                if (configSettings != null && !initialSettings)
                {
                    configSettings.Identifier = value;
                    _configSettingsDBService.UpdateEntryAsync(configSettings, CancellationToken.None);
                }
            }
        }

        private bool? _torchEnabled_01;
        public bool? TorchEnabled_01
        {
            get { return _torchEnabled_01; }

            set
            {
                _torchEnabled_01 = value;

                var configSettings = _configSettingsDBService.GetEntryAsync(CancellationToken.None).Result;
                if (configSettings != null && !initialSettings)
                {
                    configSettings.TorchEnabled_01 = value;
                    _configSettingsDBService.UpdateEntryAsync(configSettings, CancellationToken.None);
                }
            }
        }

        private bool? _torchEnabled_02;
        public bool? TorchEnabled_02
        {
            get { return _torchEnabled_02; }

            set
            {
                _torchEnabled_02 = value;

                var configSettings = _configSettingsDBService.GetEntryAsync(CancellationToken.None).Result;
                if (configSettings != null && !initialSettings)
                {
                    configSettings.TorchEnabled_02 = value;
                    _configSettingsDBService.UpdateEntryAsync(configSettings, CancellationToken.None);
                }
            }
        }

        private bool? _torchEnabled_03;
        public bool? TorchEnabled_03
        {
            get { return _torchEnabled_03; }

            set
            {
                _torchEnabled_03 = value;

                var configSettings = _configSettingsDBService.GetEntryAsync(CancellationToken.None).Result;
                if (configSettings != null && !initialSettings)
                {
                    configSettings.TorchEnabled_03 = value;
                    _configSettingsDBService.UpdateEntryAsync(configSettings, CancellationToken.None);
                }
            }
        }

        private bool? _torchEnabled_04;
        public bool? TorchEnabled_04
        {
            get { return _torchEnabled_04; }

            set
            {
                _torchEnabled_04 = value;

                var configSettings = _configSettingsDBService.GetEntryAsync(CancellationToken.None).Result;
                if (configSettings != null && !initialSettings)
                {
                    configSettings.TorchEnabled_04 = value;
                    _configSettingsDBService.UpdateEntryAsync(configSettings, CancellationToken.None);
                }
            }
        }

        private bool? _torchEnabled_05;
        public bool? TorchEnabled_05
        {
            get { return _torchEnabled_05; }

            set
            {
                _torchEnabled_05 = value;

                var configSettings = _configSettingsDBService.GetEntryAsync(CancellationToken.None).Result;
                if (configSettings != null && !initialSettings)
                {
                    configSettings.TorchEnabled_05 = value;
                    _configSettingsDBService.UpdateEntryAsync(configSettings, CancellationToken.None);
                }
            }
        }

        private bool? _torchEnabled_06;
        public bool? TorchEnabled_06
        {
            get { return _torchEnabled_06; }

            set
            {
                _torchEnabled_06 = value;

                var configSettings = _configSettingsDBService.GetEntryAsync(CancellationToken.None).Result;
                if (configSettings != null && !initialSettings)
                {
                    configSettings.TorchEnabled_06 = value;
                    _configSettingsDBService.UpdateEntryAsync(configSettings, CancellationToken.None);
                }
            }
        }

        private bool? _torchEnabled_07;
        public bool? TorchEnabled_07
        {
            get { return _torchEnabled_07; }

            set
            {
                _torchEnabled_07 = value;

                var configSettings = _configSettingsDBService.GetEntryAsync(CancellationToken.None).Result;
                if (configSettings != null && !initialSettings)
                {
                    configSettings.TorchEnabled_07 = value;
                    _configSettingsDBService.UpdateEntryAsync(configSettings, CancellationToken.None);
                }
            }
        }

        private bool? _torchEnabled_08;
        public bool? TorchEnabled_08
        {
            get { return _torchEnabled_08; }

            set
            {
                _torchEnabled_08 = value;

                var configSettings = _configSettingsDBService.GetEntryAsync(CancellationToken.None).Result;
                if (configSettings != null && !initialSettings)
                {
                    configSettings.TorchEnabled_08 = value;
                    _configSettingsDBService.UpdateEntryAsync(configSettings, CancellationToken.None);
                }
            }
        }

        private bool? _torchEnabled_09;
        public bool? TorchEnabled_09
        {
            get { return _torchEnabled_09; }

            set
            {
                _torchEnabled_09 = value;

                var configSettings = _configSettingsDBService.GetEntryAsync(CancellationToken.None).Result;
                if (configSettings != null && !initialSettings)
                {
                    configSettings.TorchEnabled_09 = value;
                    _configSettingsDBService.UpdateEntryAsync(configSettings, CancellationToken.None);
                }
            }
        }

        private bool? _torchEnabled_10;
        public bool? TorchEnabled_10
        {
            get { return _torchEnabled_10; }

            set
            {
                _torchEnabled_10 = value;

                var configSettings = _configSettingsDBService.GetEntryAsync(CancellationToken.None).Result;
                if (configSettings != null && !initialSettings)
                {
                    configSettings.TorchEnabled_10 = value;
                    _configSettingsDBService.UpdateEntryAsync(configSettings, CancellationToken.None);
                }
            }
        }

        private bool? _torchInstalled_01;
        public bool? TorchInstalled_01
        {
            get { return _torchInstalled_01; }

            set
            {
                _torchInstalled_01 = value;

                var configSettings = _configSettingsDBService.GetEntryAsync(CancellationToken.None).Result;
                if (configSettings != null && !initialSettings)
                {
                    configSettings.TorchInstalled_01 = value;
                    _configSettingsDBService.UpdateEntryAsync(configSettings, CancellationToken.None);
                }
            }
        }

        private bool? _torchInstalled_02;
        public bool? TorchInstalled_02
        {
            get { return _torchInstalled_02; }

            set
            {
                _torchInstalled_02 = value;

                var configSettings = _configSettingsDBService.GetEntryAsync(CancellationToken.None).Result;
                if (configSettings != null && !initialSettings)
                {
                    configSettings.TorchInstalled_02 = value;
                    _configSettingsDBService.UpdateEntryAsync(configSettings, CancellationToken.None);
                }
            }
        }

        private bool? _torchInstalled_03;
        public bool? TorchInstalled_03
        {
            get { return _torchInstalled_03; }

            set
            {
                _torchInstalled_03 = value;

                var configSettings = _configSettingsDBService.GetEntryAsync(CancellationToken.None).Result;
                if (configSettings != null && !initialSettings)
                {
                    configSettings.TorchInstalled_03 = value;
                    _configSettingsDBService.UpdateEntryAsync(configSettings, CancellationToken.None);
                }
            }
        }

        private bool? _torchInstalled_04;
        public bool? TorchInstalled_04
        {
            get { return _torchInstalled_04; }

            set
            {
                _torchInstalled_04 = value;

                var configSettings = _configSettingsDBService.GetEntryAsync(CancellationToken.None).Result;
                if (configSettings != null && !initialSettings)
                {
                    configSettings.TorchInstalled_04 = value;
                    _configSettingsDBService.UpdateEntryAsync(configSettings, CancellationToken.None);
                }
            }
        }

        private bool? _torchInstalled_05;
        public bool? TorchInstalled_05
        {
            get { return _torchInstalled_05; }

            set
            {
                _torchInstalled_05 = value;

                var configSettings = _configSettingsDBService.GetEntryAsync(CancellationToken.None).Result;
                if (configSettings != null && !initialSettings)
                {
                    configSettings.TorchInstalled_05 = value;
                    _configSettingsDBService.UpdateEntryAsync(configSettings, CancellationToken.None);
                }
            }
        }

        private bool? _torchInstalled_06;
        public bool? TorchInstalled_06
        {
            get { return _torchInstalled_06; }

            set
            {
                _torchInstalled_06 = value;

                var configSettings = _configSettingsDBService.GetEntryAsync(CancellationToken.None).Result;
                if (configSettings != null && !initialSettings)
                {
                    configSettings.TorchInstalled_06 = value;
                    _configSettingsDBService.UpdateEntryAsync(configSettings, CancellationToken.None);
                }
            }
        }

        private bool? _torchInstalled_07;
        public bool? TorchInstalled_07
        {
            get { return _torchInstalled_07; }

            set
            {
                _torchInstalled_07 = value;

                var configSettings = _configSettingsDBService.GetEntryAsync(CancellationToken.None).Result;
                if (configSettings != null && !initialSettings)
                {
                    configSettings.TorchInstalled_07 = value;
                    _configSettingsDBService.UpdateEntryAsync(configSettings, CancellationToken.None);
                }
            }
        }

        private bool? _torchInstalled_08;
        public bool? TorchInstalled_08
        {
            get { return _torchInstalled_08; }

            set
            {
                _torchInstalled_08 = value;

                var configSettings = _configSettingsDBService.GetEntryAsync(CancellationToken.None).Result;
                if (configSettings != null && !initialSettings)
                {
                    configSettings.TorchInstalled_08 = value;
                    _configSettingsDBService.UpdateEntryAsync(configSettings, CancellationToken.None);
                }
            }
        }

        private bool? _torchInstalled_09;
        public bool? TorchInstalled_09
        {
            get { return _torchInstalled_09; }

            set
            {
                _torchInstalled_09 = value;

                var configSettings = _configSettingsDBService.GetEntryAsync(CancellationToken.None).Result;
                if (configSettings != null && !initialSettings)
                {
                    configSettings.TorchInstalled_09 = value;
                    _configSettingsDBService.UpdateEntryAsync(configSettings, CancellationToken.None);
                }
            }
        }

        private bool? _torchInstalled_10;
        public bool? TorchInstalled_10
        {
            get { return _torchInstalled_10; }

            set
            {
                _torchInstalled_10 = value;

                var configSettings = _configSettingsDBService.GetEntryAsync(CancellationToken.None).Result;
                if (configSettings != null && !initialSettings)
                {
                    configSettings.TorchInstalled_10 = value;
                    _configSettingsDBService.UpdateEntryAsync(configSettings, CancellationToken.None);
                }
            }
        }

        private int? _dataBaseMaterialSelectedIndex;
        public int? DataBaseMaterialSelectedIndex
        {
            get { return _dataBaseMaterialSelectedIndex; }

            set
            {
                _dataBaseMaterialSelectedIndex = value;

                var configSettings = _configSettingsDBService.GetEntryAsync(CancellationToken.None).Result;
                if (configSettings != null && !initialSettings)
                {
                    configSettings.DataBaseMaterialSelectedIndex = value;
                    _configSettingsDBService.UpdateEntryAsync(configSettings, CancellationToken.None);
                }
            }
        }

        private int? _dataBaseThicknessSelectedIndex;
        public int? DataBaseThicknessSelectedIndex
        {
            get { return _dataBaseThicknessSelectedIndex; }

            set
            {
                _dataBaseThicknessSelectedIndex = value;

                var configSettings = _configSettingsDBService.GetEntryAsync(CancellationToken.None).Result;
                if (configSettings != null && !initialSettings)
                {
                    configSettings.DataBaseThicknessSelectedIndex = value;
                    _configSettingsDBService.UpdateEntryAsync(configSettings, CancellationToken.None);
                }
            }
        }

        private int? _dataBaseNozzleSelectedIndex;
        public int? DataBaseNozzleSelectedIndex
        {
            get { return _dataBaseNozzleSelectedIndex; }

            set
            {
                _dataBaseNozzleSelectedIndex = value;

                var configSettings = _configSettingsDBService.GetEntryAsync(CancellationToken.None).Result;
                if (configSettings != null && !initialSettings)
                {
                    configSettings.DataBaseNozzleSelectedIndex = value;
                    _configSettingsDBService.UpdateEntryAsync(configSettings, CancellationToken.None);
                }
            }
        }

        private Guid? _dataBaseGuid;
        public Guid? DataBaseGuid
        {
            get { return _dataBaseGuid; }

            set
            {
                _dataBaseGuid = value;

                var configSettings = _configSettingsDBService.GetEntryAsync(CancellationToken.None).Result;
                if (configSettings != null && !initialSettings)
                {
                    configSettings.DataBaseGuid = value;
                    _configSettingsDBService.UpdateEntryAsync(configSettings, CancellationToken.None);
                }
            }
        }

        private int? _dataBaseId;
        public int? DataBaseId
        {
            get { return _dataBaseId; }

            set
            {
                _dataBaseId = value;

                var configSettings = _configSettingsDBService.GetEntryAsync(CancellationToken.None).Result;
                if (configSettings != null && !initialSettings)
                {
                    configSettings.DataBaseId = value;
                    _configSettingsDBService.UpdateEntryAsync(configSettings, CancellationToken.None);
                }
            }
        }

        private int? _torchType;
        public int? TorchType
        {
            get { return _torchType; }

            set
            {
                _torchType = value;

                var configSettings = _configSettingsDBService.GetEntryAsync(CancellationToken.None).Result;
                if (configSettings != null && !initialSettings)
                {
                    configSettings.TorchType = value;
                    _configSettingsDBService.UpdateEntryAsync(configSettings, CancellationToken.None);
                }
            }
        }

        private int? _pressureUnit;
        public int? PressureUnit
        {
            get { return _pressureUnit; }

            set
            {
                _pressureUnit = value;

                var configSettings = _configSettingsDBService.GetEntryAsync(CancellationToken.None).Result;
                if (configSettings != null && !initialSettings)
                {
                    configSettings.PressureUnit = value;
                    _configSettingsDBService.UpdateEntryAsync(configSettings, CancellationToken.None);
                }
            }
        }

        private int? _lengthUnit;
        public int? LengthUnit
        {
            get { return _lengthUnit; }

            set
            {
                _lengthUnit = value;

                var configSettings = _configSettingsDBService.GetEntryAsync(CancellationToken.None).Result;
                if (configSettings != null && !initialSettings)
                {
                    configSettings.LengthUnit = value;
                    _configSettingsDBService.UpdateEntryAsync(configSettings, CancellationToken.None);
                }
            }
        }

        private string? _cultureStr;
        public string? CultureStr
        {
            get { return _cultureStr; }

            set
            {
                _cultureStr = value;

                var configSettings = _configSettingsDBService.GetEntryAsync(CancellationToken.None).Result;
                if (configSettings != null && !initialSettings)
                {
                    configSettings.CultureStr = value;
                    _configSettingsDBService.UpdateEntryAsync(configSettings, CancellationToken.None);
                }
            }
        }

        private string? _comPortLast;
        public string? ComPortLast
        {
            get { return _comPortLast; }

            set
            {
                _comPortLast = value;

                var configSettings = _configSettingsDBService.GetEntryAsync(CancellationToken.None).Result;
                if (configSettings != null && !initialSettings)
                {
                    configSettings.ComPortLast = value;
                    _configSettingsDBService.UpdateEntryAsync(configSettings, CancellationToken.None);
                }
            }
        }

        private bool? _execReset;
        public bool? ExecReset
        {
            get { return _execReset; }

            set
            {
                _execReset = value;

                var configSettings = _configSettingsDBService.GetEntryAsync(CancellationToken.None).Result;
                if (configSettings != null && !initialSettings)
                {
                    configSettings.ExecReset = value;
                    _configSettingsDBService.UpdateEntryAsync(configSettings, CancellationToken.None);
                }
            }
        }

        protected readonly IConfigSettingsDBService _configSettingsDBService;
        private readonly Settings _settings;

        public SystemSettings(
            IOptions<Settings> settings,
            IConfigSettingsDBService configSettingsDBService
            )
        {
            _settings = settings != null ? settings.Value :
               throw new ArgumentNullException($"{nameof(settings)}");

            _configSettingsDBService = configSettingsDBService ??
               throw new ArgumentNullException($"{nameof(configSettingsDBService)}");

            var configSettings = _configSettingsDBService.GetEntryAsync(CancellationToken.None).Result;

            Mode = configSettings?.Mode ?? _settings.Mode;
            TcpPort = string.IsNullOrWhiteSpace(configSettings?.TcpPort) ? _settings.TcpPort : configSettings?.TcpPort;
            IpAddr = string.IsNullOrWhiteSpace(configSettings?.IpAddr) ? _settings.IpAddr : configSettings?.IpAddr;
            ComPort = string.IsNullOrWhiteSpace(configSettings?.ComPort) ? _settings.ComPort : configSettings?.ComPort;
            Baudrate = string.IsNullOrWhiteSpace(configSettings?.Baudrate) ? _settings.Baudrate : configSettings?.Baudrate;
            DataBits = string.IsNullOrWhiteSpace(configSettings?.DataBits) ? _settings.DataBits : configSettings?.DataBits;
            StopBits = string.IsNullOrWhiteSpace(configSettings?.StopBits) ? _settings.StopBits : configSettings?.StopBits;
            Parity = string.IsNullOrWhiteSpace(configSettings?.Parity) ? _settings.Parity : configSettings?.Parity;
            Identifier = string.IsNullOrWhiteSpace(configSettings?.Identifier) ? _settings.Identifier : configSettings?.Identifier;

            TorchEnabled_01 = configSettings?.TorchEnabled_01 ?? _settings.TorchEnabled_01;
            TorchEnabled_02 = configSettings?.TorchEnabled_02 ?? _settings.TorchEnabled_02;
            TorchEnabled_03 = configSettings?.TorchEnabled_03 ?? _settings.TorchEnabled_03;
            TorchEnabled_04 = configSettings?.TorchEnabled_04 ?? _settings.TorchEnabled_04;
            TorchEnabled_05 = configSettings?.TorchEnabled_05 ?? _settings.TorchEnabled_05;
            TorchEnabled_06 = configSettings?.TorchEnabled_06 ?? _settings.TorchEnabled_06;
            TorchEnabled_07 = configSettings?.TorchEnabled_07 ?? _settings.TorchEnabled_07;
            TorchEnabled_08 = configSettings?.TorchEnabled_08 ?? _settings.TorchEnabled_08;
            TorchEnabled_09 = configSettings?.TorchEnabled_09 ?? _settings.TorchEnabled_09;
            TorchEnabled_10 = configSettings?.TorchEnabled_10 ?? _settings.TorchEnabled_10;

            TorchInstalled_01 = configSettings?.TorchInstalled_01 ?? _settings.TorchInstalled_01;
            TorchInstalled_02 = configSettings?.TorchInstalled_02 ?? _settings.TorchInstalled_02;
            TorchInstalled_03 = configSettings?.TorchInstalled_03 ?? _settings.TorchInstalled_03;
            TorchInstalled_04 = configSettings?.TorchInstalled_04 ?? _settings.TorchInstalled_04;
            TorchInstalled_05 = configSettings?.TorchInstalled_05 ?? _settings.TorchInstalled_05;
            TorchInstalled_06 = configSettings?.TorchInstalled_06 ?? _settings.TorchInstalled_06;
            TorchInstalled_07 = configSettings?.TorchInstalled_07 ?? _settings.TorchInstalled_07;
            TorchInstalled_08 = configSettings?.TorchInstalled_08 ?? _settings.TorchInstalled_08;
            TorchInstalled_09 = configSettings?.TorchInstalled_09 ?? _settings.TorchInstalled_09;
            TorchInstalled_10 = configSettings?.TorchInstalled_10 ?? _settings.TorchInstalled_10;

            DataBaseMaterialSelectedIndex = configSettings?.DataBaseMaterialSelectedIndex ?? _settings.DataBaseMaterialSelectedIndex;
            DataBaseThicknessSelectedIndex = configSettings?.DataBaseThicknessSelectedIndex ?? _settings.DataBaseThicknessSelectedIndex;
            DataBaseNozzleSelectedIndex = configSettings?.DataBaseNozzleSelectedIndex ?? _settings.DataBaseNozzleSelectedIndex;

            DataBaseGuid = configSettings?.DataBaseGuid ?? _settings.DataBaseGuid;
            DataBaseId = configSettings?.DataBaseId ?? _settings.DataBaseId;
            TorchType = configSettings?.TorchType ?? _settings.TorchType;
            PressureUnit = configSettings?.PressureUnit ?? _settings.PressureUnit;
            LengthUnit = configSettings?.LengthUnit ?? _settings.LengthUnit;
            CultureStr = configSettings?.CultureStr ?? _settings.CultureStr;
            ComPortLast = configSettings?.ComPortLast ?? _settings.ComPortLast;
            ExecReset = configSettings?.ExecReset ?? _settings.ExecReset;

            initialSettings = false;
        }
    }
}
