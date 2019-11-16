using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Comp7211GroupProject.Classes.API.Proxys;

namespace Comp7211GroupProject
{

    // This class is for Dependancy Injection
    // DO NOT MODIFY
    public static class DependancyInjection
    {
        ///Temp Edit
        public static IContainer Configure()
        {
            // Basic Injection, when we add more variables i can inject them here (INCLUDES DATABASE VARIABLES)
            var builder = new ContainerBuilder();


            // API PROXYS BELOW

            //Injects the base address into the proxys
            string baseAddress = "https://comp7211groupprojectapi20191115092109.azurewebsites.net/";

            builder.Register<UserProxy>((c, p) =>
            {
                return new UserProxy(baseAddress);
            }).As<IUserProxy>();

            builder.Register<MessagesProxy>((c, p) =>
            {
                return new MessagesProxy(baseAddress);
            }).As<IUserProxy>();

            return builder.Build();
        }
    }
}
