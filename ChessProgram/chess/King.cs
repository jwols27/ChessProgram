using board;

namespace chess {
    class King : ChessPiece {
        public King(Color color, Board board) : base(color, board) { 
        
        }

        public override string ToString() {
            return "K";
        }

        public override bool[,] possibleMoves() {
            bool[,] mat = new bool[board.rows, board.columns];

            Position pos = new Position(0, 0);

            pos.setValues(position.row - 1, position.column);
            if(board.isPositionValid(pos) && canMove(pos))
                mat[pos.row, pos.column] = true;

            pos.setValues(position.row - 1, position.column + 1);
            if (board.isPositionValid(pos) && canMove(pos))
                mat[pos.row, pos.column] = true;

            pos.setValues(position.row - 1, position.column - 1);
            if (board.isPositionValid(pos) && canMove(pos))
                mat[pos.row, pos.column] = true;

            pos.setValues(position.row + 1, position.column);
            if (board.isPositionValid(pos) && canMove(pos))
                mat[pos.row, pos.column] = true;

            pos.setValues(position.row + 1, position.column + 1);
            if (board.isPositionValid(pos) && canMove(pos))
                mat[pos.row, pos.column] = true;

            pos.setValues(position.row + 1, position.column - 1);
            if (board.isPositionValid(pos) && canMove(pos))
                mat[pos.row, pos.column] = true;

            pos.setValues(position.row, position.column + 1);
            if (board.isPositionValid(pos) && canMove(pos))
                mat[pos.row, pos.column] = true;

            pos.setValues(position.row, position.column - 1);
            if (board.isPositionValid(pos) && canMove(pos))
                mat[pos.row, pos.column] = true;

            return mat;
        }
    }
}
