
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SimpleAI
{
    class Projectile : Player
    {       
        public static PictureBox proj;
        public static int projX;
        public static int projY;       
        static bool despawned = false;
        Timer yeet = new Timer();
        public static Timer fuse = new Timer();
        public static int playerheading;
        Image image = Image.FromFile("D:\\VS projects\\SimpleAI\\Textures\\placeholder.png");
        public Projectile()
        {
            proj = new PictureBox();
            proj.Image = image;
            proj.Size = new Size(20,40);           
            yeet.Interval = 20;
            yeet.Tick += new EventHandler(yeetTick);
            fuse.Interval = 7000;
            fuse.Tick += new EventHandler(fuseTick);
            proj.Visible = false;                                          
        }   
        public void Launch ()
        {
            if (Bot.playerhit == false)
            {
                fuse.Stop();
                despawned = false;
                proj.Visible = true;
                projX = playerX;
                projY = playerY;
                proj.Location = new Point(projX, projY);
                yeet.Start();
                fuse.Start();
            }
        }
        private void yeetTick(object source, System.EventArgs e)
        {
            ProjLogic(); 
        }

        private void fuseTick(object source, System.EventArgs e)
        {
            fuse.Stop();
            Despawn();           
        }

        int projectilespeed = 12;
        private void ProjLogic()
        {
            yeet.Stop();
           
            if (despawned == false)
            {
                
                switch (playerheading)
                {                   
                    case 1:                        
                        projY += projectilespeed;                        
                        break;

                    case 2:                       
                        projY -= projectilespeed;                   
                        break;

                    case 3:                       
                        projX -= projectilespeed;                      
                        break;

                    case 4:                       
                        projX += projectilespeed;                      
                        break;
                }
                ChangeRocketTextureTo(playerheading);
                proj.Location = new Point(projX, projY);
                yeet.Start();
            }                    
            
        }

        int ChangeRocketTextureTo(int direction)
        {


            switch ( direction )
            {
                case 1:
                    image = Image.FromFile("D:\\VS projects\\SimpleAI\\Textures\\rocketDown.png");                  
                    proj.Size = new Size(20, 40);
                    break;

                case 2:
                    image = Image.FromFile("D:\\VS projects\\SimpleAI\\Textures\\rocketUp.png");                   
                    proj.Size = new Size(20, 40);
                    break;

                case 3:
                    image = Image.FromFile("D:\\VS projects\\SimpleAI\\Textures\\rocketLeft.png");                    
                    proj.Size = new Size(40, 20);
                    break;

                case 4:
                    image = Image.FromFile("D:\\VS projects\\SimpleAI\\Textures\\rocketRight.png");                   
                    proj.Size = new Size(40, 20);
                    break;
            }
            proj.Image = image;

            return 0;

        }
         static void Despawn()
         {         
            despawned = true;
            proj.Visible = false;
            projX = playerX;
            projY = playerY;
            proj.Location = new Point(projX, projY);
         }

       public static void Explode()
       { 
          
            //zmień tutaj teksture i rozmiar.
            Despawn();
       }

       
    }

}
