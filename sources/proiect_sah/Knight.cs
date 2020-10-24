using System;
using System.Collections.Generic;
using System.Text;

namespace proiect_sah
{
    public class Knight : Piece
    {
        static Knight()
        {
            di[0] = -1;
            di[1] = 1;
            di[2] = -1;
            di[3] = 1;
            di[4] = -2;
            di[5] = -2;
            di[6] = 2;
            di[7] = 2;
            dj[0] = -2;
            dj[1] = -2;
            dj[2] = 2;
            dj[3] = 2;
            dj[4] = -1;
            dj[5] = 1;
            dj[6] = -1;
            dj[7] = 1;

        }
        
        static int[] di = new int[8];
        static int[] dj = new int[8];
        private bool isOK(int i, int j)
        {
            if (i >= 1 && i <= 8 && j >= 1 && j <= 8) return true;
            return false;
        }
        int[,] AllLegalMoves = new int[9, 9];
        public override int[,] Moves(int starti, column startj)
        {

            for (int i = 1; i <= 8; i++)
                for (int j = 1; j <= 8; j++)
                    AllLegalMoves[i, j] = 0;

            int nexti, nextj, directions;
            for (directions = 0; directions <= 7; directions++)
            {
                nexti = starti + di[directions];
                nextj = (int)startj + dj[directions];
                if (isOK(nexti, nextj))
                    AllLegalMoves[nexti, nextj] = 1;
            }
            return AllLegalMoves;
        }
    }
}
