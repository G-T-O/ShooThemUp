using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using WindowsFormsApp1;

namespace ShootThemUp
{
    public partial class Form1 : Form
    {
        private Random randomNum = new Random();
        private Boolean isShoot = false,hasLost=false,hasWin=false;
        private float playerX = 0, playerY = 100;
        private Player player;
        private List<Monsters> monsters;
        private Monsters monster;
        private Sound sound;
        private Bullet bullet;
        private List<Bullet> bullets = new List<Bullet>();
        private Scenario scenario;
        private int spam = 5;

        public Form1()
        {
            InitializeComponent();
            create();
            Board.Height = Height;
            Board.Width = Width;
        }

        private void Form1_Load(object sender, EventArgs e)
        { }


        private void create()
        {
            scenario = new Scenario();
            sound = new Sound();
            monster = new Monsters();
            monsters = new List<Monsters>();
            player = new Player(30, 10, 1, "enzo", 1, playerX, playerY);
            sound.backGroundSound();
            player.CharacNow = player.CharacRight;
            monsters = scenario.createMonster(Board.Lvl,monsters);
        }

        private void nextLvl()
        {
            player = new Player(30, 10, 1, "enzo", 1, playerX, playerY);
            player.CharacNow = player.CharacRight;
            monsters = scenario.createMonster(Board.Lvl, monsters);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (spam>0)
            {
                spam--;
            }
            Graphics paper = e.Graphics; //Sets up graphics object
            Pen blackPen = new Pen(Color.Black);
            paper.DrawImage(player.CharacNow, player.X, player.Y, player.CharacNow.Width, player.CharacNow.Height);
            try
            {
                foreach (var monster in monsters)
                {//Draw all the monster
                    paper.DrawImage(monster.CharacNow, monster.X, monster.Y, monster.CharacNow.Width, monster.CharacNow.Height);
                }
            }
            catch (System.NullReferenceException)
            {/*ignore*/}
            try
            {
                if (bullet.IsAlive)
                {
                    foreach (var bullet in bullets)
                    {//Draw all the bullet 
                        paper.DrawImage(bullet.BulletNow, bullet.X, bullet.Y, bullet.BulletNow.Width, bullet.BulletNow.Height);
                    }
                }
            }
            catch (System.NullReferenceException)
            { /*ignore */}
        }
        
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            isShoot = player.action(e);//Controls what happens when pressing certain keys
            if (isShoot && spam<=0)
            {
                spam = 10;//prevent player from spamming bullet with space 
                bullet = player.shoot();
                bullets.Add(bullet);//Add bullet to list of bullet 
            }
        }

        private void monstersMove()
        {
            try
            {
                foreach (var monster in monsters)
                {
                    monster.move("Left");
                    Board.outOfScreen(monster,player);//check if the monster is out of the screen 
                }
            }
            catch (NullReferenceException)
            {/*Ignore*/}
        }
    
        public void checkCollisions()
        {
            try
            {
                foreach (var monster in monsters)//when monster hit player
                {
                    bool collisionMonster = Board.detectCollision(player.X, player.Y, player.CharacNow.Width, player.CharacNow.Height, monster.X, monster.Y, monster.CharacNow.Width, monster.CharacNow.Height);
                    if (collisionMonster)//player is touch by monster 
                    {
                        player.receiveDamage(monster.DammageMonster);
                    }
                }
            }
            catch (NullReferenceException)
            {/*Ignore*/ }

            try
            {
                if (bullet.IsAlive)
                {
                    foreach (var bullet in bullets)
                    {
                        foreach (var monster in monsters)//Check all collision for every bullet and monster 
                        {
                            bool collisionBullet = Board.detectCollision(bullet.X, bullet.Y, bullet.BulletNow.Width, bullet.BulletNow.Height, monster.X, monster.Y, monster.CharacNow.Width, monster.CharacNow.Height);
                             if (collisionBullet)
                            {
                                monster.receiveDamage(player.DamagePlayer);
                                bullet.IsAlive = false;
                            }
                        }
                    }
                }
            }
            catch (System.NullReferenceException)
            {/*Ignore*/}
        }

        public void cleanEntity()
        {
            try
            {
                bullets = bullet.remove(bullets);
            }
            catch (System.NullReferenceException)
            {/*Ignore*/}
            try
            {
                monsters = monster.remove(monsters);
            }
            catch {/*Ignore*/}
        }

        public Boolean updateWorld()
        {
            Board.setLabelLife(label1, player);
            Board.setLabelKill(label3);
            monstersMove();
            cleanEntity();
            try
            {
                bullet.move(bullets);
            }
            catch (NullReferenceException)
            {/*Ignore*/}
            checkCollisions();
            cleanEntity();
            hasLost= Board.hasLost(player);
            hasWin = Board.m_hasWin(player, monsters);

            if (hasWin)//if player win 
            {
                MessageBox.Show("Vous avez gagné le niveau" + Board.Lvl.ToString());
                Board.Lvl++;
                nextLvl();
            }
            return hasLost;
        }
    }
}