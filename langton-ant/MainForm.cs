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

            board = new Board(30, 20);
            random = new Random();
            for(int i = 0; i < 20; i++)
            {
                randomColor = Color.FromArgb(random.Next(128),
                                             random.Next(128),
                                             random.Next(128));

                board.AddAnt(randomColor, random.Next(80)+40);
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
            tileSize.X = (gamePictureBox.Width - 1)  / (float)board.Width;
            tileSize.Y = (gamePictureBox.Height - 1) / (float)board.Height;

            gamePictureBox.Image = new Bitmap(gamePictureBox.Width, gamePictureBox.Height);
            Graphics g = Graphics.FromImage(gamePictureBox.Image);
            g.Clear(Color.White);

            for(int x = 0; x < board.Width; x++)
            {
                for(int y = 0; y < board.Height; y++)
                {
                    Rectangle rect = new Rectangle((int)(x * tileSize.X) + 1,
                                                    (int)(y * tileSize.Y) + 1,
                                                    (int)tileSize.X - 2,
                                                    (int)tileSize.Y - 2);
                    SolidBrush brush = new SolidBrush(board.ColorMap[x, y]);

                    g.DrawRectangle(new Pen(Color.Black), rect);
                    g.FillRectangle(brush, rect);
                }
            }

            foreach(Ant ant in board.AntList)
            {
                Rectangle rect = new Rectangle((int)(ant.Position.X * tileSize.X) + 1,
                                               (int)(ant.Position.Y * tileSize.Y) + 1,
                                               (int)tileSize.X - 2,
                                               (int)tileSize.Y - 2);

                g.FillRectangle(new SolidBrush(ant.Color), rect);
            }


            gamePictureBox.Refresh();
        }
        
    }
}
