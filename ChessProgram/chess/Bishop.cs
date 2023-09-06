using board;

namespace chess {
    class Bishop : Piece {
        public Bishop(Color color, Board board) : base(color, board) {

        }

        public override string ToString() {
            return "B";
        }

        public override bool[,] possibleMoves() {
            bool[,] mat = new bool[board.rows, board.columns];

            return mat;
        }
    }
}

