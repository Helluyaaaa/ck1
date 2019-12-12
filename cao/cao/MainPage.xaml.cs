using DocumentFormat.OpenXml.Drawing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace cao
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
           
        }
        async void clickedEvent1(object sender, EventArgs e)
        {
            await image.RotateTo(360, 2000);
        }

        private void button2_Clicked(object sender, EventArgs e)
        {
            new Animation2();
        }
    }
}
