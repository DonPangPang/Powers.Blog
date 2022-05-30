using Autofac;
using System;
using System.IO;
using System.Reflection;

namespace Powers.Blog.Core.AutoFac
{
    public class AutofacModuleRegister : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var basePath = AppContext.BaseDirectory;

            var serviceDllFile = Path.Combine(basePath, "Powers.Blog.Services.dll");
            var repositoryDllFile = Path.Combine(basePath, "Powers.Blog.Repository.dll");

            if (!(File.Exists(serviceDllFile) && File.Exists(repositoryDllFile)))
            {
                throw new Exception("请先编译再运行");
            }

            var assemblysServices = Assembly.LoadFrom(serviceDllFile);
            builder.RegisterAssemblyTypes(assemblysServices)
                .AsImplementedInterfaces()
                .InstancePerDependency()
                .PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies);

            var assemblysRepository = Assembly.LoadFrom(repositoryDllFile);
            builder.RegisterAssemblyTypes(assemblysRepository)
                .AsImplementedInterfaces()
                .InstancePerDependency()
                .PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies);
        }
    }
}