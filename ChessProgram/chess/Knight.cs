using board;

namespace chess {
    class Knight : Piece {
        public Knight(Color color, Board board) : base(color, board) {

        }

        public override string ToString() {
            return "N";
        }
    }
}

