﻿using System;
using System.Collections.Generic;
using System.Text;

namespace proiect_sah
{
    public class Bishop : Piece
    {
        public Bishop(Color c)
        {
            this.Color = c;
            this.pieceType = PieceType.Bishop;

        }
        int[,] AllLegalMoves = new int[9, 9];
        public override int[,] Moves(int starti, column startj)
        {
            int diff = starti - (int)startj;
            int i, j;
            if (diff < 0)
            {
                diff *= -1;
                i = 1;
                j = i + diff;
                while (j <= 8)
                {
                    AllLegalMoves[i, j] = 1;
                    j++;
                    i++;
                }
            }
            if (diff > 0)
            {
                j = 1;
                i = j + diff;
                while (i <= 8)
                {
                    AllLegalMoves[i, j] = 1;
                    i++;
                    j++;
                }
            }
            i = starti;
            j = (int)startj;
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
