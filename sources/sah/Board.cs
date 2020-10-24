using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace proiect_sah
{
     public enum PieceType
    {
        Nopiece = 0,
        Pawn = 1,
        Knight = 2,
        Bishop = 3,
        Rook = 5,
        Queen = 9,
        King = 50 
    }
    /// <summary>
    /// white = 1
    /// black = -1
    /// </summary>

    public class Board
    {
        public Piece GetPieceFrom(int line, column col)
        {
            var piesa = table[line, (int)col];
            Color c = Color.White;
            if (piesa < 0)
                c = Color.Black;
            var p = Piece.GetPieceFromPieceType(piesa, c);
            return p;
        }
       /* public bool IsValid (int i, int k int pas,int[,]p)
        {
            if (pas > 1)
                return false;
            return true;
        }
        /*void bkKing(int starti, int startj, int fini, int finj, int[,] p, int pas)
        {
            bool HasArrived = false;
             int[] di = new int[8];
             int[] dj = new int[8];
            for (int i = 0; i <= 7; i++)
            {
                if (i < 2) di[i] = 0;
                if (i >= 2 && i <= 4) di[i] = 1;
                if (i > 4) di[i] = -1;
            }
            dj[0] = 1;
            dj[1] = -1;
            dj[2] = -1;
            dj[3] = 0;
            dj[4] = 1;
            dj[5] = -1;
            dj[6] = 0;
            dj[7] = 1;
            if (starti == fini && startj == finj)
                HasArrived = true;
            else
            {
                int directii;
                for (directii = 0; directii < 4; directii++)
                {
                    int next_i = starti + di[directii];
                    int next_j = startj + dj[directii];
                    if()
                }
            }
        }*/
        public bool IsLegal (int pozi_init, column pozj_init, int pozi_final, column pozj_final)
        {
            
            var p = GetPieceFrom(pozi_init, pozj_init);
            Color c = p.Color;
            var pawn = new Pawn(c); 
            var moves = p.Moves(pozi_init, pozj_init);
            
            if (p == pawn)
            {
                var enemypiece1 = table[pozi_init + 1, (int)pozj_init - 1];
                var enemypiece2 = table[pozi_init + 1, (int)pozj_init + 1];
                Color colorenemypiece1 = Color.White;
                if (enemypiece1 < 0)
                    colorenemypiece1 = Color.Black;
                Color colorenemypiece2 = Color.White;
                if (enemypiece2 < 0)
                    colorenemypiece2 = Color.Black;
                if (colorenemypiece1 != c)
                {
                    moves[pozi_init + 1, (int)pozj_init - 1] = 1;
                }
                if (colorenemypiece2 != c)
                {
                    moves[pozi_init + 1, (int)pozj_init + 1] = 1;
                }

            }
            if (moves[pozi_final, (int)pozj_final] == 1) return true;
            return false;


            
          
        }
        public void MovePiece(int pozi_init, column pozj_init, int pozi_final, column pozj_final)
        {
            if(IsLegal(pozi_init, pozj_init, pozi_final , pozj_final))
            {
                var currpiece = table[pozi_init, (int)pozj_init];
                table[pozi_init, (int)pozj_init] = PieceType.Nopiece;
                table[pozi_final, (int)pozj_final] = currpiece;
            }
            throw new Exception("piesa nu se poate muta");
        }
        public PieceType[,]            table=new PieceType[9,9];


        public Board()
        {

            for (var i = 1; i <= 8; i++)
            { 
                table[2, i] = PieceType.Pawn;
                table[7, i] = (PieceType)((int) Color.Black * (int)PieceType.Pawn);
                
            }
            table[1, 2] = PieceType.Knight;
            table[1, 7] = PieceType.Knight;
            table[8, 2] = (PieceType)((int)Color.Black * (int)PieceType.Knight);
            table[8, 7] = (PieceType)((int)Color.Black * (int)PieceType.Knight);
            table[1, 1] = PieceType.Rook;
            table[1, 8] = PieceType.Rook;
            table[1, 3] = PieceType.Bishop;
            table[1, 6] = PieceType.Bishop;
            table[1, 5] = PieceType.King;
            table[1, 4] = PieceType.Queen;
            table[8, 1] = (PieceType)((int)Color.Black * (int)PieceType.Rook);
            table[8, 8] = (PieceType)((int)Color.Black * (int)PieceType.Rook);
            table[8, 3] = (PieceType)((int)Color.Black * (int)PieceType.Bishop);
            table[8, 6] = (PieceType)((int)Color.Black * (int)PieceType.Bishop);

        }

    }
}
