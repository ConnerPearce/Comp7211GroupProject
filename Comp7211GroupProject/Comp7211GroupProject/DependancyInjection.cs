using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Autofac;

namespace Comp7211GroupProject
{

    // This class is for Dependancy Injection
    // DO NOT MODIFY
    public static class DependancyInjection
    {
        public static IContainer Configure()
        {
            // Basic Injection, when we add more variables i can inject them here (INCLUDES DATABASE VARIABLES)
            var builder = new ContainerBuilder();

            return builder.Build();
        }
    }
}
