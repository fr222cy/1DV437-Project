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

        const float maxSteerSlowDown = 0.999f;
        const float minSteerSlowDown = 0.990f;
        float steerSlowDown = 0.995f;

        float resources = 15f;
        const float minResources = 0f;

        public float getResources()
        {
            return resources;
        }

        public float getSteerSlowdown()
        {
            return steerSlowDown;
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

        public void setSteerslowDown(float value)
        {
            if (steerSlowDown <= maxSteerSlowDown && steerSlowDown >= minSteerSlowDown && hasResources())
            {
                steerSlowDown += value;
                removeResources();
            }
          
        }

        public void setMaxSpeed(float value)
        {
            if (maxspeed >= maxMaxSpeed && maxspeed <= minMaxSpeed && hasResources())
                maxspeed -= value;
                removeResources();
        }

        public void setAcceleration(float value)
        {
            if (acceleration <= maxAcceleration && acceleration >= minAcceleration && hasResources())
                acceleration += value;
                removeResources();
        }

        public void setSteeringModifier(float value)
        {
             if(steeringModifier <= maxSteering && steeringModifier >= minSteering && hasResources())
             {
                 steeringModifier += value;
                 removeResources();
             }
        }

        public void removeResources()
        {
            if (resources >= minResources)
                resources -= 0.01f;
        }

        public bool hasResources()
        {
            if (resources > minResources)
                return true;
            else
            {
                return false;
            }
        }

        public void reset()
        {
            resources = 15f;
            maxspeed = -4f;
            acceleration = 0.5f;
            steeringModifier = 0.030f;
            steerSlowDown = 0.994f;
        }
    }
}
