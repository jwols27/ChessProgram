using board;

namespace chess {
    class Knight : Piece {
        public Knight(Color color, Board board) : base(color, board) {

        }

        public override string ToString() {
            return "N";
        }

        private bool canMove(Position pos) {
            Piece p = board.piece(pos);
            return p == null || p.color != color;
        }

        public override bool[,] possibleMoves() {
            bool[,] mat = new bool[board.rows, board.columns];

            Position pos = new Position(0, 0);

            pos.setValues(position.row + 2, position.column - 1);
            if (board.isPositionValid(pos) && canMove(pos))
                mat[pos.row, pos.column] = true;

            pos.setValues(position.row + 1, position.column - 2);
            if (board.isPositionValid(pos) && canMove(pos))
                mat[pos.row, pos.column] = true;

            pos.setValues(position.row + 2, position.column + 1);
            if (board.isPositionValid(pos) && canMove(pos))
                mat[pos.row, pos.column] = true;

            pos.setValues(position.row + 1, position.column + 2);
            if (board.isPositionValid(pos) && canMove(pos))
                mat[pos.row, pos.column] = true;



            pos.setValues(position.row - 2, position.column - 1);
            if (board.isPositionValid(pos) && canMove(pos))
                mat[pos.row, pos.column] = true;

            pos.setValues(position.row - 1, position.column - 2);
            if (board.isPositionValid(pos) && canMove(pos))
                mat[pos.row, pos.column] = true;

            pos.setValues(position.row - 2, position.column + 1);
            if (board.isPositionValid(pos) && canMove(pos))
                mat[pos.row, pos.column] = true;

            pos.setValues(position.row - 1, position.column + 2);
            if (board.isPositionValid(pos) && canMove(pos))
                mat[pos.row, pos.column] = true;

            return mat;
        }
    }
}

