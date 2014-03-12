using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

namespace FunGame.Game.EnemyStuff
{
    abstract class Enemy
    {

        public readonly int UP = 0;
        public readonly int DOWN = 1;
        public readonly int RIGHT = 2;
        public readonly int LEFT = 3;

        protected string enemyType;

        protected int baseHealth;
        protected int currentHealth;
        protected int currentZoneLevel;
        protected Vector2 size;
        protected Vector2 walkingSize;
        protected List<Attack> attacks; // maybe add defensive moves as well

        protected Vector2 location;
        protected int facingDirection;

        protected int intelligence;

        public abstract void implementAttack(int attackIndex);

        public string getEnemyType()
        {
            return enemyType;
        }

        public Vector2 getSize()
        {
            return size;
        }

        public Vector2 getWalkingSize()
        {
            return walkingSize;
        }

        public int getCurrentHealth()
        {
            return currentHealth;
        }

        public void changeHealth(int change)
        {
            if (currentHealth + change >= baseHealth)
            {
                currentHealth = baseHealth;
            }
            else if (currentHealth + change <= 0)
            {
                currentHealth = 0;
            }
            else
            {
                currentHealth += change;
            }
        }

        public int getCurrentZoneLevel()
        {
            return currentZoneLevel;
        }

        public void upOneLevel()
        {
            currentZoneLevel++;
        }

        public void downOneLevel()
        {
            currentZoneLevel--;
        }

        public List<Attack> getAttacks()
        {
            return attacks;
        }

        public int getIntelligence()
        {
            return intelligence;
        }

        public void setIntelligence(int intelligence)
        {
            this.intelligence = intelligence;
        }

        public Vector2 getLocation()
        {
            return location;
        }

        public void setLocation(Vector2 location)
        {
            this.location = location;
        }

        public void move(int direction, int distance)
        {
            if (direction == UP)
            {
                location.Y -= distance;
            }
            else if (direction == DOWN)
            {
                location.Y += distance;
            }
            else if (direction == RIGHT)
            {
                location.X += distance;
            }
            else if (direction == LEFT)
            {
                location.X -= distance;
            }
        }

        public int getFacingDirection()
        {
            return facingDirection;
        }

        public void setFacingDirection(int direction)
        {
            facingDirection = direction;
        }

        public int getAttackIndexByName(string attackName)
        {
            int index = -1;

            for (int i = 0; i < attacks.Count; i++)
            {
                if (attacks[i].getAttackName() == attackName)
                {
                    index = i;
                    return index;
                }
            }
            return index;
        }

        public int getHighestDamageAttackIndex()
        {
            int index = -1;
            int highestAttack = 0;

            for (int i = 0; i < attacks.Count; i++)
            {
                if (attacks[i].getDamage() > highestAttack)
                {
                    highestAttack = attacks[i].getDamage();
                    index = i;
                }
            }

            return index;
        }

        public int getLowestDamageAttackIndex()
        {
            int index = -1;
            int lowestAttack = int.MaxValue;

            for (int i = 0; i < attacks.Count; i++)
            {
                if (attacks[i].getDamage() < lowestAttack)
                {
                    lowestAttack = attacks[i].getDamage();
                    index = i;
                }
            }

            return index;
        }

        public struct Attack //could insert the attack animation images in here as well, might need to change this to a class?
        {
            private int damage;
            private string attackName;
            private int intelligenceRequired;

            public Attack(int damage, string attackName, int intelligenceRequired)
            {
                this.damage = damage;
                this.attackName = attackName;
                this.intelligenceRequired = intelligenceRequired;
            }

            public int getDamage()
            {
                return damage;
            }

            public string getAttackName()
            {
                return attackName;
            }

            public int getRequiredIntelligence()
            {
                return intelligenceRequired;
            }
        }
    }
}
