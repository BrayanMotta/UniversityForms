using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Xamarin.Forms;

namespace University.App.ViewModels.Forms
{
    public class LoginViewModel : BaseViewModel
    {
        #region Attributes
        private string _email;
        private string _password;
        #endregion

        #region Properties
        public string Email
        {
            get { return _email; }
            set { this.SetValue(ref _email, value); }
        }

        public string Password
        {
            get { return _password; }
            set { this.SetValue(ref _password, value); }
        }
        #endregion

        #region Methods
        async void Login()
        {
            var data = new
            {
                email = this.Email,
                passwors = this.Password
            };

            var json = JsonConvert.SerializeObject(data);
            var req = new StringContent(json, Encoding.UTF8, "application/json");
            var url = "https://reqres.in/api/login";
            var result = string.Empty;

            using (var client = new HttpClient())
            {
                var response = await client.PostAsync(url, req);

                if (response.IsSuccessStatusCode)
                {
                    //TODO: Logic App
                    await Application.Current.MainPage.DisplayAlert("Notify", "Login OK", "Cancel");
                }

                var statusCode = response.StatusCode;
                result = await response.Content.ReadAsStringAsync();
            }



        }
        #endregion

        #region Commands
        public Command LoginCommand { get; set; } 
        #endregion

        public LoginViewModel()
        {
            this.LoginCommand = new Command(Login);
        }
    }
}
