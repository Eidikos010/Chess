using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Board
    {
        static public Piece[,] chessBoard = new Piece[8,8];
        static public void ChessBoard() {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    chessBoard[i, j] = new Empty(i, j);
                }
            } 
        }
            
           



    }
}
