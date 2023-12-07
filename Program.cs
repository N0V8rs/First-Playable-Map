using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace First_Playable_Map
{
    internal class Program
    {
        //Map Int and Var
        //static string path = @"Map.txt";
        static char[] mapFloor;
        static char[,] mapText;
        static char mapWalls = ((char)248);
        static char mapGround = ((char)247);
        static int mapHeight;
        static int mapWidth;
        static string path;
        static string path1 = @"Map.text";
        //Player
        static char player = ((char)246);
        static int playerX, playerY;
        static int playerDamage;
        static int playerHP;
        static int playerHealth;
        //Enemies
        static char enemy1 = ((char)255);
        static int enemy1X, enemy1Y;
        static char enemy2 = ((char)254);
        static int enemyHP;
        static int enemy1basicHP;
        static int enemy2tankHP;


        static void Main(string[] args)
        {
            LauncherManager();
            //DisplayMap();
            Console.ReadLine();
        }
        static void LauncherManager()
        {
            //The Game Settings
            playerHP = 100;
            playerDamage = 25;
            playerHealth = playerHP;
            enemy1basicHP = 25;
            enemy2tankHP = 50;
            path = path1;
            //ReadMapFromFile(path1);
        }
        //Map Spawns
        static void DisplayMap()
        {
            Console.SetCursorPosition(0, 0);
            for (int i = 0; i < mapHeight; i++)
            {
                for (int j = 0; j < mapWidth; j++)
                {
                    char tile = mapText[i, j];
                    DrawMap(tile);
                    if (tile == '-')
                    {
                        playerX = i;
                        playerY = j;
                        mapText[i, j] = '#';
                    }
                }
                Console.WriteLine(); // Add this line to move to the next line after each row.
            }
        }


        static void ReadMapFromFile()
        {
            string[] lines = File.ReadAllLines(path);
            mapHeight = lines[0].Length;
            mapWidth = lines[1].Length;

            mapText = new char[mapHeight, mapWidth];

            for (int i = 0; i < mapHeight; i++)
            {
                for (int j = 0; j < mapWidth; j++)
                {
                    mapText[i, j] = lines[i][j];
                }
            }
        }

        static void DrawMap(Char tile)
        {
            if (tile == '-')
            {
                MakeFloor();
                return;
            }
            if (tile == '#')
            {
                MakeWall();
                return;
            }
        }

        static void PlayerXY()
        {
            Console.SetCursorPosition(playerX, playerY);
        }

        static void LegendMap()
        {
            Console.Write("Floor = #");
            MakeWall();
        }

        static void HUDMap() 
        {
            Console.WriteLine(string.Format("HP:{0} Damage{1}",playerHP,playerDamage));
        }

        static void MakeWall()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write(mapWalls);
            Console.ResetColor();
        }
        static void MakeFloor()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(mapGround);
            Console.ResetColor();
        }

        

        static void PlayerCharacter(ConsoleKeyInfo keyInfo)
        {
            //Player postison
            int newPlayerX = playerX;
            int newPlayerY = playerY;
            //Player Controls
            switch (keyInfo.Key)
            {
                case ConsoleKey.W:
                case ConsoleKey.UpArrow:
                    newPlayerY = playerY - 1;
                    break;
                case ConsoleKey.S:
                case ConsoleKey.DownArrow:
                    newPlayerY = playerY + 1;
                    break;
                case ConsoleKey.A:
                case ConsoleKey.LeftArrow:
                    newPlayerX = playerX - 1;
                    break;
                case ConsoleKey.D:
                case ConsoleKey.RightArrow:
                    newPlayerX = playerX + 1;
                    break;
                case ConsoleKey.Spacebar:
                    if (IsAdjacent(playerX, playerY, enemy1X, enemy1Y))
                    {
                        PlayerDamage();
                    }
                    break;
                
            }
        }

        //Testing Enemy AI (Might removed)
        static void MoveEnemy()
        {
            int newEnemyX = enemy1X;
            int newEnemyY = enemy1Y;

            if (playerX < enemy1X && IsWithinBounds(enemy1Y, enemy1X - 1) && mapText[enemy1Y, enemy1X - 1] == '`')
                newEnemyX = enemy1X - 1;
            else if (playerX > enemy1X && IsWithinBounds(enemy1Y, enemy1X + 1) && mapText[enemy1Y, enemy1X + 1] == '`')
                newEnemyX = enemy1X + 1;

            if (playerY < enemy1Y && IsWithinBounds(enemy1Y - 1, enemy1X) && mapText[enemy1Y - 1, enemy1X] == '`')
                newEnemyY = enemy1Y - 1;
            else if (playerY > enemy1Y && IsWithinBounds(enemy1Y + 1, enemy1X) && mapText[enemy1Y + 1, enemy1X] == '`')
                newEnemyY = enemy1Y + 1;

            if (IsWithinBounds(newEnemyY, newEnemyX) && mapText[newEnemyY, newEnemyX] == '`')
            {
                mapText[enemy1Y, enemy1X] = '`';
                enemy1X = newEnemyX;
                enemy1Y = newEnemyY;
                mapText[enemy1Y, enemy1X] = '$';
            }
        }
        //Testing player and enemy pos
        static bool IsAdjacent(int x1, int y1, int x2, int y2)
        {
            return Math.Abs(x1 - x2) == 1 && y1 == y2 || Math.Abs(y1 - y2) == 1 && x1 == x2;
        }
        //Testing borders (Might remove)
        static bool IsWithinBounds(int y, int x)
        {
            return y >= 0 && y < mapText.GetLength(0) && x >= 0 && x < mapText.GetLength(1);
        }
        static void PlayerDamage()
        {
            //Player Damage
            playerDamage = 0;
            if (playerDamage <= 0 )
            {
                playerDamage++;
            }
        }

        static void Enemies(int damage)
        {
            //Enemies Damage
            playerHealth -= damage;
            if (playerHealth <= 0 )
            {
                Console.WriteLine("You die");
            }
        }

    }
}
