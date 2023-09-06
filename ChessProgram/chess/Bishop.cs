using board;

namespace chess {
    class Bishop : Piece {
        public Bishop(Color color, Board board) : base(color, board) {

        }

        public override string ToString() {
            return "B";
        }

        private bool canMove(Position pos) {
            Piece p = board.piece(pos);
            return p == null || p.color != color;
        }

        public override bool[,] possibleMoves() {
            bool[,] mat = new bool[board.rows, board.columns];

            Position pos = new Position(0, 0);

            pos.setValues(position.row + 1, position.column + 1);
            while (board.isPositionValid(pos) && canMove(pos)) {
                mat[pos.row, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color) {
                    break;
                }
                pos.row += 1;
                pos.column += 1;
            }

            pos.setValues(position.row - 1, position.column - 1);
            while (board.isPositionValid(pos) && canMove(pos)) {
                mat[pos.row, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color) {
                    break;
                }
                pos.row -= 1;
                pos.column -= 1;
            }

            pos.setValues(position.row + 1, position.column - 1);
            while (board.isPositionValid(pos) && canMove(pos)) {
                mat[pos.row, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color) {
                    break;
                }
                pos.row += 1;
                pos.column -= 1;
            }

            pos.setValues(position.row - 1, position.column + 1);
            while (board.isPositionValid(pos) && canMove(pos)) {
                mat[pos.row, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color) {
                    break;
                }
                pos.row -= 1;
                pos.column += 1;
            }

            return mat;
        }
    }
}

