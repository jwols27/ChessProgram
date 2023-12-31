﻿using board;

namespace chess {
    class ChessPosition {

        public int row { get; set; }
        public char column { get; set; }

        public ChessPosition(char column, int row) {
            this.row = row;
            this.column = column;
        }

        public Position toPosition() {
            return new Position(8 - row, column - 'a');
        }

        public override string ToString() {
            return "" + column + row;
        }
    }
}
