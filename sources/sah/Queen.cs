using System;
using System.Collections.Generic;
using System.Text;

namespace proiect_sah
{
    public class Queen : Piece
    {
        public Queen(Color c)
        {
            this.Color = c;
            this.pieceType = PieceType.Queen;
        }
        int[,] AllLegalMoves = new int[9, 9];
        public override int[,] Moves(int starti, column startj)
        {
            int i, j;
            for (i = 1; i <= 8; i++)
                for (j = 1; j <= 8; j++)
                    AllLegalMoves[i, j] = 0;
            for (i = 1; i <= 8; i++)
                AllLegalMoves[i, (int)startj] = 1;
            for (j = 1; j <= 8; j++)
                AllLegalMoves[starti, j] = 1;
            i = starti;
            j = (int)startj;
            while (i >= 1 && j >= 1)
            {
                AllLegalMoves[i, j] = 1;
                i--;
                j--;
            }
            i = starti;
            j = (int)startj;
            while (i <= 8 && j <= 8)
            {
                AllLegalMoves[i, j] = 1;
                i++;
                j++;
            }
            while (i >= 1 && j <= 8)
            {
                AllLegalMoves[i, j] = 1;
                i--;
                j++;
            }
            i = starti;
            j = (int)startj;
            while (i <= 8 && j >= 1)
            {
                AllLegalMoves[i, j] = 1;
                i++;
                j--;
            }
            return AllLegalMoves;
        }
    }
}
