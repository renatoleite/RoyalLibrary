using Application.UseCases.ListBooksUseCase;

namespace WebApi.DependencyInjection
{
    public static class ApplicationExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IListBooksUseCase, ListBooksUseCase>();

            return services;
        }
    }
}
