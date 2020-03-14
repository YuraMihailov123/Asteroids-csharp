using Asteroids.Controllers;
using System.Drawing;

namespace Asteroids.Entities
{
    public class Asteroid
    {
        public int xPos;
        public int yPos;

        public int sizeX;
        public int sizeY;

        public int type;

        public Asteroid(int x, int y)
        {
            xPos = x;
            yPos = y;
            type = 1;
            sizeX = 60;
            sizeY = 60;
        }

        public void Move()
        {
            yPos += 1;

            if (yPos > 450)
                MapController.Asteroids.Remove(this);
        }
    }
}
