using MelodicAlbuild.Games.Battleship.lib.Generation;

namespace MelodicAlbuild.Games.Battleship {
    class Program {
        static void Main(string[] args) {
            Board playerBoard = new Board(10, 10);
            GenerateShips generateShips = new GenerateShips();
            generateShips.AddShipsToBoard(playerBoard);
            foreach (var position in playerBoard.GetBoardPositions())
            {
                Console.WriteLine(position);
            }
            
            playerBoard.DrawBoard();
        }
    }
}