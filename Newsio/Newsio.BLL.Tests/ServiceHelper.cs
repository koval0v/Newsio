using AutoMapper;

namespace Newsio.BLL.Tests
{
    internal class ServiceHelper
    {
        private readonly IMapper _mapper;

        public ServiceHelper()
        {
            var myProfile = new AutomapperProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));

            _mapper = new Mapper(configuration);
        }

        public IMapper CreateMapperProfile()
        {
            var myProfile = new AutomapperProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));

            return new Mapper(configuration);
        }
    }
}
