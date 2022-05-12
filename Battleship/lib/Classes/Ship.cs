using MelodicAlbuild.Games.Battleship.lib.Enums;

namespace MelodicAlbuild.Games.Battleship.lib.Classes;

public class Ship
{
    private ShipType type;
    private int length;
    private char shipChar;
    
    public Ship(ShipType shipType, int length)
    {
        type = shipType;
        this.length = length;
        
        switch (type)
        {
            case ShipType.Battleship:
                shipChar = 'B';
                break;
            case ShipType.Cruiser:
                shipChar = 'C';
                break;
            case ShipType.Destroyer:
                shipChar = 'D';
                break;
        }
    }

    public int GetLength()
    {
        return length;
    }

    public char GetShipChar()
    {
        return shipChar;
    }
}