using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using FunGame.Game.ContentHandlers;

namespace FunGame.Game.Environment.ManipulatableObjects
{
    class TallGrass : ManipulatableObject
    {
        public TallGrass(int y, int x, int level)
        {
            this.y = y;
            this.x = x;
            this.bottomLevel = level;

            height = 1;
            width = 1;
            length = 1;
            type = "TALL_GRASS";
            pushable = false;
            jumpable = false;
            stationary = true;

            energyType = NATURE;
            energy = 6;
            drainAmount = 2;
        }

        public override void activate(ContentHandler content, Zone currentZone, string activationCode)
        {
            switch (activationCode)
            {
                case "STATIONARY":
                    stationary = true;
                    if (energy == 6)
                    {
                        setNewAnimation(content.getObjectContentHandler().getObjectAnimations()[type][activationCode], content.getObjectContentHandler().getObjectAnimationOffsets()[type][activationCode]);
                    }
                    else if (energy == 4)
                    {
                        setNewAnimation(content.getObjectContentHandler().getObjectAnimations()[type]["STATIONARY_DEPLETED1"], content.getObjectContentHandler().getObjectAnimationOffsets()[type]["STATIONARY_DEPLETED1"]);
                    }
                    else if (energy == 2)
                    {
                        setNewAnimation(content.getObjectContentHandler().getObjectAnimations()[type]["STATIONARY_DEPLETED2"], content.getObjectContentHandler().getObjectAnimationOffsets()[type]["STATIONARY_DEPLETED2"]);
                    }
                    else
                    {
                        setNewAnimation(content.getObjectContentHandler().getObjectAnimations()[type]["STATIONARY_DEPLETED3"], content.getObjectContentHandler().getObjectAnimationOffsets()[type]["STATIONARY_DEPLETED3"]);
                    }
                    break;
                case "DRAIN":
                    Console.WriteLine("DRAIIINN");
                    stationary = false;
                    if (energy == 6)
                    {
                        Console.WriteLine("new animation");
                        energy -= 2;
                        setNewAnimation(content.getObjectContentHandler().getObjectAnimations()[type]["DRAIN_0TO1"], content.getObjectContentHandler().getObjectAnimationOffsets()[type]["DRAIN_0TO1"]);
                    }
                    else if (energy == 4)
                    {
                        energy -= 2;
                        setNewAnimation(content.getObjectContentHandler().getObjectAnimations()[type]["DRAIN_1TO2"], content.getObjectContentHandler().getObjectAnimationOffsets()[type]["DRAIN_1TO2"]);
                    }
                    else if (energy == 2)
                    {
                        energy -= 2;
                        setNewAnimation(content.getObjectContentHandler().getObjectAnimations()[type]["DRAIN_2TO3"], content.getObjectContentHandler().getObjectAnimationOffsets()[type]["DRAIN_2TO3"]);
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
