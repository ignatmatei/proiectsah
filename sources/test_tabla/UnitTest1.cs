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
            Assert.True(b.IsLegal(2, column.E, 4, column.E));
        }

        [Fact]
        public void S_a_mutat()
        {
            Board b = new Board();
 
            b.MovePiece(2, column.C, 4, column.C);
            var pion = b.GetPieceFrom(4, column.C);
            var nimic = b.GetPieceFrom(2, column.C);
            Assert.Equal(PieceType.Pawn, pion.pieceType);
            Assert.Null(nimic);
        }
        public void ImposibilQueen ()
        {
            Board n = new Board();
        }

    }
}
