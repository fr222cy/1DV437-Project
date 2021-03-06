﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game1.Controller
{
    class Levels
    {

        int[,] map;
        //Create the TileMap
        //Inspired by http://xnatd.blogspot.se/2009/02/ok-so-first-part-of-our-tower-defence.html

        /*
        * 0 = Grass
        * 1 = Up-Down
        * 2 = Up
        * 3 = Down
        * 4 = Left
        * 5 = Right
        * 6 = Regular
        * 7 = Left-Top
        * 8 = Right-Top
        * 9 = Left-Down
        * 10 = Right-Down
        * 11 = Left-Right
        * 12 = goal
        * 13 = stand
        * 14 = pitlaneArrow
        * 15 = pitlaneStop
        * 16 = CheckPoint
        * 17 = Mud
         * 18 = arrowleft
        */

        public int[,] getLevel(int level)
        {


            if (level == 1)
            {
                return map = new int[,]
                {
                    {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                    {0,7,2,2,2,2,8,13,13,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                    {0,4,6,6,6,6,6,2,2,8,13,13,13,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                    {0,4,6,3,3,3,3,3,3,6,2,2,2,8,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                    {0,4,5,0,0,0,0,0,0,9,3,3,6,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                    {0,4,5,0,0,0,0,0,0,0,0,0,4,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                    {0,4,5,0,0,0,0,0,0,0,0,0,4,5,0,0,0,0,0,0,0,0,0,0,13,13,13,13,0,0,0,0},
                    {0,4,5,0,0,0,0,0,0,0,0,0,4,5,0,0,0,0,0,0,0,0,0,0,7,2,2,2,2,8,0,0},
                    {0,4,5,0,0,0,0,0,0,0,0,0,4,5,0,0,0,0,0,0,0,0,0,0,4,6,6,3,6,5,0,0},
                    {0,4,5,0,0,0,0,0,0,0,0,0,4,5,0,0,0,0,0,0,0,0,0,0,4,6,5,0,4,5,0,0},
                    {0,4,5,0,0,0,0,0,0,0,0,0,4,5,0,0,0,0,0,0,0,0,0,0,4,3,5,0,4,5,0,0},
                  {0,4,5,0,0,0,0,0,0,0,0,0,4,5,0,0,0,0,0,0,0,0,0,0,11,0,11,0,4,5,0,0},
                    {0,4,5,0,0,0,0,0,0,0,0,0,4,5,13,0,0,0,0,0,0,0,0,0,4,2,5,0,4,5,0,0},
                    {0,4,5,0,0,0,0,0,0,0,0,0,4,6,8,13,13,13,13,0,0,0,0,0,4,6,5,0,4,5,0,0},
                  {0,4,5,0,0,0,0,0,0,0,0,0,4,6,6,2,2,2,2,1,16,1,1,1,3,3,10,0,4,5,0,0},
                   {0,4,5,0,0,0,0,0,0,0,0,0,9,3,3,3,3,3,10,0,0,0,0,0,0,0,0,0,4,5,0,0},
                    {0,4,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,4,5,0,0},
                    {0,4,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,4,5,0,0},
                    {0,4,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,4,5,0,0},              
                    {0,4,6,8,0,0,0,0,0,0,0,0,0,0,13,13,13,13,13,0,0,0,0,0,0,0,0,7,6,10,0,0},
                    {0,4,6,6,2,2,2,2,2,2,2,2,2,2,2,2,12,2,2,2,2,2,2,2,2,2,2,6,6,0,0,0},
                    {0,9,3,3,3,6,6,3,3,3,3,3,3,3,3,3,12,3,3,3,3,3,3,3,3,3,3,14,5,0,0,0},
                    {0,0,0,0,0,4,18,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,4,5,0,0,0},
                    {0,0,0,0,0,9,3,1,1,1,1,1,1,1,1,1,15,1,1,1,1,1,1,1,1,1,3,3,10,0,0,0},
                }; 


              
            }
            if(level == 2)
            {
                return map = new int[,]
                {
                    {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                    {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                    {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                    {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                    {0,0,0,0,0,0,0,0,0,0,0,7,2,2,2,2,2,17,2,8,0,0,0,0,0,0,0,0,0,0,0,0},
                    {0,0,0,0,0,0,0,0,0,0,0,4,6,6,17,6,6,6,6,6,16,1,1,1,1,2,2,8,0,0,0,0},
                    {0,0,0,0,0,0,0,0,0,0,0,4,6,3,17,3,3,3,3,10,0,0,0,0,0,4,6,5,0,0,0,0},
                    {0,0,0,0,0,0,0,0,0,0,0,4,5,0,0,0,0,0,0,0,0,0,0,0,0,9,6,5,0,0,0,0},
                    {0,0,0,0,0,0,13,13,13,13,0,4,5,0,0,0,0,0,0,0,0,0,0,0,0,0,9,5,0,0,0,0},
                    {0,0,0,7,2,2,2,2,2,2,2,6,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,11,0,0,0,0},
                    {0,0,0,4,6,3,3,3,3,3,3,3,10,0,0,0,0,0,0,0,0,0,0,0,0,0,0,11,0,0,0,0},
                    {0,0,0,4,6,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,11,0,0,0,0},
                    {0,0,0,9,6,8,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,11,0,0,0,0},
                    {0,0,0,0,4,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,11,0,0,0,0},
                    {0,0,0,0,4,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,11,0,0,0,0},
                    {0,0,0,0,4,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,11,0,0,0,0},
                    {0,0,0,0,4,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,11,0,0,0,0},
                    {0,0,0,0,4,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,11,0,0,0,0},
                    {0,0,0,0,4,6,8,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,7,5,0,0,0,0},              
                    {0,0,0,0,4,6,5,0,0,0,0,0,0,13,13,13,13,13,13,13,13,0,0,0,0,2,6,5,0,0,0,0},
                    {0,0,0,0,4,6,6,2,2,2,2,2,2,2,2,2,12,2,2,2,2,2,2,2,2,6,6,5,0,0,0,0},
                    {0,0,0,0,9,6,6,3,3,3,3,3,3,3,3,3,12,3,3,3,3,3,3,3,3,3,6,5,0,0,0,0},
                    {0,0,0,0,0,4,18,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,14,14,0,0,0,0},
                    {0,0,0,0,0,9,3,1,1,1,1,1,1,1,1,1,15,1,1,1,1,1,1,1,1,1,3,10,0,0,0,0},
                }; 
            }
            if(level == 3)
            {
                return map = new int[,]
                {
                   {0,13,13,13,13,13,13,13,13,13,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                   {0,7,2,2,2,2,2,17,2,2,2,1,1,1,1,1,1,1,2,2,2,8,0,0,0,0,0,0,0,0,0,0},
                   {0,4,6,3,17,3,3,3,3,3,10,0,0,0,0,0,0,0,9,3,6,5,0,0,0,0,0,0,0,0,0,0},
                    {0,4,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,4,5,0,0,0,0,0,0,0,0,0,0},
                    {0,4,6,2,2,8,0,0,0,0,0,0,0,0,0,0,0,0,0,0,4,5,0,0,0,0,0,0,0,0,0,0},
                    {0,9,3,3,6,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,4,5,0,0,0,0,0,0,0,0,0,0},
                    {0,0,0,0,4,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,4,5,0,0,0,0,0,0,0,0,0,0},
                    {0,0,0,0,9,5,0,0,0,0,0,0,0,0,0,0,13,13,13,0,4,5,0,0,0,0,0,0,0,0,0,0},
                   {0,0,0,0,0,11,0,0,0,0,0,0,0,0,0,0,7,2,8,0,4,5,0,0,0,0,0,0,0,0,0,0},
                  {0,0,0,0,0,11,0,0,0,0,0,0,0,0,0,0,4,6,3,16,6,6,1,1,1,1,1,2,2,8,0,0},
                   {0,0,0,0,0,11,0,0,0,0,0,0,0,0,0,0,4,5,0,0,4,5,0,0,0,0,0,4,6,5,0,0},
                   {0,0,0,0,0,11,0,0,0,0,0,0,0,0,0,0,4,5,13,13,4,5,0,0,0,0,0,4,6,5,0,0},
                   {0,0,0,0,0,11,0,0,0,0,0,0,0,0,0,0,4,6,2,2,18,5,0,0,0,0,0,4,6,5,0,0},
                  {0,0,0,0,0,11,0,0,0,0,0,0,0,0,0,0,9,3,3,3,3,10,0,0,0,0,0,4,6,5,0,0},
                   {0,0,0,0,0,11,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,4,3,5,0,0},
                   {0,0,0,0,0,11,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,11,0,11,0,0},
                   {0,0,0,0,0,11,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,4,2,5,0,0},
                   {0,0,0,0,0,11,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,4,6,5,0,0},
                    {0,0,0,0,0,4,8,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,9,6,10,0,0},              
                    {0,0,0,0,0,4,5,0,0,0,0,0,0,0,13,13,13,13,13,13,0,0,0,0,0,0,0,0,11,0,0,0},
                    {0,0,0,0,0,4,6,18,2,2,2,2,2,2,2,2,2,12,2,2,2,2,2,2,2,2,2,2,5,0,0,0},
                    {0,0,0,0,0,4,6,18,3,3,3,3,3,3,3,3,3,12,3,3,3,3,3,3,3,3,14,14,5,0,0,0},
                    {0,0,0,0,0,4,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,4,5,0,0,0,0},
                  {0,0,0,0,0,9,3,1,1,1,1,1,1,1,1,1,15,1,1,1,1,1,1,1,1,1,3,10,0,0,0,0},
                }; 
            }
            if(level == 4)
            {
                return map = new int[,]
                {
                    {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                    {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                    {0,0,0,0,0,0,0,0,0,0,0,7,2,2,2,2,2,2,2,2,2,16,1,1,1,2,2,8,0,0,0,0},
                    {0,0,0,0,0,0,0,0,0,0,0,4,3,3,3,3,3,3,3,3,10,0,0,0,0,4,6,5,0,0,0,0},
                    {0,0,0,0,0,0,0,0,0,0,0,4,0,0,0,0,0,0,0,0,0,0,0,0,0,4,6,5,0,0,0,0},
                    {0,0,0,0,0,0,0,0,0,0,0,4,2,2,2,8,0,0,0,0,0,0,0,0,0,4,6,5,0,0,0,0},
                    {0,0,0,0,0,0,0,0,0,0,0,9,3,6,6,5,0,0,0,0,0,0,0,0,0,4,6,5,0,0,0,0},
                    {0,0,0,0,0,0,0,0,0,0,0,0,0,4,6,5,0,0,0,0,0,0,0,0,0,9,17,5,0,0,0,0},
                    {0,0,0,0,0,0,0,0,0,0,0,0,0,4,6,5,0,0,0,0,0,0,0,0,0,0,4,5,0,0,0,0},
                    {0,0,0,0,0,0,0,0,0,0,0,0,7,6,10,0,0,0,0,0,0,0,0,0,0,0,4,5,0,0,0,0},
                    {0,0,0,0,0,0,0,0,0,0,0,7,6,10,0,0,0,0,0,0,0,0,0,0,0,0,4,5,0,0,0,0},
                    {0,0,0,0,0,7,2,2,2,2,2,6,10,0,0,0,0,0,0,0,0,0,0,0,0,0,4,5,0,0,0,0},
                    {0,0,0,0,0,4,6,6,6,3,3,10,0,0,0,0,0,0,0,0,0,0,0,0,0,0,9,6,8,0,0,0},
                    {0,0,0,0,0,4,17,6,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,4,5,0,0,0},
                    {0,0,0,0,0,4,6,6,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,4,5,0,0,0},
                    {0,0,0,0,0,9,3,3,3,1,1,1,1,1,1,2,2,2,2,2,2,2,2,8,0,0,0,9,5,0,0,0},
                    {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,9,3,3,3,3,3,6,6,5,0,0,0,0,11,0,0,0},
                    {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,4,6,5,0,0,0,0,11,0,0,0},
                    {0,0,0,0,0,7,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,6,6,5,0,0,0,0,11,0,0,0},
                    {0,0,0,0,0,4,6,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,10,0,0,7,2,5,0,0,0},
                    {0,0,0,0,0,4,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,7,6,6,5,0,0,0},
                    {0,0,0,0,0,4,6,18,1,1,1,1,1,1,1,1,12,1,1,1,1,1,1,1,1,3,6,14,10,0,0,0},
                    {0,0,0,0,0,4,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,4,5,0,0,0,0},
                    {0,0,0,0,0,9,3,1,1,1,1,1,1,1,1,1,15,1,1,1,1,1,1,1,1,1,3,10,0,0,0,0},
                };
            }
            else
            {
                return map = new int[,]
                {
                    {0,0,0,0},
                };
            }

          
        }
        public float getLevelTime(int level)
        {
            if(level == 1)
            {
                return 25f;
            }
            if(level == 2)
            {
                return 18f;
            }
            if(level == 3)
            {
                return 25f;
            }
            if(level == 4)
            {
                return 25f;
            }

            else
            {
                return 500f;
            }
            
        }

      

        

    }
}
