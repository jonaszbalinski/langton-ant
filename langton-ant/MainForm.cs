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
        public MainForm()
        {
            InitializeComponent();

            board = new Board(20, 20);

            board.AddAnt(new Ant(Color.AliceBlue, board.Width, board.Height));
            board.AddAnt(new Ant(Color.DarkSeaGreen, board.Width, board.Height));
            board.AddAnt(new Ant(Color.IndianRed, board.Width, board.Height));
        }
    }
}
