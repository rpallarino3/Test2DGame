using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using FunGame.Game.Environment;
using FunGame.Game.EnemyStuff.Enemies;

using Microsoft.Xna.Framework;

namespace FunGame.Game.EnemyStuff
{
    class EnemySpawner
    {

        public readonly int TOP_LEFT = 0;
        public readonly int TOP = 1;
        public readonly int TOP_RIGHT = 2;
        public readonly int RIGHT = 3;
        public readonly int BOTTOM_RIGHT = 4;
        public readonly int BOTTOM = 5;
        public readonly int BOTTOM_LEFT = 6;
        public readonly int LEFT = 7;

        private Vector2 location;
        private int zoneLevel;

        private string type;
        private bool isPassable;
        private int spawnThreshold;
        private int spawnEnemies;
        private int spawnEnemiesLeft;

        private int width;
        private int height;

        private List<bool> possibleSpawns;
        private List<Vector2> spawnLocations;

        private Dictionary<string, Enemy> placeholderEnemies;

        public EnemySpawner(string type, Vector2 location, int width, int height, bool isPassable)
        {
            this.type = type;
            this.location = location;
            this.width = width;
            this.height = height;
            this.isPassable = isPassable;

            spawnThreshold = 200;
            spawnEnemies = 5;
            spawnEnemiesLeft = spawnEnemies;

            possibleSpawns = new List<bool>();
            spawnLocations = new List<Vector2>();
            placeholderEnemies = new Dictionary<string, Enemy>();

            fillTrueSpawns();
            setSpawnLocations(location);
            fillDictionary();
        }

        private void fillDictionary()
        {
            placeholderEnemies.Add("Goblin", new Goblin(new Vector2(0, 0), 0, 0));
            placeholderEnemies.Add("Rabbit", new Rabbit(new Vector2(0, 0), 0, 0));
        }

        public void setSpawnNumber(int number)
        {
            spawnEnemies = number;
        }

        public int getSpawnEnemiesLeft()
        {
            return spawnEnemiesLeft;
        }

        public void setSpawnThreshold(int threshold)
        {
            spawnThreshold = threshold;
        }

        public void resetSpawnNumber()
        {
            spawnEnemiesLeft = spawnEnemies;
        }

        public int getSpawnThreshold()
        {
            return spawnThreshold;
        }

        public string getType()
        {
            return type;
        }

        public Vector2 getLocation()
        {
            return location;
        }

        public int getWidth()
        {
            return width;
        }

        public int getHeight()
        {
            return height;
        }

        public bool isSpawnerPassable()
        {
            return isPassable;
        }

        public List<Vector2> getSpawnLocations()
        {
            return spawnLocations;
        }

        public void setPassable(bool pass)
        {
            isPassable = pass;
        }

        private void fillTrueSpawns()
        {
            possibleSpawns.Add(true);
            possibleSpawns.Add(true);
            possibleSpawns.Add(true);
            possibleSpawns.Add(true);
            possibleSpawns.Add(true);
            possibleSpawns.Add(true);
            possibleSpawns.Add(true);
            possibleSpawns.Add(true);
        }

        private void setSpawnLocations(Vector2 size) // fix this to take in an enemy
        {
            spawnLocations.Clear();
            spawnLocations.Add(new Vector2(location.X - size.X, location.Y - size.Y));
            spawnLocations.Add(new Vector2(location.X + width / 2 - size.X / 2, location.Y - size.Y));
            spawnLocations.Add(new Vector2(location.X + width, location.Y - size.Y));
            spawnLocations.Add(new Vector2(location.X + width, location.Y + height / 2 - size.Y / 2));
            spawnLocations.Add(new Vector2(location.X + width, location.Y + height));
            spawnLocations.Add(new Vector2(location.X + width / 2 - size.X / 2, location.Y + height));
            spawnLocations.Add(new Vector2(location.X - size.X, location.Y + height));
            spawnLocations.Add(new Vector2(location.X, location.Y + height / 2 - size.Y / 2));
        }

        public bool canSpawn(int index)
        {
            return possibleSpawns[index];
        }

        public void falseSpawn(int index)
        {
            possibleSpawns[index] = false;
        }

        public void trueSpawn(int index)
        {
            possibleSpawns[index] = true;
        }

        public int getZoneLevel()
        {
            return zoneLevel;
        }

        public void setZoneLevel(int level)
        {
            zoneLevel = level;
        }


        public void spawnEnemy(string type, Zone currentZone, int level)
        {
            Enemy enemy = placeholderEnemies[type];
            setSpawnLocations(enemy.getWalkingSize());
            for (int i = 0; i < spawnLocations.Count; i++)
            {
                if (canSpawn(i))
                {
                    if (checkCollision(spawnLocations[i], enemy, currentZone, level))
                    {
                        if (spawnEnemiesLeft > 0)
                        {
                            createEnemy(type, spawnLocations[i], 1, level, currentZone);
                        }
                    }
                }
            }
        }

        private void createEnemy(string type, Vector2 location, int facingDirection, int currentZoneLevel, Zone currentZone)
        {
            Console.WriteLine("creating enemy");
            spawnEnemiesLeft--;
            Enemy enemy;
            if (type == "Goblin")
            {
                enemy = new Goblin(location, facingDirection, currentZoneLevel);
                currentZone.getEnemies().Add(enemy);
                currentZone.getEnemyMap()[currentZoneLevel].insertEnemy(enemy);
            }
            else if (type == "Rabbit")
            {
                enemy = new Rabbit(location, facingDirection, currentZoneLevel);
                currentZone.getEnemies().Add(enemy);
                currentZone.getEnemyMap()[currentZoneLevel].insertEnemy(enemy);
            }
        }

        public bool checkCollision(Vector2 location, Enemy enemy, Zone currentZone, int level)
        {
            for (int i = (int) location.Y; i < (int) (location.Y + enemy.getWalkingSize().Y); i++)
            {
                for (int j = (int) location.X; j < (int) (location.X + enemy.getWalkingSize().X); j++)
                {
                    if (currentZone.getCollisionMap()[level].getCollisionMap()[i, j] == false || currentZone.getTrafficMap()[level].getTrafficMap()[i, j] == true || currentZone.getEnemyMap()[level].getTrafficMap()[i, j] == true)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        
    }
}
