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

        }
        public Player PlayerWhite;
        public Player PlayerBlack;
        public Board board;
        public List<Mutare> mutari;
    }
}
