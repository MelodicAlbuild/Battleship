namespace MelodicAlbuild.Games.Battleship.lib {
    class GenerateBoard {
        public static void Generate(int x, int y, int count) {
            Console.WriteLine(DrawFullLine(x));
        }

        private static string DrawFullLine(int length) {
            string output = "";
            for(int i = 0; i < length; i++) {
                output += "|-|";
            }
            return output;
        }
    }
}