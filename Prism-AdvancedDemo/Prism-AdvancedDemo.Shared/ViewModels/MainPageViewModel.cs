using System.Collections.Generic;
using System.Collections.ObjectModel;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;
using Microsoft.Practices.Prism.Mvvm.Interfaces;
using Prism_AdvancedDemo.Entities;
using Prism_AdvancedDemo.Services;

namespace Prism_AdvancedDemo.ViewModels
{
    public class MainPageViewModel : ViewModel
    {
        private readonly IFeedService _feedService;
        private readonly INavigationService _navigationService;

        private ObservableCollection<News> _news;

        public ObservableCollection<News> News
        {
            get { return _news; }
            set { SetProperty(ref _news, value); }   
        }

        public MainPageViewModel(IFeedService feedService, INavigationService navigationService)
        {
            _feedService = feedService;
            _navigationService = navigationService;

            ShowDetailCommand = new DelegateCommand<ItemClickEventArgs>((args) =>
            {
                News news = args.ClickedItem as News;
                _navigationService.Navigate("Detail", news);
            });
        }

        public override async void OnNavigatedTo(object navigationParameter, NavigationMode navigationMode, Dictionary<string, object> viewModelState)
        {
            IEnumerable<News> news = await _feedService.GetNews();
            News = new ObservableCollection<News>();
            foreach (News item in news)
            {
                News.Add(item);
            }
        }

        public DelegateCommand<ItemClickEventArgs> ShowDetailCommand { get; private set; }

    }
}
