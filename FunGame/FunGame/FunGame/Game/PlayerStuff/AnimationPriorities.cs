using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FunGame.Game.PlayerStuff
{
    class AnimationPriorities
    {

        private readonly Dictionary<string, int> priorities;

        public AnimationPriorities()
        {
            priorities = new Dictionary<string, int>();
            fillDictionary();
        }

        private void fillDictionary()
        {
            priorities.Add("WALK_UP", 1);
            priorities.Add("WALK_DOWN", 1);
            priorities.Add("WALK_RIGHT", 1);
            priorities.Add("WALK_LEFT", 1);
            priorities.Add("STATIONARY_UP", 0);
            priorities.Add("STATIONARY_DOWN", 0);
            priorities.Add("STATIONARY_RIGHT", 0);
            priorities.Add("STATIONARY_LEFT", 0);
            priorities.Add("BORDER_WALK_UP", 1);
            priorities.Add("BORDER_WALK_DOWN", 1);
            priorities.Add("BORDER_WALK_RIGHT", 1);
            priorities.Add("BORDER_WALK_LEFT", 1);
            priorities.Add("BORDER_STATIONARY_UP", 0);
            priorities.Add("BORDER_STATIONARY_DOWN", 0);
            priorities.Add("BORDER_STATIONARY_RIGHT", 0);
            priorities.Add("BORDER_STATIONARY_LEFT", 0);

            priorities.Add("SWORD_UP", 2);
            priorities.Add("SWORD_DOWN", 2);
            priorities.Add("SWORD_RIGHT", 2);
            priorities.Add("SWORD_LEFT", 2);
            priorities.Add("BORDER_SWORD_UP", 2);
            priorities.Add("BORDER_SWORD_DOWN", 2);
            priorities.Add("BORDER_SWORD_RIGHT", 2);
            priorities.Add("BORDER_SWORD_LEFT", 2);

            priorities.Add("SWING_SWORD_UP", 2);
            priorities.Add("SWING_SWORD_DOWN", 2);
            priorities.Add("SWING_SWORD_RIGHT", 2);
            priorities.Add("SWING_SWORD_LEFT", 2);
            priorities.Add("BORDER_SWING_SWORD_UP", 2);
            priorities.Add("BORDER_SWING_SWORD_DOWN", 2);
            priorities.Add("BORDER_SWING_SWORD_RIGHT", 2);
            priorities.Add("BORDER_SWING_SWORD_LEFT", 2);
        }

        public int getPriority(string animationName)
        {
            return priorities[animationName];
        }
    }
}
