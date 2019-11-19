using 设计模式.Factory;
namespace 设计模式.AbstractFactory_
{
    public abstract class AbstractFactory
    {
        public abstract Ishape GetIshape(string shape);
        public abstract Icolor GetIcolor(string color);
    }
}
