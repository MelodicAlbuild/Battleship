namespace MelodicAlbuild.Games.Battleship.lib.Exceptions;

[Serializable]
public class BoardSizeException : Exception
{
    public BoardSizeException() { }
    
    public BoardSizeException(string message) : base(message) { }
    
    public BoardSizeException(string message, Exception inner) : base(message, inner) { }
}