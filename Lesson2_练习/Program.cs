using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2_练习
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //玩家攻击力为8~12；
            //怪物防御力为10，血量为20
            //伤害计算公式：攻击力小于防御力，减血为0，否则减血攻击力和防御力的差值
            Random random = new Random();
            int playerAtk;
            int enemyDef = 10, enemyHp = 20;
            while (true)
            {
                playerAtk = random.Next(8, 13);
                Console.WriteLine("玩家攻击力为{0}", playerAtk);
                if (playerAtk > enemyDef)
                {
                    enemyHp -= playerAtk - enemyDef;
                    if (enemyHp <= 0)
                    {
                        Console.WriteLine("敌人当前血量为0");
                        Console.WriteLine("敌人已死亡");
                        break;
                    }
                    Console.WriteLine("对敌人造成{1}点伤害,敌人当前血量为{0}",enemyHp, playerAtk - enemyDef);
                }
                else
                {
                    Console.WriteLine("敌人未受伤");
                }

            }

            Console.ReadLine();
        }
    }
}
