using System.Collections.Generic;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using MVVMLightDesignData.Entities;
using MVVMLightDesignData.Services;

namespace MVVMLightDesignData.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(IFeedService feedService)
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
                RaisePropertyChanged();
            }
        } 
    }
}