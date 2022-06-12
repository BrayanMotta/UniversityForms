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
    public class ClienteDetailViewModel : BaseViewModel
    {
        #region Attributes
        private ClienteDTO _cliente;
        private ObservableCollection<VehiculoDTO> _vehiculo;
        private bool _isRefreshing;
        #endregion

        #region Properties
        public ClienteDTO Cliente
        {
            get { return _cliente; }
            set { this.SetValue(ref _cliente, value); }
        }
        public ObservableCollection<VehiculoDTO> Vehiculo
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


        public ClienteDetailViewModel(ClienteDTO cliente)
        {
            this.Cliente = cliente;
            this.RefreshCommand = new Command(GetVehiculo);
            this.RefreshCommand.Execute(null);
        }

        public ClienteDetailViewModel()
        {

        }



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
                    var vehiculo = JsonConvert.DeserializeObject<ObservableCollection<VehiculoDTO>>(result);
                    var vehiculoFilter = vehiculo.Where(x => x.IdCliente == _cliente.ID).ToList();
                    this.Vehiculo = new ObservableCollection<VehiculoDTO>(vehiculoFilter);
                }
            }
            this.IsRefreshing = false;
        }

        public Command RefreshCommand { get; set; }
    }
}
