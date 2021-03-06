﻿using System;
using System.Collections.Generic;
using System.Text;
namespace proiect_sah
{
    public abstract class Piece
    {
        public Color Color;
        public PieceType pieceType { get; protected set; }
        public abstract int[,] Moves(int starti, column startj);
        /*protected int [,] LegalMoe*/

        public static Piece GetPieceFromPieceType(PieceType type, Color c) 
        {
            var type1 = (PieceType)Math.Abs((int)type);
            switch (type1)
            {
                case PieceType.King:
                    return new King(c);
                case PieceType.Pawn:
                    return new Pawn(c);
                case PieceType.Knight:
                    return new Knight(c);
                case PieceType.Queen:
                    return new Queen(c);
                case PieceType.Bishop:
                    return new Bishop(c);
                case PieceType.Rook:
                    return new Rook(c);
                case PieceType.Nopiece:
                    return null;

                default:
                    throw new ArgumentException($"do not exists {type}");
            }
        }


    }

    
}
