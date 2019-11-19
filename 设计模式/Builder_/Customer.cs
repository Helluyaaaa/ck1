using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 设计模式.Builder_
{
    class Customer
    {
        public void BuyComputer()
        {
            Boss boss = new Boss();
            Builder b1 = new Class1();
            Builder b2 = new Class2();

            boss.Construct(b1);
            computer computer1 = b1.GetComputer();
            computer1.show();

            boss.Construct(b2);
            computer computer2 = b2.GetComputer();
            computer2.show();

            Console.Read();
        }
    }
}
