using System;
using System.Collections.Generic;
using System.Drawing;

namespace ShootThemUp
{
    /*
     * The monster class set img to monster,move monste,shoot(when boss will be implemented),receive damage 
     */
    class Monsters : Character
    {
        Bullet bullet;//not using yet 
        private Image monsterUp = Image.FromFile("C:/Users/axetel/source/repos/ShootThemUp/ShootThemUp/Images/bossUp.png");
        private Image monsterDown = Image.FromFile("C:/Users/axetel/source/repos/ShootThemUp/ShootThemUp/Images/bossDown.png");
        private Image monsterLeft = Image.FromFile("C:/Users/axetel/source/repos/ShootThemUp/ShootThemUp/Images/bossRight.png");
        private Image monsterRight = Image.FromFile("C:/Users/axetel/source/repos/ShootThemUp/ShootThemUp/Images/bossLeft.png");

        public bool IsAliveMonster { get => IsAlive; set => IsAlive = value; }
        public int DammageMonster { get => Damage; set => Damage = value; }


        public Monsters(int life, int damage, float velocity, String name, int id,float x, float y)
        {
            this.Life = life;
            this.Damage = damage;
            this.Velocity = velocity;
            this.Name = name;
            this.Id = id;
            this.CharacDown = this.monsterDown;
            this.CharacUp = this.monsterUp;
            this.CharacLeft = this.monsterLeft;
            this.CharacRight = this.monsterRight;
            this.X = x;
            this.Y = y;
        }
        public Monsters()
        {
        }

        public List<Monsters> remove (List<Monsters>monsters)//kill the monster
        {
            for (int i = 0; i < monsters.Count; i++)
            {
                if (monsters[i].IsAlive == false)
                {
                    monsters.RemoveAt(i);
                }
            }
            return monsters;
        }
        public override Bullet shoot(){//TO DO when create other type of monster
            return bullet;
        }

        public override void move(String monsterDir)//TO DO add algo to follow player ? 
        {
            /*for now we only have left move for the monster 
             */
            this.X -= 10 * this.Velocity;
        }

        public  override void receiveDamage(int damage){
            this.Life -= damage;
            if (this.Life <= 0)
            {
                this.IsAlive = false;
                Board.MonsterKill++;
            }
        }
    }
}
