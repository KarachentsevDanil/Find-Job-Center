using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using Ninject;
using Ninject.Web.Common;
using Ninject.Web.Common.WebHost;
using FJB.DAL.Context;
using FJB.DAL.Repositories.Leases;
using FJB.DAL.Repositories.Leases.Contracts;
using FJB.DAL.Repositories.Robots;
using FJB.DAL.Repositories.Robots.Contracts;
using FJB.DAL.Repositories.Specializations;
using FJB.DAL.Repositories.Specializations.Contracts;
using FJB.DAL.Repositories.Users;
using FJB.DAL.Repositories.Users.Contracts;
using FJB.DAL.UnitOfWork;
using FJB.DAL.UnitOfWork.Contracts;
using RJB.BLL.Leases;
using RJB.BLL.Leases.Contracts;
using RJB.BLL.Robots;
using RJB.BLL.Robots.Contracts;
using RJB.BLL.Specializations;
using RJB.BLL.Specializations.Contracts;
using RJB.BLL.Users;
using RJB.BLL.Users.Contracts;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(RJF.WebService.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(RJF.WebService.App_Start.NinjectWebCommon), "Stop")]

namespace RJF.WebService.App_Start
{
    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<RjbDbContext>().To<RjbDbContext>();

            kernel.Bind<ILeaseService>().To<LeaseService>();
            kernel.Bind<IRobotModelFeedbackService>().To<RobotModelFeedbackService>();
            kernel.Bind<IRobotModelService>().To<RobotModelService>();
            kernel.Bind<IRobotService>().To<RobotService>();
            kernel.Bind<ISpecializationService>().To<SpecializationService>();
            kernel.Bind<IClientService>().To<ClientService>();
            kernel.Bind<ICompanyService>().To<CompanyService>();

            kernel.Bind<IRjbUnitOfWorkBase>().To<RjbUnitOfWorkBase>();
            kernel.Bind<ILeaseRepository>().To<LeaseRepository>();
            kernel.Bind<IRobotModelFeedbackRepository>().To<RobotModelFeedbackRepository>();
            kernel.Bind<IRobotModelRepository>().To<RobotModelRepository>();
            kernel.Bind<IRobotRepository>().To<RobotRepository>();
            kernel.Bind<ISpecializationRepository>().To<SpecializationRepository>();
            kernel.Bind<IClientRepository>().To<ClientRepository>();
            kernel.Bind<ICompanyRepository>().To<CompanyRepository>();
        }
    }
}