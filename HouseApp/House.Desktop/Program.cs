using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Urho.Desktop;
using HouseApp;
namespace House.Desktop
{
    class Program
    {
        static void Main(string[] args)
        {
            DesktopUrhoInitializer.AssetsDirectory= @"../../Assets";
            new Houseapp().Run();
        }
    }
}
