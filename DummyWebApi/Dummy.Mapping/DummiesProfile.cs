using AutoMapper;
using dto = Dummy.DTO;
using model = Dummy.Model;

namespace Dummy.Mapping
{
    public class DummiesProfile : Profile
    {
        public DummiesProfile()
        {
            CreateMap<model.Dummy, dto.Dummy>();
            CreateMap<dto.Dummy, model.Dummy>();
        }
    }
}
