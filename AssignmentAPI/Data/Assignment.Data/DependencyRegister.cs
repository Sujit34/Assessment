using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment.Data
{
    public static class DependencyRegister
    {

        public static IServiceCollection AddRepositoryDependency(
            this IServiceCollection services)
        {

            return services;
        }

    }
}
