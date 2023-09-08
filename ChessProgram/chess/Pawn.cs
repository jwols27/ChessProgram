using board;

namespace chess {
    class Pawn : ChessPiece {

        private ChessMatch match;

        public Pawn(Color color, Board board, ChessMatch match) : base(color, board) {
            this.match = match;
        }

        public override string ToString() {
            return "P";
        }

        public override bool[,] possibleMoves() {
            bool[,] mat = new bool[board.rows, board.columns];

            Position pos = new Position(0, 0);

            int x = 0;

            // En passant
            if (color == Color.White) {
                x = -1;
                if(position.row == 3 && match.enPassantable != null) {
                    Position l = position.setColumn(-1);
                    Position r = position.setColumn(1);
                    Piece left = board.isPositionValid(l) ? board.piece(l) : null;
                    Piece right = board.isPositionValid(r) ? board.piece(r) : null;
                    if (match.enPassantable == left) 
                        mat[l.row + x, l.column] = true;
                    if(match.enPassantable == right)
                        mat[r.row + x, r.column] = true;
                }
            }
                
            if (color == Color.Black) {
                x = 1;
                if (position.row == 4 && match.enPassantable != null) {
                    Position l = position.setColumn(-1);
                    Position r = position.setColumn(1);
                    Piece left = board.isPositionValid(l) ? board.piece(l) : null;
                    Piece right = board.isPositionValid(r) ? board.piece(r) : null;
                    if (match.enPassantable == left)
                        mat[l.row + x, l.column] = true;
                    if (match.enPassantable == right)
                        mat[r.row + x, r.column] = true;
                }
            }

            pos.setValues(position.row + x, position.column);
            if (board.isPositionValid(pos) && canMove(pos))
                mat[pos.row, pos.column] = true;

            if (moveCount == 0) {
                pos.setValues(position.row + (x*2), position.column);
                if (board.isPositionValid(pos) && canMove(pos))
                    mat[pos.row, pos.column] = true;
            }

            pos.setValues(position.row + x, position.column - 1);
            if(board.isPositionValid(pos))
                if (board.piece(pos) != null && board.piece(pos).color != color)
                    mat[pos.row, pos.column] = true;

            pos.setValues(position.row + x, position.column + 1);
            if (board.isPositionValid(pos))
                if (board.piece(pos) != null && board.piece(pos).color != color)
                    mat[pos.row, pos.column] = true;

            return mat;
        }
    }
}

