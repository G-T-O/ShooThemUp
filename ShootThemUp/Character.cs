using System;
using System.Drawing;

namespace ShootThemUp
{
    public abstract class Character
    {
        private int id;
        private int life;
        private int damage;
        private String name;
        private String imgCharac,characDir;//The direction of the charac 
        private int characWidth, characHeight;
        private float x, y;
        private Image characNow, characLeft, characRight, characUp, characDown;
        private float velocity;// Is the speed of the Charac 
        private int lvl;
        private Boolean isAlive;

        protected int Id { get => id; set => id = value; }
        protected int Life { get => life; set => life = value; }
        protected int Damage { get => damage; set => damage = value; }
        protected string Name { get => name; set => name = value; }
        protected string ImgCharac { get => imgCharac; set => imgCharac = value; }
        public float Velocity { get => velocity; set => velocity = value; }
        protected int Lvl { get => lvl; set => lvl = value; }
        protected int CharacWidth { get => characWidth; set => characWidth = value; }
        protected int CharacHeight { get => characHeight; set => characHeight = value; }
        protected Boolean IsAlive { get => isAlive; set => isAlive = value; }
        public Image CharacNow { get => characNow; set => characNow = value; }
        public Image CharacLeft { get => characLeft; set => characLeft = value; }
        public Image CharacRight { get => characRight; set => characRight = value; }
        public Image CharacUp { get => characUp; set => characUp = value; }
        public Image CharacDown { get => characDown; set => characDown = value; }

        public String CharacDir { get => characDir; set => characDir = value; }
        public float X { get => x; set => x = value; }
        public float Y { get => y; set => y = value; }

        public abstract Bullet shoot(); 
        public abstract void move(String characDir);
        public abstract void receiveDamage(int damage);
       }
    }
