using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 设计模式.Factory;

namespace 设计模式.AbstractFactory_
{
    class shapeFactory:AbstractFactory
    {
        public override Ishape GetIshape(string shape)
        {
            if (shape == null)
            {
                return null;
            }
            if (shape.Equals("Rectangle"))
            {
                return new Rectangle();
            }
            else if (shape.Equals("Square"))
            {
                return new Square();
            }
            return null;
        }
        public override Icolor GetIcolor(string color)
        {
            return null;
        }
    }
}
