using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson1_控制台相关
{
    internal class Program
    {
        static void Main(string[] args)
        {/*
            #region 知识点一 复习 输入输出
            Console.WriteLine();
            Console.Write("");
            string str=Console.ReadLine();
            //ReadKey(true)不会把输入的内容显示在控制台
            char c = Console.ReadKey(true).KeyChar;
            #endregion
            */
            #region 知识点二 控制台其他方法
            //1.清空
            Console.Clear();

            //2.设置控制台大小
            //窗口大小 缓冲区大小
            //注意：
            //    1.先设置窗口大小 后设置缓冲区大小
            //    2.缓冲区的大小不能小于窗口大小
            //    3.窗口大小不能大于控制台的最大尺寸
            //窗口大小
            Console.SetWindowSize(100, 50);
            //缓冲区大小(可打印内容区域的宽高)
            Console.SetBufferSize(1000, 1000);

            //3.设置光标位置
            //左上角为原点，向左(向下)为X轴(y轴)正方向
            //注意：
            //    1.边界问题
            //    2.横纵距离单位不同 1y=2x 视觉上的
            Console.SetCursorPosition(4, 2);
            Console.WriteLine("光标位置");

            //4.设置颜色相关
            //文字颜色设置
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("文字颜色设置");
            //背景颜色设置
            Console.BackgroundColor = ConsoleColor.White;
            //设置背景颜色之后，需要Clear一次 才可以将整个背景颜色改变
            Console.Clear();

            //5.光标显隐
            Console.CursorVisible = false;

            //6.关闭控制台
            Environment.Exit(0);
            #endregion
        }
    }
}
