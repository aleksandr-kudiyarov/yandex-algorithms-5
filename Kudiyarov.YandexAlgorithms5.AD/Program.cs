using System;
using System.Collections.Generic;
using System.IO;

namespace Kudiyarov.YandexAlgorithms5.AD;

public static class Program
{
    private const int BoardSize = 8;

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
        var solution = GetSolution(board);
        return solution;
    }

    private static int GetSolution(Board board)
    {
        var set = new HashSet<Point>();
        Func<int, int> incr = i => ++i;
        Func<int, int> decr = i => --i;
        Func<int, int> same = i => i;

        foreach (var piece in board.Pieces)
        {
            set.Add(piece.Point);

            if (piece.Type == PieceType.Rook)
            {
                // up
                Do(board, piece, set, same, decr);

                // right
                Do(board, piece, set, incr, same);

                // left
                Do(board, piece, set, decr, same);

                // down
                Do(board, piece, set, same, incr);
            }
            else
            {
                // up
                Do(board, piece, set, incr, decr);

                // right
                Do(board, piece, set, incr, incr);

                // left
                Do(board, piece, set, decr, incr);

                // down
                Do(board, piece, set, decr, decr);
            }
        }

        return BoardSize * BoardSize - set.Count;
    }

    private static void Do(Board board, Piece piece, ISet<Point> points, Func<int, int> xFunc, Func<int, int> yFunc)
    {
        var x = piece.Point.X;
        var y = piece.Point.Y;

        while (true)
        {
            x = xFunc(x);

            if (x is < 0 or > BoardSize - 1)
            {
                break;
            }

            y = yFunc(y);

            if (y is < 0 or > BoardSize - 1)
            {
                break;
            }

            var point = new Point { X = x, Y = y };
            points.Add(point);

            if (board.Grid[x, y] != PieceType.Empty)
            {
                break;
            }
        }
    }

    private static Board GetBoard(string[] input)
    {
        var pieces = new List<Piece>();

        var board = new Board
        {
            Pieces = pieces
        };

        for (var i = 0; i < BoardSize; i++)
        for (var j = 0; j < BoardSize; j++)
        {
            var pieceType = GetPiece(input[i][j]);

            if (pieceType is PieceType.Bishop or PieceType.Rook)
            {
                var piece = new Piece
                {
                    Type = pieceType,
                    Point = new Point { X = j, Y = i }
                };

                pieces.Add(piece);
            }

            board.Grid[j, i] = pieceType;
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
    public PieceType[,] Grid { get; } = new PieceType[8, 8];
    public IReadOnlyList<Piece> Pieces { get; set; }
}

public class Piece
{
    public PieceType Type { get; set; }
    public Point Point { get; set; }
}

public record struct Point
{
    public int X { get; set; }
    public int Y { get; set; }
}

public enum PieceType : byte
{
    Empty = 0,
    Rook = 1,
    Bishop = 2
}