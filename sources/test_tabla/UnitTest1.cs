using System;
using Xunit;
using proiect_sah;

namespace test_tabla
{
    public class TestTablaInceput
    {
        [Fact]
        public void TestPionInceput()
        {
            Board b = new Board();
            var piesa = b.GetPieceFrom(2, column.E);
            Assert.Equal(PieceType.Pawn, piesa.pieceType);
            Assert.Equal(Color.White, piesa.Color);
            piesa = b.GetPieceFrom(7, column.H);
            Assert.Equal(PieceType.Pawn, piesa.pieceType);
            Assert.Equal(Color.Black, piesa.Color);
        }

    }
}
