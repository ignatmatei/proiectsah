using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
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
       
       public int min (int a, int b)
        {
            if (a < b) return a;
            return b;
        }
        public int max(int a, int b)
        {
            if (a > b) return a;
            return b;
        }
        public bool IsLegal (int pozi_init, column pozj_init, int pozi_final, column pozj_final)
        {
            
            var piece = GetPieceFrom(pozi_init, pozj_init);
            Color c = piece.Color;
            var moves = piece.Moves(pozi_init, pozj_init);
             if (piece.pieceType == PieceType.Pawn)
            {
                var pioninamic1 = table[pozi_init + 1, ((int)pozj_init) - 1];
                var pioninamic2 = table[pozi_init + 1, ((int)pozj_init) + 1];
                Color cul1 = Color.White; 
                Color cul2 = Color.Black;
                if(pioninamic1 < 0)
                {
                    cul1 = Color.Black;
                }
                if (pioninamic2 < 0)
                {
                    cul2 = Color.Black;
                }
                if (Math.Abs((int)pioninamic1)  == 1 && cul1 != c)
                    moves[pozi_init + 1, ((int)pozj_init) - 1] = 1;
                if(Math.Abs((int)pioninamic2) == 1 && cul2 != c)
                    moves[pozi_init + 1, ((int)pozj_init) + 1] = 1;
            }
            if (moves[pozi_final, (int)pozj_final] == 1)
                {
                    if (piece.pieceType == PieceType.King)
                    {
                        var opozitie = GetPieceFrom(pozi_final, pozj_final);
                        if (opozitie != null)
                            if (piece.Color == opozitie.Color)
                                return false;
                        return true;
                    }
                    if (piece.pieceType == PieceType.Rook)
                    {
                        if (pozi_init == pozi_final)
                        {
                            for (int i = min((int)pozj_init, (int)pozj_final); i < max((int)pozj_init, (int)pozj_final); i++)
                                if (table[pozi_init, i] != PieceType.Nopiece)
                                    return false;
                            int j = max((int)pozj_init, (int)pozj_final);
                            var fin = table[pozi_init, j];
                            
                            if (fin == 0)
                                return true;
                          
                            Color c1 = Color.White;
                            if (fin < 0)
                                c1 = Color.Black;
                            if (c1 == piece.Color)
                                return false;
                            return true;
                          

                        }
                        for (int i = min(pozi_init, pozi_final); i < max(pozi_init,pozi_final); i++)
                            if (table[i, (int)pozj_init] != PieceType.Nopiece)
                                return false;
                        int j1 = max(pozi_init, pozi_final);
                        var fin1 = table[j1, (int)pozj_init];
                        if (fin1 == 0) return true;
                        Color c2 = Color.White;
                        if (fin1 < 0)
                            c2 = Color.Black;
                        if (c2 == piece.Color)
                            return false;
                        return true;

                    }
                    if (piece.pieceType == PieceType.Knight)
                    {
                        var opozitiecal = GetPieceFrom(pozi_final, pozj_final);
                        if (opozitiecal != null)
                            if (piece.Color == opozitiecal.Color)
                                return false;
                        return true;
                    }
                    if(piece.pieceType == PieceType.Pawn)
                {
                    if(pozj_init == pozj_final)
                    {
                        var opozitiepion = GetPieceFrom(pozi_init + 1, pozj_init);
                        if (opozitiepion != null)
                            return false;
                        if (pozi_final == pozi_init + 2)
                        {
                            opozitiepion = GetPieceFrom(pozi_init + 2, pozj_init);
                            if (opozitiepion != null)
                                return false;
                            return true;
                        }
                        return true;
                    }
                    return true;
                }
                }
             return false;
              
        }
        public void MovePiece(int pozi_init, column pozj_init, int pozi_final, column pozj_final)
        {
            if(IsLegal(pozi_init, pozj_init, pozi_final , pozj_final))
            {
                var currpiece = table[pozi_init, (int)pozj_init];
                table[pozi_init, (int)pozj_init] = PieceType.Nopiece;
                table[pozi_final, (int)pozj_final] = currpiece;
                return;
            }
            
                throw new Exception("mutare imposibila");
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
            table[8, 4] = (PieceType)((int)Color.Black * (int)PieceType.Queen);
            table[8, 5] = (PieceType)((int)Color.Black * (int)PieceType.King);
            table[8, 1] = (PieceType)((int)Color.Black * (int)PieceType.Rook);
            table[8, 8] = (PieceType)((int)Color.Black * (int)PieceType.Rook);
            table[8, 3] = (PieceType)((int)Color.Black * (int)PieceType.Bishop);
            table[8, 6] = (PieceType)((int)Color.Black * (int)PieceType.Bishop);

        }

    }
}
