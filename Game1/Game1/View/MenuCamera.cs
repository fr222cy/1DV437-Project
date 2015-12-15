using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1.View
{
    class MenuCamera
    {

        private float scaleX;
        private float scaleY;
        private float scale;
        

        public MenuCamera(Viewport port)
        {

            scaleX = port.Width;
            scaleY = port.Height;

            if(scaleX > scaleY)
            {
                scale = scaleX;
            }
            else
            {
                scale = scaleY;
            }

        }

        public Vector2 getViewCoords(Vector2 position, float textureWidth, float textureHeight)
        {
            float screenX = (scaleX * position.X);
            float screenY = (scaleY * position.Y);

            return new Vector2(screenX, screenY);
        }

        public Vector2 getClickModelCoords(Vector2 position)
        { 

            float logicalX = (position.X / scaleX);
            float logicalY = (position.Y / scaleY);

            return new Vector2(logicalX, logicalY);
        }


        public float getScale(float width)
        {
            return scale / width ;
        }

        public float getModelWidth(float width)
        {
            return width / scaleX ;
        }

        public float getModelHeight(float height)
        {
            return height / scaleY;
        }



    }
}

