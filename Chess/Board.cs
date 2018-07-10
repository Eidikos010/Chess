using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Board
    {
        static public Piece[,] chessBoard = new Piece[8, 8];
        static public void ChessBoard()
        {
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
            for (int i = 0; i <= 7; i++)
            {
                chessBoard[1, i] = new Pawn(1, i, false);
            }
            chessBoard[0, 0] = new Rook(0, 0, false);
            chessBoard[0, 7] = new Rook(0, 0, false);
            chessBoard[0, 1] = new Knight(0, 1, false);
            chessBoard[0, 6] = new Knight(0, 6, false);
            chessBoard[0, 2] = new Bishop(0, 2, false);
            chessBoard[0, 5] = new Bishop(0, 5, false);
            chessBoard[0, 3] = new Queen(0, 3, false);
            chessBoard[0, 4] = new King(0, 4, false);
            for (int i = 0; i <= 7; i++)
            {
                chessBoard[6, i] = new Pawn(1, i, true);
            }
            chessBoard[7, 0] = new Rook(7, 0, true);
            chessBoard[7, 7] = new Rook(7, 0, true);
            chessBoard[7, 1] = new Knight(7, 1, true);
            chessBoard[7, 6] = new Knight(7, 6, true);
            chessBoard[7, 2] = new Bishop(7, 2, true);
            chessBoard[7, 5] = new Bishop(7, 5, true);
            chessBoard[7, 3] = new Queen(7, 3, true);
            chessBoard[7, 4] = new King(7, 4, true);



        }


        static public void PrintChessBoard()
        {
            int counter = 0;
            foreach (Piece p in chessBoard)
            {
                counter++;
                if (p is Empty)
                    Console.Write("-");
                else if (p is Pawn)
                    if (p.color)
                        Console.Write("P");
                    else
                        Console.Write("p");
                else if (p is Rook)
                    if (p.color)
                        Console.Write("R");
                    else
                        Console.Write("r");
                else if (p is Knight)
                    if (p.color)
                        Console.Write("N");
                    else
                        Console.Write("n");
                else if (p is Bishop)
                    if (p.color)
                        Console.Write("B");
                    else
                        Console.Write("b");
                else if (p is Queen)
                    if (p.color)
                        Console.Write("Q");
                    else
                        Console.Write("q");
                else if (p is King)
                    if (p.color)
                        Console.Write("K");
                    else
                        Console.Write("k");
                if (counter != 0 && counter % 8 == 0)
                    Console.WriteLine();



            }         
        }
    }
}
