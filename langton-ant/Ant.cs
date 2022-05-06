using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace langton_ant
{
    enum Direction
    {
        up,
        down,
        left,
        right
    }
    internal class Ant
    {
        private Point position;
        private Color color;
        private Direction direction;
        private Random random;
        private Timer timer;
        private Board board;
        public Ant(Board board, Color color, int interval)
        {
            random = new Random();
            this.board = board;

            Position = new Point();
            this.color = color;
            position.X = random.Next(board.Width);
            position.Y = random.Next(board.Height);
            direction = Direction.up;

            timer = new Timer();
            timer.Interval = interval;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            switch(direction)
            {
                case Direction.up:
                    position.Y -= 1;
                    if(position.Y < 0)
                    {
                        position.Y = 0;
                        direction = Direction.down;
                    }
                    break;

                case Direction.down:
                    position.Y += 1;
                    if(position.Y > board.Height - 1)
                    {
                        position.Y = board.Height - 1;
                        direction = Direction.up;
                    }
                    break;

                case Direction.left:
                    position.X -= 1;
                    break;

                case Direction.right:
                    position.X += 1;
                    break;
            }
        }

        public Point Position { get => position; set => position = value; }
        public Color Color { get => color; set => color = value; }
        internal Direction Direction { get => direction; set => direction = value; }
    }
}
