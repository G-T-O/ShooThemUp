using System;
using System.Drawing;
using System.Windows.Forms;

namespace ShootThemUp
{
    /*
     * The player class who set img to the player , move, shoot,receive damage and reset the X Y of the player
     */
    public class Player : Character
    {
        private Image playerUp = Image.FromFile("C:/Users/axetel/source/repos/ShootThemUp/ShootThemUp/Images/survivorUp.png");
        private Image playerDown = Image.FromFile("C:/Users/axetel/source/repos/ShootThemUp/ShootThemUp/Images/survivorDown.png");
        private Image playerLeft = Image.FromFile("C:/Users/axetel/source/repos/ShootThemUp/ShootThemUp/Images/survivorLeft.png");
        private Image playerRight = Image.FromFile("C:/Users/axetel/source/repos/ShootThemUp/ShootThemUp/Images/survivorRight.png");
        private Random rnd = new Random();

        private Bullet bullet;
        private Boolean isShoot = false;
        private int idBullet;
         
        public int IdBullet { get => idBullet; set => idBullet = value; }
        public int LifePlayer { get => Life; set => Life = value; }
        public int DamagePlayer { get => this.Damage; set => this.Damage = value; }

        public Player(int life, int damage, float velocity, String name, int id, float x, float y)
        {
            this.Life = life;
            this.Damage = damage;
            this.Velocity = velocity;
            this.Name = name;
            this.Id = id;
            this.X = x;
            this.Y = y;
            this.CharacLeft = this.playerLeft;
            this.CharacRight = this.playerRight;
            this.CharacUp = this.playerUp;
            this.CharacDown = this.playerDown;
            this.CharacNow = this.CharacRight;
            this.CharacDir = "Right";
        }
        public override Bullet shoot()
        {
            this.IdBullet += 1;
            bullet = new Bullet(this.Damage, this.IdBullet, this.X, this.Y, this);
            bullet.IsAlive = true;
            switch (this.CharacDir)
            {
                case ("Up"):
                    bullet.BulletDir = "Up";
                    bullet.Y -= 20;
                    bullet.X += 0;
                    break;
                case ("Down"):
                    bullet.BulletDir = "Down";
                    bullet.Y += 30;
                    bullet.X += 0;
                    break;
                case ("Right"):
                    bullet.BulletDir = "Right";
                    bullet.X += 10;
                    break;
                case ("Left"):
                    bullet.BulletDir = "Left";
                    bullet.X = bullet.X;
                    break;
                default:
                    break;
            }
            return bullet;
        }

        internal Boolean action(KeyEventArgs e)//the action of the player 
        {
            isShoot = false;
            switch (e.KeyCode)
            {
                case (Keys.Z):
                    this.CharacNow = this.CharacUp;
                    move("Up");
                    break;
                case (Keys.S):
                    this.CharacNow = this.CharacDown;
                    this.move("Down");
                    break;
                case (Keys.D):
                    this.CharacNow = this.CharacRight;
                    this.move("Right");
                    break;
                case (Keys.Q):
                    this.CharacNow = this.CharacLeft;
                    this.move("Left");
                    break;
                case (Keys.R):
                    break;
                case (Keys.Space):
                    isShoot = true;
                    break;
            }
            return isShoot;
        }
        private void pauseGame()
        {

        }
        public override void move(String characDir)
        {
            this.CharacDir = characDir;
            switch (characDir)
            {
                case ("Up"):
                    this.Y -= 10 * this.Velocity;
                    break;
                case ("Down"):
                    this.Y += 10 * this.Velocity;
                    break;
                case ("Left"):
                    this.X -= 10 * this.Velocity;
                    break;
                case ("Right"):
                    this.X += 10 * this.Velocity;
                    break;
                default:
                    break;
            }
            this.CharacDir = characDir;
        }


        public override void receiveDamage(int damage)
        {
            Life -= damage;
            resetPos();
        }

        public void receiveBoardDamage(int damage)
        {
            this.Life -= damage;
        }

        private void resetPos()
        {
            Random rnd = new Random();
            this.X = 0;
            this.Y = rnd.Next(50, 400);
        }

    }
}
