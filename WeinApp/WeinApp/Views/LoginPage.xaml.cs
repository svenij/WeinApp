using Plugin.Fingerprint;
using Plugin.Fingerprint.Abstractions;
using System;
using WeinApp.Models;
using WeinApp.Services;
using WeinApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WeinApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
	{
		public LoginPage()
		{
			InitializeComponent();
		}

		async void OnSignUpButtonClicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new SignUpPage());
		}

		async void OnLoginButtonClicked(object sender, EventArgs e)
		{
			var user = new User
			{
				Username = usernameEntry.Text,
				Password = passwordEntry.Text
			};

                return;
            }
            var authResult = await
                CrossFingerprint.Current.AuthenticateAsync(new
                AuthenticationRequestConfiguration("Achtung!", "Bitte Fingerprint verwenden!"));

            if (authResult.Authenticated)
            {
                await DisplayAlert("Yes!", "Zugriff zugelassen", "Weiter");
                await Shell.Current.GoToAsync("//AboutPage");
            }
        }
    }
}
