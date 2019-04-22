
namespace Vote.UIForms.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using System.Windows.Input;
    using Vote.UIForms.Views;
    using Xamarin.Forms;

    public class LoginViewModel 
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public ICommand LoginCommand => new RelayCommand(Login);

        public LoginViewModel()
        {
            this.Email = "santisuarez1100@gmail.com";
            this.Password = "123456";
        }


        private async void Login()
        {
            if (string.IsNullOrEmpty(this.Email))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "You must enter a Email",
                    "Accept");
                return;
            }


            if (string.IsNullOrEmpty(this.Password))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "You must enter a Password",
                    "Accept");
                return;
            }

            if (!this.Email.Equals("santisuarez1100@gmail.com") || !this.Password.Equals("123456"))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "User or password wrong",
                    "Accept");
                return;
            }


            /*await Application.Current.MainPage.DisplayAlert(
                  "Hello,",
                  "Welcome ",
                  "Accept");*/

            MainViewModel.GetInstance().Events = new EventsViewModel(); 
            await Application.Current.MainPage.Navigation.PushAsync(new EventsPage());
            

        }
    }
}
