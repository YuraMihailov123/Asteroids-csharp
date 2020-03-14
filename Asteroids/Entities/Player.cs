using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids.Entities
{
    public class Player
    {
        public int xPos;
        public int yPos;

        public int dirX;
        public int size;
        public bool isMoving;

        public Image spritesheet;

        public Player(int xPos,int yPos, Image spritesheet)
        {
            this.xPos = xPos;
            this.yPos = yPos;
            this.spritesheet = spritesheet;
            size = 50;
        }

        public void Move()
        {
            xPos += dirX;
        }
    }
}
