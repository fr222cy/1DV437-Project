using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game1.Model
{
    class SoundHandler
    {


        int tire_scream = 0;
        int crash = 0;
        int mud = 0;
        int goal = 0;
        public void setCrash()
        {
            if(crash == 0)
            {
                crash = 1;
            }         
        }
        
        public bool isCrashing()
        {
            if (crash == 1)
            {
                crash = 0;
                return true;
            }  
            else
            {
                return false;
            }
                
        }

        public void setTireScream()
        {
            if(tire_scream == 0)
            {
                tire_scream = 1;
            }
        }

        public bool isTireScreaming()
        {
            if(tire_scream == 1)
            {
                tire_scream = 0;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void setMud()
        {
            if (mud == 0)
            {
                mud = 1;
            }
        }

        public bool isInMud()
        {
            if (mud == 1)
            {
                mud = 0;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void setGoalSound()
        {
            if (goal == 0)
            {
                goal = 1;
            }
        }

        public bool isInGoal()
        {
            if (goal == 1)
            {
                goal = 0;
                return true;
            }
            else
            {
                return false;
            }

        }



    }
}
