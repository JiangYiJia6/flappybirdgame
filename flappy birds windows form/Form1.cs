using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace flappy_birds_windows_form
{
    public partial class Form1 : Form
    {
        int pipeSpeed=8;
        int gravity = 5;
        int score = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void gameTimerEvent(object sender, EventArgs e)
        {
            flappybird.Top += gravity;
            pipebottom.Left -= pipeSpeed;
            pipetop.Left -= pipeSpeed;
            scoreText.Text = "score:"+score.ToString();

            if (pipebottom.Left < -150)
            {
                pipebottom.Left = 800;
                score++;
            }
            if (pipetop.Left < -180) 
            {
                pipetop.Left = 950;
                score++;
            }
            if (flappybird.Bounds.IntersectsWith(pipebottom.Bounds)|| flappybird.Bounds.IntersectsWith(pipetop.Bounds)|| flappybird.Bounds.IntersectsWith(ground.Bounds))
            {
                endGame();
            }
            if (score > 5)
            {
                pipeSpeed = 18;
            }
            if (score > 10)
            {
                pipeSpeed = 20;
            }


            if (flappybird.Top < -25)
            {
                endGame();
            }
        }

        private void gamekeyisdown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Space)
            {
                gravity = -5;
               
            }
        }

        private void gamekeyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = 5;
                
            }
        }
        private void endGame()
        {
            gameTimer.Stop();
            scoreText.Text += "  game over";
        }
    }
}
