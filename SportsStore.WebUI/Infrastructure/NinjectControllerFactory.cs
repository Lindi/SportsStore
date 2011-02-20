using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using Ninject.Modules;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Concrete;
using System.Configuration;

namespace SportsStore.WebUI.Infrastructure
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        //  A Ninject kernel is the thing that returns object instances
        private IKernel kernel = new StandardKernel( new SportsStoreServices());

        //  Returns the controller from the Ninject kernel
        protected override IController GetControllerInstance(System.Web.Routing.RequestContext requestContext, Type controllerType)
        {
            if (controllerType == null)
                return null;
            return (IController)kernel.Get(controllerType);
        }

        //  Maps abstract services to concrete implementations
        private class SportsStoreServices : NinjectModule
        {
            public override void Load()
            {
                Bind<IProductsRepository>()
                    .To<SqlSportsRepository>()
                    .WithConstructorArgument("connectionString",
                        ConfigurationManager.ConnectionStrings["AppDb"].ConnectionString);
            }
        }
    }
}