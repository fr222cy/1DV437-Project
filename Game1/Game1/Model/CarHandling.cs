using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game1.Model
{
    class CarHandling
    {
        const float maxMaxSpeed = -4.5f;
        const float minMaxSpeed = -3.5f;
        float maxspeed = -4f;

        const float maxAcceleration = 1f;
        const float minAcceleration = 0.1f;
        float acceleration = 0.5f;

        const float maxSteering = 0.04f;
        const float minSteering = 0.02f;
        float steeringModifier = 0.030f;
        float playerSteering ;

        public CarHandling()
        {

        }

        public float getMaxSpeed()
        {
            return maxspeed;
        }

        public float getAcceleration()
        {
            return acceleration;
        }

        public float getSteeringModifier()
        {
            return steeringModifier;
        }

        public void setMaxSpeed(float value)
        {
             if(maxspeed >= maxMaxSpeed && maxspeed <= minMaxSpeed)
                maxspeed -= value;
        }

        public void setAcceleration(float value)
        {
             if(acceleration <= maxAcceleration && acceleration >= minAcceleration)
                acceleration += value;
        }

        public void setSteeringModifier(float value)
        {
             if(steeringModifier <= maxSteering && steeringModifier >= minSteering)
             {
                 steeringModifier += value;
             }
        }


        public void reset()
        {
            maxspeed = -4f;
            acceleration = 0.5f;
            steeringModifier = 0.030f;
        }
    }
}
