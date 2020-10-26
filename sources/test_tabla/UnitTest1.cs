using System;
using Xunit;
using proiect_sah;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace test_tabla
{
    public class TestTablaInceput
    {
       /* [Theory]
      
        [InlineData(2,column.E,PieceType.Pawn, Color.White)]
        [InlineData(7, column.E, PieceType.Pawn, Color.Black)]
        public void TestPionInceput(int linie, column col,PieceType type, Color c)
        {
            Board b = new Board();
            var piesa= b.GetPieceFrom(linie, col);
            Assert.Equal(type, piesa.pieceType);
            Assert.Equal(c, piesa.Color);

            //var piesa = b.GetPieceFrom(2, column.E);
            //Assert.Equal(PieceType.Pawn, piesa.pieceType);
            //Assert.Equal(Color.White, piesa.Color);
            //piesa = b.GetPieceFrom(7, column.H);
            //Assert.Equal(PieceType.Pawn, piesa.pieceType);
            //Assert.Equal(Color.Black, piesa.Color);
        }
       */
        
        [Fact]
        public void ExistaPion()
        {
            Board b = new Board();
            var pion = b.GetPieceFrom(2, column.E);
            Assert.Equal(PieceType.Pawn, pion.pieceType);
            Assert.Equal(Color.White, pion.Color);
        }

        [Fact]
        public void Mutarilegale()
        {
            Board b = new Board();
            Assert.True(b.IsLegal(2, column.C, 4, column.C));
        }

        [Fact]
        public void S_a_mutat()
        {
            Board b = new Board();
 
            b.MovePiece(2, column.E, 4, column.E);
            
            var pion = b.GetPieceFrom(4, column.E);
            var nimic = b.GetPieceFrom(2, column.E);
            Assert.Equal(PieceType.Pawn, pion.pieceType);
            Assert.Null(nimic);
        }
        [Fact]
        public void ImposibilKing ()
        {
            Board n = new Board();
            Assert.Throws<Exception>(
                () =>
            n.MovePiece(1, column.E, 2, column.E)
           );

        }
        [Fact]

        public void ImposibilRook()
        {
            Board n = new Board();
            Assert.Throws<Exception>(
                () =>
            n.MovePiece(1, column.A, 6, column.A)
           );
        }

        [Fact]
        public void ImposibilKnight()
        {
            Board n = new Board();
            Assert.Throws<Exception>(
                () =>
            n.MovePiece(1, column.B, 2, column.D)
           );
        }
        [Fact]
        public void PosibilKnight ()
        {
            Board n = new Board();
            Assert.True(n.IsLegal(1, column.B, 3, column.C));
        }

        [Fact]
        public void ImposibilPawn ()
        {
            Board b = new Board();
            Assert.False(b.IsLegal(2, column.A, 3, column.C));
        }

        [Fact]
        public void ImposibilBishop()
        {
            Board b = new Board();
            Assert.False(b.IsLegal(1, column.C, 3, column.E));
        }

        [Fact]
        public void PosibilBishop()
        {
            Board b = new Board();
            b.MovePiece(2, column.B, 3, column.B);
            Assert.True(b.IsLegal(1, column.C, 2, column.B));
        }

        [Fact]
        public void ImposibilQueen()
        {
            Board b = new Board();
            Assert.False(b.IsLegal(1, column.D, 3, column.D));
        }

        [Fact]
        public void PosibilQueen()
        {
            Board b = new Board();
            b.MovePiece(2, column.D, 4, column.D);
            Assert.True(b.IsLegal(1, column.D, 3, column.D));
        }

        [Fact]
        public void PosibilKing()
        {
            Board b = new Board();
            b.MovePiece(2, column.E, 4, column.E);
            Assert.True(b.IsLegal(1, column.E, 2, column.E));
        }

        [Fact] 
        public void IsWhiteKingInCheck ()
        {
            Board b = new Board();
            Assert.False(b.IsKingInCheck(Color.White, 1, column.E));
        }

        [Fact]
        public void PossibleBlackPawn()
        {
            Board b = new Board();
            Assert.True(b.IsLegal(7, column.E, 6, column.E));
        }

        [Fact]
        public void IsBlacKKingInCheck()
        {
            Board b = new Board();
            Assert.False(b.IsKingInCheck(Color.Black, 8, column.E));
        }

        [Fact]
        public void ImpossibleCastle()
        {
            Board b = new Board();
            Assert.False(b.IsLegal(1, column.E, 1, column.G));
        }
    }
}
