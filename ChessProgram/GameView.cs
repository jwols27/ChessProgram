using System;
using board;

namespace ChessProgram {
    class GameView {
        public static void renderBoard(Board board) {
            for(int i = 0; i < board.rows; i++) {
                Console.Write(8 - i + " ");
                for (int j = 0; j < board.columns; j++) {
                    Position pos = new Position(i, j);
                    if (board.isPositionEmpty(pos))
                        Console.Write("-");
                    else
                        renderPiece(board.piece(pos));
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        public static void renderPiece(Piece p) {
            ConsoleColor aux = Console.ForegroundColor;
            switch (p.color) {
                case Color.Black:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case Color.Red:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                default:
                    break;
            }
            Console.Write(p);
            Console.ForegroundColor = aux;
        }
    }

}
