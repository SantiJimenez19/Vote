
namespace Vote.UIForms.ViewModels
{
    using Common.Models;
    using Common.Services;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Xamarin.Forms;

    public class EventsViewModel : BaseViewModel
    {
        private readonly ApiService apiService;
        private ObservableCollection<Event> events;
        private bool isRefreshing;

        public ObservableCollection<Event> Events
        {
            get => this.events;
            set => this.SetValue(ref this.events, value);
        }

        public bool IsRefreshing
        {
            get => this.isRefreshing;
            set => this.SetValue(ref this.isRefreshing, value);
        }



        public EventsViewModel()
        {
            this.apiService = new ApiService();
            this.LoadEvents();
        }

        private async void LoadEvents()
        {
;            this.IsRefreshing = true;
            var response = await this.apiService.GetListAsync<Event>(
                "https://vote2020web.azurewebsites.net",
                "/api",
                "/Events");

            this.IsRefreshing = false;

            if (!response.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    response.Message,
                    "Accept");
                return;
            }

            var myEvents = (List<Event>)response.Result;
            this.Events = new ObservableCollection<Event>(myEvents);
        }
    }
}
