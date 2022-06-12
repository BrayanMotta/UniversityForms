using System;
using System.Collections.Generic;
using System.Text;
using University.App.DTOs;
using University.App.Views.Forms;
using Xamarin.Forms;


namespace University.App.ViewModels.Forms
{
    public class ClienteItemViewModel : ClienteDTO
    {
        async void OnItemClick()
        {
            await Application.Current.MainPage.DisplayAlert("Notify", $"Selected {this.FullName}", "Cancel");

            ClienteDetailPage detailPage = new ClienteDetailPage();
            detailPage.BindingContext = new ClienteDetailViewModel(this);
            await Application.Current.MainPage.Navigation.PushAsync(detailPage);
        }

        public Command OnItemClickCommand { get; set; }

        public ClienteItemViewModel()
        {
            this.OnItemClickCommand = new Command(OnItemClick);
        }
    }
}
