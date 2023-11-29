using System;
using System.Collections.Generic;
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
        static string path;
        static char[] mapFloor;
        static char[,] mapText;
        static char mapwalls = ((char)248);
        static int mapHeight;
        static int mapWidth;
        //Player
        static int playerX, playerY;
        static int playerDamage;
        static int playerHP;
        static int playerHealth;
        //Enemies
        static int enemyHP;
        static int enemy1basicHP;
        static int enemy2tankHP;

        static string path = path1;
        static string path1 = @"Map.txt";
        static string[] MapArrays;
        static void Main(string[] args)
        {
            DisplayMap();
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

        }

        public static void DisplayMap()
        {
          Console.SetCursorPosition(0, 0);
          for (int i = 0; i < mapHeight; i++)
            {
                for (int j = 0; j < mapWidth; j++)
                {
                    char tile = mapText[i,j];
                    DrawTile
                }
            }
        }

        static void DrawMap(Char tile)
        {
            if (tile == '-')
            {

            }
        }

        static void LegendMap()
        {
            Console.Write("Floor = " )
        }

        static void HUDMap() 
        {
            Console.WriteLine(string.Format("HP:{0} Damage{1}",playerHP,playerDamage));
        }

        static void PlayerCharacter(ConsoleKeyInfo keyInfo)
        {
            int newPlayerX = playerX;
            int newPlayerY = playerY;

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
                    if (IsAdjacent(playerX, playerY, enemyX, enemyY))
                    {
                        PlayerDamage();
                    }
                    break;
                
            }
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
