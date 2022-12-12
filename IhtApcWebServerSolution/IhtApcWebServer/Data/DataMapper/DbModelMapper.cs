using AutoMapper;
using APCHardwareMoq = IhtApcWebServer.Data.Models.APCHardwareMock;
using IhtApcWebServer.Data.Models.APCHardware;
using IhtApcWebServer.Data.Models.CuttingData;
using SharedComponents.Models.APCHardware;
using SharedComponents.Models.CuttingData;

namespace IhtApcWebServer.Data.DataMapper
{
    public class DbModelMapper
    {
        private IMapper _mapper;

        public DbModelMapper()
        {
            _mapper = CreateMapper();
        }

        public R Map<T, R>(T entity)
        {
            if (entity == null)
            {
                return default;
            }

            return _mapper.Map<R>(entity);
        }

        private IMapper CreateMapper()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                // CuttingData
                // TODO: add a condition to not override the Id to null
                cfg.CreateMap<GasModel, Gas>().ReverseMap();
                cfg.CreateMap<MaterialModel, Material>().ReverseMap();
                cfg.CreateMap<NozzleModel, Nozzle>().ReverseMap();
                cfg.CreateMap<CuttingDataModel, CuttingData>()
                .ForMember(
                    dest => dest.Material,
                    opt => opt.Ignore())
                .ForMember(
                    dest => dest.Nozzle,
                    opt => opt.Ignore())
                .ForMember(
                    dest => dest.Gas,
                    opt => opt.Ignore())
                .ReverseMap();

                // APCHardwareMoq
                cfg.CreateMap<APCDeviceModel, APCHardwareMoq.APCDevice>().ReverseMap();
                cfg.CreateMap<ConstParamsModel, APCHardwareMoq.ConstParams>().ReverseMap();
                cfg.CreateMap<LiveParamsModel, APCHardwareMoq.LiveParams>().ReverseMap();
                cfg.CreateMap<APCSimulationDataModel, APCHardwareMoq.APCSimulationData>().ReverseMap();
                cfg.CreateMap<ParameterDataInfoModel, APCHardwareMoq.ParameterDataInfo>().ReverseMap();
                cfg.CreateMap<DynParamsModel, APCHardwareMoq.DynParams>()
                .ForMember(
                    dest => dest.ConstParams,
                    opt => opt.Ignore())
                .ReverseMap();
                cfg.CreateMap<ParameterDataModel, APCHardwareMoq.ParameterData>()
                .ForMember(
                    dest => dest.APCDevice,
                    opt => opt.Ignore())
                .ForMember(
                    dest => dest.DynParams,
                    opt => opt.Ignore())
                .ReverseMap();

                // APCHardware
                cfg.CreateMap<APCDeviceModel, APCDevice>().ReverseMap();
                cfg.CreateMap<ConstParamsModel, ConstParams>().ReverseMap();
                cfg.CreateMap<LiveParamsModel, LiveParams>().ReverseMap();
                cfg.CreateMap<APCDefaultDataModel, APCHardwareMoq.APCDefaultData>().ReverseMap();
                cfg.CreateMap<APCDefaultDataModel, APCHardwareMoq.APCSimulationData>().ReverseMap();
                cfg.CreateMap<ParameterDataInfoModel, ParameterDataInfo>().ReverseMap();
                cfg.CreateMap<DynParamsModel, DynParams>()
                .ForMember(
                    dest => dest.ConstParams,
                    opt => opt.Ignore())
                .ForMember(
                    dest => dest.ParameterDataInfo,
                    opt => opt.Ignore())
                .ReverseMap();

                cfg.CreateMap<ParameterDataModel, ParameterData>()
                .ForMember(
                    dest => dest.APCDevice,
                    opt => opt.Ignore())
                .ForMember(
                    dest => dest.DynParams,
                    opt => opt.Ignore())
                .ReverseMap();

                cfg.CreateMap<ParamViewGroupModel, ParamViewGroup>().ReverseMap();
                cfg.CreateMap<ParamSettingsModel<Enum>, ParamSettings>().ReverseMap();
            });

            return configuration.CreateMapper();
        }
    }
}
