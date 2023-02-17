using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedComponents.IhtDev;
using SharedComponents.IhtModbus;

namespace SharedComponents.Helpers
{
    public class IhtSettings
    {
        public static void LoadSettings(SystemSettings settings, IhtModbusCommunicData ihtModbusCommunicData)
        {
            settings = settings 
                ?? throw new ArgumentNullException(nameof(settings), $"Param is empty when func {nameof(LoadSettings)} is running.");

            ihtModbusCommunicData = ihtModbusCommunicData 
                ?? throw new ArgumentNullException(nameof(ihtModbusCommunicData), $"Param is empty when func {nameof(LoadSettings)} is running.");

            //Load communication data
            ihtModbusCommunicData.LoadSettings(settings);

            LoadTorchType(settings);

            //TODO implement in the next vertion ?
            //LoadPressureUnit(settings);
            //LoadLengthUnit(settings);

            LoadDevices(settings);

            //TODO implement in the next vertion ?
            //LoadDataBaseControl(settings);
            //LoadLanguage(settings);
        }

        public static void UpdateSettings(SystemSettings settings, IhtModbusCommunicData ihtModbusCommunicData)
        {
            settings = settings ?? throw new ArgumentNullException(nameof(settings), $"Param is empty when func {nameof(UpdateSettings)} is running.");


            //TODO implement in the next vertion ?
            //IhtModbusCommunicData communicData = (IhtModbusCommunicData)mainWnd.FindResource("modbusCommunicData");
            //communicData.UpdateSettings(settings);

            //Update communication data
            if (ihtModbusCommunicData != null)
            {
                ihtModbusCommunicData.UpdateSettings(settings);
            }

            UpdateTorchType(settings);
            //UpdatePressureUnit(settings);
            //UpdateLengthUnit(settings);
            UpdateDevices(settings);
            //UpdateDataBaseControl(settings);
            //UpdateLanguage(settings);
        }

        private static void LoadTorchType(SystemSettings settings)
        {
            var _ihtDevices = IhtDevices.GetIhtDevices();

            _ihtDevices.TorchTypeSetup = (IhtDevices.TorchType)(settings?.TorchType ?? -1);

            //TODO: remove if OK
            //SettingsTorchInstalled settingsTorchInstalled = mainWnd.settingsTorchInstalled;
            //switch (settings.TorchType)
            //{
            //    case 2:
            //        settingsTorchInstalled.IsPropane = false;
            //        settingsTorchInstalled.IsAcetylane = false;
            //        settingsTorchInstalled.IsNaturalGas = true;
            //        break;
            //    case 1:
            //        settingsTorchInstalled.IsPropane = false;
            //        settingsTorchInstalled.IsAcetylane = true;
            //        settingsTorchInstalled.IsNaturalGas = false;
            //        break;
            //    case 0:
            //    default:
            //        settingsTorchInstalled.IsPropane = true;
            //        settingsTorchInstalled.IsAcetylane = false;
            //        settingsTorchInstalled.IsNaturalGas = false;
            //        break;
            //}
        }

        private static void UpdateTorchType(SystemSettings settings)
        {
            var _ihtDevices = IhtDevices.GetIhtDevices();

            if(settings != null)
            {
                settings.TorchType = (int)_ihtDevices.TorchTypeSetup;
            }

            //TODO: remove if OK
            //SettingsTorchInstalled settingsTorchInstalled = mainWnd.settingsTorchInstalled;
            //settings.TorchType = (settingsTorchInstalled.IsNaturalGas == true) ? 2 : (settingsTorchInstalled.IsAcetylane == true) ? 1 : 0;

        }

        private static void LoadDevices(SystemSettings settings)
        {
            var _ihtDevices = IhtDevices.GetIhtDevices().GetDevices();
            if (_ihtDevices == null)
                return;
            foreach (IhtDevice _ihtDevice in _ihtDevices)
            {
                if (_ihtDevice != null)
                {
                    switch (_ihtDevice.DeviceNumber)
                    {
                        case (int)IhtDevices.DeviceNumber.Device_01:
                            _ihtDevice.IsVisible = settings.TorchInstalled_01 ?? false;
                            _ihtDevice.IsOn = settings.TorchEnabled_01 ?? false && _ihtDevice.IsVisible;
                            break;
                        case (int)IhtDevices.DeviceNumber.Device_02:
                            _ihtDevice.IsVisible = settings.TorchInstalled_02 ?? false;
                            _ihtDevice.IsOn = settings.TorchEnabled_02 ?? false && _ihtDevice.IsVisible;
                            break;
                        case (int)IhtDevices.DeviceNumber.Device_03:
                            _ihtDevice.IsVisible = settings.TorchInstalled_03 ?? false;
                            _ihtDevice.IsOn = settings.TorchEnabled_03 ?? false && _ihtDevice.IsVisible;
                            break;
                        case (int)IhtDevices.DeviceNumber.Device_04:
                            _ihtDevice.IsVisible = settings.TorchInstalled_04 ?? false;
                            _ihtDevice.IsOn = settings.TorchEnabled_04 ?? false && _ihtDevice.IsVisible;
                            break;
                        case (int)IhtDevices.DeviceNumber.Device_05:
                            _ihtDevice.IsVisible = settings.TorchInstalled_05 ?? false;
                            _ihtDevice.IsOn = settings.TorchEnabled_05 ?? false && _ihtDevice.IsVisible;
                            break;
                        case (int)IhtDevices.DeviceNumber.Device_06:
                            _ihtDevice.IsVisible = settings.TorchInstalled_06 ?? false;
                            _ihtDevice.IsOn = settings.TorchEnabled_06 ?? false && _ihtDevice.IsVisible;
                            break;
                        case (int)IhtDevices.DeviceNumber.Device_07:
                            _ihtDevice.IsVisible = settings.TorchInstalled_07 ?? false;
                            _ihtDevice.IsOn = settings.TorchEnabled_07 ?? false && _ihtDevice.IsVisible;
                            break;
                        case (int)IhtDevices.DeviceNumber.Device_08:
                            _ihtDevice.IsVisible = settings.TorchInstalled_08 ?? false;
                            _ihtDevice.IsOn = settings.TorchEnabled_08 ?? false && _ihtDevice.IsVisible;
                            break;
                        case (int)IhtDevices.DeviceNumber.Device_09:
                            _ihtDevice.IsVisible = settings.TorchInstalled_09 ?? false;
                            _ihtDevice.IsOn = settings.TorchEnabled_09 ?? false && _ihtDevice.IsVisible;
                            break;
                        case (int)IhtDevices.DeviceNumber.Device_10:
                            _ihtDevice.IsVisible = settings.TorchInstalled_10 ?? false;
                            _ihtDevice.IsOn = settings.TorchEnabled_10 ?? false && _ihtDevice.IsVisible;
                            break;
                    }
                }
            }
        }

