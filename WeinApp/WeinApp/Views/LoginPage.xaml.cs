using Plugin.Fingerprint;
using Plugin.Fingerprint.Abstractions;
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
            this.BindingContext = new LoginViewModel();
        }
        async void Btn_Biometrie(System.Object sender, System.EventArgs e)
        {
            var availability = await
                CrossFingerprint.Current.IsAvailableAsync();

            if (!availability)
            {
                await DisplayAlert("Warnung!", "Keine Biometrie verfügbar!", "OK!");

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
