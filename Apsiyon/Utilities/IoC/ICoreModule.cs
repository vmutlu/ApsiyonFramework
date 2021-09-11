using Microsoft.Extensions.DependencyInjection;

namespace Apsiyon.Utilities.IoC
{
    public interface ICoreModule
    {
        void Load(IServiceCollection services);
    }
}
