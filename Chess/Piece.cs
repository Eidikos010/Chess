using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    abstract class Piece
    {
        public String name;
        public int id;
        public Boolean color;
        public Point position;

        public abstract void Move();
        public abstract void Attack();
    }
    class Pawn : Piece
    {

        public Pawn(int a, int b, Boolean c) {
            this.name = "Pawn";
            this.position.X = a;
            this.position.Y = b;
            this.color = c;

        }



        public override void Attack()
        {

        }

        public override void Move()
        {
            if (this.position.Y == 1 && Board.chessBoard[this.position.X, this.position.Y + 1] is Empty && Board.chessBoard[this.position.X, this.position.Y + 2] is Empty)
                this.position.Y += 2;

            else if (this.position.Y < 6 && Board.chessBoard[this.position.X, this.position.Y + 1] is Empty)
                this.position.Y += 1;

            else if (this.position.Y == 1 && Board.chessBoard[this.position.X, this.position.Y + 1] is Empty)
                this.position.Y += 1;
            else if (this.position.Y == 6 && Board.chessBoard[this.position.X, this.position.Y + 1] is Empty)
            {
                this.position.Y += 1;
                this.transform();
            }
        }

        private void transform()
        {

        }
    }
    class Empty : Piece
    {

        public Empty(int a, int b) {

            this.position.X = a;
            this.position.Y = b;
            this.name = "Empty block";
            if (b % 2 == 0 && a % 2 == 0)
                this.color = false;
            else if (b % 2 == 1 && a % 2 == 1)
                this.color = false;
            else
                this.color = true;
        }
        public override void Attack()
        {
            throw new NotImplementedException();
        }

        public override void Move()
        {
            throw new NotImplementedException();
        }
    }
    class Rook : Piece
    {
        public Rook(int a, int b, Boolean c) {
            this.position.X = a;
            this.position.Y = b;
            this.color = c;
            this.name = "Rook";

        }
        public override void Attack()
        {
            throw new NotImplementedException();
        }

        public override void Move()
        {

            for (int i = this.position.Y; i < 7; i++)
            {
                int emptySpaces = 0;
                for (int j = this.position.Y; j < i; j++)
                {
                    if (Board.chessBoard[this.position.X, j] is Empty)
                        emptySpaces += 1;
                }
                if (emptySpaces == i - this.position.Y)
                {
                    this.position.Y = i;
                    return;
                }
            }
            for (int i = this.position.X; i < 7; i++) {
                int emptySpaces = 0;
                for (int j = this.position.X; j < i; j++)
                {
                    if (Board.chessBoard[j, this.position.Y] is Empty)
                        emptySpaces += 1;
                }
                if (emptySpaces == i - this.position.X) {
                    this.position.X = i;
                    return;
                }
            }
            for (int i = this.position.Y; i >0 ; i--)
            {
                int emptySpaces = 0;
                for (int j = this.position.Y; j > i; j--)
                {
                    if (Board.chessBoard[this.position.X, j] is Empty)
                        emptySpaces += 1;
                }
                if (emptySpaces == Math.Abs(i - this.position.Y))
                {
                    this.position.Y = i;
                    return;
                }
            }
            for (int i = this.position.X; i > 0; i--) {
                int emptySpaces = 0;
                for (int j = this.position.X; j > i; j--)
                {
                    if (Board.chessBoard[j, this.position.Y] is Empty)
                        emptySpaces += 1;
                }
                if (emptySpaces == Math.Abs(i - this.position.X))
                {
                    this.position.X = i;
                    return;
                }
            }
        }
    }
    class Knight : Piece
    {

        public Knight(int a, int b, Boolean c) {
            this.position.X = a;
            this.position.Y = b;
            this.color = c;
            this.name = "Knight";
        }




        public override void Attack()
        {
            throw new NotImplementedException();
        }

        public override void Move()
        {
            if (this.position.X + 1 <= 7 && this.position.Y + 2 <= 7 && Board.chessBoard[this.position.X + 1, this.position.Y + 2] is Empty)
            {
                this.position.X += 1;
                this.position.Y += 2;
            }
            else if (this.position.X + 1 <= 7 && this.position.Y - 2 >= 0 && Board.chessBoard[this.position.X + 1, this.position.Y - 2] is Empty)
            {
                this.position.X += 1;
                this.position.Y -= 2;
            }
            else if (this.position.X - 1 >= 0 && this.position.Y + 2 <= 7 && Board.chessBoard[this.position.X - 1, this.position.Y + 2] is Empty)
            {
                this.position.X -= 1;
                this.position.Y += 2;
            }
            else if (this.position.X - 1 >= 0 && this.position.Y - 2 >= 0 && Board.chessBoard[this.position.X - 1, this.position.Y - 2] is Empty)
            {
                this.position.X -= 1;
                this.position.Y -= 2;
            }
            else if (this.position.X + 2 <= 7 && this.position.Y + 1 <= 7 && Board.chessBoard[this.position.X + 2, this.position.Y + 1] is Empty)
            {
                this.position.X += 2;
                this.position.Y += 1;
            }
            else if (this.position.X + 2 <= 7 && this.position.Y - 1 >= 0 && Board.chessBoard[this.position.X + 2, this.position.Y - 1] is Empty)
            {
                this.position.X += 2;
                this.position.Y -= 1;
            }
            else if (this.position.X - 2 >= 0 && this.position.Y + 1 <= 7 && Board.chessBoard[this.position.X - 2, this.position.Y + 1] is Empty)
            {
                this.position.X -= 2;
                this.position.Y += 1;
            }
            else if (this.position.X - 2 >= 0 && this.position.Y - 1 >= 0 && Board.chessBoard[this.position.X - 2, this.position.Y - 1] is Empty)
            {
                this.position.X -= 2;
                this.position.Y -= 1;
            }


        }
    }
    class Bishop : Piece
    {


        public Bishop (int a, int b, Boolean c) {
            this.position.X = a;
            this.position.Y = b;
            this.color = c;
            this.name = "Bishop";
        }





    public override void Attack()
        {
            throw new NotImplementedException();
        }

        public override void Move()
        {
            for (Point p = this.position; p.X <= 7 && p.X >= 0 && p.Y >= 0 && p.Y <= 7; p.X++, p.Y++) {
                int emptySpaces = 0;
                for (Point j = this.position; j.X < p.X && j.Y<p.Y; j.X++,j.Y++)
                {
                    if (Board.chessBoard[j.X, j.Y] is Empty)
                        emptySpaces += 1;
                }
                if (emptySpaces == p.X - this.position.X)
                {
                    this.position = p;
                    return;
                }
            }
            for (Point p = this.position; p.X <= 7 && p.X >= 0 && p.Y >= 0 && p.Y <= 7; p.X++, p.Y--)
            {
                int emptySpaces = 0;
                for (Point j = this.position; j.X < p.X && j.Y > p.Y; j.X++, j.Y--)
                {
                    if (Board.chessBoard[j.X, j.Y] is Empty)
                        emptySpaces += 1;
                }
                if (emptySpaces == p.X - this.position.X)
                {
                    this.position = p;
                    return;
                }
            }
            for (Point p = this.position; p.X <= 7 && p.X >= 0 && p.Y >= 0 && p.Y <= 7; p.X--, p.Y--)
            {
                int emptySpaces = 0;
                for (Point j = this.position; j.X > p.X && j.Y > p.Y; j.X--, j.Y--)
                {
                    if (Board.chessBoard[j.X, j.Y] is Empty)
                        emptySpaces += 1;
                }
                if (emptySpaces == this.position.X- p.X)
                {
                    this.position = p;
                    return;
                }
            }
            for (Point p = this.position; p.X <= 7 && p.X >= 0 && p.Y >= 0 && p.Y <= 7; p.X--, p.Y++)
            {
                int emptySpaces = 0;
                for (Point j = this.position; j.X > p.X && j.Y < p.Y; j.X--, j.Y++)
                {
                    if (Board.chessBoard[j.X, j.Y] is Empty)
                        emptySpaces += 1;
                }
                if (emptySpaces == p.Y - this.position.Y)
                {
                    this.position = p;
                    return;
                }
            }
        }
                
    }
    class Queen : Piece
    {

        public Queen(int a, int b, Boolean c)
        {
            this.position.X = a;
            this.position.Y = b;
            this.color = c;
            this.name = "Queen";
        }


        public override void Attack()
        {
            throw new NotImplementedException();
        }

        public override void Move()
        {
            new Rook(this.position.X, this.position.Y, this.color).Move();
            new Bishop(this.position.X, this.position.Y, this.color).Move();

        }
    }
    class King : Piece
    {
        public King(int a, int b, Boolean c)
        {
            this.position.X = a;
            this.position.Y = b;
            this.color = c;
            this.name = "King";
        }

        public override void Attack()
        {
            throw new NotImplementedException();
        }

        public override void Move()
        {
            if (this.position.X + 1 <= 7 && this.position.Y + 1 <= 7 && Board.chessBoard[this.position.X + 1, this.position.Y + 1] is Empty)
            {
                this.position.X += 1;
                this.position.Y += 1;
            }
            else if (this.position.X - 1 >= 0 && this.position.Y + 1 <= 7 && Board.chessBoard[this.position.X - 1, this.position.Y + 1] is Empty)
            {
                this.position.X -= 1;
                this.position.Y += 1;
            }
            else if (this.position.X + 1 <= 7 && this.position.Y - 1 >= 0 && Board.chessBoard[this.position.X + 1, this.position.Y - 1] is Empty)
            {
                this.position.X += 1;
                this.position.Y -= 1;
            }
            else if (this.position.X - 1 >= 0 && this.position.Y - 1 >= 0 && Board.chessBoard[this.position.X - 1, this.position.Y - 1] is Empty)
            {
                this.position.X -= 1;
                this.position.Y -= 1;
            }
            else if (this.position.Y + 1 <= 7 && Board.chessBoard[this.position.X, this.position.Y + 1] is Empty)
            {

                this.position.Y += 1;
            }
            else if (this.position.Y - 1 >= 0 && Board.chessBoard[this.position.X, this.position.Y - 1] is Empty)
            {
                this.position.Y -= 1;
            }
            else if (this.position.X + 1 <= 7 && Board.chessBoard[this.position.X + 1, this.position.Y] is Empty)
            {
                this.position.X += 1;
            }
            else if (this.position.X - 1 >= 0 && Board.chessBoard[this.position.X - 1, this.position.Y] is Empty)
            {
                this.position.X -= 1;
            }
            else
                //an apileite
                Console.WriteLine("Check Mate");
        }
    }
}



