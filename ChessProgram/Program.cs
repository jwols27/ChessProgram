using System;
using board;
using chess;

namespace ChessProgram {
    class Program {
        static void Main(string[] args) {

            try {
                Board board = new Board(8, 8);

                board.placePiece(new Rook(Color.Black, board), new Position(0, 0));
                board.placePiece(new Queen(Color.Black, board), new Position(1, 3));
                board.placePiece(new King(Color.Black, board), new Position(2, 4));


                GameView.viewBoard(board);
            } catch (BoardException e) {
                Console.WriteLine(e.Message);
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
            }
        }
    }
}
