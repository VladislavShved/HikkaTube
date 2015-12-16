using AutoMapper;

namespace Core.Mappers
{
    public static class UserMapper
    {
        static UserMapper()
        {
            Mapper.CreateMap<DataSource.User, Authentication.Models.User>();
            Mapper.CreateMap<Authentication.Models.User, DataSource.User>();
        }

        public static DataSource.User ToDataSourceModel(Authentication.Models.User user)
        {
            return Mapper.Map<Authentication.Models.User, DataSource.User>(user);
        }

        public static Authentication.Models.User ToCoreModel(DataSource.User user)
        {
            return Mapper.Map<DataSource.User, Authentication.Models.User>(user);
        }
    }
}
