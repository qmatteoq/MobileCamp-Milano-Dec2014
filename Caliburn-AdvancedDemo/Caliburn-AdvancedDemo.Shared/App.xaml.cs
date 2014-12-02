using System;
using System.Collections.Generic;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml.Controls;
using Caliburn.Micro;
using Caliburn_AdvancedDemo.Services;
using Caliburn_AdvancedDemo.ViewModels;
using Caliburn_AdvancedDemo.Views;

// The Blank Application template is documented at http://go.microsoft.com/fwlink/?LinkId=234227

namespace Caliburn_AdvancedDemo
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    public sealed partial class App
    {
        private WinRTContainer container;

        protected override void Configure()
        {
            container = new WinRTContainer();

            container.RegisterWinRTServices();
            container.PerRequest<MainViewModel>();
            container.PerRequest<DetailViewModel>();

            if (Execute.InDesignMode)
            {
                container.PerRequest<IFeedService, FakeFeedService>();
            }
            else
            {
                container.PerRequest<IFeedService, FeedService>();
            }
        }

        protected override void PrepareViewFirst(Frame rootFrame)
        {
            container.RegisterNavigationService(rootFrame);
        }

        protected override void OnLaunched(LaunchActivatedEventArgs args)
        {
            if (args.PreviousExecutionState == ApplicationExecutionState.Running)
            {
                return;
            }
            DisplayRootView<MainView>();
        }

        protected override object GetInstance(Type service, string key)
        {
            return container.GetInstance(service, key);
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return container.GetAllInstances(service);
        }

        protected override void BuildUp(object instance)
        {
            container.BuildUp(instance);
        }
    }
}