using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 设计模式.Builder_
{
    public class computer
    {
        private IList<string> parts = new List<string>();
        public void Add(string part)
        {
            parts.Add(part);
        }
        public void show()
        {
            Console.WriteLine("电脑正在组装……");
            foreach(string part in parts)
            {
                Console.WriteLine("组件" + part + "已装完");
            }
            Console.WriteLine("电脑装好了");
        }
    }
}
