using OOPGame.Enum;
using OOPGame.Equipment;

namespace OOPGame
{
    internal class Program
    {
        static Random rng = new Random();
        static void Main(string[] args)
        {
            Warrior goodGuy = new Warrior("Emma", Faction.GoodGuy);
            Warrior badGuy = new Warrior("Shogo", Faction.BadGuy);

            while (goodGuy.IsAlive && badGuy.IsAlive)
            {
                if (rng.Next(1, 10) <= 5)
                {
                    goodGuy.Attack(badGuy);
                }
                else
                {
                    badGuy.Attack(goodGuy);
                }
            }
        }
    }
}