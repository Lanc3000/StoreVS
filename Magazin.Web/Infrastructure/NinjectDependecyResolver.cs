using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Mvc;
using Moq;
using Ninject;
using Magazin.Domain.Abstract;
using Magazin.Domain.Entities;
using Magazin.Domain.Concrete;
using Magazin.Web.Infrastructure.Abstract;
using Magazin.Web.Infrastructure.Concrete;

namespace Magazin.Web.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            kernel.Bind<IMagazinRepository>().To<EFDbMagazinRepository>();
            kernel.Bind<IAuthProvider>().To<FormAuthProvider>();
        }
    }
}