using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DegreeConverter
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            ConvertButton.Clicked += ConvertButton_Clicked;
            CleanButton.Clicked += CleanButton_Clicked;
        }

        private void CleanButton_Clicked(object sender, EventArgs e)
        {
            KelvinEntry.Text = null;
            FahrenheitEntry.Text = null;
            CelsiusEntry.Text = null;
            return;
        }

        private void ConvertButton_Clicked(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(CelsiusEntry.Text))
            {
                DisplayAlert("Error","Please enter a numeric value in Celsius...","Accept");
                return;
            }

            decimal Celsius = 0;
            if(!decimal.TryParse(CelsiusEntry.Text, out Celsius))
            {
                DisplayAlert("Error","Please enter a numeric value in Celsius..." ,"Accept");
                return;
            }

            var Fahrenheit = (9*Convert.ToDouble(Celsius)/5)+32;
            var Kelvin = Convert.ToDouble(Celsius)+273.15;

            KelvinEntry.Text = String.Format("{0} °K",Kelvin);
            FahrenheitEntry.Text = String.Format("{0} °F", Fahrenheit);
        }
    }
}