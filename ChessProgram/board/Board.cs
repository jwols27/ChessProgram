﻿using System;

namespace board {
    class Board {
        public int rows { get; set; }
        public int columns { get; set; }
        private Piece[,] pieces;

        public Board(int rows, int columns) {
            this.rows = rows;
            this.columns = columns;
            pieces = new Piece[rows, columns];
        }

        public Piece piece(Position pos) {
            if (!isPositionValid(pos)) 
                throw new BoardException("Invalid position");
                
            return pieces[pos.row, pos.column];
        }

        public Piece piece(int row, int column) {
            return pieces[row, column];
        }

        public void placePiece(Piece p, Position pos) {
            if (!isPositionEmpty(pos))
                throw new BoardException("The desired position is not empty");
            pieces[pos.row, pos.column] = p;
            p.position = pos;
        }

        public Piece removePiece(Position pos) {
            if (isPositionEmpty(pos)) return null;

            Piece aux = piece(pos);
            aux.position = null;
            pieces[pos.row, pos.column] = null;
            return aux;
        }

        public bool isPositionEmpty(Position pos) {
            validatePosition(pos);
            return piece(pos) == null;
        }

        public bool isPositionValid(Position pos) {
            if((pos.row < 0 || pos.row >= rows) || (pos.column < 0 || pos.column >= columns)) {
                return false;
            }
            return true;
        }

        public void validatePosition(Position pos) {
            if (!isPositionValid(pos))
                throw new BoardException("Invalid Position");
        }
    }
}
