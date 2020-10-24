using System;
using Xunit;
using proiect_sah;
using System.ComponentModel.DataAnnotations;

namespace test_tabla
{
    public class TestTablaInceput
    {
        [Theory]
      
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


        [Fact]
        public void TestPion()
        {

        }

        }
}
