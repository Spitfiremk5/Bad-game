
using System;
using System.Drawing;
using System.Windows.Forms;
using SimpleAI;

public class Bot
{
    int hp = 100;
    bool dead = false;
    int spawnX;
    int spawnY;
    int botY;
    int botX;
    protected int botSpeed = 4;      
    public  PictureBox pb;
    public static  bool botshot = false;   
    public static bool playerhit = false;
    Timer delay = new Timer();
    Image image = Image.FromFile("D:\\VS projects\\SimpleAI\\Textures\\placeholder.png");
    
    public Bot()
    {
        pb = new PictureBox();
        pb.Image = image;        
        pb.Size = new Size(40, 40);
        pb.Visible = false;
        pb.Enabled = false;
        delay.Interval = 35;
        delay.Tick += new EventHandler(delayTick);
        delay.Start();
    }
    private void CollisionDetect()
    {
        if (dead == false)
        {
            if (botX < Player.playerX + 40 && botX > Player.playerX - 35)
            {
                if (botY < Player.playerY + 30 && botY > Player.playerY - 30)
                {
                    playerhit = true;                    
                }
            }
        }

    }
    public void Botlogic()
    {        
        delay.Stop();
        if ( dead == false)
        {
            if (Player.playerX > botX)
            {
                botX += botSpeed;
            }

            if (Player.playerX < botX)
            {
                botX -= botSpeed;
            }

            if (Player.playerY > botY)
            {
                botY += botSpeed;
            }

            if (Player.playerY < botY)
            {
                botY -= botSpeed;
            }
            CheckifShot();
            CollisionDetect();
            pb.Location = new Point(botX, botY);
            delay.Start();
        }
    }

    void delayTick(object source, System.EventArgs e)
    {        
        Botlogic();            
    }  

    public int SetSpawnLocation(int botspawnx, int botspawny)
    {
        spawnX = botspawnx;
        spawnY = botspawny;
        pb.Visible = true;
        pb.Location = new Point(spawnX, spawnY);
        botX = spawnX;
        botY = spawnY;        
        return 0;
    }
   
    public void CheckifShot()
    {            
        if ( Projectile.projX < botX + 20 && Projectile.projX > botX - 30 && Projectile.projY < botY + 30 && Projectile.projY > botY - 30 )
        {    
            if (hp <= 50)
            {
                Die();
            }  
            else
            {
                hp -= 50;
            }
            Projectile.Explode();
        }
    }
   
   

    public void Die()
    {     
        pb.Dispose();
        dead = true;
    }
}

