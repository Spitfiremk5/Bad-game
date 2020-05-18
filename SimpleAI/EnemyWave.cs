// Aby użyć, wezwij metode InitializeBotArrayAndSpawn() w form1
// a potem Addcontrols(form1), z każdym użyciem tych dwóch metod
// będzie o 2 więcej wrogów.

using System;
using System.Windows.Forms;

namespace SimpleAI
{    
    class EnemyWave
    {    
        int wavecount = 0;
        static int howmany = 1;
        Bot[] bots;   
               
        public void InitializeBotArrayAndSpawn()
        {            
            if (howmany < 2)
            {
                howmany++;
            }

            bots = new Bot[howmany];     
            
            Random randx = new Random();
            Random randy = new Random();

            int botspawny;
            int botspawnx;        
            
            for (int i = 0; i < howmany; i++)
            {              
                botspawny = randy.Next(200);
                botspawnx = randx.Next(1920);
                
                randy.Next(1920);
                randx.Next(200);
                bots[i] = new Bot();                              
                bots[i].SetSpawnLocation(botspawnx, botspawny);
            }
            wavecount++;
        }

        public Form AddControls(Form form)
        {
            for (int i = 0; i < howmany; i++)
            {
                Console.WriteLine(i);
                form.Controls.Add(bots[i].pb);
            }
            return form;
        }

    }
}