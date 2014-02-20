using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Animation
{
    interface MenuAnimationInterface
    {

        int getAnimationDelay();
        List<Image> getAnimationImages();
        int getAnimationIndex();
        void advanceAnimation();
        bool isAnimationFinished();
        void startAnimation();
    }
}
