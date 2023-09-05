using System;
using board;

namespace ChessProgram {
    class GameView {
        public static void viewBoard(Board board) {
            for(int i = 0; i < board.rows; i++) {
                for (int j = 0; j < board.columns; j++) {
                    if (board.piece(i, j) == null)
                        Console.Write("-");
                    Console.Write(board.piece(i, j) + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
