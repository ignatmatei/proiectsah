using proiect_sah;
using System;
using System.Collections.Generic;
using System.Text;

namespace sah
{
    public class Game
    {
       
        public Game()
        {
            PlayerWhite = new Player();
            PlayerBlack = new Player();
            board = new Board();
            WhoShouldMove = Color.White;
            board.PieceHasMoved += Board_PieceHasMoved;

        }

        private void Board_PieceHasMoved(object sender, Color e)
        {
            WhoShouldMove = (Color)(-1 * (int)e);
        }


        public Color WhoShouldMove;
        public Player PlayerWhite;
        public Player PlayerBlack;
        public Board board;
        public List<Mutare> mutari;
    }
}
