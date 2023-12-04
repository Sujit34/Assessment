using Assignment.Business.MoneyTransfer;
using Assignment.Contract.BusinessContract.MoneyTransfer;
using Microsoft.Extensions.DependencyInjection;

namespace Assignment.Business
{
    public static class DependencyRegister
    {
        
        public static IServiceCollection AddBusinessDependency(
            this IServiceCollection services)
        {            
            services.AddScoped<IExchangeRateHandler, ExchangeRateHandler>();
            return services;
        }
        
    }
}
