using System.Collections.Generic;
using Windows.UI.Xaml.Navigation;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;
using Microsoft.Practices.Prism.Mvvm.Interfaces;
using Prism_AdvancedDemo.Entities;

namespace Prism_AdvancedDemo.ViewModels
{
    public class DetailPageViewModel : ViewModel
    {
        public DetailPageViewModel(INavigationService navigationService)
        {
            GoBackCommand = new DelegateCommand(() =>
            {
                if (navigationService.CanGoBack())
                {
                    navigationService.GoBack();
                }  
            });
        }

        public override void OnNavigatedTo(object navigationParameter, NavigationMode navigationMode, Dictionary<string, object> viewModelState)
        {
            News news = navigationParameter as News;
            if (news != null)
            {
                Title = news.Title;
                Summary = news.Summary;
            }
        }

        public DelegateCommand GoBackCommand { get; private set; }

        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private string _summary;

        public string Summary
        {
            get { return _summary; }
            set { SetProperty(ref _summary, value); }
        }
    }
}
