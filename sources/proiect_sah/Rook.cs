using System;
using System.Collections.Generic;
using System.Text;

namespace proiect_sah
{
    class Rook : Piece
    {
        public Rook(Color c)
        {
            this.Color = c;

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
            return AllLegalMoves;
        }
    }
}
