using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace langton_ant
{
    public partial class MainForm : Form
    {
        Board board;
        Random random;
        Color randomColor;
        Timer timer;
        public MainForm()
        {
            InitializeComponent();

            int boardWidth = 144;
            int boardHeight = 81;
            double populationPercent = 10;
            int populationSize = (int)((boardWidth*boardHeight) * (populationPercent/100.0));

            board = new Board(boardWidth, boardWidth);
            random = new Random();
            
            for(int i = 0; i < populationSize; i++)
            {
                randomColor = Color.FromArgb(random.Next(256),
                                             random.Next(256),
                                             random.Next(256));

                board.AddAnt(randomColor, random.Next(120)+40);
            }

            timer = new Timer();
            timer.Interval = 60;
            timer.Tick += Main_Tick;
            timer.Start();
        }

        private void Main_Tick(object sender, EventArgs e)
        {
            DrawBoard();
        }
        private void DrawBoard()
        {
            PointF tileSize = new PointF();
            tileSize.X = (gamePictureBox.Width)  / (float)board.Width;
            tileSize.Y = (gamePictureBox.Height) / (float)board.Height;

            gamePictureBox.Image = new Bitmap(gamePictureBox.Width, gamePictureBox.Height);
            Graphics g = Graphics.FromImage(gamePictureBox.Image);
            g.Clear(Color.White);

            for(int x = 0; x < board.Width; x++)
            {
                for(int y = 0; y < board.Height; y++)
                {
                    Rectangle rect = new Rectangle((int)(x * tileSize.X),
                                                    (int)(y * tileSize.Y),
                                                    (int)tileSize.X,
                                                    (int)tileSize.Y);
                    SolidBrush brush = new SolidBrush(board.ColorMap[x, y]);

                    //g.DrawRectangle(new Pen(Color.Black), rect);
                    g.FillRectangle(brush, rect);
                }
            }

            foreach(Ant ant in board.AntList)
            {
                Rectangle rect = new Rectangle((int)(ant.Position.X * tileSize.X),
                                               (int)(ant.Position.Y * tileSize.Y),
                                               (int)tileSize.X,
                                               (int)tileSize.Y);

                //g.FillRectangle(new SolidBrush(ant.Color), rect);
                g.FillEllipse(new SolidBrush(ant.Color), rect);
            }


            gamePictureBox.Refresh();
        }
        
    }
}
