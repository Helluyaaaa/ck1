using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 设计模式.Factory;
using 设计模式.Factory.shiti.color;

namespace 设计模式.AbstractFactory_
{
    class ColorFactory:AbstractFactory
    {
        public override Ishape GetIshape(string shape)
        {
            return null;
        }
        public override Icolor GetIcolor(string color)
        {
            if (color == null)
            {
                return null;
            }
            if (color.Equals("red"))
            {
                return new red();
            }
            else if (color.Equals("green"))
            {
                return new green();
            }
            else return null;
        }
    }
}
