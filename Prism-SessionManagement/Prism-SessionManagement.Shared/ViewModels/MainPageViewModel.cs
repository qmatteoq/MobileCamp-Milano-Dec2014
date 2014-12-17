using System.Collections.Generic;
using Windows.UI.Xaml.Navigation;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;
using Microsoft.Practices.Prism.Mvvm.Interfaces;
using Prism_SessionManagement.Entities;

namespace Prism_SessionManagement.ViewModels
{
    public class MainPageViewModel : ViewModel
    {
        private readonly ISessionStateService _sessionStateService;
        private string _name;

        [RestorableState]
        public string Name
        {
            get {return _name;}
            set { SetProperty(ref _name, value); }
        }

        private string _surname;

        [RestorableState]
        public string Surname
        {
            get { return _surname; }
            set { SetProperty(ref _surname, value); }
        }

        private Person _latestPerson;

        public Person LatestPerson
        {
            get {return _latestPerson;}
            set { SetProperty(ref _latestPerson, value); }
        }

        public MainPageViewModel(ISessionStateService sessionStateService)
        {
            _sessionStateService = sessionStateService;
            SavePerson = new DelegateCommand(() =>
            {
                LatestPerson = new Person
                {
                    Name = Name,
                    Surname = Surname
                };

                sessionStateService.SessionState.Add("Person", LatestPerson);
            });
        }

        public DelegateCommand SavePerson { get; private set; }

        public override void OnNavigatedTo(object navigationParameter, NavigationMode navigationMode, Dictionary<string, object> viewModelState)
        {
            base.OnNavigatedTo(navigationParameter, navigationMode, viewModelState);
            if (_sessionStateService.SessionState.ContainsKey("Person"))
            {
                LatestPerson = _sessionStateService.SessionState["Person"] as Person;
            }
        }
    }
}
