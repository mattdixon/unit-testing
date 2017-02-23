using System;
using System.Collections.Generic;
using System.Windows;
using Caliburn.Micro;
using FrontRangeSystems.UnitTesting.Services;
using FrontRangeSystems.UnitTesting.Services.Contracts;
using FrontRangeSystems.UnitTesting.WindowsClient.ViewModels;

namespace FrontRangeSystems.UnitTesting.WindowsClient
{
    public class AppBootstrapper : BootstrapperBase
    {
        public AppBootstrapper()
        {
            Initialize();
        }

        public SimpleContainer Container { get; set; }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<ShellViewModel>();
        }

        protected override void Configure()
        {
            Container = new SimpleContainer();

            Container.Singleton<IWindowManager, WindowManager>();
            Container.Singleton<IEventAggregator, EventAggregator>();

            Container.PerRequest<ShellViewModel, ShellViewModel>();

            Container.PerRequest<IMathService, MathService>();
            Container.PerRequest<IPrizeMoneyCalculationService, PrizeMoneyCalculationService>();
        }

        protected override object GetInstance(Type service, string key)
        {
            var instance = Container.GetInstance(service, key);
            if (instance != null)
                return instance;

            throw new InvalidOperationException("Could not locate any instances.");
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return Container.GetAllInstances(service);
        }

        protected override void BuildUp(object instance)
        {
            Container.BuildUp(instance);
        }
    }
}