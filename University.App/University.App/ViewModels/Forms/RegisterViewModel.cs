using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using University.App.DTOs;
using University.App.Views.Forms;
using Xamarin.Forms;
using static University.App.DTOs.RegisterDTO;

namespace University.App.ViewModels.Forms
{
    public class RegisterViewModel : BaseViewModel
    {
        #region Attributes
        //private string _name;
        //private string _lastName;
        private string _email;
        private string _password;
        #endregion

        #region Properties
        //public string Name
        //{
        //    get { return _name; }
        //    set { this.SetValue(ref _name, value); }
        //}

        //public string LastName
        //{
        //    get { return _lastName; }
        //    set { this.SetValue(ref _lastName, value); }
        //}

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
        async void Register()
        {
            
            var data = new RegisterReqDTO { Email = this.Email, Password = this.Password };

            var json = JsonConvert.SerializeObject(data);
            var req = new StringContent(json, Encoding.UTF8, "application/json");
            var url = "https://reqres.in/api/register";
            var result = string.Empty;

            using (var client = new HttpClient())
            {
                var response = await client.PostAsync(url, req);
                var statusCode = response.StatusCode;
                result = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    //TODO: Logic App
                    var registerRes = JsonConvert.DeserializeObject<RegisterResDTO>(result);
                    var token = registerRes.Token;
                    var id = registerRes.Id;
                    await Application.Current.MainPage.DisplayAlert("Notify", "id: " + id + " token:" + token, "Cancel");

                    //redirect
                    await Application.Current.MainPage.Navigation.PushAsync(new HomePage());
                }
                else
                {
                    var registerResFail = JsonConvert.DeserializeObject<RegisterResFailDTO>(result);
                    var error = registerResFail.Error;
                    await Application.Current.MainPage.DisplayAlert("Notify", error, "Cancel");
                }


            }



        }

        async void AlreadyRegistered()
        {
            
            await Application.Current.MainPage.Navigation.PushAsync(new LoginPage());
        }
        #endregion

        #region Commands
        public Command AlreadyRegisteredCommand { get; set; }
        public Command RegisterCommand { get; set; }
        #endregion

        public RegisterViewModel()
        {
            this.AlreadyRegisteredCommand = new Command(AlreadyRegistered);
            this.RegisterCommand = new Command(Register);
        }
    }
}
