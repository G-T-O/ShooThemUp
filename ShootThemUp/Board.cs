using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
/*
 * Static class who check the move of entity inside the board
 * And update the label of the board
 */
namespace ShootThemUp
{
    static class Board
    {
        static private int height, width, monsterKill, monsterEscape, lvl=1;
        static private bool hasWin = false;

        public static int Height { get => height; set => height = value; }
        public static int Width { get => width; set => width = value; }
        public static int MonsterKill { get => monsterKill; set => monsterKill = value; }
        public static int MonsterEscape { get => monsterEscape; set => monsterEscape = value; }
        public static int Lvl { get => lvl; set => lvl = value; }

        static public bool detectCollision(float object1X, float object1Y, int object1Width, int object1Height, float object2X, float object2Y, int object2Width, int object2Height)
        {
            {
                if (object1X + object1Width <= object2X || object1X >= object2X + object2Width ||
                    object1Y + object1Height <= object2Y || object1Y >= object2Y + object2Height)
                {
                    return false;//No collision
                }
                else
                {
                    return true; //Collision
                }
            }
        }
        static public void outOfScreen(Bullet bullet)//Bullet is out of the screen 
        {
            if (bullet.X >= width || bullet.X <= (width - width - 20) || bullet.Y >= height || bullet.Y <= (height - height - 20))
            {
                bullet.IsAlive = false;
            }
        }

        static public void outOfScreen(Player player)//Player is out of screen 
        {
           //TO DO check before move player  
        }

        static public void outOfScreen(Monsters monster, Player player)//Monster out of screen 
        {
            if (monster.X <= (width - width - 20))//if monster pass the left screen 
            {
                player.receiveBoardDamage(monster.DammageMonster);
                monster.IsAliveMonster = false;
                monsterEscape++;
            }
        }

        static public void setLabelLife(Label label1, Player player)//Show the life of the player 
        {
            
            label1.Text=(player.LifePlayer/10).ToString();

        }
        static public void setLabelKill(Label label3)//show the kill of the player 
        {
            label3.Text = monsterKill.ToString();
        }
        static public bool hasLost(Player player)
        {
            if (player.LifePlayer / 10 <= 0)
            {
                MessageBox.Show("Game Over");
                return true;
            }
            return false;
        }

        static public bool m_hasWin(Player player,List<Monsters> monsters)
        {
            hasWin = !monsters.Any();
            return hasWin;
        }

    }
}
