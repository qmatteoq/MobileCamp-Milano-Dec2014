using System.Collections.Generic;
using System.Collections.ObjectModel;
using Windows.ApplicationModel;
using Microsoft.Practices.Prism.Mvvm;
using Prism_DesignData.Entities;
using Prism_DesignData.Services;

namespace Prism_DesignData.ViewModels
{
    public class MainPageViewModel : ViewModel
    {
        public MainPageViewModel()
        {
            if (DesignMode.DesignModeEnabled)
            {
                News = new ObservableCollection<News>
                {
                    new News
                    {
                        Title = "Test 1",
                        Summary = "Summary 1"
                    },
                    new News
                    {
                        Title = "Test 2",
                        Summary = "Summary 2"
                    },
                    new News
                    {
                        Title = "Test 3",
                        Summary = "Summary 3"
                    }
                };
            }
        }

        public MainPageViewModel(IFeedService feedService)
        {
            IEnumerable<News> list = feedService.GetNews();
            News = new ObservableCollection<News>();
            foreach (News news in list)
            {
                News.Add(news);
            }
        }

        private ObservableCollection<News> _news;

        public ObservableCollection<News> News
        {
            get { return _news; }
            set
            {
                _news = value;
                SetProperty(ref _news, value);
            }
        }
    }
}
