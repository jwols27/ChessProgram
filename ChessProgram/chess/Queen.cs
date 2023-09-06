using board;

namespace chess {
    class Queen : Piece {
        public Queen(Color color, Board board) : base(color, board) {

        }

        public override string ToString() {
            return "Q";
        }

        public override bool[,] possibleMoves() {
            bool[,] mat = new bool[board.rows, board.columns];

            return mat;
        }
    }
}

