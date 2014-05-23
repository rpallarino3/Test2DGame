using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using FunGame.Game.ContentHandlers;

namespace FunGame.Game.Environment.ManipulatableObjects
{
    class SteppingStone : ManipulatableObject
    {

        public SteppingStone(int y, int x, int level)
        {
            this.y = y;
            this.x = x;
            this.bottomLevel = level;
            height = 2;
            width = 1;
            length = 1;
            type = "STEPPING_STONE";
            pushable = true;
            jumpable = false;
            stationary = true;

            energyType = FIRE;
            energy = 0;
            drainAmount = 0;
        }

        public override void activate(ContentHandler content, Zone currentZone, string activationCode)
        {
            switch (activationCode)
            {
                case "STATIONARY":
                    stationary = true;
                    setNewAnimation(content.getObjectContentHandler().getObjectAnimations()[type][activationCode], content.getObjectContentHandler().getObjectAnimationOffsets()[type][activationCode]);
                    break;
                case "PUSH_UP":
                    stationary = false;
                    moveUp(currentZone);
                    setNewAnimation(content.getObjectContentHandler().getObjectAnimations()[type][activationCode], content.getObjectContentHandler().getObjectAnimationOffsets()[type][activationCode]);
                    break;
                case "PUSH_DOWN":
                    stationary = false;
                    moveDown(currentZone);
                    setNewAnimation(content.getObjectContentHandler().getObjectAnimations()[type][activationCode], content.getObjectContentHandler().getObjectAnimationOffsets()[type][activationCode]);
                    break;
                case "PUSH_RIGHT":
                    stationary = false;
                    moveRight(currentZone);
                    setNewAnimation(content.getObjectContentHandler().getObjectAnimations()[type][activationCode], content.getObjectContentHandler().getObjectAnimationOffsets()[type][activationCode]);
                    break;
                case "PUSH_LEFT":
                    stationary = false;
                    moveLeft(currentZone);
                    setNewAnimation(content.getObjectContentHandler().getObjectAnimations()[type][activationCode], content.getObjectContentHandler().getObjectAnimationOffsets()[type][activationCode]);
                    break;
                default:
                    break;
            }
        }

        private void moveUp(Zone currentZone)
        {
            currentZone.getZoneTileMap().getTile(y, x, bottomLevel).freeTile();
            currentZone.getZoneTileMap().getTile(y - 1, x, bottomLevel).fillTile(this);
            currentZone.getZoneTileMap().getTile(y - 1, x, bottomLevel + 1).freeTile();
            currentZone.getZoneTileMap().getTile(y - 2, x, bottomLevel + 1).insertObject(this);
            y--;
        }

        private void moveDown(Zone currentZone)
        {
            currentZone.getZoneTileMap().getTile(y, x, bottomLevel).freeTile();
            currentZone.getZoneTileMap().getTile(y + 1, x, bottomLevel).fillTile(this);
            currentZone.getZoneTileMap().getTile(y - 1, x, bottomLevel + 1).freeTile();
            currentZone.getZoneTileMap().getTile(y, x, bottomLevel + 1).insertObject(this);
            y++;
        }

        private void moveRight(Zone currentZone)
        {
            currentZone.getZoneTileMap().getTile(y, x, bottomLevel).freeTile();
            currentZone.getZoneTileMap().getTile(y, x + 1, bottomLevel).fillTile(this);
            currentZone.getZoneTileMap().getTile(y - 1, x, bottomLevel + 1).freeTile();
            currentZone.getZoneTileMap().getTile(y - 1, x + 1, bottomLevel + 1).insertObject(this);
            x++;
        }

        private void moveLeft(Zone currentZone)
        {
            currentZone.getZoneTileMap().getTile(y, x, bottomLevel).freeTile();
            currentZone.getZoneTileMap().getTile(y, x - 1, bottomLevel).fillTile(this);
            currentZone.getZoneTileMap().getTile(y - 1, x, bottomLevel + 1).freeTile();
            currentZone.getZoneTileMap().getTile(y - 1, x - 1, bottomLevel + 1).insertObject(this);
            x--;
        }
    }
}
