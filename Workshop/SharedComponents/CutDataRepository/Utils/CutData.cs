using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CutDataRepository.Utils
{
    public class CCutData
    {
        private Guid _idCutData;
        private Guid _idMaterial;
        private Guid _idNozzle;
        private int _idGas;
        private double _dThickness;
        private double _dKerf;
        private int _iLeadInLength;
        private int _iCuttingSpeed;
        private double _iIgnitionFlameAdjustment;
        private double _dPreHeatHeight;
        private double _dPreHeatHeatingOxygenPressure;
        private double _dPreHeatFuelGasPressure;
        private double _dPreHeatTime;
        private double _dPierceHeight;
        private double _dPierceHeatingOxygenPressure;
        private double _dPierceCuttingOxygenPressure;
        private double _dPierceFuelGasPressure;
        private int _iPierceCuttingSpeedChange;
        private double _dPierceTime;
        private double _dCutHeight;
        private double _dCutHeatingOxygenPressure;
        private double _dCutCuttingOxygenPressure;
        private double _dCutFuelGasPressure;
        private double _dPI0;
        private double _dPI1;
        private double _dPP0;
        private double _dPP1;
        private double _dPP2;
        private double _dPP3;
        private double _dPP4;
        private string _strRemark;
        private string _strExtKey;
        private Guid _idCutDataParent;

        private int _iControlBits;

        private CMaterial _Material;
        private CNozzle _Nozzle;
        private CGas _Gas;

        public int DataRecordId { get; set; } = 0;
        ///////////////////////////////////////////////////////////////////////
        public CCutData()
        {
            _idCutData = Guid.Empty;
            _idMaterial = Guid.Empty;
            Guid _idNozzle = Guid.Empty;
            _idGas = 0;
            _dThickness = 0.0;
            _dKerf = 0.0;
            _iLeadInLength = 0;
            _iCuttingSpeed = 0;
            _iIgnitionFlameAdjustment = 0;
            _dPreHeatHeight = 0.0;
            _dPreHeatHeatingOxygenPressure = 0.0;
            _dPreHeatFuelGasPressure = 0.0;
            _dPreHeatTime = 0.0;
            _dPierceHeight = 0.0;
            _dPierceHeatingOxygenPressure = 0.0;
            _dPierceCuttingOxygenPressure = 0.0;
            _dPierceFuelGasPressure = 0.0;
            _iPierceCuttingSpeedChange = 0;
            _dPierceTime = 0.0;
            _dCutHeight = 0.0;
            _dCutHeatingOxygenPressure = 0.0;
            _dCutCuttingOxygenPressure = 0.0;
            _dCutFuelGasPressure = 0.0;
            _dPI0 = 0.0;
            _dPI1 = 0.0;
            _dPP0 = 0.0;
            _dPP1 = 0.0;
            _dPP2 = 0.0;
            _dPP3 = 0.0;
            _dPP4 = 0.0;
            _strRemark = "";
            _strExtKey = "";
            _iControlBits = 0;
            _idCutDataParent = Guid.Empty;
        }

        ///////////////////////////////////////////////////////////////////////
        public Guid IdCutData
        {
            get { return _idCutData; }
            set { _idCutData = value; }
        }

        ///////////////////////////////////////////////////////////////////////
        public Guid IdMaterial
        {
            get { return _idMaterial; }
            set { _idMaterial = value; }
        }

        ///////////////////////////////////////////////////////////////////////
        public Guid IdNozzle
        {
            get { return _idNozzle; }
            set { _idNozzle = value; }
        }

        ///////////////////////////////////////////////////////////////////////
        public int IdGas
        {
            get { return _idGas; }
            set { _idGas = value; }
        }

        ///////////////////////////////////////////////////////////////////////
        public double Thickness
        {
            get { return _dThickness; }
            set { _dThickness = value; }
        }

        ///////////////////////////////////////////////////////////////////////
        public double Kerf
        {
            get { return _dKerf; }
            set { _dKerf = value; }
        }

        ///////////////////////////////////////////////////////////////////////
        public int LeadInLength
        {
            get { return _iLeadInLength; }
            set { _iLeadInLength = value; }
        }

        ///////////////////////////////////////////////////////////////////////
        public int CuttingSpeed
        {
            get { return _iCuttingSpeed; }
            set { _iCuttingSpeed = value; }
        }

        ///////////////////////////////////////////////////////////////////////
        public double IgnitionFlameAdjustment
        {
            get { return _iIgnitionFlameAdjustment; }
            set { _iIgnitionFlameAdjustment = value; }
        }

        ///////////////////////////////////////////////////////////////////////
        public double PreHeatHeight
        {
            get { return _dPreHeatHeight; }
            set { _dPreHeatHeight = value; }
        }

        ///////////////////////////////////////////////////////////////////////
        public double PreHeatHeatingOxygenPressure
        {
            get { return _dPreHeatHeatingOxygenPressure; }
            set { _dPreHeatHeatingOxygenPressure = value; }
        }

        ///////////////////////////////////////////////////////////////////////
        public double PreHeatFuelGasPressure
        {
            get { return _dPreHeatFuelGasPressure; }
            set { _dPreHeatFuelGasPressure = value; }
        }

        ///////////////////////////////////////////////////////////////////////
        public double PreHeatTime
        {
            get { return _dPreHeatTime; }
            set { _dPreHeatTime = value; }
        }

        ///////////////////////////////////////////////////////////////////////
        public double PierceHeight
        {
            get { return _dPierceHeight; }
            set { _dPierceHeight = value; }
        }

        ///////////////////////////////////////////////////////////////////////
        public double PierceHeatingOxygenPressure
        {
            get { return _dPierceHeatingOxygenPressure; }
            set { _dPierceHeatingOxygenPressure = value; }
        }

        ///////////////////////////////////////////////////////////////////////
        public double PierceCuttingOxygenPressure
        {
            get { return _dPierceCuttingOxygenPressure; }
            set { _dPierceCuttingOxygenPressure = value; }
        }

        ///////////////////////////////////////////////////////////////////////
        public double PierceFuelGasPressure
        {
            get { return _dPierceFuelGasPressure; }
            set { _dPierceFuelGasPressure = value; }
        }

        ///////////////////////////////////////////////////////////////////////
        public int PierceCuttingSpeedChange
        {
            get { return _iPierceCuttingSpeedChange; }
            set { _iPierceCuttingSpeedChange = value; }
        }

        ///////////////////////////////////////////////////////////////////////
        public double PierceTime
        {
            get { return _dPierceTime; }
            set { _dPierceTime = value; }
        }

        ///////////////////////////////////////////////////////////////////////
        public double CutHeight
        {
            get { return _dCutHeight; }
            set { _dCutHeight = value; }
        }

        ///////////////////////////////////////////////////////////////////////
        public double CutHeatingOxygenPressure
        {
            get { return _dCutHeatingOxygenPressure; }
            set { _dCutHeatingOxygenPressure = value; }
        }

        ///////////////////////////////////////////////////////////////////////
        public double CutCuttingOxygenPressure
        {
            get { return _dCutCuttingOxygenPressure; }
            set { _dCutCuttingOxygenPressure = value; }
        }

        ///////////////////////////////////////////////////////////////////////
        public double CutFuelGasPressure
        {
            get { return _dCutFuelGasPressure; }
            set { _dCutFuelGasPressure = value; }
        }

        ///////////////////////////////////////////////////////////////////////
        public double PI0
        {
            get { return _dPI0; }
            set { _dPI0 = value; }
        }

        ///////////////////////////////////////////////////////////////////////
        public double PI1
        {
            get { return _dPI1; }
            set { _dPI1 = value; }
        }

        ///////////////////////////////////////////////////////////////////////
        public double PP0
        {
            get { return _dPP0; }
            set { _dPP0 = value; }
        }

        ///////////////////////////////////////////////////////////////////////
        public double PP1
        {
            get { return _dPP1; }
            set { _dPP1 = value; }
        }

        ///////////////////////////////////////////////////////////////////////
        public double PP2
        {
            get { return _dPP2; }
            set { _dPP2 = value; }
        }

        ///////////////////////////////////////////////////////////////////////
        public double PP3
        {
            get { return _dPP3; }
            set { _dPP3 = value; }
        }

        ///////////////////////////////////////////////////////////////////////
        public double PP4
        {
            get { return _dPP4; }
            set { _dPP4 = value; }
        }

        ///////////////////////////////////////////////////////////////////////
        public string Remark
        {
            get { return _strRemark; }
            set { _strRemark = value; }
        }

        ///////////////////////////////////////////////////////////////////////
        public string ExtKey
        {
            get { return _strExtKey; }
            set { _strExtKey = value; }
        }

        ///////////////////////////////////////////////////////////////////////
        public Guid IdCutDataParent
        {
            get { return _idCutDataParent; }
            set { _idCutDataParent = value; }
        }

        ///////////////////////////////////////////////////////////////////////
        public int ControlBits
        {
          get { return _iControlBits; }
          set { _iControlBits = value; }
        }

        ///////////////////////////////////////////////////////////////////////
        public CMaterial Material
        {
            get { return _Material; }
            set { _Material = value; }
        }

        ///////////////////////////////////////////////////////////////////////
        public string MaterialName
        {
            get
            {
                string Result = "";
                if (Material != null)
                    Result = Material.Material;
                return Result;
            }
        }

        ///////////////////////////////////////////////////////////////////////
        public CNozzle Nozzle
        {
            get { return _Nozzle; }
            set { _Nozzle = value; }
        }

        ///////////////////////////////////////////////////////////////////////
        public string NozzleName
        {
            get
            {
                string Result = "";
                if (Nozzle != null)
                    Result = Nozzle.Nozzle;
                return Result;
            }
        }

        ///////////////////////////////////////////////////////////////////////
        public CGas Gas
        {
            get { return _Gas; }
            set { _Gas = value; }
        }

        ///////////////////////////////////////////////////////////////////////
        public string GasName
        {
            get 
            {
                string Result = "";
                if (Gas != null)
                    Result = Gas.Gas;
                return Result;
            }
        }

    }
}
