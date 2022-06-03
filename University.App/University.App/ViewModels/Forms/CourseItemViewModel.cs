using System;
using System.Collections.Generic;
using System.Text;
using University.App.DTOs;
using Xamarin.Forms;

namespace University.App.ViewModels.Forms
{
    public class CourseItemViewModel : CourseDTO
    {
        async void OnItemClick()
        {
            await Application.Current.MainPage.DisplayAlert("Notify", $"Selected {this.Title}", "Cancel");
        }

        public Command OnItemClickCommand { get; set; }

        public CourseItemViewModel()
        {
            this.OnItemClickCommand = new Command(OnItemClick);
        }
    }
}
