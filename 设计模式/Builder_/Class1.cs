using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 设计模式.Builder_
{
    class Class1:Builder
    {
        computer computer1 = new computer();
        public override void BuiderCard()
        {
            computer1.Add("Card1");
        }
        public override void BuilderCPU()
        {
            computer1.Add("CPU1");
        }
        public override void BuilderPartMainBoard()
        {
            computer1.Add("Main board1");
        }
        public override computer GetComputer()
        {
            return computer1;
        }
    }
}
