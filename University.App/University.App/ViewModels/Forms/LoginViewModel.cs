using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using University.App.DTOs;
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
            //var data = new{email = this.Email, password = this.Password};
            var data = new LoginReqDTO{Email = this.Email, Password = this.Password};

            var json = JsonConvert.SerializeObject(data);
            var req = new StringContent(json, Encoding.UTF8, "application/json");
            var url = "https://reqres.in/api/login";
            var result = string.Empty;

            using (var client = new HttpClient())
            {
                var response = await client.PostAsync(url, req);
                var statusCode = response.StatusCode;
                result = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    //TODO: Logic App
                    var loginRes = JsonConvert.DeserializeObject<LoginResDTO>(result);
                    var token = loginRes.Token;
                    await Application.Current.MainPage.DisplayAlert("Notify", token, "Cancel");

                    //redirect
                    await Application.Current.MainPage.Navigation.PushAsync(new HomePage());
                }
                else
                {
                    var loginResFail = JsonConvert.DeserializeObject<LoginResFailDTO>(result);
                    var error = loginResFail.Error;
                    await Application.Current.MainPage.DisplayAlert("Notify", error, "Cancel");
                }

                
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
