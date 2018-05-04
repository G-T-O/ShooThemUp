using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using WindowsFormsApp1;

namespace ShootThemUp
{

    public class Bullet
    {
    private Image bulletUp = Image.FromFile("C:/Users/axetel/source/repos/ShootThemUp/ShootThemUp/Images/bulletUp.png");
    private Image bulletDown = Image.FromFile("C:/Users/axetel/source/repos/ShootThemUp/ShootThemUp/Images/bulletDown.png");
    private Image bulletRight = Image.FromFile("C:/Users/axetel/source/repos/ShootThemUp/ShootThemUp/Images/bulletRight.png");
    private Image bulletLeft = Image.FromFile("C:/Users/axetel/source/repos/ShootThemUp/ShootThemUp/Images/bulletLeft.png");
    private int damage, bulletDelay, id;
    private Boolean isAlive = false;
    private String bulletDir;
    private float x, y;
    private Image bulletNow;

    public int Id { get => id; set => id = value; }
    public float X { get => x; set => x = value; }
    public float Y { get => y; set => y = value; }
    protected int Damage { get => damage; set => damage = value; }
    public Image BulletNow { get => bulletNow; set => bulletNow = value; }
    public int BulletDelay { get => bulletDelay; set => bulletDelay = value; }
    public bool IsAlive { get => isAlive; set => isAlive = value; }
    public string BulletDir { get => bulletDir; set => bulletDir = value; }
       
        public Bullet(int damage, int id, float x, float y,Player player)//Construct
        {
            this.Damage = damage;
            this.Id = id;
            this.X = x;
            this.Y = y;

            if(player.CharacNow == player.CharacRight)
            {
                this.BulletNow = bulletRight;
            }else if(player.CharacNow == player.CharacLeft)
            {
                this.BulletNow = bulletLeft;
            }else if(player.CharacNow == player.CharacUp)
            {
                this.BulletNow = bulletUp;
            }else if(player.CharacNow == player.CharacDown)
            {
                this.BulletNow = bulletDown;
            }
            this.bulletDelay = 10;
            isAlive = true;
            /*this.thread = new Thread(new ThreadStart(new Sound().soundShoot));
            this.thread.Start();*/
            
        }

        private void bulletSound()
        {
            //TO DO 
        }
        public List<Bullet> remove(List<Bullet> bullets)
        {
            for (int i = 0; i < bullets.Count; i++)
            {
                if (bullets[i].IsAlive == false)
                {
                    bullets.RemoveAt(i);
                }
            }
            return bullets;
        }

        public void move(List<Bullet> bullets)
        {
            try
            {
                foreach (var bullet in bullets)
                {
                    switch (bullet.BulletDir)
                    {
                        case ("Up"):
                            bullet.X = bullet.X + 0;
                            bullet.Y = bullet.Y - 20;
                            break;
                        case ("Down"):
                            bullet.X = bullet.X + 0;
                            bullet.Y = bullet.Y + 20;
                            break;
                        case ("Right"):
                            bullet.X = bullet.X + 20;
                            bullet.Y = bullet.Y + 0;
                            break;
                        case ("Left"):
                            bullet.X = bullet.X - 20;
                            bullet.Y = bullet.Y + 0;
                            break;
                    }
                    Board.outOfScreen(bullet);
                }
            }
            catch (NullReferenceException)
            {
            }
        }
    }

}