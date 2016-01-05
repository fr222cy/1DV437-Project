using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game1.Model
{
    class SoundHandler
    {


        
        int crash = 0;
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



    }
}
