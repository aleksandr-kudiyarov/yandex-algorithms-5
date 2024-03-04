namespace Kudiyarov.YandexAlgorithms5.AD;

public static class Program
{
    public static void Main()
    {
        var input = File.ReadAllLines("input.txt");
        var solution = Solution(input);
        File.WriteAllText("output.txt", solution);
    }

    public static string Solution(string[] input)
    {
        return InnerSolution(input).ToString();
    }

    private static int InnerSolution(string[] input)
    {
        var board = GetBoard(input);
        return 0;
    }

    private static Board GetBoard(string[] input)
    {
        const int size = 8;

        var pieces = new List<Piece>();

        var board = new Board
        {
            Pieces = pieces
        };
        
        for (var i = 0; i < size; i++)
        {
            for (var j = 0; j < size; j++)
            {
                var pieceType = GetPiece(input[i][j]);

                if (pieceType is PieceType.Bishop or PieceType.Rook)
                {
                    var piece = new Piece
                    {
                        Type = pieceType,
                        X = i,
                        Y = j
                    };
                    
                    pieces.Add(piece);
                }
                
                board.Grid[i, j] = pieceType;
            }
        }

        return board;
    }

    private static PieceType GetPiece(char ch)
    {
        switch (ch)
        {
            case '*':
                return PieceType.Empty;
            case 'r':
            case 'R':
                return PieceType.Rook;
            case 'b':
            case 'B':
                return PieceType.Bishop;
            default:
                throw new ArgumentOutOfRangeException(nameof(ch), ch, "Char is invalid");
        }
    }
}

public class Board
{
    public PieceType[,] Grid { get; } = new PieceType[8,8];
    public IReadOnlyList<Piece> Pieces { get; set; }
}

public class Piece
{
    public PieceType Type { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
}

public enum PieceType : byte
{
    Empty = 0,
    Rook = 1,
    Bishop = 2
}