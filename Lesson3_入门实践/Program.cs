using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson3_入门实践
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region 1 控制台基础设置
            int windowsWidth = 100;
            int windowsHeight = 30;
            //隐藏光标
            Console.CursorVisible = false;
            //设置窗口
            Console.SetWindowSize(windowsWidth, windowsHeight);
            Console.SetBufferSize(windowsWidth, windowsHeight);
            Console.Clear();
            #endregion

            #region 2 多个场景
            int currentSceneId = 1;
            char inputKey;
            int gameState = 0;
            while (true)
            {

                switch (currentSceneId)
                {
                    //开始场景
                    case 1:
                        Console.Clear();
                        #region 开始场景
                        Console.SetCursorPosition(windowsWidth / 2 - 4, windowsHeight / 2 - 7);
                        Console.WriteLine("营救公主");

                        int currentSelectId = 0;
                        while (true)
                        {

                            bool isQuitWhile = false;
                            Console.ForegroundColor = currentSelectId == 0 ? ConsoleColor.Red : ConsoleColor.White;
                            Console.SetCursorPosition(windowsWidth / 2 - 4, windowsHeight / 2 + 4);
                            Console.WriteLine("开始游戏");
                            Console.ForegroundColor = currentSelectId == 1 ? ConsoleColor.Red : ConsoleColor.White;
                            Console.SetCursorPosition(windowsWidth / 2 - 4, windowsHeight / 2 + 8);
                            Console.WriteLine("退出游戏");

                            inputKey = Console.ReadKey(true).KeyChar;
                            switch (inputKey)
                            {
                                case 'w':
                                case 'W':
                                    --currentSelectId;
                                    if (currentSelectId < 0)
                                    {
                                        currentSelectId = 0;
                                    }
                                    break;
                                case 's':
                                case 'S':
                                    ++currentSelectId;
                                    if (currentSelectId > 1)
                                    {
                                        currentSelectId = 1;
                                    }
                                    break;
                                case 'j':
                                case 'J':
                                    if (currentSelectId == 0)
                                    {
                                        currentSceneId = 2;
                                        isQuitWhile = true;
                                    }
                                    else
                                    {
                                        Environment.Exit(0);
                                    }
                                    break;
                            }
                            if (isQuitWhile == true)
                            {
                                break;
                            }
                        }
                        #endregion
                        break;
                    //游戏场景
                    case 2:
                        Console.Clear();
                        #region 不变的红墙
                        Console.ForegroundColor = ConsoleColor.Red;
                        for (int i = 0; i <= windowsWidth - 2; i += 2)
                        {
                            //上方的墙
                            Console.SetCursorPosition(i, 0);
                            Console.Write("■");
                            //下方的墙
                            Console.SetCursorPosition(i, windowsHeight - 2);
                            Console.Write("■");
                            //中间的墙
                            Console.SetCursorPosition(i, windowsHeight - 6);
                            Console.Write("■");
                        }
                        for (int i = 0; i < windowsHeight - 1; ++i)
                        {
                            //左边的墙
                            Console.SetCursorPosition(0, i);
                            Console.Write("■");
                            //右边的墙
                            Console.SetCursorPosition(windowsWidth - 2, i);
                            Console.Write("■");
                        }

                        #endregion

                        #region Boss属性相关
                        int bossHp = 20;
                        int bossDef = 2;
                        int bossAtkMin = 7;
                        int bossAtkMax = 13;
                        int bossAtk = 0;
                        int bossPosX, bossPosY;
                        Random random = new Random();
                        bossPosX = random.Next(1, (windowsWidth - 2) / 2) * 2;
                        bossPosY = random.Next(windowsHeight / 2, windowsHeight - 8);
                        string bossIcon = "■";
                        ConsoleColor bossColor = ConsoleColor.Green;
                        Console.ForegroundColor = bossColor;
                        #endregion

                        #region 玩家属性相关
                        int playerPosX = 2, playerPosY = 1;
                        int playerHp = 20;
                        int playerDef = 9;
                        int playerAtkMin = 8;
                        int playerAtkMax = 12;
                        int playerAtk = 0;
                        string playerIcon = "●";
                        ConsoleColor playerColor = ConsoleColor.White;
                        #endregion

                        #region 公主属性相关
                        int princessPosX = random.Next(windowsWidth / 4, (windowsWidth - 2) / 2) * 2;
                        int PrincessPosY = random.Next(1, windowsHeight / 2 - 3);
                        string princessIcon = "★";
                        ConsoleColor princessColor = ConsoleColor.Yellow;
                        #endregion

                        #region 玩家战斗相关
                        bool isFight = false;
                        bool isGameOver = false;
                        #endregion

                        while (true)
                        {
                            if (bossHp > 0)
                            {
                                Console.SetCursorPosition(bossPosX, bossPosY);
                                Console.ForegroundColor = bossColor;
                                Console.Write(bossIcon);
                            }
                            else
                            {
                                Console.SetCursorPosition(princessPosX, PrincessPosY);
                                Console.ForegroundColor = princessColor;
                                Console.Write(princessIcon);
                            }

                            //画出玩家
                            Console.SetCursorPosition(playerPosX, playerPosY);
                            Console.ForegroundColor = playerColor;
                            Console.Write(playerIcon);
                            //输入
                            inputKey = Console.ReadKey(true).KeyChar;

                            if (isFight)
                            {
                                #region 攻击逻辑
                                if (inputKey == 'j' || inputKey == 'J')
                                {
                                    if (playerHp <= 0)
                                    {
                                        currentSceneId = 3;
                                        gameState = 1;
                                        break;
                                    }
                                    else
                                    {
                                        bossAtk = random.Next(bossAtkMin, bossAtkMax);
                                        playerAtk = random.Next(playerAtkMin, playerAtkMax);
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        if (playerAtk - bossDef > 0)
                                        {
                                            bossHp = bossHp - (playerAtk - bossDef);
                                            Console.SetCursorPosition(2, windowsHeight - 4);
                                            for (int i = 2; i < windowsWidth - 2; ++i)
                                            {
                                                Console.Write(" ");
                                            }
                                            Console.SetCursorPosition(2, windowsHeight - 4);
                                            Console.Write("你对Boss造成了{0}点伤害，Boss当前剩余血量为：{1}", playerAtk - bossDef, bossHp);

                                        }
                                        else
                                        {
                                            Console.SetCursorPosition(2, windowsHeight - 4);
                                            for (int i = 2; i < windowsWidth - 2; ++i)
                                            {
                                                Console.Write(" ");
                                            }
                                            Console.SetCursorPosition(2, windowsHeight - 4);
                                            Console.Write("你对Boss造成了0点伤害，Boss当前剩余血量为：{0}", bossHp);

                                        }
                                        if (bossHp > 0)
                                        {
                                            if (bossAtk - playerDef > 0)
                                            {
                                                playerHp = playerHp - (bossAtk - playerDef);
                                                Console.SetCursorPosition(2, windowsHeight - 3);
                                                for (int i = 2; i < windowsWidth - 2; ++i)
                                                {
                                                    Console.Write(" ");
                                                }
                                                Console.SetCursorPosition(2, windowsHeight - 3);
                                                if (playerHp > 0)
                                                {
                                                    Console.Write("Boss对你造成了{0}点伤害，你当前剩余血量为：{1}", bossAtk - playerDef, playerHp);
                                                }
                                                else
                                                {
                                                    Console.Write("Boss对你造成了{0}点伤害，你当前剩余血量为：0", bossAtk - playerDef, playerHp);
                                                }
                                            }
                                            else
                                            {
                                                Console.SetCursorPosition(2, windowsHeight - 3);
                                                for (int i = 2; i < windowsWidth - 2; ++i)
                                                {
                                                    Console.Write(" ");
                                                }
                                                Console.SetCursorPosition(2, windowsHeight - 3);
                                                Console.Write("Boss对你造成了0点伤害，你当前剩余血量为：{0}", playerHp);
                                            }
                                        }
                                        else
                                        {
                                            Console.SetCursorPosition(2, windowsHeight - 5);
                                            for (int i = 2; i < windowsWidth - 2; ++i)
                                            {
                                                Console.Write(" ");
                                            }
                                            Console.SetCursorPosition(2, windowsHeight - 5);
                                            Console.Write("你对Boss造成了{0}点伤害，Boss当前剩余血量为：0", playerAtk - bossDef);
                                            Console.SetCursorPosition(2, windowsHeight - 4);
                                            for (int i = 2; i < windowsWidth - 2; ++i)
                                            {
                                                Console.Write(" ");
                                            }
                                            Console.SetCursorPosition(2, windowsHeight - 4);
                                            Console.Write("恭喜！战斗胜利！");
                                            Console.SetCursorPosition(2, windowsHeight - 3);
                                            for (int i = 2; i < windowsWidth - 2; ++i)
                                            {
                                                Console.Write(" ");
                                            }
                                            Console.SetCursorPosition(2, windowsHeight - 3);
                                            Console.Write("请前往星星处，按下J键营救公主！");
                                            Console.SetCursorPosition(bossPosX, bossPosY);
                                            Console.Write("    ");
                                            isFight = false;
                                        }
                                    }

                                }
                                #endregion
                            }
                            else
                            {
                                #region 玩家移动相关

                                //擦除
                                Console.SetCursorPosition(playerPosX, playerPosY);
                                Console.Write("  ");


                                switch (inputKey)
                                {
                                    case 'a':
                                    case 'A':
                                        playerPosX -= 2;
                                        if (playerPosX < 2)
                                        {
                                            playerPosX = 2;
                                        }
                                        if (playerPosX == bossPosX && playerPosY == bossPosY && bossHp > 0)
                                        {
                                            playerPosX += 2;
                                        }
                                        else if (playerPosX == princessPosX && playerPosY == PrincessPosY && bossHp <= 0)
                                        {
                                            playerPosX += 2;
                                        }

                                        break;
                                    case 'd':
                                    case 'D':
                                        playerPosX += 2;
                                        if (playerPosX > windowsWidth - 4)
                                        {
                                            playerPosX = windowsWidth - 4;
                                        }
                                        if (playerPosX == bossPosX && playerPosY == bossPosY && bossHp > 0)
                                        {
                                            playerPosX -= 2;
                                        }
                                        else if (playerPosX == princessPosX && playerPosY == PrincessPosY && bossHp <= 0)
                                        {
                                            playerPosX -= 2;
                                        }
                                        break;
                                    case 'w':
                                    case 'W':
                                        --playerPosY;
                                        if (playerPosY < 1)
                                        {
                                            playerPosY = 1;
                                        }
                                        if (playerPosX == bossPosX && playerPosY == bossPosY && bossHp > 0)
                                        {
                                            ++playerPosY;
                                        }
                                        else if (playerPosX == princessPosX && playerPosY == PrincessPosY && bossHp <= 0)
                                        {
                                            ++playerPosY;
                                        }
                                        break;
                                    case 's':
                                    case 'S':
                                        ++playerPosY;
                                        if (playerPosY > windowsHeight - 7)
                                        {
                                            playerPosY = windowsHeight - 7;
                                        }
                                        if (playerPosX == bossPosX && playerPosY == bossPosY && bossHp > 0)
                                        {
                                            --playerPosY;
                                        }
                                        else if (playerPosX == princessPosX && playerPosY == PrincessPosY && bossHp <= 0)
                                        {
                                            --playerPosY;
                                        }
                                        break;
                                    case 'j':
                                    case 'J':
                                        if ((playerPosX == bossPosX && playerPosY == bossPosY - 1 ||
                                            playerPosX == bossPosX && playerPosY == bossPosY + 1 ||
                                            playerPosY == bossPosY && playerPosX == bossPosX - 2 ||
                                            playerPosY == bossPosY && playerPosX == bossPosX + 2) &&
                                            bossHp > 0)
                                        {
                                            isFight = true;
                                            Console.SetCursorPosition(2, windowsHeight - 5);
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.Write("开始战斗，按J键继续");
                                            Console.SetCursorPosition(2, windowsHeight - 4);
                                            Console.Write("玩家当前血量{0}", playerHp);
                                            Console.SetCursorPosition(2, windowsHeight - 3);
                                            Console.Write("Boss当前血量{0}", bossHp);
                                        }
                                        else if ((playerPosX == princessPosX && playerPosY == PrincessPosY - 1 ||
                                                  playerPosX == princessPosX && playerPosY == PrincessPosY + 1 ||
                                                  playerPosY == PrincessPosY && playerPosX == princessPosX - 2 ||
                                                  playerPosY == PrincessPosY && playerPosX == princessPosX + 2) &&
                                                  bossHp <= 0)
                                        {
                                            currentSceneId = 3;
                                            isGameOver = true;
                                            gameState = 0;
                                        }
                                            break;
                                }
                                #endregion
                            }
                            if (isGameOver)
                            {
                                break;
                            }
                        }
                        break;
                    //结束场景
                    case 3:
                        Console.Clear();
                        #region 胜利场景
                        Console.SetCursorPosition(windowsWidth / 2 - 4, windowsHeight / 2 - 6);
                        if (gameState == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("Victory");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("Defeat");
                        }
                        currentSelectId = 0;
                        while (true)
                        {
                        bool isQuitWhile = false;
                            Console.SetCursorPosition(windowsWidth / 2 - 6, windowsHeight / 2 + 3);
                            Console.ForegroundColor = currentSelectId==0? ConsoleColor.Red: ConsoleColor.White;
                            Console.Write("回到开始界面");
                            Console.SetCursorPosition(windowsWidth / 2 - 5, windowsHeight / 2 + 6);
                            Console.ForegroundColor = currentSelectId == 1 ? ConsoleColor.Red : ConsoleColor.White;
                            Console.Write("退出游戏");
                            inputKey = Console.ReadKey(true).KeyChar;

                            switch(inputKey)
                            {
                                case 'w':
                                case 'W':
                                    --currentSelectId;
                                    if (currentSelectId < 0)
                                    {
                                        currentSelectId = 0;
                                    }
                                    break;
                                case 's':
                                case 'S':
                                    ++currentSelectId;
                                    if (currentSelectId > 1)
                                    {
                                        currentSelectId = 1;
                                    }
                                    break;
                                case 'j':
                                case 'J':
                                    if(currentSelectId == 0)
                                    {
                                        currentSceneId = 1;
                                        isQuitWhile = true;
                                    }
                                    else
                                    {
                                        Environment.Exit(0);
                                    }
                                    break;
                            }
                            if(isQuitWhile)
                            {
                                break;
                            }
                        }
                        #endregion
                        break;
                }
            }
            #endregion
        }
    }
}
