using System;

namespace proiect_sah
{   
    class Program
    {
       static bool GameOver ()
        {
            return false;
        }
        static void Main(string[] args)
        {
            
            var board = new Board();
            var currmove = "";
            column coloanainit , coloanafin;
            int linieinit, liniefin;
       while (!GameOver())
            {
                Console.WriteLine("Introduceti mutarea (ex: E2 E4)");
              currmove = Console.ReadLine();
                coloanainit = Enum.Parse<column>( currmove.Substring(0 , 1), true);
                linieinit = int.Parse(currmove.Substring(1, 1));
                coloanafin = Enum.Parse<column>(currmove.Substring(3 , 1) , true);
                liniefin = int.Parse(currmove.Substring(4 , 1));
                board.MovePiece(linieinit, coloanainit, liniefin, coloanafin);

            }

        }
    }
}
