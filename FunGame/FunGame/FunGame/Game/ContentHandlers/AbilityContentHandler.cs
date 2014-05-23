using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace FunGame.Game.ContentHandlers
{
    class AbilityContentHandler
    {

        private ContentManager content;

        private Dictionary<string, List<Texture2D>> abilityAnimations;
        private Dictionary<string, List<Vector2>> abilityAnimationOffsets;

        public AbilityContentHandler(ContentManager content)
        {
            this.content = content;

            abilityAnimations = new Dictionary<string, List<Texture2D>>();
            abilityAnimationOffsets = new Dictionary<string, List<Vector2>>();
        }

        public void loadContent()
        {
            loadDrainContent();
        }

        private void loadDrainContent()
        {
            List<Texture2D> circleGrow = new List<Texture2D>();

            circleGrow.Add(content.Load<Texture2D>("Images/Abilities/Drain/Drain10"));
            circleGrow.Add(content.Load<Texture2D>("Images/Abilities/Drain/Drain11"));
            circleGrow.Add(content.Load<Texture2D>("Images/Abilities/Drain/Drain12"));
            circleGrow.Add(content.Load<Texture2D>("Images/Abilities/Drain/Drain13"));
            circleGrow.Add(content.Load<Texture2D>("Images/Abilities/Drain/Drain14"));
            circleGrow.Add(content.Load<Texture2D>("Images/Abilities/Drain/Drain15"));
            circleGrow.Add(content.Load<Texture2D>("Images/Abilities/Drain/Drain16"));
            circleGrow.Add(content.Load<Texture2D>("Images/Abilities/Drain/Drain17"));
            circleGrow.Add(content.Load<Texture2D>("Images/Abilities/Drain/Drain18"));
            circleGrow.Add(content.Load<Texture2D>("Images/Abilities/Drain/Drain19"));
            circleGrow.Add(content.Load<Texture2D>("Images/Abilities/Drain/Drain20"));
            circleGrow.Add(content.Load<Texture2D>("Images/Abilities/Drain/Drain21"));
            circleGrow.Add(content.Load<Texture2D>("Images/Abilities/Drain/Drain22"));
            circleGrow.Add(content.Load<Texture2D>("Images/Abilities/Drain/Drain23"));
            circleGrow.Add(content.Load<Texture2D>("Images/Abilities/Drain/Drain24"));
            circleGrow.Add(content.Load<Texture2D>("Images/Abilities/Drain/Drain25"));
            circleGrow.Add(content.Load<Texture2D>("Images/Abilities/Drain/Drain26"));
            circleGrow.Add(content.Load<Texture2D>("Images/Abilities/Drain/Drain27"));
            circleGrow.Add(content.Load<Texture2D>("Images/Abilities/Drain/Drain28"));
            circleGrow.Add(content.Load<Texture2D>("Images/Abilities/Drain/Drain29"));
            circleGrow.Add(content.Load<Texture2D>("Images/Abilities/Drain/Drain30"));
            circleGrow.Add(content.Load<Texture2D>("Images/Abilities/Drain/Drain31"));
            circleGrow.Add(content.Load<Texture2D>("Images/Abilities/Drain/Drain32"));
            circleGrow.Add(content.Load<Texture2D>("Images/Abilities/Drain/Drain33"));
            circleGrow.Add(content.Load<Texture2D>("Images/Abilities/Drain/Drain34"));
            circleGrow.Add(content.Load<Texture2D>("Images/Abilities/Drain/Drain35"));
            circleGrow.Add(content.Load<Texture2D>("Images/Abilities/Drain/Drain36"));
            circleGrow.Add(content.Load<Texture2D>("Images/Abilities/Drain/Drain37"));
            circleGrow.Add(content.Load<Texture2D>("Images/Abilities/Drain/Drain38"));
            circleGrow.Add(content.Load<Texture2D>("Images/Abilities/Drain/Drain39"));
            circleGrow.Add(content.Load<Texture2D>("Images/Abilities/Drain/Drain40"));
            circleGrow.Add(content.Load<Texture2D>("Images/Abilities/Drain/Drain41"));
            circleGrow.Add(content.Load<Texture2D>("Images/Abilities/Drain/Drain42"));
            circleGrow.Add(content.Load<Texture2D>("Images/Abilities/Drain/Drain43"));
            circleGrow.Add(content.Load<Texture2D>("Images/Abilities/Drain/Drain44"));
            circleGrow.Add(content.Load<Texture2D>("Images/Abilities/Drain/Drain45"));
            circleGrow.Add(content.Load<Texture2D>("Images/Abilities/Drain/Drain46"));
            circleGrow.Add(content.Load<Texture2D>("Images/Abilities/Drain/Drain47"));
            circleGrow.Add(content.Load<Texture2D>("Images/Abilities/Drain/Drain48"));
            circleGrow.Add(content.Load<Texture2D>("Images/Abilities/Drain/Drain49"));
            circleGrow.Add(content.Load<Texture2D>("Images/Abilities/Drain/Drain50"));
            circleGrow.Add(content.Load<Texture2D>("Images/Abilities/Drain/Drain51"));
            circleGrow.Add(content.Load<Texture2D>("Images/Abilities/Drain/Drain52"));
            circleGrow.Add(content.Load<Texture2D>("Images/Abilities/Drain/Drain53"));
            circleGrow.Add(content.Load<Texture2D>("Images/Abilities/Drain/Drain54"));
            circleGrow.Add(content.Load<Texture2D>("Images/Abilities/Drain/Drain55"));
            circleGrow.Add(content.Load<Texture2D>("Images/Abilities/Drain/Drain56"));
            circleGrow.Add(content.Load<Texture2D>("Images/Abilities/Drain/Drain57"));
            circleGrow.Add(content.Load<Texture2D>("Images/Abilities/Drain/Drain58"));
            circleGrow.Add(content.Load<Texture2D>("Images/Abilities/Drain/Drain59"));
            circleGrow.Add(content.Load<Texture2D>("Images/Abilities/Drain/DrainMax"));

            List<Vector2> circleGrowUp = new List<Vector2>();

            circleGrowUp.Add(new Vector2(-45, -75));
            circleGrowUp.Add(new Vector2(-45, -75));
            circleGrowUp.Add(new Vector2(-45, -75));
            circleGrowUp.Add(new Vector2(-45, -75));
            circleGrowUp.Add(new Vector2(-45, -75));
            circleGrowUp.Add(new Vector2(-45, -75));
            circleGrowUp.Add(new Vector2(-45, -75));
            circleGrowUp.Add(new Vector2(-45, -75));
            circleGrowUp.Add(new Vector2(-45, -75));
            circleGrowUp.Add(new Vector2(-45, -75));
            circleGrowUp.Add(new Vector2(-45, -75));
            circleGrowUp.Add(new Vector2(-45, -75));
            circleGrowUp.Add(new Vector2(-45, -75));
            circleGrowUp.Add(new Vector2(-45, -75));
            circleGrowUp.Add(new Vector2(-45, -75));
            circleGrowUp.Add(new Vector2(-45, -75));
            circleGrowUp.Add(new Vector2(-45, -75));
            circleGrowUp.Add(new Vector2(-45, -75));
            circleGrowUp.Add(new Vector2(-45, -75));
            circleGrowUp.Add(new Vector2(-45, -75));
            circleGrowUp.Add(new Vector2(-45, -75));
            circleGrowUp.Add(new Vector2(-45, -75));
            circleGrowUp.Add(new Vector2(-45, -75));
            circleGrowUp.Add(new Vector2(-45, -75));
            circleGrowUp.Add(new Vector2(-45, -75));
            circleGrowUp.Add(new Vector2(-45, -75));
            circleGrowUp.Add(new Vector2(-45, -75));
            circleGrowUp.Add(new Vector2(-45, -75));
            circleGrowUp.Add(new Vector2(-45, -75));
            circleGrowUp.Add(new Vector2(-45, -75));
            circleGrowUp.Add(new Vector2(-45, -75));
            circleGrowUp.Add(new Vector2(-45, -75));
            circleGrowUp.Add(new Vector2(-45, -75));
            circleGrowUp.Add(new Vector2(-45, -75));
            circleGrowUp.Add(new Vector2(-45, -75));
            circleGrowUp.Add(new Vector2(-45, -75));
            circleGrowUp.Add(new Vector2(-45, -75));
            circleGrowUp.Add(new Vector2(-45, -75));
            circleGrowUp.Add(new Vector2(-45, -75));
            circleGrowUp.Add(new Vector2(-45, -75));
            circleGrowUp.Add(new Vector2(-45, -75));
            circleGrowUp.Add(new Vector2(-45, -75));
            circleGrowUp.Add(new Vector2(-45, -75));
            circleGrowUp.Add(new Vector2(-45, -75));
            circleGrowUp.Add(new Vector2(-45, -75));
            circleGrowUp.Add(new Vector2(-45, -75));
            circleGrowUp.Add(new Vector2(-45, -75));
            circleGrowUp.Add(new Vector2(-45, -75));
            circleGrowUp.Add(new Vector2(-45, -75));
            circleGrowUp.Add(new Vector2(-45, -75));
            circleGrowUp.Add(new Vector2(-45, -75));

            abilityAnimations.Add("CIRCLEGROWUP", circleGrow);
            abilityAnimationOffsets.Add("CIRCLEGROWUP", circleGrowUp);

            List<Vector2> circleGrowDown = new List<Vector2>();

            circleGrowDown.Add(new Vector2(-45, -15));
            circleGrowDown.Add(new Vector2(-45, -15));
            circleGrowDown.Add(new Vector2(-45, -15));
            circleGrowDown.Add(new Vector2(-45, -15));
            circleGrowDown.Add(new Vector2(-45, -15));
            circleGrowDown.Add(new Vector2(-45, -15));
            circleGrowDown.Add(new Vector2(-45, -15));
            circleGrowDown.Add(new Vector2(-45, -15));
            circleGrowDown.Add(new Vector2(-45, -15));
            circleGrowDown.Add(new Vector2(-45, -15));
            circleGrowDown.Add(new Vector2(-45, -15));
            circleGrowDown.Add(new Vector2(-45, -15));
            circleGrowDown.Add(new Vector2(-45, -15));
            circleGrowDown.Add(new Vector2(-45, -15));
            circleGrowDown.Add(new Vector2(-45, -15));
            circleGrowDown.Add(new Vector2(-45, -15));
            circleGrowDown.Add(new Vector2(-45, -15));
            circleGrowDown.Add(new Vector2(-45, -15));
            circleGrowDown.Add(new Vector2(-45, -15));
            circleGrowDown.Add(new Vector2(-45, -15));
            circleGrowDown.Add(new Vector2(-45, -15));
            circleGrowDown.Add(new Vector2(-45, -15));
            circleGrowDown.Add(new Vector2(-45, -15));
            circleGrowDown.Add(new Vector2(-45, -15));
            circleGrowDown.Add(new Vector2(-45, -15));
            circleGrowDown.Add(new Vector2(-45, -15));
            circleGrowDown.Add(new Vector2(-45, -15));
            circleGrowDown.Add(new Vector2(-45, -15));
            circleGrowDown.Add(new Vector2(-45, -15));
            circleGrowDown.Add(new Vector2(-45, -15));
            circleGrowDown.Add(new Vector2(-45, -15));
            circleGrowDown.Add(new Vector2(-45, -15));
            circleGrowDown.Add(new Vector2(-45, -15));
            circleGrowDown.Add(new Vector2(-45, -15));
            circleGrowDown.Add(new Vector2(-45, -15));
            circleGrowDown.Add(new Vector2(-45, -15));
            circleGrowDown.Add(new Vector2(-45, -15));
            circleGrowDown.Add(new Vector2(-45, -15));
            circleGrowDown.Add(new Vector2(-45, -15));
            circleGrowDown.Add(new Vector2(-45, -15));
            circleGrowDown.Add(new Vector2(-45, -15));
            circleGrowDown.Add(new Vector2(-45, -15));
            circleGrowDown.Add(new Vector2(-45, -15));
            circleGrowDown.Add(new Vector2(-45, -15));
            circleGrowDown.Add(new Vector2(-45, -15));
            circleGrowDown.Add(new Vector2(-45, -15));
            circleGrowDown.Add(new Vector2(-45, -15));
            circleGrowDown.Add(new Vector2(-45, -15));
            circleGrowDown.Add(new Vector2(-45, -15));
            circleGrowDown.Add(new Vector2(-45, -15));
            circleGrowDown.Add(new Vector2(-45, -15));

            abilityAnimations.Add("CIRCLEGROWDOWN", circleGrow);
            abilityAnimationOffsets.Add("CIRCLEGROWDOWN", circleGrowDown);

            List<Vector2> circleGrowRight = new List<Vector2>();

            circleGrowRight.Add(new Vector2(-15, -45));
            circleGrowRight.Add(new Vector2(-15, -45));
            circleGrowRight.Add(new Vector2(-15, -45));
            circleGrowRight.Add(new Vector2(-15, -45));
            circleGrowRight.Add(new Vector2(-15, -45));
            circleGrowRight.Add(new Vector2(-15, -45));
            circleGrowRight.Add(new Vector2(-15, -45));
            circleGrowRight.Add(new Vector2(-15, -45));
            circleGrowRight.Add(new Vector2(-15, -45));
            circleGrowRight.Add(new Vector2(-15, -45));
            circleGrowRight.Add(new Vector2(-15, -45));
            circleGrowRight.Add(new Vector2(-15, -45));
            circleGrowRight.Add(new Vector2(-15, -45));
            circleGrowRight.Add(new Vector2(-15, -45));
            circleGrowRight.Add(new Vector2(-15, -45));
            circleGrowRight.Add(new Vector2(-15, -45));
            circleGrowRight.Add(new Vector2(-15, -45));
            circleGrowRight.Add(new Vector2(-15, -45));
            circleGrowRight.Add(new Vector2(-15, -45));
            circleGrowRight.Add(new Vector2(-15, -45));
            circleGrowRight.Add(new Vector2(-15, -45));
            circleGrowRight.Add(new Vector2(-15, -45));
            circleGrowRight.Add(new Vector2(-15, -45));
            circleGrowRight.Add(new Vector2(-15, -45));
            circleGrowRight.Add(new Vector2(-15, -45));
            circleGrowRight.Add(new Vector2(-15, -45));
            circleGrowRight.Add(new Vector2(-15, -45));
            circleGrowRight.Add(new Vector2(-15, -45));
            circleGrowRight.Add(new Vector2(-15, -45));
            circleGrowRight.Add(new Vector2(-15, -45));
            circleGrowRight.Add(new Vector2(-15, -45));
            circleGrowRight.Add(new Vector2(-15, -45));
            circleGrowRight.Add(new Vector2(-15, -45));
            circleGrowRight.Add(new Vector2(-15, -45));
            circleGrowRight.Add(new Vector2(-15, -45));
            circleGrowRight.Add(new Vector2(-15, -45));
            circleGrowRight.Add(new Vector2(-15, -45));
            circleGrowRight.Add(new Vector2(-15, -45));
            circleGrowRight.Add(new Vector2(-15, -45));
            circleGrowRight.Add(new Vector2(-15, -45));
            circleGrowRight.Add(new Vector2(-15, -45));
            circleGrowRight.Add(new Vector2(-15, -45));
            circleGrowRight.Add(new Vector2(-15, -45));
            circleGrowRight.Add(new Vector2(-15, -45));
            circleGrowRight.Add(new Vector2(-15, -45));
            circleGrowRight.Add(new Vector2(-15, -45));
            circleGrowRight.Add(new Vector2(-15, -45));
            circleGrowRight.Add(new Vector2(-15, -45));
            circleGrowRight.Add(new Vector2(-15, -45));
            circleGrowRight.Add(new Vector2(-15, -45));
            circleGrowRight.Add(new Vector2(-15, -45));

            abilityAnimations.Add("CIRCLEGROWRIGHT", circleGrow);
            abilityAnimationOffsets.Add("CIRCLEGROWRIGHT", circleGrowRight);

            List<Vector2> circleGrowLeft = new List<Vector2>();

            circleGrowLeft.Add(new Vector2(-75, -45));
            circleGrowLeft.Add(new Vector2(-75, -45));
            circleGrowLeft.Add(new Vector2(-75, -45));
            circleGrowLeft.Add(new Vector2(-75, -45));
            circleGrowLeft.Add(new Vector2(-75, -45));
            circleGrowLeft.Add(new Vector2(-75, -45));
            circleGrowLeft.Add(new Vector2(-75, -45));
            circleGrowLeft.Add(new Vector2(-75, -45));
            circleGrowLeft.Add(new Vector2(-75, -45));
            circleGrowLeft.Add(new Vector2(-75, -45));
            circleGrowLeft.Add(new Vector2(-75, -45));
            circleGrowLeft.Add(new Vector2(-75, -45));
            circleGrowLeft.Add(new Vector2(-75, -45));
            circleGrowLeft.Add(new Vector2(-75, -45));
            circleGrowLeft.Add(new Vector2(-75, -45));
            circleGrowLeft.Add(new Vector2(-75, -45));
            circleGrowLeft.Add(new Vector2(-75, -45));
            circleGrowLeft.Add(new Vector2(-75, -45));
            circleGrowLeft.Add(new Vector2(-75, -45));
            circleGrowLeft.Add(new Vector2(-75, -45));
            circleGrowLeft.Add(new Vector2(-75, -45));
            circleGrowLeft.Add(new Vector2(-75, -45));
            circleGrowLeft.Add(new Vector2(-75, -45));
            circleGrowLeft.Add(new Vector2(-75, -45));
            circleGrowLeft.Add(new Vector2(-75, -45));
            circleGrowLeft.Add(new Vector2(-75, -45));
            circleGrowLeft.Add(new Vector2(-75, -45));
            circleGrowLeft.Add(new Vector2(-75, -45));
            circleGrowLeft.Add(new Vector2(-75, -45));
            circleGrowLeft.Add(new Vector2(-75, -45));
            circleGrowLeft.Add(new Vector2(-75, -45));
            circleGrowLeft.Add(new Vector2(-75, -45));
            circleGrowLeft.Add(new Vector2(-75, -45));
            circleGrowLeft.Add(new Vector2(-75, -45));
            circleGrowLeft.Add(new Vector2(-75, -45));
            circleGrowLeft.Add(new Vector2(-75, -45));
            circleGrowLeft.Add(new Vector2(-75, -45));
            circleGrowLeft.Add(new Vector2(-75, -45));
            circleGrowLeft.Add(new Vector2(-75, -45));
            circleGrowLeft.Add(new Vector2(-75, -45));
            circleGrowLeft.Add(new Vector2(-75, -45));
            circleGrowLeft.Add(new Vector2(-75, -45));
            circleGrowLeft.Add(new Vector2(-75, -45));
            circleGrowLeft.Add(new Vector2(-75, -45));
            circleGrowLeft.Add(new Vector2(-75, -45));
            circleGrowLeft.Add(new Vector2(-75, -45));
            circleGrowLeft.Add(new Vector2(-75, -45));
            circleGrowLeft.Add(new Vector2(-75, -45));
            circleGrowLeft.Add(new Vector2(-75, -45));
            circleGrowLeft.Add(new Vector2(-75, -45));
            circleGrowLeft.Add(new Vector2(-75, -45));

            abilityAnimations.Add("CIRCLEGROWLEFT", circleGrow);
            abilityAnimationOffsets.Add("CIRCLEGROWLEFT", circleGrowLeft);

            List<Texture2D> maxDrainCircle = new List<Texture2D>();

            maxDrainCircle.Add(content.Load<Texture2D>("Images/Abilities/Drain/DrainMax"));
            maxDrainCircle.Add(content.Load<Texture2D>("Images/Abilities/Drain/DrainMax"));
            maxDrainCircle.Add(content.Load<Texture2D>("Images/Abilities/Drain/DrainMax"));
            maxDrainCircle.Add(content.Load<Texture2D>("Images/Abilities/Drain/DrainMax"));
            maxDrainCircle.Add(content.Load<Texture2D>("Images/Abilities/Drain/DrainMax"));
            maxDrainCircle.Add(content.Load<Texture2D>("Images/Abilities/Drain/DrainMax"));
            maxDrainCircle.Add(content.Load<Texture2D>("Images/Abilities/Drain/DrainMax"));
            maxDrainCircle.Add(content.Load<Texture2D>("Images/Abilities/Drain/DrainMax"));
            maxDrainCircle.Add(content.Load<Texture2D>("Images/Abilities/Drain/DrainMax"));
            maxDrainCircle.Add(content.Load<Texture2D>("Images/Abilities/Drain/DrainMax"));

            List<Vector2> maxDrainUp = new List<Vector2>();

            maxDrainUp.Add(new Vector2(-45, -75));
            maxDrainUp.Add(new Vector2(-45, -75));
            maxDrainUp.Add(new Vector2(-45, -75));
            maxDrainUp.Add(new Vector2(-45, -75));
            maxDrainUp.Add(new Vector2(-45, -75));
            maxDrainUp.Add(new Vector2(-45, -75));
            maxDrainUp.Add(new Vector2(-45, -75));
            maxDrainUp.Add(new Vector2(-45, -75));
            maxDrainUp.Add(new Vector2(-45, -75));
            maxDrainUp.Add(new Vector2(-45, -75));

            abilityAnimations.Add("MAXDRAINUP", maxDrainCircle);
            abilityAnimationOffsets.Add("MAXDRAINUP", maxDrainUp);

            List<Vector2> maxDrainDown = new List<Vector2>();

            maxDrainDown.Add(new Vector2(-45, -15));
            maxDrainDown.Add(new Vector2(-45, -15));
            maxDrainDown.Add(new Vector2(-45, -15));
            maxDrainDown.Add(new Vector2(-45, -15));
            maxDrainDown.Add(new Vector2(-45, -15));
            maxDrainDown.Add(new Vector2(-45, -15));
            maxDrainDown.Add(new Vector2(-45, -15));
            maxDrainDown.Add(new Vector2(-45, -15));
            maxDrainDown.Add(new Vector2(-45, -15));
            maxDrainDown.Add(new Vector2(-45, -15));

            abilityAnimations.Add("MAXDRAINDOWN", maxDrainCircle);
            abilityAnimationOffsets.Add("MAXDRAINDOWN", maxDrainDown);

            List<Vector2> maxDrainRight = new List<Vector2>();

            maxDrainRight.Add(new Vector2(-15, -45));
            maxDrainRight.Add(new Vector2(-15, -45));
            maxDrainRight.Add(new Vector2(-15, -45));
            maxDrainRight.Add(new Vector2(-15, -45));
            maxDrainRight.Add(new Vector2(-15, -45));
            maxDrainRight.Add(new Vector2(-15, -45));
            maxDrainRight.Add(new Vector2(-15, -45));
            maxDrainRight.Add(new Vector2(-15, -45));
            maxDrainRight.Add(new Vector2(-15, -45));
            maxDrainRight.Add(new Vector2(-15, -45));

            abilityAnimations.Add("MAXDRAINRIGHT", maxDrainCircle);
            abilityAnimationOffsets.Add("MAXDRAINRIGHT", maxDrainRight);

            List<Vector2> maxDrainLeft = new List<Vector2>();

            maxDrainLeft.Add(new Vector2(-75, -45));
            maxDrainLeft.Add(new Vector2(-75, -45));
            maxDrainLeft.Add(new Vector2(-75, -45));
            maxDrainLeft.Add(new Vector2(-75, -45));
            maxDrainLeft.Add(new Vector2(-75, -45));
            maxDrainLeft.Add(new Vector2(-75, -45));
            maxDrainLeft.Add(new Vector2(-75, -45));
            maxDrainLeft.Add(new Vector2(-75, -45));
            maxDrainLeft.Add(new Vector2(-75, -45));
            maxDrainLeft.Add(new Vector2(-75, -45));

            abilityAnimations.Add("MAXDRAINLEFT", maxDrainCircle);
            abilityAnimationOffsets.Add("MAXDRAINLEFT", maxDrainLeft);
        }

        public Dictionary<string, List<Texture2D>> getAbilityAnimations()
        {
            return abilityAnimations;
        }

        public Dictionary<string, List<Vector2>> getAbilityAnimationOffsets()
        {
            return abilityAnimationOffsets;
        }
    }
}
