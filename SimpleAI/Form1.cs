
using System;
using System.Windows.Forms;



namespace SimpleAI
{
   
    public partial class Form1 : Form
    {               
        public Form1()
        {
            InitializeComponent();           
        }       
        Player p1 = new Player();
        EnemyWave wave1 = new EnemyWave();
        Timer timebetweenwaves = new Timer();        
        int wavenum;
        string wavetime;

        void WavePacing()
        {
            wavenum++;
            int time = wavenum * 3000;                  
            timebetweenwaves.Interval = time;
            timebetweenwaves.Tick += new EventHandler(timebetweenwavesTick);
            timebetweenwaves.Start();
        }
        public void timebetweenwavesTick(object source, System.EventArgs e)
        {
            timebetweenwaves.Stop();
            StartWave();
        }

        void StartWave()
        {
            wave1.InitializeBotArrayAndSpawn();
            wave1.AddControls(this);
            WavePacing();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StartWave();
            p1.SetSpawnLocation(300, 300);
            Controls.Add(Player.playerbox);                               
            Controls.Add(Projectile.proj);
        }


        Projectile pj1 = new Projectile();
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            p1.Movement(sender,e);
        }     
        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            pj1.Launch();
        }      
    }
}
