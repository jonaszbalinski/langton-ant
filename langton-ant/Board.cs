using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace langton_ant
{
    internal class Board
    {
        private List<Ant> antList;
        private int width;
        private int height;

        public Board(int x, int y)
        {
            antList = new List<Ant>();
            Width = x;
            Height = y;
        }

        public void AddAnt(Ant newAnt)
        {
            antList.Add(newAnt);
        }

        public int Width { get => width; set => width = value; }
        public int Height { get => height; set => height = value; }
        internal List<Ant> AntList { get => antList; set => antList = value; }
    }
}
