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

        public static Piece GetPieceFromPieceType(PieceType type)
        {
            switch (type)
            {
                case PieceType.King:
                    return new King();
                case PieceType.Pawn:
                    return new Pawn();
                case PieceType.Knight:
                    return new Knight();
                case PieceType.Queen:
                    return new Queen();
                case PieceType.Bishop:
                    return new Bishop();
                case PieceType.Rook:
                    return new Rook();

                default:
                    throw new ArgumentException($"do not exists {type}");
            }
        }


    }

    
}
