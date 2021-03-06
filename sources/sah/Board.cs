﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Net.WebSockets;
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
        public event EventHandler<Color> PieceHasMoved;
        public Piece GetPieceFromPromotion(char pl, Color c)
        {
            switch (pl)
            {
                case 'Q':
                    return new Queen(c);
                case 'R':
                    return new Knight(c);
                case 'B':
                    return new Bishop(c);
                case 'K':
                    return new Knight(c);

                default:
                    throw new ArgumentException($"do not exists {pl}. YOU CAN'T PROMOTE TO NEW KING OR NEW PAWN");
            }
        }
        public bool IsKingInCheck(Color c, int poziking, column pozjking)
        {
            int i, j;
            for (i = 1; i <= 8; i++)
                for(j = 1; j <= 8; j++)
            {
                var inamic = table[i, j];
                Color advers = Color.White;
                if (inamic < 0)
                    advers = Color.Black;
                if(advers != c && inamic != PieceType.Nopiece)
                {
                    column col = column.A;
                    if (j == 2)
                        col = column.B;
                    if (j == 3)
                        col = column.C;
                    if (j == 4)
                        col = column.D;
                    if (j == 5)
                        col = column.E;
                    if (j == 6)
                        col = column.F;
                    if (j == 7)
                        col = column.G;
                    if (j == 8)
                        col = column.H;
                    if (IsLegal(i, col, poziking, pozjking))
                        return true;
                }
            }
            return false;
        }
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
                if (piece.Color == Color.White)
                {
                    if (pozj_init == pozj_final)
                    {
                        var opozitiepion = GetPieceFrom(pozi_init + 1, pozj_init);
                        if (opozitiepion != null)
                            return false;
                        if (pozi_final == pozi_init + 2 && pozi_init == 2)
                        {
                            opozitiepion = GetPieceFrom(pozi_init + 2, pozj_init); ;
                            if (opozitiepion != null)
                                return false;
                            return true;

                        }
                        if (pozi_final == pozi_init + 1)
                            return true;
                        return false;
                    }
                    if ((pozi_init == pozi_final - 1) && ((int)pozj_final == (int)pozj_init + 1 || (int)pozj_final == (int)pozj_init - 1))
                    {
                        var opozitiepion1 = GetPieceFrom(pozi_final, pozj_final);
                        var opozitiepion2 = GetPieceFrom(pozi_init, pozj_final);
                        if ((opozitiepion1 != null && opozitiepion1.Color != piece.Color) || (opozitiepion2 != null && opozitiepion2.Color != piece.Color && pozi_init == 6))
                            return true;
                        return false;
                    }

                }
                if (piece.Color == Color.Black)
                {
                    if (pozj_init == pozj_final)
                    {
                        var opozitiepion = GetPieceFrom(pozi_init - 1, pozj_init);
                        if (opozitiepion != null)
                            return false;
                        if (pozi_final == pozi_init - 2 && pozi_init == 7)
                        {
                            opozitiepion = GetPieceFrom(pozi_init - 2, pozj_init); ;
                            if (opozitiepion != null)
                                return false;
                            return true;

                        }
                        if (pozi_final == pozi_init - 1)
                            return true;
                        return false;
                    }
                    if ((pozi_init == pozi_final + 1) && ((int)pozj_final == (int)pozj_init + 1 || (int)pozj_final == (int)pozj_init - 1))
                    {
                        var opozitiepion1 = GetPieceFrom(pozi_final, pozj_final);
                        var opozitiepion2 = GetPieceFrom(pozi_init, pozj_final);
                        if ((opozitiepion1 != null && opozitiepion1.Color != piece.Color) || (opozitiepion2 != null && opozitiepion2.Color != piece.Color && pozi_init == 3))
                            return true;
                        return false;
                    }
                    return false;
                }
                return false;
            }
            if(piece.pieceType == PieceType.King)
            {
                if (moves[pozi_final, (int)pozj_final] == 1)
                {
                    var opozitie = GetPieceFrom(pozi_final, pozj_final);
                    if (opozitie != null)
                        if (piece.Color == opozitie.Color)
                            return false;
                    return true;
                }
                if(pozj_final == column.G)
                {
                    var opozitierege = table[pozi_init, 6];
                    if (opozitierege != PieceType.Nopiece)
                        return false;
                    opozitierege = table[pozi_init, 7];
                    if (opozitierege != PieceType.Nopiece)
                        return false;
                }
                if (pozj_final == column.C)
                {
                    var opozitierege1 = table[pozi_init, 4];
                    for (int m = 4; m >= 2; m--)
                    {
                        opozitierege1 = table[pozi_init, m];
                        if (opozitierege1 != PieceType.Nopiece)
                            return false;
                    }
                }
                if (piece.Color == Color.White)
                    if (pozi_init == 1 && pozj_init == column.E && pozi_final == 1 && (pozj_final == column.G || pozj_final == column.C))
                        return true;
                if (piece.Color == Color.Black)
                    if (pozi_init == 8 && pozj_init == column.E && pozi_final == 8 && (pozj_final == column.G || pozj_final == column.C))
                        return true;
                return false;
            }
            else
            {
                if (moves[pozi_final, (int)pozj_final] == 1)
                {
                    if (piece.pieceType == PieceType.Rook)
                    {
                        var fin = table[pozi_final, (int)pozj_final];
                        Color cult = Color.White;
                        if (fin < 0)
                            cult = Color.Black;
                        if (pozi_init == pozi_final)
                        {
                            for (int i = min((int)pozj_init, (int)pozj_final) + 1; i < max((int)pozj_init, (int)pozj_final); i++)
                                if (table[pozi_init, i] != PieceType.Nopiece)
                                    return false;
                        }
                        for (int i = min(pozi_init, pozi_final) + 1; i < max(pozi_init, pozi_final); i++)
                            if (table[i, (int)pozj_init] != PieceType.Nopiece)
                                return false;
                        if (fin == 0)
                            return true;
                        if (cult != piece.Color)
                            return true;
                        return false;

                    }
                    if (piece.pieceType == PieceType.Knight)
                    {
                        var opozitiecal = GetPieceFrom(pozi_final, pozj_final);
                        if (opozitiecal != null)
                            if (piece.Color == opozitiecal.Color)
                                return false;
                        return true;
                    }
                    if (piece.pieceType == PieceType.Pawn && piece.Color == Color.White)
                    {
                        if (pozj_init == pozj_final)
                        {
                            var opozitiepion = GetPieceFrom(pozi_init + 1, pozj_init);
                            if (opozitiepion != null)
                                return false;
                            if (pozi_final == pozi_init + 2 && pozi_init == 2)
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
                    if (piece.pieceType == PieceType.Bishop)
                    {
                        var opozitienebun = table[pozi_final, (int)pozj_final];
                        Color culn = Color.White;
                        if (opozitienebun < 0)
                            culn = Color.Black;
                        if (pozi_init < pozi_final && (int)pozj_init < (int)pozj_final)
                        {
                            int i = pozi_init + 1, j = (int)pozj_init + 1;
                            while (i < pozi_final)
                            {
                                if (table[i, j] != PieceType.Nopiece)
                                    return false;
                                i++;
                                j++;
                            }
                        }
                        if (pozi_init < pozi_final && (int)pozj_init > (int)pozj_final)
                        {
                            int i = pozi_init + 1, j = (int)pozj_init - 1;
                            while (i < pozi_final)
                            {
                                if (table[i, j] != PieceType.Nopiece)
                                    return false;
                                i++;
                                j--;
                            }
                        }
                        if (pozi_init > pozi_final && (int)pozj_init > (int)pozj_final)
                        {
                            int i = pozi_init - 1, j = (int)pozj_init - 1;
                            while (i > pozi_final)
                            {
                                if (table[i, j] != PieceType.Nopiece)
                                    return false;
                                i--;
                                j--;
                            }
                        }
                        if (pozi_init > pozi_final && (int)pozj_init < (int)pozj_final)
                        {
                            int i = pozi_init - 1, j = (int)pozj_init + 1;
                            while (i > pozi_final)
                            {
                                if (table[i, j] != PieceType.Nopiece)
                                    return false;
                                i--;
                                j++;
                            }
                        }
                        if (opozitienebun == 0)
                            return true;
                        if (culn != piece.Color)
                            return true;
                        return false;
                    }
                    if (piece.pieceType == PieceType.Queen)
                    {
                        var fin = table[pozi_final, (int)pozj_final];
                        Color culd = Color.White;
                        if (fin < 0)
                            culd = Color.Black;
                        if (pozi_init == pozi_final)
                        {
                            for (int i = min((int)pozj_init, (int)pozj_final) + 1; i < max((int)pozj_init, (int)pozj_final); i++)
                                if (table[pozi_init, i] != PieceType.Nopiece)
                                    return false;
                        }
                        if ((int)pozj_init == (int)pozj_final)
                        {
                            for (int i = min(pozi_init, pozi_final) + 1; i < max(pozi_init, pozi_final); i++)
                                if (table[i, (int)pozj_init] != PieceType.Nopiece)
                                    return false;
                        }
                        if (pozi_init < pozi_final && (int)pozj_init < (int)pozj_final)
                        {
                            int i = pozi_init + 1, j = (int)pozj_init + 1;
                            while (i < pozi_final)
                            {
                                if (table[i, j] != PieceType.Nopiece)
                                    return false;
                                i++;
                                j++;
                            }
                        }
                        if (pozi_init < pozi_final && (int)pozj_init > (int)pozj_final)
                        {
                            int i = pozi_init + 1, j = (int)pozj_init - 1;
                            while (i < pozi_final)
                            {
                                if (table[i, j] != PieceType.Nopiece)
                                    return false;
                                i++;
                                j--;
                            }
                        }
                        if (pozi_init > pozi_final && (int)pozj_init > (int)pozj_final)
                        {
                            int i = pozi_init - 1, j = (int)pozj_init - 1;
                            while (i > pozi_final)
                            {
                                if (table[i, j] != PieceType.Nopiece)
                                    return false;
                                i--;
                                j--;
                            }
                        }
                        if (pozi_init > pozi_final && (int)pozj_init < (int)pozj_final)
                        {
                            int i = pozi_init - 1, j = (int)pozj_init + 1;
                            while (i > pozi_final)
                            {
                                if (table[i, j] != PieceType.Nopiece)
                                    return false;
                                i--;
                                j++;
                            }
                        }
                        if (fin == 0)
                            return true;
                        if (culd != piece.Color)
                            return true;
                        return false;

                    }
                }
                return false;
            }
              
        }
        public void MovePiece(int pozi_init, column pozj_init, int pozi_final, column pozj_final  , char pl = ' ')
        {
            if(IsLegal(pozi_init, pozj_init, pozi_final , pozj_final))
            {

                var currpiece = GetPieceFrom(pozi_init , pozj_init);
                table[pozi_final, (int)pozj_final] = table[pozi_init, (int)pozj_init];
                table[pozi_init, (int)pozj_init] = PieceType.Nopiece;
                if (currpiece.pieceType == PieceType.King && pozj_init == column.E && ( pozj_final == column.G  || pozj_final == column.C))
                {
                    
                        if (pozj_final == column.G)
                        {   
                            table[pozi_init, 8] = PieceType.Nopiece;
                            table[pozi_init, 6] =(PieceType) ((int)currpiece.Color *  (int)PieceType.Rook);
                        }
                        if (pozj_final == column.C)
                        {
                            table[pozi_init, 1] = PieceType.Nopiece;
                            table[pozi_init, 4] =(PieceType) ((int)currpiece.Color * (int)PieceType.Rook);
                        }
                    
                   
                }
                if (currpiece.pieceType == PieceType.Pawn && (pozi_final == 8 || pozi_final == 1))
                {
                    var promoted = GetPieceFromPromotion(pl, currpiece.Color);
                    table[pozi_final, (int)pozj_final] =(PieceType)((int)promoted.Color *(int)promoted.pieceType);
                }

                if (PieceHasMoved != null)
                    PieceHasMoved(this, currpiece.Color);
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
