using MelodicAlbuild.Games.Battleship.lib.Classes;
using MelodicAlbuild.Games.Battleship.lib.Enums;

namespace MelodicAlbuild.Games.Battleship.lib.Generation;

public class GenerateShips
{
    private List<Ship> ships = new List<Ship>();

    public GenerateShips()
    {
        ships.Add(new Ship(ShipType.Battleship, 4));
        ships.Add(new Ship(ShipType.Cruiser, 3));
        ships.Add(new Ship(ShipType.Destroyer, 2));
    }

    public void AddShipsToBoard(Board board)
    {
        ships.Clear();
        ships.Add(new Ship(ShipType.Battleship, 4));
        ships.Add(new Ship(ShipType.Cruiser, 3));
        ships.Add(new Ship(ShipType.Destroyer, 2));
        
        Random random = new Random();
        List<BoardPosition> positions = board.GetBoardPositions();
        try
        {
            foreach (var ship in ships)
            {
                // 1 = Left, 2 = Up, 3 = Right, 4 = Down
                int direction = random.Next(1, 5);
                int index = random.Next(positions.Count);
                PlaceShip(board, random, ship, direction, positions, index);
            }
        }
        catch (Exception e)
        {
            foreach (var ship in ships)
            {
                // 1 = Left, 2 = Up, 3 = Right, 4 = Down
                int direction = random.Next(1, 5);
                int index = random.Next(positions.Count);
                PlaceShip(board, random, ship, direction, positions, index);
            }
        }
        
        board.UpdateBoardPositions(positions);
    }

    private void PlaceShip(Board board, Random random, Ship ship, int direction, List<BoardPosition> positions, int index)
    {
        int dir = direction;
        Console.WriteLine(dir + " " + positions[index]);
        positions[index].UpdatePositionStatus(PositionStatus.Ship);
        positions[index].UpdatePositionShip(ship);
        List<BoardPosition> lastMoves = new List<BoardPosition>();
        lastMoves.Add(positions[index]);
        
        for (int i = 0; i < ship.GetLength() - 1; i++)
        {
            switch (direction)
            {
                case 1:
                    try
                    {
                        if (IsValidShipPlacement(board, positions[index - (i + 1)], 1, lastMoves))
                        {
                            positions[index - (i + 1)].UpdatePositionStatus(PositionStatus.Ship);
                            positions[index - (i + 1)].UpdatePositionShip(ship);
                            lastMoves.Add(positions[index - (i + 1)]);
                        }
                        else
                        {
                            foreach (var obj in lastMoves)
                            {
                                obj.UpdatePositionStatus(PositionStatus.Blank);
                                obj.UpdatePositionShip(null);
                            }
                            lastMoves.Clear();
                            dir = random.Next(1, 5);
                            PlaceShip(board, random, ship, dir, positions, random.Next(positions.Count));
                        }
                    }
                    catch (Exception e)
                    {
                        foreach (var obj in lastMoves)
                        {
                            obj.UpdatePositionStatus(PositionStatus.Blank);
                            obj.UpdatePositionShip(null);
                        }
                        lastMoves.Clear();
                        dir = random.Next(1, 5);
                        PlaceShip(board, random, ship, dir, positions, random.Next(positions.Count));
                    }
                    break;
                case 2:
                    try
                    {
                        if (IsValidShipPlacement(board, positions[index - ((i + 1) * board.GetX())], 2, lastMoves))
                        {
                            positions[index - ((i + 1) * board.GetX())].UpdatePositionStatus(PositionStatus.Ship);
                            positions[index - ((i + 1) * board.GetX())].UpdatePositionShip(ship);   
                            lastMoves.Add(positions[index - ((i + 1) * board.GetX())]);
                        }
                        else
                        {
                            foreach (var obj in lastMoves)
                            {
                                obj.UpdatePositionStatus(PositionStatus.Blank);
                                obj.UpdatePositionShip(null);
                            }
                            lastMoves.Clear();
                            dir = random.Next(1, 5);
                            PlaceShip(board, random, ship, dir, positions, random.Next(positions.Count));
                        }
                    }
                    catch (Exception e)
                    {
                        foreach (var obj in lastMoves)
                        {
                            obj.UpdatePositionStatus(PositionStatus.Blank);
                            obj.UpdatePositionShip(null);
                        }
                        lastMoves.Clear();
                        dir = random.Next(1, 5);
                        PlaceShip(board, random, ship, dir, positions, random.Next(positions.Count));
                    }
                    break;
                case 3:
                    try
                    {
                        if (IsValidShipPlacement(board, positions[index + (i + 1)], 3, lastMoves))
                        {
                            positions[index + (i + 1)].UpdatePositionStatus(PositionStatus.Ship);
                            positions[index + (i + 1)].UpdatePositionShip(ship);   
                            lastMoves.Add(positions[index + (i + 1)]);
                        }
                        else
                        {
                            foreach (var obj in lastMoves)
                            {
                                obj.UpdatePositionStatus(PositionStatus.Blank);
                                obj.UpdatePositionShip(null);
                            }
                            lastMoves.Clear();
                            dir = random.Next(1, 5);
                            PlaceShip(board, random, ship, dir, positions, random.Next(positions.Count));
                        }
                    }
                    catch (Exception e)
                    {
                        foreach (var obj in lastMoves)
                        {
                            obj.UpdatePositionStatus(PositionStatus.Blank);
                            obj.UpdatePositionShip(null);
                        }
                        lastMoves.Clear();
                        dir = random.Next(1, 5);
                        PlaceShip(board, random, ship, dir, positions, random.Next(positions.Count));
                    }
                    break;
                case 4:
                    try
                    {
                        if (IsValidShipPlacement(board, positions[index + ((i + 1) * board.GetX())], 4, lastMoves))
                        {
                            positions[index + ((i + 1) * board.GetX())].UpdatePositionStatus(PositionStatus.Ship);
                            positions[index + ((i + 1) * board.GetX())].UpdatePositionShip(ship);   
                            lastMoves.Add(positions[index + ((i + 1) * board.GetX())]);
                        }
                        else
                        {
                            foreach (var obj in lastMoves)
                            {
                                obj.UpdatePositionStatus(PositionStatus.Blank);
                                obj.UpdatePositionShip(null);
                            }
                            lastMoves.Clear();
                            dir = random.Next(1, 5);
                            PlaceShip(board, random, ship, dir, positions, random.Next(positions.Count));
                        }
                    }
                    catch (Exception e)
                    {
                        foreach (var obj in lastMoves)
                        {
                            obj.UpdatePositionStatus(PositionStatus.Blank);
                            obj.UpdatePositionShip(null);
                        }
                        lastMoves.Clear();
                        dir = random.Next(1, 5);
                        PlaceShip(board, random, ship, dir, positions, random.Next(positions.Count));
                    }
                    break;
            }
        }
    }
    
    private bool IsValidShipPlacement(Board board, BoardPosition pos, int dir, List<BoardPosition> lastMoves)
    {
        if (pos.GetShip() != null)
        {
            return false;
        }
        
        // 1 = Left, 2 = Up, 3 = Right, 4 = Down
        if ((pos.GetNumPosition() == 1 && dir == 1) || (pos.GetNumPosition() == 7 && dir == 3))
        {
            return false;
        }

        if ((pos.GetLetterPosition() == 'A' && dir == 2) || (pos.GetLetterPosition() == board.GetLetterList()[board.GetY() - 1] && dir == 4))
        {
            return false;
        }

        if (dir is 1 or 3 && pos.GetLetterPosition() != lastMoves[^1].GetLetterPosition())
        {
            return false;
        }
        
        return true;
    }
}