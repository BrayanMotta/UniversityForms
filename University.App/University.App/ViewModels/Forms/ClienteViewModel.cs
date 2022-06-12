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
    public class ClienteViewModel : BaseViewModel
    {
        #region Attributes
        private ObservableCollection<ClienteItemViewModel> _cliente;
        private bool _isRefreshing;
        #endregion

        #region Properties
        public ObservableCollection<ClienteItemViewModel> Cliente
        {
            get { return _cliente; }
            set { this.SetValue(ref _cliente, value); }
        }

        public bool IsRefreshing
        {
            get { return _isRefreshing; }
            set { this.SetValue(ref _isRefreshing, value); }
        }
        #endregion

        #region Methods
        async void GetClientes()
        {
            this.IsRefreshing = true;
            
            var url = "https://62a286bbcd2e8da9b00913a9.mockapi.io/api/Clientes";
            var result = string.Empty;

            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                result = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    var cliente = JsonConvert.DeserializeObject<ObservableCollection<ClienteItemViewModel>>(result);

                    this.Cliente = cliente;
                }
            }
            this.IsRefreshing = false;
        }
        #endregion

        #region Commands
        public Command RefreshCommand { get; set; }
        #endregion

        public ClienteViewModel()
        {
            this.RefreshCommand = new Command(GetClientes);
            this.RefreshCommand.Execute(null);
        }
    }
}