        private static void UpdateDevices(SystemSettings settings)
        {
            var _ihtDevices = IhtDevices.GetIhtDevices().GetDevices();
            if (_ihtDevices == null)
                return;
            foreach (IhtDevice _ihtDevice in _ihtDevices)
            {
                if (_ihtDevice != null)
                {
                    if (!_ihtDevice.IsVisible)
                    {
                        switch (_ihtDevice.DeviceNumber)
                        {
                            case (int)IhtDevices.DeviceNumber.Device_01:
                                settings.TorchInstalled_01 = false;
                                settings.TorchEnabled_01 = false;
                                break;
                            case (int)IhtDevices.DeviceNumber.Device_02:
                                settings.TorchInstalled_02 = false;
                                settings.TorchEnabled_02 = false;
                                break;
                            case (int)IhtDevices.DeviceNumber.Device_03:
                                settings.TorchInstalled_03 = false;
                                settings.TorchEnabled_03 = false;
                                break;
                            case (int)IhtDevices.DeviceNumber.Device_04:
                                settings.TorchInstalled_04 = false;
                                settings.TorchEnabled_04 = false;
                                break;
                            case (int)IhtDevices.DeviceNumber.Device_05:
                                settings.TorchInstalled_05 = false;
                                settings.TorchEnabled_05 = false;
                                break;
                            case (int)IhtDevices.DeviceNumber.Device_06:
                                settings.TorchInstalled_06 = false;
                                settings.TorchEnabled_06 = false;
                                break;
                            case (int)IhtDevices.DeviceNumber.Device_07:
                                settings.TorchInstalled_07 = false;
                                settings.TorchEnabled_07 = false;
                                break;
                            case (int)IhtDevices.DeviceNumber.Device_08:
                                settings.TorchInstalled_08 = false;
                                settings.TorchEnabled_08 = false;
                                break;
                            case (int)IhtDevices.DeviceNumber.Device_09:
                                settings.TorchInstalled_09 = false;
                                settings.TorchEnabled_09 = false;
                                break;
                            case (int)IhtDevices.DeviceNumber.Device_10:
                                settings.TorchInstalled_10 = false;
                                settings.TorchEnabled_10 = false;
                                break;
                        }
                        continue;
                    }

                    switch (_ihtDevice.DeviceNumber)
                    {
                        case (int)IhtDevices.DeviceNumber.Device_01:
                            settings.TorchInstalled_01 = true;
                            settings.TorchEnabled_01 = _ihtDevice.IsOn;
                            break;
                        case (int)IhtDevices.DeviceNumber.Device_02:
                            settings.TorchInstalled_02 = true;
                            settings.TorchEnabled_02 = _ihtDevice.IsOn;
                            break;
                        case (int)IhtDevices.DeviceNumber.Device_03:
                            settings.TorchInstalled_03 = true;
                            settings.TorchEnabled_03 = _ihtDevice.IsOn;
                            break;
                        case (int)IhtDevices.DeviceNumber.Device_04:
                            settings.TorchInstalled_04 = true;
                            settings.TorchEnabled_04 = _ihtDevice.IsOn;
                            break;
                        case (int)IhtDevices.DeviceNumber.Device_05:
                            settings.TorchInstalled_05 = true;
                            settings.TorchEnabled_05 = _ihtDevice.IsOn;
                            break;
                        case (int)IhtDevices.DeviceNumber.Device_06:
                            settings.TorchInstalled_06 = true;
                            settings.TorchEnabled_06 = _ihtDevice.IsOn;
                            break;
                        case (int)IhtDevices.DeviceNumber.Device_07:
                            settings.TorchInstalled_07 = true;
                            settings.TorchEnabled_07 = _ihtDevice.IsOn;
                            break;
                        case (int)IhtDevices.DeviceNumber.Device_08:
                            settings.TorchInstalled_08 = true;
                            settings.TorchEnabled_08 = _ihtDevice.IsOn;
                            break;
                        case (int)IhtDevices.DeviceNumber.Device_09:
                            settings.TorchInstalled_09 = true;
                            settings.TorchEnabled_09 = _ihtDevice.IsOn;
                            break;
                        case (int)IhtDevices.DeviceNumber.Device_10:
                            settings.TorchInstalled_10 = true;
                            settings.TorchEnabled_10 = _ihtDevice.IsOn;
                            break;
                    }
                }
            }
        }


    }

    
}
