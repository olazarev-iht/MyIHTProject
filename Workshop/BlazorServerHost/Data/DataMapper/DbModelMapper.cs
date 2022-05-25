using AutoMapper;
using BlazorServerHost.Data.Models.CuttingData;
using SharedComponents.Models.CuttingData;

namespace BlazorServerHost.Data.DataMapper
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
            });

            return configuration.CreateMapper();
        }
    }
}
