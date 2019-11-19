using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 设计模式.Builder_
{
    public abstract class Builder
    {
        public abstract void BuilderCPU();
        public abstract void BuilderPartMainBoard();
        public abstract void BuiderCard();
        public abstract computer GetComputer();
    }
}
