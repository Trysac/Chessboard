[System.Serializable]
public enum PieceType 
{ 
    Pawn,
    Bishop,
    Tower,
    Knight,
    King,
    Queen,
    WarDog // Title for the pawn that get to the other size of the board
}

[System.Serializable]
public enum WildcardType
{
    Tramp,
    PowerUp,
    Self_Destruction,
    Telepord,
    Ramdom_Telepord,
    DoubleMove
}
