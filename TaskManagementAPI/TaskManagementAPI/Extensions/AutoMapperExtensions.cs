namespace TaskManagementAPI.Extensions
{
    public static class AutoMapperExtensions
    {
        public static IServiceCollection AddAutoMapper(this IServiceCollection services, params AutoMapper.Profile[] profiles)
        {
            return services.AddAutoMapper(x =>
            {
                foreach (var profile in profiles)
                    x.AddProfile(profile);
            });
        }
    }
}
