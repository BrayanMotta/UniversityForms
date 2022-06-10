using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using University.App.DTOs;
using Xamarin.Forms;

namespace University.App.ViewModels.Forms
{
    public class CourseDetailViewModel : BaseViewModel
    {

        #region Attributes
        private CourseDTO _course;
        private ObservableCollection<StudentDTO> _students;
        private bool _isRefreshing;
        #endregion

        #region Properties
        public CourseDTO Course
        {
            get { return _course; }
            set { this.SetValue(ref _course, value); }
        }
        public ObservableCollection<StudentDTO> Students
        {
            get { return _students; }
            set { this.SetValue(ref _students, value); }
        }

        public bool IsRefreshing
        {
            get { return _isRefreshing; }
            set { this.SetValue(ref _isRefreshing, value); }
        }
        #endregion

        
        public CourseDetailViewModel(CourseDTO course)
        {
            this.Course = course;
            this.RefreshCommand = new Command(GetStudents);
            this.RefreshCommand.Execute(null);
        }

        public CourseDetailViewModel()
        {

        }



        async void GetStudents()
        {
            this.IsRefreshing = true;
            //var url = "https://apimocha.com/universitybsm/api/Courses";
            var url = "https://62a28504cd2e8da9b00903d5.mockapi.io/api/Students";
            var result = string.Empty;

            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                result = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    var students = JsonConvert.DeserializeObject<ObservableCollection<StudentDTO>>(result);
                    var studentsFilter = students.Where(x => x.CourseID == _course.CourseID).ToList();
                    this.Students = new ObservableCollection<StudentDTO>(studentsFilter);
                }
            }
            this.IsRefreshing = false;
        }

        public Command RefreshCommand { get; set; }
    }
}
