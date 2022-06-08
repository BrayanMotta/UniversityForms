using System;
using System.Collections.Generic;
using System.Text;
using University.App.DTOs;
using University.App.Views.Forms;
using Xamarin.Forms;

namespace University.App.ViewModels.Forms
{
    public class CourseItemViewModel : CourseDTO
    {
        async void OnItemClick()
        {
            await Application.Current.MainPage.DisplayAlert("Notify", $"Selected {this.Title}", "Cancel");
            
            CourseDetailPage detailPage = new CourseDetailPage();
            detailPage.BindingContext = new CourseDetailViewModel(this);
            await Application.Current.MainPage.Navigation.PushAsync(detailPage);
        }

        public Command OnItemClickCommand { get; set; }

        public CourseItemViewModel()
        {
            this.OnItemClickCommand = new Command(OnItemClick);
        }
    }
}
