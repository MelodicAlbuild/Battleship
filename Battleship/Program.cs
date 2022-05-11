using MelodicAlbuild.Games.Battleship.lib;

namespace MelodicAlbuild.Games.Battleship {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Hello World");
            GenerateBoard.Generate(5, 5, 1);
        }
    }
}