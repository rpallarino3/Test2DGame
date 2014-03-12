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
        }

        public int getPriority(string animationName)
        {
            return priorities[animationName];
        }
    }
}
