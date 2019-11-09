using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 设计模式.Factory
{
    public class Rectangle:Ishape
    {
        public void draw()
        {
            Console.WriteLine("draw Rectangle");
        }
    }
}
