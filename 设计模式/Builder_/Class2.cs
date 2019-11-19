using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 设计模式.Builder_
{
    class Class2:Builder
    {
        computer computer2 = new computer();
        public override void BuiderCard()
        {
            computer2.Add("Card2");
        }
        public override void BuilderCPU()
        {
            computer2.Add("CPU2");
        }
        public override void BuilderPartMainBoard()
        {
            computer2.Add("Main board2");
        }
        public override computer GetComputer()
        {
            return computer2;
        }

    }
}
