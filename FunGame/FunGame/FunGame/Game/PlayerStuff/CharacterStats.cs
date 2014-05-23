using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FunGame.Game.PlayerStuff
{
    class CharacterStats
    {

        private readonly int FIRE = 0;
        private readonly int WATER = 1;
        private readonly int NATURE = 2;

        private readonly int capHealth = 9999;
        private readonly int capEnergy = 9999;

        private int fireEnergy;
        private int natureEnergy;
        private int waterEnergy;

        private int currentFireEnergy;
        private int currentNatureEnergy;
        private int currentWaterEnergy;

        public CharacterStats()
        {

        }

        public void removeEnergy(int type, int amount)
        {
            if (type == FIRE)
            {
                if (currentFireEnergy - amount < 0)
                {
                    currentFireEnergy = 0;
                }
                else
                {
                    currentFireEnergy -= amount;
                }
            }
            else if (type == WATER)
            {
                if (currentWaterEnergy - amount < 0)
                {
                    currentWaterEnergy = 0;
                }
                else
                {
                    currentWaterEnergy -= amount;
                }
            }
            else if (type == NATURE)
            {
                if (currentNatureEnergy - amount < 0)
                {
                    currentNatureEnergy = 0;
                }
                else
                {
                    currentNatureEnergy -= amount;
                }
            }
        }

        public void restoreEnergy(int type, int amount)
        {
            if (type == FIRE)
            {
                if (currentFireEnergy + amount > fireEnergy)
                {
                    currentFireEnergy = fireEnergy;
                }
                else
                {
                    currentFireEnergy += amount;
                }
            }
            else if (type == WATER)
            {
                if (currentWaterEnergy + amount > waterEnergy)
                {
                    currentWaterEnergy = waterEnergy;
                }
                else
                {
                    currentWaterEnergy += amount;
                }
            }
            else if (type == NATURE)
            {
                if (currentNatureEnergy + amount > natureEnergy)
                {
                    currentNatureEnergy = natureEnergy;
                }
                else
                {
                    currentNatureEnergy += amount;
                }
                Console.WriteLine("ENERGY: " + currentNatureEnergy);
            }
        }

        public void setFireEnergy(int energy)
        {
            fireEnergy = energy;
        }

        public int getFireEnergy()
        {
            return fireEnergy;
        }

        public void setNatureEnergy(int energy)
        {
            natureEnergy = energy;
        }

        public int getNatureEnergy()
        {
            return natureEnergy;
        }

        public void setWaterEnergy(int energy)
        {
            waterEnergy = energy;
        }

        public int getWaterEnergy()
        {
            return waterEnergy;
        }

        public void setCurrentFireEnergy(int energy)
        {
            currentFireEnergy = energy;
        }

        public int getCurrentFireEnergy()
        {
            return currentFireEnergy;
        }

        public void setCurrentNatureEnergy(int energy)
        {
            currentNatureEnergy = energy;
        }

        public int getCurrentNatureEnergy()
        {
            return currentNatureEnergy;
        }

        public void setCurrentWaterEnergy(int energy)
        {
            currentWaterEnergy = energy;
        }

        public int getCurrentWaterEnergy()
        {
            return currentWaterEnergy;
        }
    }
}
