﻿using board;

namespace chess {
    class Rook : Piece {
        public Rook(Color color, Board board) : base(color, board) {

        }

        public override string ToString() {
            return "R";
        }

        private bool canMove(Position pos) {
            Piece p = board.piece(pos);
            return p == null || p.color != color;
        }

        public override bool[,] possibleMoves() {
            bool[,] mat = new bool[board.rows, board.columns];

            Position pos = new Position(0, 0);

            pos.setValues(position.row - 1, position.column);
            while(board.isPositionValid(pos) && canMove(pos)) {
                mat[pos.row, pos.column] = true;
                if(board.piece(pos) != null && board.piece(pos).color != color) {
                    break;
                }
                pos.row -= 1;
            }

            pos.setValues(position.row + 1, position.column);
            while (board.isPositionValid(pos) && canMove(pos)) {
                mat[pos.row, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color) {
                    break;
                }
                pos.row += 1;
            }

            pos.setValues(position.row, position.column - 1);
            while (board.isPositionValid(pos) && canMove(pos)) {
                mat[pos.row, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color) {
                    break;
                }
                pos.column -= 1;
            }

            pos.setValues(position.row, position.column + 1);
            while (board.isPositionValid(pos) && canMove(pos)) {
                mat[pos.row, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color) {
                    break;
                }
                pos.column += 1;
            }

            return mat;
        }
    }
}

