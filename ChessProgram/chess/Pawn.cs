using board;

namespace chess {
    class Pawn : Piece {
        public Pawn(Color color, Board board) : base(color, board) {

        }

        public override string ToString() {
            return "P";
        }
    }
}

