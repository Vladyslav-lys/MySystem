using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace MySystem.Service.Contract
{
    public interface IStartup
    {
        void ConfigureServices(IServiceCollection services);
        void Configure(IApplicationBuilder app);
    }
}
