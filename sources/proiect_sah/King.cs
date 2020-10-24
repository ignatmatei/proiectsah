using System;
using System.Collections.Generic;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;

namespace proiect_sah
{
   public  class King : Piece
    {
        public King(Color c)
        {
            //de fiecare data cnd new King()
            base.pieceType = PieceType.King;
            this.Color = c;
            bool HasKingMoved = false;
        }

        static King()
        {

            //1 singura data
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


        }
        
        static int[] di = new int[8];
        static int[] dj = new int[8];

        private bool isOK(int i, int j)
        {
            if (i >= 1 && i <= 8 && j>= 1 && j <= 8) return true;
            return false;
        }
        int[,] AllLegalMoves = new int[9, 9];
        public  override int[,] Moves (int starti, column startj)
        {

            for (int i = 1; i <= 8; i++)
                for (int j = 1; j <= 8; j++)
                    AllLegalMoves[i, j] = 0;
            
            int nexti , nextj, directions;
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
