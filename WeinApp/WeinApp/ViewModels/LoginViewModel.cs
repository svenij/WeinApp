using System;
using System.ComponentModel;
using System.Windows.Input;
using WeinApp.Views;
using Xamarin.Forms;

namespace WeinApp.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public Command LoginCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
            SubmitCommand = new Command(OnSubmit);
        }

        private async void OnLoginClicked(object obj)
        {
            await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
        }
        public Action DisplayInvalidLoginPrompt;
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        private string username;
        public string Username
        {
            get => username;
            set
            {
                username = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Email"));
            }
        }

        private string password;
        public string Password
        {
            get => password;
            set
            {
                password = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Password"));
            }
        }
        public ICommand SubmitCommand { protected set; get; }

        public void OnSubmit()
        {
            if (username != "user" || password != "user")
            {
                DisplayInvalidLoginPrompt();
            }
        }
    }
}

