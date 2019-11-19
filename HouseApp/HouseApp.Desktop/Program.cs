using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Urho;
using Urho.Desktop;

namespace HouseApp.Desktop
{
    class Program
    {
        static void Main(string[] args)
        {
            DesktopUrhoInitializer.AssetsDirectory = @"C:\Users\94351\source\repos\ck1\HouseApp\Assets";
            new Houseapp().Run();
        }
    }
}
