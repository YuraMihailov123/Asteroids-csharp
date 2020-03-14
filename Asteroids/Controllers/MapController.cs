using Asteroids.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids.Controllers
{
    public static class MapController
    {
        public static List<Asteroid> Asteroids = new List<Asteroid>();

        public static int width = 800;
        public static int height = 600;

        public static void AddAsteroid()
        {
            Random r = new Random();
            int xPos = r.Next(0, width);
            int yPos = r.Next(-100, -50);

            Asteroid asteroid = new Asteroid(xPos,yPos);
            Asteroids.Add(asteroid);
        }
    }
}
