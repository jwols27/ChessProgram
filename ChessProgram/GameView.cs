using System;
using System.Collections.Generic;
using board;
using chess;

namespace ChessProgram {
    class GameView {
        public static void renderMatch(ChessMatch match, bool[,] posMoves = null) {
            renderMatchInfo(match);

            Board board = match.board;
            if (posMoves == null) posMoves = new bool[board.rows, board.columns];
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
            if (match.check && !match.isOver)
                Console.WriteLine("\n   YOU ARE IN CHECK!");
            if (match.isOver)
                Console.WriteLine("\n   CHECKMATE!!!");
        }

        public static void renderMatchInfo(ChessMatch match) {
            Console.Clear();
            Console.WriteLine("Turn " + match.turn);
            if(match.isOver)
                Console.WriteLine(match.currentPlayer + " wins!");
            else
                Console.WriteLine("Waiting for " + match.currentPlayer + " to play\n");
            renderCapturedPieces(match);
        }

        public static void renderCapturedPieces(ChessMatch match) {
            ConsoleColor aux = Console.ForegroundColor;
            Console.WriteLine("Captured pieces:");

            changeForegroundColor(Color.White);
            Console.Write("White: ");
            renderPieceSet(match.capturedPieces(Color.White));
            
            changeForegroundColor(Color.Black);
            Console.Write("Black: ");
            renderPieceSet(match.capturedPieces(Color.Black));

            Console.WriteLine();
            Console.ForegroundColor = aux;
        }

        public static void renderPieceSet(HashSet<Piece> set) {
            Console.Write("[");

            Console.Write(String.Join(", ", set));
                
            Console.WriteLine("]");
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
            changeForegroundColor(p.color);
            Console.Write(p);
            Console.ForegroundColor = aux;
        }

        public static void changeForegroundColor(Color color) {
            switch (color) {
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
        }
    }

}
