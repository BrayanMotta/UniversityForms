using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace University.App.Views.Forms
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IMCPage : ContentPage
    {
        public IMCPage()
        {
            InitializeComponent();
        }

        private void Calcular_Clicked(object sender, EventArgs e)
        {
            var peso = double.Parse(Peso.Text);
            var altura = double.Parse(Altura.Text)/100;

            var resultado = peso / (altura*altura);

            Result.Text = Math.Round(resultado,2).ToString();

            if (resultado < 18.5)
            {
                var message = $"Tienes bajo peso.";
                DisplayAlert("Resultado", message, "Cerrar");
            }else if(resultado <= 24.9)
            {
                var message = $"Tu peso es normal.";
                DisplayAlert("Resultado", message, "Cerrar");
            }else if(resultado <= 29.9)
            {
                var message = $"Tienes sobrepeso.";
                DisplayAlert("Resultado", message, "Cerrar");
            }
            else
            {
                var message = $"Tienes obesidad, ¡Cuidate!.";
                DisplayAlert("Resultado", message, "Cerrar");
            }
        }
    }
}