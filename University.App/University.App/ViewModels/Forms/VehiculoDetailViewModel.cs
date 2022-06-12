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
    public class VehiculoDetailViewModel : BaseViewModel
    {
        #region Attributes
        private VehiculoDTO _vehiculo;
        private ObservableCollection<EmpleadoDTO> _empleado;
        private bool _isRefreshing;
        #endregion

        #region Properties
        public VehiculoDTO Vehiculo
        {
            get { return _vehiculo; }
            set { this.SetValue(ref _vehiculo, value); }
        }
        public ObservableCollection<EmpleadoDTO> Empleado
        {
            get { return _empleado; }
            set { this.SetValue(ref _empleado, value); }
        }

        public bool IsRefreshing
        {
            get { return _isRefreshing; }
            set { this.SetValue(ref _isRefreshing, value); }
        }
        #endregion


        public VehiculoDetailViewModel(VehiculoDTO vehiculo)
        {
            this.Vehiculo = vehiculo;
            this.RefreshCommand = new Command(GetEmpleado);
            this.RefreshCommand.Execute(null);
        }

        public VehiculoDetailViewModel()
        {

        }



        #region Methods
        async void GetEmpleado()
        {
            this.IsRefreshing = true;

            var url = "https://62a286bbcd2e8da9b00913a9.mockapi.io/api/Empleados";
            var result = string.Empty;

            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                result = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    var empleado = JsonConvert.DeserializeObject<ObservableCollection<EmpleadoDTO>>(result);
                    var empleadoFilter = empleado.Where(x => x.ID == _vehiculo.IdEmpleado).ToList();
                    this.Empleado = new ObservableCollection<EmpleadoDTO>(empleadoFilter);
                }
            }
            this.IsRefreshing = false;
        }
        #endregion

        #region Commands
        public Command RefreshCommand { get; set; } 
        #endregion
    }
}
