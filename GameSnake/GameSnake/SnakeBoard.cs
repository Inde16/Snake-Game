//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

using System.Windows.Forms;
using System.Drawing;


namespace GameSnake
{    
    public class SnakeBoard
    {
        public int Rows;
        public int Cols;  
        public Color BgColor;

        private Panel pnl;
        private Graphics g;
        private float cellHeight; 
        private float cellWidth; 

        public SnakeBoard(Panel pnl, int rows = 20, int cols = 46, Color? bgColor = null)
        {
            // Color? <=> nullable <Color>
            this.Rows = rows;
            this.Cols = cols;
            this.BgColor = bgColor ?? Color.Aqua;
            this.pnl = pnl;            
            //Resize();
        }
        
        public void Resize()
        {
            cellHeight = pnl.Height / (float)Rows;
            cellWidth = pnl.Width / (float)Cols;
            g = pnl.CreateGraphics();
            lock (this)
            {
                g.Clear(BgColor);
            }
        }

        public void Clear()
        {
            lock (this)
            {
                g.Clear(BgColor);
            }
        }

        public void DrawXY(int x, int y, Color color)
        {
            Brush b = new SolidBrush(color);
            lock (this)
            {
                g.FillEllipse(b, x * cellWidth, y * cellHeight, cellWidth, cellHeight);                
            }
         }
        public void DrawXY(Point p, Color color)
        {
            DrawXY(p.X, p.Y, color);
        }
                
        public void ClearXY(int x, int y)
        {
            DrawXY(x, y, BgColor);
            /*
            Brush b = new SolidBrush(BgColor);
            lock (this)
            {
                g.FillRectangle(b, x * cellWidth, y * cellHeight, cellWidth, cellHeight);
            }
             * */

        }
        public void ClearXY(Point p)
        {
            DrawXY(p.X, p.Y,BgColor);
        }
    }
}
