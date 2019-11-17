using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Comp7211GroupProject.Classes.API.Proxys;
using Comp7211GroupProject.Classes.LoginPage;

namespace Comp7211GroupProject
{

    // This class is for Dependancy Injection
    // DO NOT MODIFY WITHOUT ASKING
    public static class DependancyInjection
    {
        public static IContainer Configure()
        {
            // Basic Injection, when we add more variables i can inject them here (INCLUDES DATABASE VARIABLES)
            var builder = new ContainerBuilder();

            // Injection helpers
            builder.RegisterType<LoginBackend>().As<ILoginBackend>();

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
            }).As<IMessagesProxy>();

            builder.Register<SettingsProxy>((c, p) =>
            {
                return new SettingsProxy(baseAddress);
            }).As<ISettingsProxy>();

            builder.Register<PostProxy>((c, p) =>
            {
                return new PostProxy(baseAddress);
            }).As<IPostProxy>();

            builder.Register<CommentsProxy>((c, p) =>
            {
                return new CommentsProxy(baseAddress);
            }).As<ICommentsProxy>();

            // END OF API PROXYS

            return builder.Build();
        }
    }
}
