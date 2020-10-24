using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using System.Text;

namespace proiect_sah
{
    class Pawn : Piece
    {
        public Pawn(Color c ):base()
        {
            this.Color = c;

        }
        private bool isOK(int i, int j)
        {
            if (i >= 1 && i <= 7 && j >= 1 && j <= 7) return true;
            return false;
        }
        int[,] AllLegalMoves = new int[9, 9];
        XoY [] Allcapture = new XoY [2]; 
        public override int[,] Moves(int starti, column startj)
        {
            for (int i = 1; i <= 8; i++)
                for (int j = 1; j <= 8; j++)
                    AllLegalMoves[i, j] = 0;
            if (starti == 2) AllLegalMoves[starti + 2, (int)startj] = 1;
            AllLegalMoves[starti + 1, (int)startj] = 1;


            return AllLegalMoves;
        }
        public XoY[] Capture (int starti, column startj)
        {
            if(Allcapture[0] == null)
                Allcapture[0] = new XoY();
            Allcapture[0].y = (column)((int)startj - 1);
            Allcapture[0].x = starti + 1;
            if (Allcapture[1] == null)
                Allcapture[1] = new XoY();
            Allcapture[1].y = (column)((int)startj + 1);
            Allcapture[1].x = starti + 1;
            if(startj == column.A)
            {
                Allcapture[0] = null;
            }
            if (startj == column.H)
            {
                Allcapture[1] = null;
            }


            return Allcapture;
        }
    }
}
