using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 设计模式.dan_li
{
    class danli
    {
        public static danli danli1;
        private static readonly object locker = new object();

        private danli() { }

        public static danli GetDanli()
        {
            if (danli1 == null)
            {
                lock (locker)
                {
                    if (danli1 == null)
                    {
                        danli1 = new danli();
                    }
                }
            }
            return danli1;
        }
    }
}
