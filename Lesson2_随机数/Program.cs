using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2_随机数
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region 产生随机数对象
            //固定写法
            //Random 变量名 = new Random();
            #endregion

            #region 生成随机数
            Random random = new Random();
            int i = random.Next();      //生成非负数的随机数
            i = random.Next(100);       //生成0~99的随机数
            i = random.Next(5, 100);    //生成5~99的随机数

            #endregion
        }
    }
}
