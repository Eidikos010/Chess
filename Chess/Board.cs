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

        static public void StartingChessBoard()
        {
            for (int i = 0; i <= 7; i++) {
                chessBoard[1, i] = new Pawn(1, i, false);
            }
            for (int i = 0; i <= 7; i++)
            {
                chessBoard[6, i] = new Pawn(1, i, true);
            }



        }


            static public void PrintChessBoard() {
            int counter = 0;
            foreach (Piece p in chessBoard) {
                 counter++;
                if (p is Empty)
                    Console.Write("-");
                else if(p is Pawn)
                    Console.Write("p");
                else if (p is Rook)
                    Console.Write("r");
                else if (p is Knight)
                    Console.Write("n");
                else if (p is Bishop)
                    Console.Write("b");
                else if (p is Queen)
                    Console.Write("q");
                else if (p is King)
                    Console.Write("k");
                if (counter!=0 && counter % 8 == 0)
                    Console.WriteLine();
               
                
                        
            }


        }
            
           



    }
}
