using System;
using board;

namespace ChessProgram {
    class GameView {
        public static void viewBoard(Board board) {
            for(int i = 0; i < board.rows; i++) {
                for (int j = 0; j < board.columns; j++) {
                    if (board.isPositionEmpty(new Position(i, j)))
                        Console.Write("-");
                    Console.Write(board.piece(new Position(i, j)) + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
