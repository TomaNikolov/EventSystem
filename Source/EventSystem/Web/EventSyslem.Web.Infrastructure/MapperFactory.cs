using AutoMapper;

namespace EventSystem.Web.Infrastructure
{
    public static class MapperFactory
    {
        private static MapperConfiguration mapperConfig;

        public static void InititializeMapper(MapperConfiguration config)
        {
            mapperConfig = config;
        }

        public static MapperConfiguration GetConfig()
        {
            return mapperConfig;
        }
    }
}
