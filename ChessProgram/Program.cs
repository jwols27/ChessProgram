using System;
using board;
using chess;

namespace ChessProgram {
    class Program {
        static void Main(string[] args) {

            try {
                ChessMatch match = new ChessMatch();


                GameView.renderBoard(match.board);
            } catch (BoardException e) {
                Console.WriteLine(e.Message);
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
            }
        }
    }
}
