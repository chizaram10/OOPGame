using OOPGame.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPGame.Equipment
{
    internal class Warrior
    {
        private const int GOOD_GUY_STARTING_HEALTH = 100;
        private const int BAD_GUY_STARTING_HEALTH = 100;

        private readonly Faction FACTION;

        private int health;
        private string name;
        private bool isAlive;

        private Weapon weapon;
        private Armor armor;

        public bool IsAlive
        {
            get
            {
                return isAlive;
            }
        }

        public Warrior(string name, Faction faction)
        {
            this.name = name;
            FACTION = faction;
            isAlive = true;

            switch (faction)
            {
                case Faction.GoodGuy:
                    weapon  = new Weapon(faction);
                    armor   = new Armor(faction);
                    health = GOOD_GUY_STARTING_HEALTH;
                    break;
                case Faction.BadGuy:
                    weapon = new Weapon(faction);
                    armor = new Armor(faction);
                    health = BAD_GUY_STARTING_HEALTH;
                    break;
                default:
                    break;
            }
        }

        public void Attack (Warrior enemy)
        {
            int damage = weapon.Damage / enemy.armor.ArmorPoints;
            enemy.health -= damage;

            if (enemy.health <= 0)
            {
                enemy.isAlive = false;
                Tools.ColorfulResult($"{name} attcked {enemy.name}. {damage} was inflicted. Remaining health is {enemy.health}.", ConsoleColor.DarkRed);
                Tools.ColorfulResult($"{enemy.name} is dead! {name} Wins!", ConsoleColor.Red);
            }
            else
            {
                if (enemy.FACTION == Faction.GoodGuy) 
                {
                    Tools.ColorfulResult($"{name} attcked {enemy.name}. {damage} was inflicted. " +
                        $"Remaining health is {enemy.health}.\n", ConsoleColor.Cyan);
                }
                else
                {
                    Tools.ColorfulResult($"{name} attcked {enemy.name}. {damage} was inflicted. " +
                        $"Remaining health is {enemy.health}.\n", ConsoleColor.DarkYellow);
                }
                
            }
            Thread.Sleep( 500 );

        }
    }
}
