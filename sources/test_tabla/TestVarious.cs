using proiect_sah;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace test_tabla
{
    public class TestVarious
    {
        [Fact]
        public void ExistaPion()
        {
            Board b = new Board();
            var R = b.GetPieceFrom(1, column.A);
            Assert.Equal(PieceType.Rook, R.pieceType);
            Assert.Equal(Color.White, R.Color);
        }
    }
}
