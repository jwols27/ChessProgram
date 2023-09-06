using System;
using board;
using chess;

namespace ChessProgram {
    class Program {
        static void Main(string[] args) {

            ChessMatch match = new ChessMatch();
            while (!match.isOver) {
                try {
                    GameView.renderMatch(match);

                    Console.WriteLine("\nFrom:");
                    Position start = GameView.readChessPosition().toPosition();
                    match.validateStart(start);

                    bool[,] possibleMoves = match.board.piece(start).possibleMoves();

                    GameView.renderMatch(match, possibleMoves);

                    Console.WriteLine("\nTo:");
                    Position end = GameView.readChessPosition().toPosition();
                    match.validateEnd(start, end);

                    match.play(start, end);
                }
                catch (BoardException e) {
                    Console.WriteLine(e.Message);
                    Console.ReadLine();
                }
            }
            GameView.renderMatch(match);
        }
    }
}

