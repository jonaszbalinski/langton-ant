using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace langton_ant
{
    internal class Board
    {
        private Color[,] colorMap;
        private List<Ant> antList;
        private int width;
        private int height;

        public Board(int x, int y)
        {
            colorMap = new Color[x, y];
            for(int i = 0; i < x; i++)
            {
                for(int j = 0; j < y; j++)
                {
                    colorMap[i, j] = Color.White;
                }
            }
            antList = new List<Ant>();
            width = x;
            height = y;
        }

        public void AddAnt(Ant newAnt)
        {
            antList.Add(newAnt);
        }

        public void AddAnt(Color color, int interval)
        {
            Ant newAnt = new Ant(this, color, interval);
            antList.Add(newAnt);
        }

        public void updateColor(int x, int y, Color color)
        {
            colorMap[x, y] = color;
        }

        public int Width { get => width; set => width = value; }
        public int Height { get => height; set => height = value; }
        internal List<Ant> AntList { get => antList; set => antList = value; }
        public Color[,] ColorMap { get => colorMap; set => colorMap = value; }
    }
}
