using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

namespace FunGame.Game.EnemyStuff.Enemies
{
    class Goblin : Enemy
    {

        public Goblin(Vector2 location, int facingDirection, int currentZoneLevel)
        {
            this.enemyType = "Goblin";

            this.location = location;
            this.facingDirection = facingDirection;
            this.currentZoneLevel = currentZoneLevel;

            size = new Vector2(30, 50);
            walkingSize = new Vector2(30, 30);

            baseHealth = 50;
            currentHealth = baseHealth;
            intelligence = 1;

            attacks = new List<Attack>();
            attacks.Add(new Attack(2, "Light", 1));
            attacks.Add(new Attack(5, "Medium", 1));
            attacks.Add(new Attack(10, "Heavy", 1));
        }


        public override void implementAttack(int attackIndex)
        {
            if (attacks.Count > attackIndex)
            {
                Console.WriteLine("Attack Name: " + attacks[attackIndex].getAttackName());
                Console.WriteLine("Attack Damage: " + attacks[attackIndex].getDamage());
                Console.WriteLine("Int required: " + attacks[attackIndex].getRequiredIntelligence());
            }
            else
            {
                Console.WriteLine("No attack found");
            }
        }
    }
}
