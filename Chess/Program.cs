using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Board.ChessBoard();
            
            Board.StartingChessBoard();
            Board.PrintChessBoard();
            Board.chessBoard[0, 1].Move();
            Board.PrintChessBoard();



            Application.Run(new Form1());
           
        }
    }
}
