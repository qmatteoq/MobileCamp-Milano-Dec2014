using System.Collections.Generic;
using System.Collections.ObjectModel;
using Windows.UI.Xaml.Controls;
using Caliburn.Micro;
using Caliburn_AdvancedDemo.Entities;
using Caliburn_AdvancedDemo.Services;

namespace Caliburn_AdvancedDemo.ViewModels
{
    public class MainViewModel : Screen
    {
        private readonly IFeedService _feedService;
        private readonly INavigationService _navigationService;

        private ObservableCollection<News> _news;

        public ObservableCollection<News> News
        {
            get { return _news; }
            set
            {
                _news = value;
                NotifyOfPropertyChange(() => News);
            }
        } 

        public MainViewModel(IFeedService feedService, INavigationService navigationService)
        {
            _feedService = feedService;
            _navigationService = navigationService;
        }

        protected override async void OnActivate()
        {
            IEnumerable<News> news = await _feedService.GetNews();
            News = new ObservableCollection<News>();
            foreach (News item in news)
            {
                News.Add(item);
            }
        }

        public void ShowDetail(ItemClickEventArgs args)
        {
            News selectedNews = args.ClickedItem as News;
            _navigationService.NavigateToViewModel<DetailViewModel>(selectedNews);
        }
    }
}
