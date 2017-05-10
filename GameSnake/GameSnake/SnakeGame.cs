using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;


namespace GameSnake
{    
    public enum GameState : byte
    {
        GAMEOVER = 0,
        GAMEPAUSE = 1,
        GAMERUN = 2
    }

    public enum Direction: byte 
    {
        UP = 0,
        LEFT = 1,
        DOWN = 2,
        RIGHT = 3
    }

    internal class SnakeSegnement
    {
        public Point Point;
        public Direction Direction; 
        public SnakeSegnement(Point point, Direction direction)
        {
            this.Point = point;
            this.Direction = direction;
        }
    }

    public class SnakeGame
    {        
        public Direction Direction = Direction.RIGHT;        
        public int Delay {
            get { return _delay; }
            set { _delay = (value < 10) ? 0 : value; }
        }
        public GameState State = GameState.GAMEOVER;
        public Color ColorBody = Color.Black;
        public Color ColorHead = Color.Green;
        public Task Runner;

        private int _delay=200;
        private int scor=0;        
        
        private Point pos = new Point();
        private frmSnakeGame parentForm;
        private SnakeBoard board;
        private Point bonus;
        private List<SnakeSegnement> snake = new List<SnakeSegnement>();
                       
        public SnakeGame(frmSnakeGame frm, Panel p)
        {
            parentForm = frm;
            board = new SnakeBoard(p,cols:30);
            this.Init();
        }

        private void Init()
        {
            State = GameState.GAMEOVER;
            snake.Clear();
            Direction = Direction.RIGHT;
            for (int i = 4; i >= 0; i--)
            {
                snake.Add(new SnakeSegnement(new Point(i, board.Cols / 2), Direction));
            }
            pos = new Point(4, board.Cols / 2);
            scor = 0;
            Delay = 200;
        }

        public void Stop()
        {
            State = GameState.GAMEOVER;
        }

        public void Pause()
        {
            if(State== GameState.GAMERUN ) State = GameState.GAMEPAUSE;
        }

        public void Continue()
        {
            if (State == GameState.GAMEPAUSE) State = GameState.GAMERUN;
        }

        public void Run()
        {
            Runner = new Task(runGame);
            State = GameState.GAMERUN;
            RePaint();
            Runner.Start();
        }

        private void runGame()
        {
            while (State != GameState.GAMEOVER)
            {
                try 
                {
                    move();
                    parentForm.WritePosition(pos.ToString());
                    Runner.Wait(_delay);
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }                              
            }
        }

        private void move()
        {
            if (State != GameState.GAMERUN)
            {
                return;
            }

            switch (Direction)
            {
                case Direction.UP: pos.Y--; break;
                case Direction.DOWN: pos.Y++; break;
                case Direction.RIGHT: pos.X++; break;
                case Direction.LEFT: pos.X--;  break;
            }

            if (!checkPosition())
            {
                State = GameState.GAMEOVER;
            }
            else {
                Point tempPoint = snake[snake.Count - 1].Point;
                snake.RemoveAt(snake.Count - 1);
                board.ClearXY(tempPoint);
                
                snake.Insert(0, new SnakeSegnement(pos, Direction));
            }
            
            board.DrawXY(snake[0].Point, Color.Green);
            board.DrawXY(snake[1].Point, Color.Black);
        }

        private bool checkPosition()
        {
            bool retv=false;
            if (pos.X < 0) { pos.X = board.Cols - 1; }
            else if (pos.X >= board.Cols) { pos.X = 0; }
            else if (pos.Y < 0) { pos.Y = board.Rows - 1; }
            else if (pos.Y >= board.Rows) { pos.Y = 0; }
            
         
            retv = !inSnakeList(pos);
            return retv;
        }

        private bool inSnakeList(Point p)
        {            
            bool retv=true;
            try  {
                SnakeSegnement listItem = snake.First(s => s.Point == p);
            }
            catch { retv = false;  };
            return retv;
        }

        public void RePaint()
        {
            if (snake.Count == 0) return;
            parentForm.SuspendLayout();
            board.Resize();
            board.DrawXY(snake[0].Point, ColorHead);
            for (int i = 1; i < snake.Count; i++)
            {
                board.DrawXY(snake[i].Point, ColorBody);
            }
            parentForm.ResumeLayout(false);
        }
    }
}
