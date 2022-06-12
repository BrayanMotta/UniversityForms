using System;
using System.Collections.Generic;
using System.Text;
using University.App.DTOs;
using University.App.Views.Forms;
using Xamarin.Forms;

namespace University.App.ViewModels.Forms
{
    public class VehiculoItemViewModel : VehiculoDTO
    {
        async void OnItemClick()
        {
            await Application.Current.MainPage.DisplayAlert("Notify", $"Selected {this.VhPlaca}", "Cancel");

            VehiculoDetailPage detailPage = new VehiculoDetailPage();
            detailPage.BindingContext = new VehiculoDetailViewModel(this);
            await Application.Current.MainPage.Navigation.PushAsync(detailPage);
        }

        public Command OnItemClickCommand { get; set; }

        public VehiculoItemViewModel()
        {
            this.OnItemClickCommand = new Command(OnItemClick);
        }
    }
}
