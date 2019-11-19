using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 设计模式.AbstractFactory_;
using 设计模式.Factory;
using 设计模式.dan_li;
using 设计模式.Builder_;
namespace 设计模式
{
    class Program
    {
        static void Main(string[] args)
        {
            AbstractFactory shapefactory = FactoryProducer.GetFactory("Shape");
            Ishape shape1 = shapefactory.GetIshape("Rectangle");
            shape1.draw();
            Ishape shape2 = shapefactory.GetIshape("Square");
            shape2.draw();

            AbstractFactory colorfactory = FactoryProducer.GetFactory("Color");
            Icolor color1 = colorfactory.GetIcolor("red");
            color1.fill();
            Icolor color2 = colorfactory.GetIcolor("green");
            color2.fill();

            //单例
            danli newclass = danli.GetDanli();
            danli newclass2 = danli.GetDanli();

            //建造者模式
            Customer customer1 = new Customer();
            customer1.BuyComputer();
            
            
            
            
            
            
            
            
            
            
            
            Console.Read();


        }
    }
}
