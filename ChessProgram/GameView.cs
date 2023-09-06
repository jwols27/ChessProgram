using System;
using board;
using chess;

namespace ChessProgram {
    class GameView {
        public static void renderBoard(Board board) {
            for(int i = 0; i < board.rows; i++) {
                Console.Write(8 - i + "  ");
                for (int j = 0; j < board.columns; j++) {
                    renderPiece(board.piece(new Position(i, j)));
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("\n   a b c d e f g h");
        }

        public static void renderBoard(Board board, bool[,] posMoves) {

            ConsoleColor originalBg = Console.BackgroundColor;
            ConsoleColor highlightedBg = ConsoleColor.DarkGray;

            for (int i = 0; i < board.rows; i++) {
                Console.Write(8 - i + "  ");
                for (int j = 0; j < board.columns; j++) {
                    Console.BackgroundColor = (posMoves[i, j]) ? highlightedBg : originalBg;
                    renderPiece(board.piece(new Position(i, j)));
                    Console.Write(" ");
                }
                Console.WriteLine();
                Console.BackgroundColor = originalBg;
            }
            Console.WriteLine("\n   a b c d e f g h");
        }

        public static ChessPosition readChessPosition() {
            string s = Console.ReadLine();
            char column = s[0];
            int row = int.Parse(s[1] + "");
            return new ChessPosition(column, row);
        }

        public static void renderPiece(Piece p) {
            if(p == null) {
                Console.Write("-");
                return;
            }

            ConsoleColor aux = Console.ForegroundColor;
            switch (p.color) {
                case Color.Black:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case Color.Blue:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                case Color.Red:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case Color.White:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                default:
                    break;
            }
            Console.Write(p);
            Console.ForegroundColor = aux;
        }
    }

}
