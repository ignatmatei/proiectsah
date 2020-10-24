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

    class Board
    {
        public bool IsLegal (int pozi_init, column pozj_init, int pozi_final, column pozj_final)
        {
            var piesa = table[pozi_init, (int)pozj_init];
            Color c = Color.White;
            if (piesa < 0)
                c = Color.Black;
            var p = Piece.GetPieceFromPieceType(piesa, c);
            var moves = p.Moves(pozi_init, pozj_init);
            if (moves[pozi_init, (int)pozj_init] == 1) return true;
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
        }
        public PieceType[,]            table=new PieceType[9,9];


        public Board()
        {

            for (var i = 1; i <= 8; i++)
            { 
                table[2, i] = PieceType.Pawn;
                table[7, i] =(PieceType)((int) Color.Black * (int) PieceType.Pawn);
                
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
