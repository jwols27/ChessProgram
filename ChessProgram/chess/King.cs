using board;

namespace chess {
    class King : ChessPiece {
        private ChessMatch match;

        public King(Color color, Board board, ChessMatch match) : base(color, board) {
            this.match = match;
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

            // Castling
            if(moveCount == 0 && !match.check) {
                
                // Short Castle
                pos.setValues(position.row, position.column + 3);
                Piece R = board.piece(pos);
                if(R != null && R.color == color && R.moveCount == 0) {
                    bool emptyRight =
                        board.isPositionEmpty(pos.setColumn(-1)) &&
                        board.isPositionEmpty(pos.setColumn(-2));
                    if (emptyRight)
                        mat[position.row, position.column + 2] = true;
                }

                // Long Castle
                pos.setValues(position.row, position.column - 4);
                R = board.piece(pos);
                if (R != null && R.color == color && R.moveCount == 0) {
                    bool emptyLeft = 
                        board.isPositionEmpty(pos.setColumn(1)) &&
                        board.isPositionEmpty(pos.setColumn(2)) &&
                        board.isPositionEmpty(pos.setColumn(3));
                    if (emptyLeft)
                        mat[position.row, position.column - 2] = true;
                }
            }



            return mat;
        }
    }
}
