using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    internal interface IServerPersonalFactory
    {
         virtual ServerPersonal GetSP() 
        {
           ServerPersonal s= new ServerPersonal();
            return s;
        }
    }
}
