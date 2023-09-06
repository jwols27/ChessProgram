using System;
using board;
using chess;

namespace ChessProgram {
    class Program {
        static void Main(string[] args) {

            ChessMatch match = new ChessMatch();
            while (!match.isOver) {
                try {
                    Console.Clear();
                    Console.WriteLine("Turn " + match.turn);
                    Console.WriteLine("Waiting for " + match.currentPlayer + " to play\n");
                    GameView.renderBoard(match.board);

                    Console.WriteLine("\nFrom:");
                    Position start = GameView.readChessPosition().toPosition();
                    match.validatePlay(start);

                    bool[,] possibleMoves = match.board.piece(start).possibleMoves();

                    Console.Clear();
                    Console.WriteLine("Turn " + match.turn);
                    Console.WriteLine("Waiting for " + match.currentPlayer + " to play\n");
                    GameView.renderBoard(match.board, possibleMoves);

                    Console.WriteLine("\nTo:");
                    Position end = GameView.readChessPosition().toPosition();

                    match.play(start, end);
                }
                catch (BoardException e) {
                    Console.WriteLine(e.Message);
                    Console.ReadLine();
                }
            }
        }
    }
}

