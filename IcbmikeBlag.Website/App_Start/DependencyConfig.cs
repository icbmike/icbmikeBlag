﻿using System.Reflection;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using IcbmikeBlag.Application.DAL;
using IcbmikeBlag.Application.Repositories;
using IcbmikeBlag.Application.Services;

namespace IcbmikeBlag
{
    public class DependencyConfig
    {
        public static void RegisterDepencies()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());


            //DbContext
            builder.RegisterType<BlagContext>();

            //Repositories
            builder.RegisterType<BlogPostRepository>().As<IBlogPostRepository>();
            builder.RegisterType<UserRepository>().As<IUserRepository>();
            
            //Services
            builder.RegisterType<TwitterService>().As<ITwitterService>();
            builder.RegisterType<TwitterServiceSettings>().As<ITwitterServiceSettings>();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(builder.Build()));
        }
    }
}