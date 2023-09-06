using System;
using board;
using chess;

namespace ChessProgram {
    class Program {
        static void Main(string[] args) {

            try {
                ChessMatch match = new ChessMatch();

                while (!match.isOver) {
                    Console.Clear();
                    GameView.renderBoard(match.board);

                    Console.WriteLine("\nFrom:");
                    Position start = GameView.readChessPosition().toPosition();
                    if (match.board.piece(start) == null) continue;

                    bool[,] possibleMoves = match.board.piece(start).possibleMoves();

                    Console.Clear();
                    GameView.renderBoard(match.board, possibleMoves);

                    Console.WriteLine("\nTo:");
                    Position end = GameView.readChessPosition().toPosition();

                    match.movePiece(start, end);

                }


            }
            catch (BoardException e) {
                Console.WriteLine(e.Message);
            }
            //catch (Exception e) {
            //    Console.WriteLine(e.Message);
            //}
        }
    }
}
