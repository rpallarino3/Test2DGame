using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace FunGame.Game.ContentHandlers
{
    class ObjectContentHandler
    {

        private ContentManager content;

        private Dictionary<string, Dictionary<string, List<Texture2D>>> objectAnimations;
        private Dictionary<string, Dictionary<string, List<Vector2>>> objectAnimationOffsets;

        private Dictionary<string, List<Texture2D>> steppingStoneAnimations;
        private Dictionary<string, List<Vector2>> steppingStoneAnimationOffsets;

        private Dictionary<string, List<Texture2D>> tallGrassAnimations;
        private Dictionary<string, List<Vector2>> tallGrassAnimationOffsets;

        public ObjectContentHandler(ContentManager content)
        {
            this.content = content;

            objectAnimations = new Dictionary<string, Dictionary<string, List<Texture2D>>>();
            objectAnimationOffsets = new Dictionary<string, Dictionary<string, List<Vector2>>>();

            steppingStoneAnimations = new Dictionary<string, List<Texture2D>>();
            steppingStoneAnimationOffsets = new Dictionary<string, List<Vector2>>();

            tallGrassAnimations = new Dictionary<string, List<Texture2D>>();
            tallGrassAnimationOffsets = new Dictionary<string, List<Vector2>>();

        }

        public Dictionary<string, Dictionary<string, List<Texture2D>>> getObjectAnimations()
        {
            return objectAnimations;
        }

        public Dictionary<string, Dictionary<string, List<Vector2>>> getObjectAnimationOffsets()
        {
            return objectAnimationOffsets;
        }

        public void loadContent()
        {
            loadSteppingStoneContent();
            loadTallGrassContent();
        }

        private void loadTallGrassContent()
        {
            objectAnimations.Add("TALL_GRASS", tallGrassAnimations);
            objectAnimationOffsets.Add("TALL_GRASS", tallGrassAnimationOffsets);

            List<Texture2D> stationary = new List<Texture2D>();
            List<Vector2> stationaryOffset = new List<Vector2>();

            stationary.Add(content.Load<Texture2D>("Images/Objects/TallGrass/TallGrass"));
            stationaryOffset.Add(new Vector2(0, 0));

            tallGrassAnimations.Add("STATIONARY", stationary);
            tallGrassAnimationOffsets.Add("STATIONARY", stationaryOffset);

            List<Texture2D> stationaryDepleted1 = new List<Texture2D>();
            List<Vector2> stationaryDepleted1Offset = new List<Vector2>();

            stationaryDepleted1.Add(content.Load<Texture2D>("Images/Objects/TallGrass/TallGrassDepleted"));
            stationaryDepleted1Offset.Add(new Vector2(0, 0));

            tallGrassAnimations.Add("STATIONARY_DEPLETED1", stationaryDepleted1);
            tallGrassAnimationOffsets.Add("STATIONARY_DEPLETED1", stationaryDepleted1Offset);

            List<Texture2D> stationaryDepleted2 = new List<Texture2D>();
            List<Vector2> stationaryDepleted2Offset = new List<Vector2>();

            stationaryDepleted2.Add(content.Load<Texture2D>("Images/Objects/TallGrass/TallGrassDepleted1"));
            stationaryDepleted2Offset.Add(new Vector2(0, 0));

            tallGrassAnimations.Add("STATIONARY_DEPLETED2", stationaryDepleted2);
            tallGrassAnimationOffsets.Add("STATIONARY_DEPLETED2", stationaryDepleted2Offset);

            List<Texture2D> stationaryDepleted3 = new List<Texture2D>();
            List<Vector2> stationaryDepleted3Offset = new List<Vector2>();

            stationaryDepleted3.Add(content.Load<Texture2D>("Images/Objects/TallGrass/TallGrassDepleted2"));
            stationaryDepleted3Offset.Add(new Vector2(0, 0));

            tallGrassAnimations.Add("STATIONARY_DEPLETED3", stationaryDepleted3);
            tallGrassAnimationOffsets.Add("STATIONARY_DEPLETED3", stationaryDepleted3Offset);

            List<Texture2D> drain0to1 = new List<Texture2D>();
            List<Vector2> drain0to1Offset = new List<Vector2>();

            drain0to1.Add(content.Load<Texture2D>("Images/Objects/TallGrass/TallGrass"));
            drain0to1.Add(content.Load<Texture2D>("Images/Objects/TallGrass/TallGrass"));
            drain0to1.Add(content.Load<Texture2D>("Images/Objects/TallGrass/TallGrass"));
            drain0to1.Add(content.Load<Texture2D>("Images/Objects/TallGrass/TallGrass"));
            drain0to1.Add(content.Load<Texture2D>("Images/Objects/TallGrass/TallGrass"));
            drain0to1.Add(content.Load<Texture2D>("Images/Objects/TallGrass/TallGrassDepleted"));
            drain0to1.Add(content.Load<Texture2D>("Images/Objects/TallGrass/TallGrassDepleted"));
            drain0to1.Add(content.Load<Texture2D>("Images/Objects/TallGrass/TallGrassDepleted"));
            drain0to1.Add(content.Load<Texture2D>("Images/Objects/TallGrass/TallGrassDepleted"));
            drain0to1.Add(content.Load<Texture2D>("Images/Objects/TallGrass/TallGrassDepleted"));

            drain0to1Offset.Add(new Vector2(0, 0));
            drain0to1Offset.Add(new Vector2(0, 0));
            drain0to1Offset.Add(new Vector2(0, 0));
            drain0to1Offset.Add(new Vector2(0, 0));
            drain0to1Offset.Add(new Vector2(0, 0));
            drain0to1Offset.Add(new Vector2(0, 0));
            drain0to1Offset.Add(new Vector2(0, 0));
            drain0to1Offset.Add(new Vector2(0, 0));
            drain0to1Offset.Add(new Vector2(0, 0));
            drain0to1Offset.Add(new Vector2(0, 0));

            tallGrassAnimations.Add("DRAIN_0TO1", drain0to1);
            tallGrassAnimationOffsets.Add("DRAIN_0TO1", drain0to1Offset);

            List<Texture2D> drain1to2 = new List<Texture2D>();
            List<Vector2> drain1to2Offset = new List<Vector2>();

            drain1to2.Add(content.Load<Texture2D>("Images/Objects/TallGrass/TallGrassDepleted"));
            drain1to2.Add(content.Load<Texture2D>("Images/Objects/TallGrass/TallGrassDepleted"));
            drain1to2.Add(content.Load<Texture2D>("Images/Objects/TallGrass/TallGrassDepleted"));
            drain1to2.Add(content.Load<Texture2D>("Images/Objects/TallGrass/TallGrassDepleted"));
            drain1to2.Add(content.Load<Texture2D>("Images/Objects/TallGrass/TallGrassDepleted"));
            drain1to2.Add(content.Load<Texture2D>("Images/Objects/TallGrass/TallGrassDepleted1"));
            drain1to2.Add(content.Load<Texture2D>("Images/Objects/TallGrass/TallGrassDepleted1"));
            drain1to2.Add(content.Load<Texture2D>("Images/Objects/TallGrass/TallGrassDepleted1"));
            drain1to2.Add(content.Load<Texture2D>("Images/Objects/TallGrass/TallGrassDepleted1"));
            drain1to2.Add(content.Load<Texture2D>("Images/Objects/TallGrass/TallGrassDepleted1"));

            drain1to2Offset.Add(new Vector2(0, 0));
            drain1to2Offset.Add(new Vector2(0, 0));
            drain1to2Offset.Add(new Vector2(0, 0));
            drain1to2Offset.Add(new Vector2(0, 0));
            drain1to2Offset.Add(new Vector2(0, 0));
            drain1to2Offset.Add(new Vector2(0, 0));
            drain1to2Offset.Add(new Vector2(0, 0));
            drain1to2Offset.Add(new Vector2(0, 0));
            drain1to2Offset.Add(new Vector2(0, 0));
            drain1to2Offset.Add(new Vector2(0, 0));

            tallGrassAnimations.Add("DRAIN_1TO2", drain1to2);
            tallGrassAnimationOffsets.Add("DRAIN_1TO2", drain1to2Offset);

            List<Texture2D> drain2to3 = new List<Texture2D>();
            List<Vector2> drain2to3Offset = new List<Vector2>();

            drain2to3.Add(content.Load<Texture2D>("Images/Objects/TallGrass/TallGrassDepleted1"));
            drain2to3.Add(content.Load<Texture2D>("Images/Objects/TallGrass/TallGrassDepleted1"));
            drain2to3.Add(content.Load<Texture2D>("Images/Objects/TallGrass/TallGrassDepleted1"));
            drain2to3.Add(content.Load<Texture2D>("Images/Objects/TallGrass/TallGrassDepleted1"));
            drain2to3.Add(content.Load<Texture2D>("Images/Objects/TallGrass/TallGrassDepleted1"));
            drain2to3.Add(content.Load<Texture2D>("Images/Objects/TallGrass/TallGrassDepleted2"));
            drain2to3.Add(content.Load<Texture2D>("Images/Objects/TallGrass/TallGrassDepleted2"));
            drain2to3.Add(content.Load<Texture2D>("Images/Objects/TallGrass/TallGrassDepleted2"));
            drain2to3.Add(content.Load<Texture2D>("Images/Objects/TallGrass/TallGrassDepleted2"));
            drain2to3.Add(content.Load<Texture2D>("Images/Objects/TallGrass/TallGrassDepleted2"));

            drain2to3Offset.Add(new Vector2(0, 0));
            drain2to3Offset.Add(new Vector2(0, 0));
            drain2to3Offset.Add(new Vector2(0, 0));
            drain2to3Offset.Add(new Vector2(0, 0));
            drain2to3Offset.Add(new Vector2(0, 0));
            drain2to3Offset.Add(new Vector2(0, 0));
            drain2to3Offset.Add(new Vector2(0, 0));
            drain2to3Offset.Add(new Vector2(0, 0));
            drain2to3Offset.Add(new Vector2(0, 0));
            drain2to3Offset.Add(new Vector2(0, 0));

            tallGrassAnimations.Add("DRAIN_2TO3", drain2to3);
            tallGrassAnimationOffsets.Add("DRAIN_2TO3", drain2to3Offset);

        }

        private void loadSteppingStoneContent()
        {
            objectAnimations.Add("STEPPING_STONE", steppingStoneAnimations);
            objectAnimationOffsets.Add("STEPPING_STONE", steppingStoneAnimationOffsets);

            List<Texture2D> stationary = new List<Texture2D>();
            List<Vector2> stationaryOffset = new List<Vector2>();

            stationary.Add(content.Load<Texture2D>("Images/Objects/SteppingStone/SteppingStone"));
            stationaryOffset.Add(new Vector2(0, 0));

            steppingStoneAnimations.Add("STATIONARY", stationary);
            steppingStoneAnimationOffsets.Add("STATIONARY", stationaryOffset);

            List<Texture2D> pushUp = new List<Texture2D>();
            List<Vector2> pushUpOffset = new List<Vector2>();

            pushUp.Add(content.Load<Texture2D>("Images/Objects/SteppingStone/SteppingStone"));
            pushUp.Add(content.Load<Texture2D>("Images/Objects/SteppingStone/SteppingStone"));
            pushUp.Add(content.Load<Texture2D>("Images/Objects/SteppingStone/SteppingStone"));
            pushUp.Add(content.Load<Texture2D>("Images/Objects/SteppingStone/SteppingStone"));
            pushUp.Add(content.Load<Texture2D>("Images/Objects/SteppingStone/SteppingStone"));
            pushUp.Add(content.Load<Texture2D>("Images/Objects/SteppingStone/SteppingStone"));
            pushUp.Add(content.Load<Texture2D>("Images/Objects/SteppingStone/SteppingStone"));
            pushUp.Add(content.Load<Texture2D>("Images/Objects/SteppingStone/SteppingStone"));
            pushUp.Add(content.Load<Texture2D>("Images/Objects/SteppingStone/SteppingStone"));
            pushUp.Add(content.Load<Texture2D>("Images/Objects/SteppingStone/SteppingStone"));

            pushUpOffset.Add(new Vector2(0, 30));
            pushUpOffset.Add(new Vector2(0, 27));
            pushUpOffset.Add(new Vector2(0, 24));
            pushUpOffset.Add(new Vector2(0, 21));
            pushUpOffset.Add(new Vector2(0, 18));
            pushUpOffset.Add(new Vector2(0, 15));
            pushUpOffset.Add(new Vector2(0, 12));
            pushUpOffset.Add(new Vector2(0, 9));
            pushUpOffset.Add(new Vector2(0, 6));
            pushUpOffset.Add(new Vector2(0, 3));

            steppingStoneAnimations.Add("PUSH_UP", pushUp);
            steppingStoneAnimationOffsets.Add("PUSH_UP", pushUpOffset);

            List<Texture2D> pushDown = new List<Texture2D>();
            List<Vector2> pushDownOffset = new List<Vector2>();

            pushDown.Add(content.Load<Texture2D>("Images/Objects/SteppingStone/SteppingStone"));
            pushDown.Add(content.Load<Texture2D>("Images/Objects/SteppingStone/SteppingStone"));
            pushDown.Add(content.Load<Texture2D>("Images/Objects/SteppingStone/SteppingStone"));
            pushDown.Add(content.Load<Texture2D>("Images/Objects/SteppingStone/SteppingStone"));
            pushDown.Add(content.Load<Texture2D>("Images/Objects/SteppingStone/SteppingStone"));
            pushDown.Add(content.Load<Texture2D>("Images/Objects/SteppingStone/SteppingStone"));
            pushDown.Add(content.Load<Texture2D>("Images/Objects/SteppingStone/SteppingStone"));
            pushDown.Add(content.Load<Texture2D>("Images/Objects/SteppingStone/SteppingStone"));
            pushDown.Add(content.Load<Texture2D>("Images/Objects/SteppingStone/SteppingStone"));
            pushDown.Add(content.Load<Texture2D>("Images/Objects/SteppingStone/SteppingStone"));

            pushDownOffset.Add(new Vector2(0, -30));
            pushDownOffset.Add(new Vector2(0, -27));
            pushDownOffset.Add(new Vector2(0, -24));
            pushDownOffset.Add(new Vector2(0, -21));
            pushDownOffset.Add(new Vector2(0, -18));
            pushDownOffset.Add(new Vector2(0, -15));
            pushDownOffset.Add(new Vector2(0, -12));
            pushDownOffset.Add(new Vector2(0, -9));
            pushDownOffset.Add(new Vector2(0, -6));
            pushDownOffset.Add(new Vector2(0, -3));

            steppingStoneAnimations.Add("PUSH_DOWN", pushDown);
            steppingStoneAnimationOffsets.Add("PUSH_DOWN", pushDownOffset);

            List<Texture2D> pushRight = new List<Texture2D>();
            List<Vector2> pushRightOffset = new List<Vector2>();

            pushRight.Add(content.Load<Texture2D>("Images/Objects/SteppingStone/SteppingStone"));
            pushRight.Add(content.Load<Texture2D>("Images/Objects/SteppingStone/SteppingStone"));
            pushRight.Add(content.Load<Texture2D>("Images/Objects/SteppingStone/SteppingStone"));
            pushRight.Add(content.Load<Texture2D>("Images/Objects/SteppingStone/SteppingStone"));
            pushRight.Add(content.Load<Texture2D>("Images/Objects/SteppingStone/SteppingStone"));
            pushRight.Add(content.Load<Texture2D>("Images/Objects/SteppingStone/SteppingStone"));
            pushRight.Add(content.Load<Texture2D>("Images/Objects/SteppingStone/SteppingStone"));
            pushRight.Add(content.Load<Texture2D>("Images/Objects/SteppingStone/SteppingStone"));
            pushRight.Add(content.Load<Texture2D>("Images/Objects/SteppingStone/SteppingStone"));
            pushRight.Add(content.Load<Texture2D>("Images/Objects/SteppingStone/SteppingStone"));

            pushRightOffset.Add(new Vector2(-30, 0));
            pushRightOffset.Add(new Vector2(-27, 0));
            pushRightOffset.Add(new Vector2(-24, 0));
            pushRightOffset.Add(new Vector2(-21, 0));
            pushRightOffset.Add(new Vector2(-18, 0));
            pushRightOffset.Add(new Vector2(-15, 0));
            pushRightOffset.Add(new Vector2(-12, 0));
            pushRightOffset.Add(new Vector2(-9, 0));
            pushRightOffset.Add(new Vector2(-6, 0));
            pushRightOffset.Add(new Vector2(-3, 0));

            steppingStoneAnimations.Add("PUSH_RIGHT", pushRight);
            steppingStoneAnimationOffsets.Add("PUSH_RIGHT", pushRightOffset);

            List<Texture2D> pushLeft = new List<Texture2D>();
            List<Vector2> pushLeftOffset = new List<Vector2>();

            pushLeft.Add(content.Load<Texture2D>("Images/Objects/SteppingStone/SteppingStone"));
            pushLeft.Add(content.Load<Texture2D>("Images/Objects/SteppingStone/SteppingStone"));
            pushLeft.Add(content.Load<Texture2D>("Images/Objects/SteppingStone/SteppingStone"));
            pushLeft.Add(content.Load<Texture2D>("Images/Objects/SteppingStone/SteppingStone"));
            pushLeft.Add(content.Load<Texture2D>("Images/Objects/SteppingStone/SteppingStone"));
            pushLeft.Add(content.Load<Texture2D>("Images/Objects/SteppingStone/SteppingStone"));
            pushLeft.Add(content.Load<Texture2D>("Images/Objects/SteppingStone/SteppingStone"));
            pushLeft.Add(content.Load<Texture2D>("Images/Objects/SteppingStone/SteppingStone"));
            pushLeft.Add(content.Load<Texture2D>("Images/Objects/SteppingStone/SteppingStone"));
            pushLeft.Add(content.Load<Texture2D>("Images/Objects/SteppingStone/SteppingStone"));

            pushLeftOffset.Add(new Vector2(30, 0));
            pushLeftOffset.Add(new Vector2(27, 0));
            pushLeftOffset.Add(new Vector2(24, 0));
            pushLeftOffset.Add(new Vector2(21, 0));
            pushLeftOffset.Add(new Vector2(18, 0));
            pushLeftOffset.Add(new Vector2(15, 0));
            pushLeftOffset.Add(new Vector2(12, 0));
            pushLeftOffset.Add(new Vector2(9, 0));
            pushLeftOffset.Add(new Vector2(6, 0));
            pushLeftOffset.Add(new Vector2(3, 0));

            steppingStoneAnimations.Add("PUSH_LEFT", pushLeft);
            steppingStoneAnimationOffsets.Add("PUSH_LEFT", pushLeftOffset);
        }
    }
}
