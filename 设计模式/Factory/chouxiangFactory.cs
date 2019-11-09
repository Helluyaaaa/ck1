using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 设计模式.Factory
{
    abstract class chouxiangFactory
    {
        public abstract Icolor GetIcolor(string color);
        public abstract Ishape GetIshape(string shape);
    }
}
