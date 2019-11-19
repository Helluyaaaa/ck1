using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 设计模式.AbstractFactory_
{
    public abstract class FactoryProducer
    {
        public static AbstractFactory GetFactory(string choice)
        {
            if (choice.Equals("Shape"))
            {
                return new shapeFactory();
            }else if(choice.Equals("Color"))
            {
                return new ColorFactory();
            }        return null;
        }

    }
}
