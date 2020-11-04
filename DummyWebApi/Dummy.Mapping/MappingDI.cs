using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Dummy.Mapping
{
    public static class MappingDI
    {
        public static void AddMappings(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {

                mc.AddProfile(new DummiesProfile());

            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
