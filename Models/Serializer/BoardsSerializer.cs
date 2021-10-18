using System.Collections.Generic;
public class Board
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Logo { get; set; }
}

public class BoardResquest
{
    public int Id {get; set;}
}

public class ListBoardResponse{
    public List<Board> Boards = new List<Board>();
}

public class PostBoardResponse{
    public Board Board {get; set;}
}
