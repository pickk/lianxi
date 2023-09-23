// See https://aka.ms/new-console-template for more information
using System.Runtime.InteropServices;

Console.WriteLine("Hello, World!");
int nowScence=1;
int w = 50, h = 30;
Console.SetWindowSize(w, h);
Console.SetBufferSize(w,h);
char? playerInput = null;
bool FlagAck = true;
while (true)
{
    int playerX = 4;
    int playerY = 5;
    switch (nowScence)
    {
        case 1:
            Console.Clear();
            Console.SetCursorPosition(w / 2 - 7, 8);
            Console.WriteLine("啊实打实大苏打");
            int nowSelIndex = 0;
            bool IfQuit = false;
            while (!IfQuit)
            {

                Console.SetCursorPosition(w / 2 - 4, 13);
                if (nowSelIndex == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.WriteLine("开始模拟");
                Console.SetCursorPosition(w / 2 - 4, 15);
                Console.ForegroundColor = nowSelIndex == 1 ? ConsoleColor.Red : ConsoleColor.White;
                Console.WriteLine("退出模拟");
                char input = Console.ReadKey(true).KeyChar;
                switch (input)
                {
                    case 'W':
                    case 'w':
                        nowSelIndex = 0;
                        break;
                    case 'S':
                    case 's':
                        nowSelIndex = 1;
                        break;
                    case 'J':
                    case 'j':
                        if (nowSelIndex == 0)
                        {
                            nowScence = 2;
                            IfQuit = true;
                            break;
                        }
                        else
                        {
                            Environment.Exit(0);
                        }
                        break;
                }
            }

            break;
        case 2:
            Console.Clear();
            Console.ForegroundColor= ConsoleColor.Red;
            for(int i=0;i<w;i+=2)
            {
                Console.SetCursorPosition(i, 0);
                Console.WriteLine("■");
            }
            for(int ib = 0; ib < w; ib += 2)
            {
                Console.SetCursorPosition(ib, h-2);
                Console.WriteLine("■");
            }
            for (int ib = 0; ib < h-2; ib ++)
            {
                Console.SetCursorPosition(0, ib);
                Console.WriteLine("■");
            }
            for (int ib = 0; ib < h - 2; ib++)
            {
                Console.SetCursorPosition(w-2, ib);
                Console.WriteLine("■");
            }

            #region BOSS
            int bossX = 34;
            int bossY = 15;
            int bossAtkMin = 7;
            int bossAtkMax = 13;
            int bossHp = 100;
            string bossIcon = "■";   
            ConsoleColor bossColor= ConsoleColor.Green;
            #endregion
            while (nowScence==2)
            {
                if (bossHp > 0)
                {
                    Console.SetCursorPosition(bossX, bossY);
                    Console.ForegroundColor = bossColor;
                    Console.WriteLine(bossIcon);
                }
                #region 玩家属性

                int playerAtkMin = 7;
                int playerAtkMax = 13;
                int playerHp = 100;
                string playerIcon = "2";
                ConsoleColor playerColor = ConsoleColor.White;
                #endregion
                if (playerHp > 0)
                {
                    Console.ForegroundColor = playerColor;
                    Console.SetCursorPosition(playerX, playerY);
                    Console.Write(playerIcon);
                }
                bool IsFight = false;
                playerInput = Console.ReadKey(true).KeyChar;
                if ((playerX == bossX  && playerY == bossY - 1) || (playerY == bossY && playerX == bossX + 1) || (playerX == bossX && playerY == bossY + 1) || (playerY == bossY  && playerX == bossX - 1))
                {
                    IsFight = true;
                }
                if (IsFight == false)
                {
                    Console.SetCursorPosition(playerX, playerY);
                    Console.Write("  ");
                    switch (playerInput)
                    {
                        case 'W':
                        case 'w':
                            --playerY;
                            if (playerY < 2)
                            {
                                playerY = 2;
                            }
                            else if (playerY == bossY && playerX == bossX && (bossHp > 0))
                            {
                                ++playerY;
                            }
                            break;
                        case 'a':
                        case 'A':
                            --playerX;
                            if (playerX < 2)
                            {
                                playerX = 2;
                            }
                            else if (playerY == bossY && playerX == bossX && (bossHp > 0))
                            {
                                ++playerX;
                            }
                            break;
                        case 'S':
                        case 's':
                            ++playerY;
                            if (playerY > h - 4)
                            {
                                playerY--;
                            }
                            else if (playerY == bossY && playerX == bossX && (bossHp > 0))
                            {
                                playerY--;
                            }
                            break;
                        case 'D':
                        case 'd':
                            ++playerX;
                            if (playerX > w - 4)
                            {
                                playerX--;
                            }
                            else if (playerY == bossY && playerX == bossX && (bossHp > 0))
                            {
                                playerX--;
                            }
                            break;
                    }
                }
                else
                {
                    if (playerHp > 0 && bossHp > 0)
                    {
                        Console.SetCursorPosition(2, 25);
                        Console.Write("press k to attack");
                    }
                    else
                    {
                        IsFight = false;
                    }
                    if (playerInput == 'K' || playerInput == 'k')
                    {
                        Console.SetCursorPosition(2, 25);
                        Console.Write("                               ");
                        Console.SetCursorPosition(2, 25);
                        Console.Write("press c to continue");
                        playerInput = Console.ReadKey(true).KeyChar;
                        while (FlagAck)
                        {
                            if (playerInput == 'C' || playerInput == 'c')
                            {
                                 
                                if (playerHp > 0&& bossHp > 0)
                                {
                                        Console.SetCursorPosition(2, 25);
                                        Console.Write("                                     ");
                                        Console.SetCursorPosition(2, 25);
                                        bossHp -= playerAtkMax;
                                    if (bossHp < 0)
                                        Console.Write("bossHP:{0},press c", 0);
                                    else
                                        Console.Write("bossHP:{0},press c", bossHp);
                                    playerInput = Console.ReadKey(true).KeyChar;
                                }
                                else
                                {
                                    if ( playerHp <=0)
                                    { 
                                        Console.SetCursorPosition(2, 25);
                                        Console.Write("                                     ");
                                        Console.SetCursorPosition(2, 25);
                                        Console.Write("DEAD,Press c");
                                        playerInput = Console.ReadKey(true).KeyChar;
                                        FlagAck = false;
                                        nowScence = 3;
                                        break;
                                    }
                                }
                                if (bossHp > 0&& playerHp > 0)
                                {
                                    {
                                        Console.SetCursorPosition(2, 25);
                                        Console.Write("                                     ");
                                        Console.SetCursorPosition(2, 25);
                                        playerHp-= bossAtkMax;
                                        if (playerHp > 0)
                                            Console.Write("playerHP:{0},press c", playerHp);
                                        else
                                            Console.Write("playerHP:0,press c");
                                        playerInput = Console.ReadKey(true).KeyChar;
                                    }
                                }
                                else
                                {   if(playerHp >= 0) 
                                    {
                                        Console.SetCursorPosition(2, 25);
                                        Console.Write("                                     ");
                                        Console.SetCursorPosition(2, 25);
                                        Console.Write("WIN,press c");
                                        playerInput = Console.ReadKey(true).KeyChar;
                                        FlagAck = false;
                                        Console.SetCursorPosition(bossX, bossY);
                                        Console.Write("  ");
                                        nowScence = 3;
                                        break;
                                    }
                                }
                            }
                            else
                                playerInput = Console.ReadKey(true).KeyChar;
                        }
                    }
                }
            }
            break;
                
        case 3:
            Console.Clear();
            break;
        default:
            break;
    }
}