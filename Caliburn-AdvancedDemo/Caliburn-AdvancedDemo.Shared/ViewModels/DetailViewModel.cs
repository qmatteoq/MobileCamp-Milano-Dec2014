using Caliburn.Micro;
using Caliburn_AdvancedDemo.Entities;

namespace Caliburn_AdvancedDemo.ViewModels
{
    public class DetailViewModel : Screen
    {
        private readonly INavigationService _navigationService;
        private string _title;

        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                NotifyOfPropertyChange(() => Title);
            }
        }

        private string _summary;

        public string Summary
        {
            get { return _summary; }
            set
            {
                _summary = value;
                NotifyOfPropertyChange(() => Summary);
            }
        }

        public News Parameter { get; set; }

        protected override void OnActivate()
        {
            Title = Parameter.Title;
            Summary = Parameter.Summary;
        }

        public DetailViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public void GoBack()
        {
            if (_navigationService.CanGoBack)
            {
                _navigationService.GoBack();
            }
        }
    }
}
