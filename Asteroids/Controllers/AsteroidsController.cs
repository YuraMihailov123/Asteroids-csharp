using Asteroids.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids.Controllers
{
    public static class AsteroidsController
    {

        public static bool Collide(Player player)
        {
            for(int i = 0; i < MapController.Asteroids.Count; i++)
            {
                int deltaX = (player.xPos + player.size / 2) - (MapController.Asteroids[i].xPos + MapController.Asteroids[i].sizeX / 2);
                int deltaY = (player.yPos + player.size / 2) - (MapController.Asteroids[i].yPos + MapController.Asteroids[i].sizeY / 2);

                if(Math.Abs(deltaX)<= player.size / 2 + MapController.Asteroids[i].sizeX / 2)
                {
                    if (Math.Abs(deltaY) <= player.size / 2 + MapController.Asteroids[i].sizeY / 2)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

    }
}
