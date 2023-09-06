using board;

namespace chess {
    class Pawn : ChessPiece {
        public Pawn(Color color, Board board) : base(color, board) {

        }

        public override string ToString() {
            return "P";
        }

        public override bool[,] possibleMoves() {
            bool[,] mat = new bool[board.rows, board.columns];

            Position pos = new Position(0, 0);

            int x = 0;

            if (color == Color.White)
                x = -1;
            if (color == Color.Black)
                x = 1;

            pos.setValues(position.row + x, position.column);
            if (board.isPositionValid(pos) && canMove(pos))
                mat[pos.row, pos.column] = true;

            if (moveCount == 0) {
                pos.setValues(position.row + (x*2), position.column);
                if (board.isPositionValid(pos) && canMove(pos))
                    mat[pos.row, pos.column] = true;
            }

            pos.setValues(position.row + x, position.column - 1);
            if (board.piece(pos) != null && board.piece(pos).color != color)
                mat[pos.row, pos.column] = true;

            pos.setValues(position.row + x, position.column + 1);
            if (board.piece(pos) != null && board.piece(pos).color != color)
                mat[pos.row, pos.column] = true;

            return mat;
        }
    }
}

