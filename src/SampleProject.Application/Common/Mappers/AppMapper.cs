using AutoMapper;

namespace SampleProject.Application.Common.Mappers
{
    public class AppMapper
    {
        private static readonly Lazy<IMapper> Lazy = new(() =>
        {

            var mapper = new MapperConfiguration(map =>
            {
                map.ShouldMapProperty = property => property.GetMethod.IsPublic | property.GetMethod.IsAssembly;
                map.AddProfile<ProductMappingProfile>();
            });

            var mapped = mapper.CreateMapper();
            return mapped;
        });

        public static IMapper Mapper => Lazy.Value;
    }
}
