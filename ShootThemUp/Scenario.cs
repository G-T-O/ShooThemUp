

using System.Collections.Generic;

namespace ShootThemUp
{
    class Scenario
    {
        private Monsters monster;
        private float x=800,y=200;

        public List<Monsters> createMonster(int lvl,List<Monsters>monsters)
        {
            switch (lvl)
            {
                case 1:
                    monsters.Add(monster = new Monsters(50, 10, 0.2F, "Monstre", 1, x, y));
                    monster.CharacNow = monster.CharacRight;
                    monster.IsAliveMonster = true;

                    monsters.Add(monster = new Monsters(50, 10, 0.2F, "Monstre2", 1, x+10, y+30));
                    monster.CharacNow = monster.CharacRight;
                    monster.IsAliveMonster = true;
                    break;
                case 2:
                    monsters.Add(monster = new Monsters(60, 10, 0.2F, "Monstre", 1, x, y));
                    monster.CharacNow = monster.CharacRight;
                    monster.IsAliveMonster = true;

                    monsters.Add(monster = new Monsters(60, 10, 0.2F, "Monstre", 1, x+60, y));
                    monster.CharacNow = monster.CharacRight;
                    monster.IsAliveMonster = true;
                    break;
                case 3:
                    for(int i = 0; i < 10; i++)
                    {
                        monsters.Add(monster = new Monsters(50, 10, 0.8F, "Monstre", 1, x, y));
                        monster.CharacNow = monster.CharacRight;
                        monster.IsAliveMonster = true;
                        x += 20;
                        y += 20;
                    }
                    break;
                case 4:
                    break;
                case 5:
                    break;
            }
            return monsters;
        }

    }
}
