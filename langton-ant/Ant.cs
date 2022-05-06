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
        up = 0,
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
            direction = (Direction)random.Next(4);

            timer = new Timer();
            timer.Interval = interval;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Color fieldColor = board.ColorMap[position.X, position.Y];
            if(fieldColor == Color.White)
            {
                TurnAnt(Direction.left);
                board.updateColor(position.X, position.Y, color);
            }
            else if(fieldColor == color)
            {
                TurnAnt(Direction.right);
                board.updateColor(position.X, position.Y, Color.White);
            }
            else
            {
                TurnAnt(Direction.left);
                TurnAnt(Direction.left);
                board.updateColor(position.X, position.Y, color);
            }

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
                    if(position.X < 0)
                    {
                        position.X = 0;
                        direction = Direction.right;
                    }
                    break;

                case Direction.right:
                    position.X += 1;
                    if (position.X > board.Width - 1)
                    {
                        position.X = board.Width - 1;
                        direction = Direction.left;
                    }
                    break;
            }
        }

        private void TurnAnt(Direction directionToTurn)
        {
            switch(direction)
            {
                case Direction.up:
                    if(directionToTurn == Direction.left)
                    {
                        direction = Direction.left;
                    }
                    else
                    {
                        direction = Direction.right;
                    }
                    break;

                case Direction.down:
                    if (directionToTurn == Direction.left)
                    {
                        direction = Direction.right;
                    }
                    else
                    {
                        direction = Direction.left;
                    }
                    break;

                case Direction.left:
                    if (directionToTurn == Direction.left)
                    {
                        direction = Direction.down;
                    }
                    else
                    {
                        direction = Direction.up;
                    }
                    break;

                case Direction.right:
                    if (directionToTurn == Direction.left)
                    {
                        direction = Direction.up;
                    }
                    else
                    {
                        direction = Direction.down;
                    }
                    break;
            }
        }

        public Point Position { get => position; set => position = value; }
        public Color Color { get => color; set => color = value; }
        internal Direction Direction { get => direction; set => direction = value; }
    }
}
