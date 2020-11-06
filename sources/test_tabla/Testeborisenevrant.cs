using proiect_sah;
using sah;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace test_tabla
{
    public class Testeborisenevrant
    {
        [Fact]
 
        public void ChangeMove()
        {
            Game g = new Game();
            Assert.Equal(Color.White, g.WhoShouldMove);
            g.board.MovePiece(2, column.E, 4, column.E);
            Assert.Equal(Color.Black, g.WhoShouldMove);
        }

    }
}
