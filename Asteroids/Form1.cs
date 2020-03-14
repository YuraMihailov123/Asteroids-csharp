using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Asteroids.Entities;
using Asteroids.Controllers;
using System.Threading;

namespace Asteroids
{
    public partial class Form1 : Form
    {
        public Image spritesheet;
        public Player player;
        public float asteroidToSpawn;
        public Form1()
        {
            InitializeComponent();

            spritesheet = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Sprites\\spritesheet.png"));

            this.KeyDown += new KeyEventHandler(KeyboardCallback);
            this.KeyUp += new KeyEventHandler(KeyboardUpCallback);

            timer1.Interval = 10;
            timer1.Tick += new EventHandler(UpdateCallback);
            timer1.Start();

            Init();
        }

        private void KeyboardUpCallback(object sender, KeyEventArgs e)
        {
            player.isMoving = false;
            player.dirX = 0;
        }

        private void UpdateCallback(object sender, EventArgs e)
        {
            if (AsteroidsController.Collide(player))
            {
                Init();                
            }

            if (asteroidToSpawn > 0)
                asteroidToSpawn -= (float)timer1.Interval/300;
            if (asteroidToSpawn <= 0)
            {
                MapController.AddAsteroid();
                asteroidToSpawn = 2f;
            }


            if (player.isMoving)
                player.Move();

            for (int i = 0; i < MapController.Asteroids.Count; i++)
                MapController.Asteroids[i].Move();

            Invalidate();
        }

        private void KeyboardCallback(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A:
                    player.dirX = -3;
                    player.isMoving = true;
                    break;
                case Keys.D:
                    player.dirX = 3;
                    player.isMoving = true;
                    break;
            }
        }

        public void Init()
        {
            MapController.Asteroids.Clear();
            player = new Player(300, 400, spritesheet);
            asteroidToSpawn = 2f;
            MapController.AddAsteroid();
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
                        
            g.DrawImage(player.spritesheet, new Rectangle(new Point(player.xPos, player.yPos), new Size(player.size, player.size)), 202, 0, 60, 46, GraphicsUnit.Pixel);

            for (int i = 0; i < MapController.Asteroids.Count; i++)
                g.DrawImage(player.spritesheet, new Rectangle(new Point(MapController.Asteroids[i].xPos, MapController.Asteroids[i].yPos), new Size(60, 60)), 0, 324, 73, 60, GraphicsUnit.Pixel);
        }
    }
}
