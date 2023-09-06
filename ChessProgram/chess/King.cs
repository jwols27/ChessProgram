using board;

namespace chess {
    class King : Piece {
        public King(Color color, Board board) : base(color, board) { 
        
        }

        public override string ToString() {
            return "K";
        }

        private bool canMove(Position pos) {
            Piece p = board.piece(pos);
            return p == null || p.color != color;
        }

        public override bool[,] possibleMoves() {
            bool[,] mat = new bool[board.rows, board.columns];

            Position pos = new Position(0, 0);

            pos.setValues(pos.row - 1, pos.column);
            if(board.isPositionValid(pos) && canMove(pos))
                mat[pos.row, pos.column] = true;

            pos.setValues(pos.row - 1, pos.column + 1);
            if (board.isPositionValid(pos) && canMove(pos))
                mat[pos.row, pos.column] = true;

            pos.setValues(pos.row - 1, pos.column - 1);
            if (board.isPositionValid(pos) && canMove(pos))
                mat[pos.row, pos.column] = true;

            pos.setValues(pos.row + 1, pos.column);
            if (board.isPositionValid(pos) && canMove(pos))
                mat[pos.row, pos.column] = true;

            pos.setValues(pos.row + 1, pos.column + 1);
            if (board.isPositionValid(pos) && canMove(pos))
                mat[pos.row, pos.column] = true;

            pos.setValues(pos.row + 1, pos.column - 1);
            if (board.isPositionValid(pos) && canMove(pos))
                mat[pos.row, pos.column] = true;

            pos.setValues(pos.row, pos.column + 1);
            if (board.isPositionValid(pos) && canMove(pos))
                mat[pos.row, pos.column] = true;

            pos.setValues(pos.row, pos.column - 1);
            if (board.isPositionValid(pos) && canMove(pos))
                mat[pos.row, pos.column] = true;

            return mat;
        }
    }
}
