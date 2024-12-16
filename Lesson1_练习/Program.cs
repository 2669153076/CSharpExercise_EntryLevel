using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson1_练习
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region 练习题
            //通过WASD键在控制台中控制一个黄色方块上下左右移动
            Console.SetWindowSize(100, 50);
            Console.SetBufferSize(110, 60);
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.CursorVisible = false;
            Console.Clear();
            char input;
            int x = 0, y = 0;
            while (true)
            {
                Console.SetCursorPosition(x, y);
                Console.Write("■");
                input = Console.ReadKey(true).KeyChar;
                if (input == 'Q' || input == 'q')
                {
                    Environment.Exit(0);
                }
                Console.SetCursorPosition(x, y);
                Console.Write("  ");
                switch (input)
                {
                    case 'w':
                    case 'W':
                        --y;
                        if (y < 0)
                        {
                            y = 0;
                        }
                        break;
                    case 's':
                    case 'S':
                        ++y;
                        if (y > Console.BufferHeight - 1)
                        {
                            y = Console.BufferHeight - 1;
                        }
                        break;
                    case 'a':
                    case 'A':
                        x -= 2;
                        if (x < 0)
                        {
                            x = 0;
                        }
                        break;
                    case 'd':
                    case 'D':
                        x += 2;
                        if (x > Console.BufferWidth - 2)
                        {
                            x = Console.BufferWidth - 2;
                        }
                        break;
                }
            }


            #endregion
        }
    }
}
