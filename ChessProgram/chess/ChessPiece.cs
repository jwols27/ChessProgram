using board;

namespace chess {
    abstract class ChessPiece : Piece {

        public ChessPiece(Color color, Board board) : base(color, board) {

        }

        protected bool canMove(Position pos) {
            Piece p = board.piece(pos);
            return p == null || p.color != color;
        }


        public abstract override bool[,] possibleMoves();

    }
}
