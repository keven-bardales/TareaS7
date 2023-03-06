using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MovilLibroPersona.ViewModel;

namespace MovilLibroPersona.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewPrestamo : ContentPage
    {
        public ViewPrestamo()
        {
            InitializeComponent();

           
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            this.BindingContext = new ViewModelPrestamo();
        }
    }
}