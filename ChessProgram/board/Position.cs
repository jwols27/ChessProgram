namespace board {
    class Position {

        public int row { get; set; }
        public int column { get; set; }

        public Position(int row, int column) {
            this.row = row;
            this.column = column;
        }

        public void setValues(int row, int column) {
            this.row = row;
            this.column = column;
        }

        public Position setColumn(int value) {
            return new Position(row, column + value);
        }

        public Position setRow(int value) {
            return new Position(row + value, column);
        }

        public override string ToString() {
            return row + ", " + column;
        }

    }
}
