using System;
using System.Collections.Generic;
using System.Text;
namespace proiect_sah
{
    public abstract class Piece
    {
        public Color Color;
        public PieceType pieceType { get; protected set; }
        public abstract int[,] Moves(int starti, column startj);

        public static Piece GetPieceFromPieceType(PieceType type, Color c) 
        {
            switch (type)
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

                default:
                    throw new ArgumentException($"do not exists {type}");
            }
        }


    }

    
}
