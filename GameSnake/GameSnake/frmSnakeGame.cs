using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameSnake
{
    public partial class frmSnakeGame : Form
    {
        SnakeGame game=null;
                
        public frmSnakeGame()
        {
            InitializeComponent();            
        }

        private void frmSnakeGame_Load(object sender, EventArgs e)
        {
            lblInfo.Text = "+/- Αλλαγή ταχύτητας." +
              "\nP: Pause ON/OFF";
            game = new SnakeGame(this, pnlBoard);
        }
        
        private void frmSnakeGame_Shown(object sender, EventArgs e)
        {             
            game.Run();
        }
        
        private void frmSnakeGame_KeyDown(object sender, KeyEventArgs e)
        {
            //game.KeyDown(e);
            if (game == null) return;
            if (e.KeyCode == Keys.Left)
            {
                if (game.Direction != Direction.RIGHT) { game.Direction = Direction.LEFT; }
            }
            else if (e.KeyCode == Keys.Right)
            {
                if (game.Direction != Direction.LEFT) { game.Direction = Direction.RIGHT; }
            }
            else if (e.KeyCode == Keys.Up)
            {
                if (game.Direction != Direction.DOWN) { game.Direction = Direction.UP; }
            }
            else if (e.KeyCode == Keys.Down)
            {
                if (game.Direction != Direction.UP) { game.Direction = Direction.DOWN; }
            }

            else if (e.KeyCode == Keys.Subtract) { game.Delay += 10; }
            else if (e.KeyCode == Keys.Add) { game.Delay -= 10; }
            else if (e.KeyCode == Keys.P)
            {
                if (game.State == GameState.GAMERUN)
                {
                    game.Pause();
                }
                else if (game.State == GameState.GAMEPAUSE)
                {
                    game.Continue();
                }
            }
        }

        private async void frmSnakeGame_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (game == null) return;
            game.Stop();
            if (!game.Runner.IsCompleted)
            {
#if RELESE
                this.Hide();
#endif
                e.Cancel = true;
                await game.Runner;
                this.Close();
            }
        }

        private void frmSnakeGame_Activated(object sender, EventArgs e)
        {
            //if (game == null) return;
            //game.Continue();
        }

        private void frmSnakeGame_Deactivate(object sender, EventArgs e)
        {
            if (game == null) return;
            game.Pause();
        }

        private void pnlBoard_Resize(object sender, EventArgs e)
        {
            game.RePaint();
        }

        private void pnlBoard_Paint(object sender, PaintEventArgs e)
        {
            game.RePaint();
        }

        public void WritePosition(string value)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(WritePosition), new object[] { value });
                //Invoke(new Action<string>(WritePosition), value);
                return;
            }
            this.lblPosition.Text = value;
        }

    }//end form
        
}
