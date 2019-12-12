using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace cao
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Animation2 : ContentPage
    {
        public Animation2()
        {
            InitializeComponent();
           
        }

        private void button3_Clicked(object sender, EventArgs e)
        {
            var animation = new Animation(v => image2.Scale = v, 1, 2);
        }
    }
}