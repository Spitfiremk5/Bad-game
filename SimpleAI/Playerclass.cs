
using System.Drawing;
using System.Windows.Forms;


namespace SimpleAI
{
    class Player
    {

        public bool playerShot = false;
        int playerSpeed = 6;
        public static int playerY = 200;
        public static int playerX = 200;
        protected bool playerHit = false;

        private int playerhead = 0;
        // 1 = left, 2 = right, 3 = up, 4 = down

        public static PictureBox playerbox;
        Image image = Image.FromFile("D:\\VS projects\\SimpleAI\\Textures\\placeholder.png");

        public Player()
        {
            playerbox = new PictureBox();
            playerbox.Image = (image);
            playerbox.Size = new Size(40, 40);
            playerbox.Visible = false;
        }

        public void Movement(object sender, KeyEventArgs e)
        {
            playerbox.Location = new Point(playerX, playerY);
            if (Bot.playerhit == false && playerShot == false)
            {
                switch (e.KeyCode)
                {
                    case Keys.Down:

                        playerY += playerSpeed;
                        playerhead = 1;
                        break;


                    case Keys.Up:

                        playerY -= playerSpeed;
                        playerhead = 2;
                        break;

                    case Keys.Left:

                        playerX -= playerSpeed;
                        playerhead = 3;
                        break;

                    case Keys.Right:

                        playerX += playerSpeed;
                        playerhead = 4;
                        break;
                }
                Projectile.playerheading = playerhead;
            }
        }
            public int SetSpawnLocation(int playerspawnx, int playerspawny)
             {
                playerX = playerspawnx;
                playerY = playerspawny;
                playerbox.Visible = true;
                playerbox.Location = new Point(playerX, playerY);
                return 0;
             }
    }
}


