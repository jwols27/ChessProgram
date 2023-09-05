using System;
using board;

namespace ChessProgram {
    class Program {
        static void Main(string[] args) {
            Board board = new Board(8, 8);

            GameView.viewBoard(board);
        }
    }
}
