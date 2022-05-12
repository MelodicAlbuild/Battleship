using MelodicAlbuild.Games.Battleship.lib.Enums;

namespace MelodicAlbuild.Games.Battleship.lib.Classes;

public class BoardPosition
{
    private char letterPosition;
    private int numPosition;
    private PositionStatus status;
    private Ship? positionShip;

    public BoardPosition(char letter, int num)
    {
        letterPosition = letter;
        numPosition = num;
        status = PositionStatus.Blank;
        positionShip = null;
    }

    public char GetLetterPosition()
    {
        return letterPosition;
    }

    public int GetNumPosition()
    {
        return numPosition;
    }

    public PositionStatus GetPositionStatus()
    {
        return status;
    }

    public PositionStatus UpdatePositionStatus(PositionStatus newStatus)
    {
        status = newStatus;
        return status;
    }

    public Ship? UpdatePositionShip(Ship? newShip)
    {
        positionShip = newShip;
        return positionShip;
    }

    public void ClearPositionShip()
    {
        positionShip = null;
    }

    public Ship? GetShip()
    {
        return positionShip;
    }

    public string GetShipString()
    {
        if (positionShip != null)
        {
            return positionShip.GetShipChar().ToString();
        }
        else
        {
            return " ";
        }
    }

    public override string ToString()
    {
        string ship = "";
        if (positionShip != null)
        {
            ship = positionShip.GetShipChar().ToString();
        }
        
        return "" + letterPosition + numPosition + " | " + status + " | " + ship;
    }
}