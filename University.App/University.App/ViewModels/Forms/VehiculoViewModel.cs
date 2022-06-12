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
    public class VehiculoViewModel : BaseViewModel
    {
        #region Attributes
        private ObservableCollection<VehiculoItemViewModel> _vehiculo;
        private bool _isRefreshing;
        #endregion

        #region Properties
        public ObservableCollection<VehiculoItemViewModel> Vehiculo
        {
            get { return _vehiculo; }
            set { this.SetValue(ref _vehiculo, value); }
        }

        public bool IsRefreshing
        {
            get { return _isRefreshing; }
            set { this.SetValue(ref _isRefreshing, value); }
        }
        #endregion

        #region Methods
        async void GetVehiculo()
        {
            this.IsRefreshing = true;
            
            var url = "https://62a286bbcd2e8da9b00913a9.mockapi.io/api/Vehiculos";
            var result = string.Empty;

            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                result = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    var vehiculo = JsonConvert.DeserializeObject<ObservableCollection<VehiculoItemViewModel>>(result);

                    this.Vehiculo = vehiculo;
                }
            }
            this.IsRefreshing = false;
        }
        #endregion

        #region Commands
        public Command RefreshCommand { get; set; }
        #endregion

        public VehiculoViewModel()
        {
            this.RefreshCommand = new Command(GetVehiculo);
            this.RefreshCommand.Execute(null);
        }
    }
}
