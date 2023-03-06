using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using MovilLibroPersona.ViewModel;
using Xamarin.Forms.Xaml;

namespace MovilLibroPersona.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewLibro : ContentPage
    {
        public ViewLibro()
        {
            InitializeComponent();
            BindingContext = new ViewModelLibro();
        }
    }
}