using MelodicAlbuild.Games.Battleship.lib.Classes;
using MelodicAlbuild.Games.Battleship.lib.Exceptions;

namespace MelodicAlbuild.Games.Battleship.lib.Generation {
    public class Board
    {
        private int x;
        private int y;
        private int row = 0;
        
        private List<char> letters = new List<char>()
            {'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N'};

        private List<BoardPosition> playerBoardStatus = new List<BoardPosition>();

        private Dictionary<PositionIdentifier, BoardPosition> boardPositions =
            new Dictionary<PositionIdentifier, BoardPosition>();

        public Board(int x, int y)
        {
            if (x > 13 || y > 13)
            {
                throw new BoardSizeException("The Given Size was More than 13x13...");
            }

            if (x < 3 || y < 3)
            {
                throw new BoardSizeException("The Given Size was Less than 3x3...");
            }
            
            this.x = x;
            this.y = y;
            
            for (int i = 0; i < y; i++)
            {
                for (int z = 0; z < y; z++)
                {
                    BoardPosition thisPosition = new BoardPosition(letters[i], z + 1);
                    playerBoardStatus.Add(thisPosition);
                    boardPositions.Add(new PositionIdentifier(z + 1, letters[i]), thisPosition);
                }
            }
        }

        public int GetX()
        {
            return x;
        }

        public int GetY()
        {
            return y;
        }

        public List<char> GetLetterList()
        {
            return letters;
        }
        
        public void DrawBoard()
        {
            for (int i = 0; i < y; i++)
            {
                if (i == 0)
                {
                    Console.WriteLine(DrawNums(x) + "     " + DrawNums(x));
                    Console.WriteLine(DrawFullLine(x) + "     " + DrawFullLine(x));
                    Console.WriteLine(DrawBlankedLine(x, i) + "     " + DrawFullBlankedLine(x, i));
                    row++;
                    Console.WriteLine(DrawFullLine(x) + "     " + DrawFullLine(x));
                }
                else
                {
                    Console.WriteLine(DrawBlankedLine(x, i) + "     " + DrawFullBlankedLine(x, i));
                    row++;
                    Console.WriteLine(DrawFullLine(x) + "     " + DrawFullLine(x));
                }
            }
        }

        public List<BoardPosition> GetBoardPositions()
        {
            return playerBoardStatus;
        }

        public void UpdateBoardPositions(List<BoardPosition> positions)
        {
            playerBoardStatus = positions;
        }
        
        public Dictionary<PositionIdentifier, BoardPosition> GetBoardPositionsDictionary()
        {
            return boardPositions;
        }

        public void UpdateBoardPositionsDictionary(Dictionary<PositionIdentifier, BoardPosition> positions)
        {
            boardPositions = positions;
        }

        private string DrawFullLine(int length) {
            string output = "";
            for(int i = 0; i < length; i++) {
                if (i == 0)
                {
                    output += "  | - ";
                }
                else if (i == length - 1)
                {
                    output += "| - |";
                }
                else
                {
                    output += "| - ";
                }
            }
            return output;
        }

        private string DrawNums(int length)
        {
            string output = "  ";
            for(int i = 0; i < length; i++)
            {
                output += "  " + (i + 1) + " ";
            }
            output += " ";
            return output;
        }
        
        private string DrawBlankedLine(int length, int yx) {
            string output = "";

            for(int i = 0; i < length; i++)
            {
                string shipInsert = " ";
                PositionIdentifier? id = boardPositions.Keys.ToList()
                    .Find(q => q.charPos == letters[row] && q.intPos == i + 1);
                if (id != null)
                {
                    shipInsert = boardPositions[id].GetShipString();
                }

                if (i == 0)
                {
                    output += letters[yx] + " | " + shipInsert + " ";
                }
                else if (i == length - 1)
                {
                    output += "| " + shipInsert + " |";
                }
                else
                {
                    output += "| " + shipInsert + " ";
                }
            }
            return output;
        }
        
        private string DrawFullBlankedLine(int length, int yx) {
            string output = "";

            for(int i = 0; i < length; i++)
            {
                if (i == 0)
                {
                    output += letters[yx] + " |   ";
                }
                else if (i == length - 1)
                {
                    output += "|   |";
                }
                else
                {
                    output += "|   ";
                }
            }
            return output;
        }
    }
}