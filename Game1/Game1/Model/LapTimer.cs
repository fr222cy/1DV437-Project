using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game1.Model
{
    class LapTimer
    {

        float lapTimer;
        bool lapComplete = false;
   

        public LapTimer()
        {
            lapTimer = 0;
        }

        public void update(float elapsedTime)
        {
            if(!lapComplete)
            lapTimer += elapsedTime;
        }

        public void lapCompleted()
        {
            lapComplete = true;
        }

        public float getLapTime()
        {
            return lapTimer;
        }



        
    }
}
