using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        private Random random = new Random();

        public Ant(Color color, Point position)
        {
            this.position = position;
            this.color = color;
        }

        public Ant(Color color, int x, int y)
        {
            Position = new Point();
            this.color = color;
            this.position.X = random.Next(x);
            this.position.Y = random.Next(y);
        }

        public Point Position { get => position; set => position = value; }
        public Color Color { get => color; set => color = value; }
        internal Direction Direction { get => direction; set => direction = value; }
    }
}
