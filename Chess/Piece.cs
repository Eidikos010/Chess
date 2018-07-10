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
        public Point position = new Point();

        public abstract void Move();
        public abstract void Attack();
        public static void Print(Piece piece) {



        }
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
            int x = this.position.X;
            int y = this.position.Y;
            if (x+1<=7 && y+1<=7 && !(Board.chessBoard[x + 1, y + 1] is Empty) && Board.chessBoard[x + 1, y + 1].color != this.color)
            {
                Board.chessBoard[x + 1, y + 1] = new Empty(x + 1, y + 1);
                this.position.X += 1;
                this.position.Y += 1;
            }
            else if (!(Board.chessBoard[x - 1, y + 1] is Empty) && Board.chessBoard[x - 1, y + 1].color != Board.chessBoard[x, y].color)
            {
                Board.chessBoard[x - 1, y + 1] = new Empty(x - 1, y + 1);
                this.position.X -= 1;
                this.position.Y += 1;
            }
        }

        public override void Move()
        {
 /*-----------------------------------ti tha ginei me ta apo pano??---------------------------------------*/
            int x = this.position.X;
            int y = this.position.Y;
            if (y == 1 && Board.chessBoard[x, y + 1] is Empty && Board.chessBoard[x, y + 2] is Empty)
                this.position.Y += 2;

            else if (y < 6 && Board.chessBoard[x, y + 1] is Empty)
                this.position.Y += 1;

            else if (y == 1 && Board.chessBoard[x, y + 1] is Empty)
                this.position.Y += 1;
            else if (y == 6 && Board.chessBoard[x, y + 1] is Empty)
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
            int originalX = this.position.X;
            int originalY = this.position.Y;


            int y = originalY;
            int x = originalX;

            while (Board.chessBoard[this.position.X, y] is Empty && y<7) {
                y++;
            }
            if (Board.chessBoard[this.position.X, y].color != Board.chessBoard[this.position.X, this.position.Y].color) {
                Board.chessBoard[this.position.X, y] = new Empty(this.position.X, y);
                this.position.Y = y;
            }
            y = originalY;
            while (Board.chessBoard[this.position.X, y] is Empty && y>0)
            {
                y--;
            }
            if (Board.chessBoard[this.position.X, y].color != Board.chessBoard[this.position.X, this.position.Y].color)
            {
                Board.chessBoard[this.position.X, y] = new Empty(this.position.X, y);
                this.position.Y = y;
            }
            y = originalY;
            while (Board.chessBoard[x, this.position.Y] is Empty && x>0)
            {
                x--;
            }
            if (Board.chessBoard[x, this.position.Y].color != Board.chessBoard[this.position.X, this.position.Y].color)
            {
                Board.chessBoard[x, this.position.Y] = new Empty(x, this.position.Y);
                this.position.X = x;
            }
            x = originalX;
            while (Board.chessBoard[x, this.position.Y] is Empty && x<7)
            {
                x++;
            }
            if (Board.chessBoard[x, this.position.Y].color != this.color)
            {
                Board.chessBoard[x, this.position.Y] = new Empty(x, this.position.Y);
                this.position.X = x;
            }
            x = originalX;
        }

        public override void Move()
        {
            int x = this.position.X;
            int y = this.position.Y;
            for (int i = y; i < 7; i++)
            {
                int emptySpaces = 0;
                for (int j = y; j < i; j++)
                {
                    if (Board.chessBoard[x, j] is Empty)
                        emptySpaces += 1;
                }
                if (emptySpaces == i - y)
                {
                    this.position.Y = i;
                    //fonazeis ton mini max

                    return;
                }
            }
            for (int i = x; i < 7; i++) {
                int emptySpaces = 0;
                for (int j = x; j < i; j++)
                {
                    if (Board.chessBoard[j, y] is Empty)
                        emptySpaces += 1;
                }
                if (emptySpaces == i - x) {
                    this.position.X = i;
                    return;
                }
            }
            for (int i = y; i >0 ; i--)
            {
                int emptySpaces = 0;
                for (int j = y; j > i; j--)
                {
                    if (Board.chessBoard[x, j] is Empty)
                        emptySpaces += 1;
                }
                if (emptySpaces == Math.Abs(i - y))
                {
                    this.position.Y = i;
                    return;
                }
            }
            for (int i = x; i > 0; i--) {
                int emptySpaces = 0;
                for (int j = x; j > i; j--)
                {
                    if (Board.chessBoard[j, y] is Empty)
                        emptySpaces += 1;
                }
                if (emptySpaces == Math.Abs(i - x))
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
            int x = this.position.X;
            int y = this.position.Y;
            if (x+1<=7 && y+2<=7 && !(Board.chessBoard[x + 1, y + 2] is Empty) && Board.chessBoard[x + 1, y + 2].color != this.color) {
                Board.chessBoard[x + 1, y + 2] = new Empty(x + 1, y + 2);
                this.position.X = x;
                this.position.Y = y;
            }
         
            if (x+1<=7 && y-2>=0 && !(Board.chessBoard[x + 1, y - 2] is Empty) && Board.chessBoard[x + 1, y - 2].color != this.color)
            {
                Board.chessBoard[x + 1, y - 2] = new Empty(x + 1, y - 2);
                this.position.X = x;
                this.position.Y = y;
            }
        
            if (x-1>=0 && y+2 <=7 && !(Board.chessBoard[x - 1, y + 2] is Empty) && Board.chessBoard[x - 1, y + 2].color != this.color)
            {
                Board.chessBoard[x - 1, y + 2] = new Empty(x - 1, y + 2);
                this.position.X = x;
                this.position.Y = y;
            }
          
            if (x-1>=0 && y-2>=0 && !(Board.chessBoard[x - 1, y - 2] is Empty) && Board.chessBoard[x - 1, y - 2].color != this.color)
            {
                Board.chessBoard[x - 1, y - 2] = new Empty(x - 1, y - 2);
                this.position.X = x;
                this.position.Y = y;
            }
        
            if (x+2<= 7 && y+1 <= 7 && !(Board.chessBoard[x + 2, y + 1] is Empty) && Board.chessBoard[x + 2, y + 1].color != this.color)
            {
                Board.chessBoard[x + 2, y + 1] = new Empty(x + 2, y + 1);
                this.position.X = x;
                this.position.Y = y;
            }
           
            if (x+2<= 7 && y-1>=0 && !(Board.chessBoard[x + 2, y - 1] is Empty) && Board.chessBoard[x + 2, y - 1].color != this.color)
            {
                Board.chessBoard[x + 2, y - 1] = new Empty(x + 2, y - 1);
                this.position.X = x;
                this.position.Y = y;
            }
            if (x-2>=0 && y+1 <=7 && !(Board.chessBoard[x - 2, y + 1] is Empty) && Board.chessBoard[x - 2, y + 1].color != this.color)
            {
                Board.chessBoard[x - 2, y + 1] = new Empty(x - 2, y + 1);
                this.position.X = x;
                this.position.Y = y;
            }
            if (x-2>=0 && y-1>=0 && !(Board.chessBoard[x - 2, y - 1] is Empty) && Board.chessBoard[x - 2, y - 1].color != this.color)
            {
                Board.chessBoard[x - 2, y - 1] = new Empty(x - 2, y - 1);
                this.position.X = x;
                this.position.Y = y;
            }
        }

        public override void Move()
        {
            int x = this.position.X;
            int y = this.position.Y;
            if (x + 1 <= 7 && y + 2 <= 7 && Board.chessBoard[x + 1, y + 2] is Empty)
            {
                this.position.X += 1;
                this.position.Y += 2;
            }
            else if (x + 1 <= 7 && y - 2 >= 0 && Board.chessBoard[x + 1, y - 2] is Empty)
            {
                this.position.X += 1;
                this.position.Y -= 2;
            }
            else if (x - 1 >= 0 && y + 2 <= 7 && Board.chessBoard[x - 1, y + 2] is Empty)
            {
                this.position.X -= 1;
                this.position.Y += 2;
            }
            else if (x - 1 >= 0 && y - 2 >= 0 && Board.chessBoard[x - 1, y - 2] is Empty)
            {
                this.position.X -= 1;
                this.position.Y -= 2;
            }
            else if (x + 2 <= 7 && y + 1 <= 7 && Board.chessBoard[x + 2, y + 1] is Empty)
            {
                this.position.X += 2;
                this.position.Y += 1;
            }
            else if (x + 2 <= 7 && y - 1 >= 0 && Board.chessBoard[x + 2, y - 1] is Empty)
            {
                this.position.X += 2;
                this.position.Y -= 1;
            }
            else if (x - 2 >= 0 && y + 1 <= 7 && Board.chessBoard[x - 2, y + 1] is Empty)
            {
                this.position.X -= 2;
                this.position.Y += 1;
            }
            else if (x - 2 >= 0 && y - 1 >= 0 && Board.chessBoard[x - 2, y - 1] is Empty)
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
            int x = this.position.X;
            int y = this.position.Y;
            int tempX = x;
            int tempY = y;
            while (Board.chessBoard[tempX, tempY] is Empty && tempX < 7 && tempY < 7)
            {
                tempX++;
                tempY++;
            }
            if (Board.chessBoard[tempX, tempY].color != this.color)
            {
                Board.chessBoard[tempX, tempY] = new Empty(tempX, tempY);
                this.position.X = tempX;
                this.position.Y = tempY;
            }
            tempX = x;
            tempY = y;
            while (Board.chessBoard[tempX, tempY] is Empty && tempX > 0 && tempY < 7)
            {
                tempX--;
                tempY++;
            }
            if (Board.chessBoard[tempX, tempY].color != this.color)
            {
                Board.chessBoard[tempX, tempY] = new Empty(tempX, tempY);
                this.position.X = tempX;
                this.position.Y = tempY;

            }
            tempX = x;
            tempY = y;
            while (Board.chessBoard[tempX, tempY] is Empty && tempX > 0 && tempY > 0)
            {
                tempX--;
                tempY--;
            }
            if (Board.chessBoard[tempX, tempY].color != this.color)
            {
                Board.chessBoard[tempX, tempY] = new Empty(tempX, tempY);
                this.position.X = tempX;
                this.position.Y = tempY;

            }
            tempX = x;
            tempY = y;
            while (Board.chessBoard[tempX, tempY] is Empty && tempX < 7 && tempY > 0)
            {
                tempX++;
                tempY--;
            }
            if (Board.chessBoard[tempX, tempY].color != this.color)
            {
                Board.chessBoard[tempX, tempY] = new Empty(tempX, tempY);
                this.position.X = tempX;
                this.position.Y = tempY;

            }
        }

        public override void Move()
        {
            Point originalPosition = this.position;
            for (Point p = originalPosition; p.X <= 7 && p.X >= 0 && p.Y >= 0 && p.Y <= 7; p.X++, p.Y++) {
                int emptySpaces = 0;
                for (Point j = originalPosition; j.X < p.X && j.Y<p.Y; j.X++,j.Y++)
                {
                    if (Board.chessBoard[j.X, j.Y] is Empty)
                        emptySpaces += 1;
                }
                if (emptySpaces == p.X - originalPosition.X)
                {
                    this.position = p;
                    return;
                }
            }
            for (Point p = originalPosition; p.X <= 7 && p.X >= 0 && p.Y >= 0 && p.Y <= 7; p.X++, p.Y--)
            {
                int emptySpaces = 0;
                for (Point j = originalPosition; j.X < p.X && j.Y > p.Y; j.X++, j.Y--)
                {
                    if (Board.chessBoard[j.X, j.Y] is Empty)
                        emptySpaces += 1;
                }
                if (emptySpaces == p.X - originalPosition.X)
                {
                    this.position = p;
                    return;
                }
            }
            for (Point p = originalPosition; p.X <= 7 && p.X >= 0 && p.Y >= 0 && p.Y <= 7; p.X--, p.Y--)
            {
                int emptySpaces = 0;
                for (Point j = originalPosition; j.X > p.X && j.Y > p.Y; j.X--, j.Y--)
                {
                    if (Board.chessBoard[j.X, j.Y] is Empty)
                        emptySpaces += 1;
                }
                if (emptySpaces == originalPosition.X- p.X)
                {
                    this.position = p;
                    return;
                }
            }
            for (Point p = originalPosition; p.X <= 7 && p.X >= 0 && p.Y >= 0 && p.Y <= 7; p.X--, p.Y++)
            {
                int emptySpaces = 0;
                for (Point j = originalPosition; j.X > p.X && j.Y < p.Y; j.X--, j.Y++)
                {
                    if (Board.chessBoard[j.X, j.Y] is Empty)
                        emptySpaces += 1;
                }
                if (emptySpaces == p.Y - originalPosition.Y)
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
            new Rook(this.position.X, this.position.Y, this.color).Attack();
            new Bishop(this.position.X, this.position.Y, this.color).Attack();
            /* auto exei problima logika giati tha bazei sti thesi pou brike oxi basilisa
             * alla analoga rook i bishop*/

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
            int x = this.position.X;
            int y = this.position.Y;

            if (x + 1 <= 7 && y + 1 <= 7 && !(Board.chessBoard[x + 1, y + 1] is Empty) && Board.chessBoard[x + 1, y + 1].color != this.color)
            {
                Board.chessBoard[x + 1, y + 1] = new Empty(x + 1, y + 1);
                this.position.X = x + 1;
                this.position.Y = y + 1;
            }
            if (y + 1 <= 7 && !(Board.chessBoard[x, y + 1] is Empty) && Board.chessBoard[x, y + 1].color != this.color) { 
                Board.chessBoard[x, y + 1] = new Empty(x, y + 1);
                this.position.Y = y + 1;
            }
            if (x - 1 >= 0 && y + 1 <= 7 && !(Board.chessBoard[x - 1, y + 1] is Empty) && Board.chessBoard[x - 1, y + 1].color != this.color)
            {
                Board.chessBoard[x - 1, y + 1] = new Empty(x - 1, y + 1);
                this.position.X = x - 1;
                this.position.Y = y + 1;
            }
            if (x - 1 >= 0 && !(Board.chessBoard[x - 1, y] is Empty) && Board.chessBoard[x - 1, y].color != this.color)
            {
                Board.chessBoard[x - 1, y] = new Empty(x - 1, y);
                this.position.X = x - 1;
            }
            if (x - 1 >= 0 && y - 1 >= 0 && !(Board.chessBoard[x - 1, y - 1] is Empty) && Board.chessBoard[x - 1, y - 1].color != this.color)
            {
                Board.chessBoard[x - 1, y - 1] = new Empty(x - 1, y - 1);
                this.position.X = x - 1;
                this.position.Y = y - 1;
            }
            if (y - 1 >= 0 && !(Board.chessBoard[x, y - 1] is Empty) && Board.chessBoard[x, y - 1].color != this.color)
            {
                Board.chessBoard[x, y - 1] = new Empty(x, y - 1);
                this.position.Y = y - 1;
            }
            if (x + 1 <= 7 && y - 1 >= 0 && !(Board.chessBoard[x + 1, y - 1] is Empty) && Board.chessBoard[x + 1, y - 1].color != this.color)
            {
                Board.chessBoard[x + 1, y - 1] = new Empty(x + 1, y - 1);
                this.position.X = x + 1;
                this.position.Y = y - 1;
            }
            if (x + 1 <= 7 && !(Board.chessBoard[x + 1, y] is Empty) && Board.chessBoard[x + 1, y].color != this.color)
            {
                Board.chessBoard[x + 1, y] = new Empty(x + 1, y);
                this.position.X = x + 1;
                
            }



        }

        public override void Move()
        {
            int x = this.position.X;
            int y = this.position.Y;

            if (x + 1 <= 7 && y + 1 <= 7 && Board.chessBoard[x + 1, y + 1] is Empty)
            {
                this.position.X += 1;
                this.position.Y += 1;
            }
            else if (x - 1 >= 0 && y + 1 <= 7 && Board.chessBoard[x - 1, y + 1] is Empty)
            {
                this.position.X -= 1;
                this.position.Y += 1;
            }
            else if (x + 1 <= 7 && y - 1 >= 0 && Board.chessBoard[x + 1, y - 1] is Empty)
            {
                this.position.X += 1;
                this.position.Y -= 1;
            }
            else if (x - 1 >= 0 && y - 1 >= 0 && Board.chessBoard[x - 1, y - 1] is Empty)
            {
                this.position.X -= 1;
                this.position.Y -= 1;
            }
            else if (y + 1 <= 7 && Board.chessBoard[x, y + 1] is Empty)
            {

                this.position.Y += 1;
            }
            else if (y - 1 >= 0 && Board.chessBoard[x, y - 1] is Empty)
            {
                this.position.Y -= 1;
            }
            else if (x + 1 <= 7 && Board.chessBoard[x + 1, y] is Empty)
            {
                this.position.X += 1;
            }
            else if (x - 1 >= 0 && Board.chessBoard[x - 1, y] is Empty)
            {
                this.position.X -= 1;
            }
            else
                //an apileite
                Console.WriteLine("Check Mate");           
        }
    }
}



