using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 设计模式.Builder_
{
    class Boss
    {
        public void Construct(Builder builder)
        {
            builder.BuilderCPU();
            builder.BuiderCard();
            builder.BuilderPartMainBoard();
        }
    }
}
