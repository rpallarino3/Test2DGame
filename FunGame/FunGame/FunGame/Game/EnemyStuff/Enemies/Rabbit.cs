using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

namespace FunGame.Game.EnemyStuff.Enemies
{
    class Rabbit : Enemy
    {


        public Rabbit(Vector2 location, int facingDirection, int currentZoneLevel)
        {
            this.enemyType = "Rabbit";

            this.location = location;
            this.facingDirection = facingDirection;
            this.currentZoneLevel = currentZoneLevel;

            size = new Vector2(10, 10);
            walkingSize = new Vector2(10, 10);

            baseHealth = 1;
            currentHealth = baseHealth;
            intelligence = 0;

            attacks = new List<Attack>();
            attacks.Add(new Attack(1, "Light", 0));
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
