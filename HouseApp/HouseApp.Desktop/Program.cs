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
            DesktopUrhoInitializer.AssetsDirectory = @"D:\ck1\HouseApp\Assets";
            new Houseapp().Run();
        }
    }
}
