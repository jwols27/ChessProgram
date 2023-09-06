namespace board {
    abstract class Piece {

        public Position position { get; set; }
        public Color color { get; protected set; }
        public int moveCount { get; protected set; }

        public Board board { get; protected set; }

        public Piece(Color color, Board board) {
            this.position = null;
            this.color = color;
            this.board = board;
            this.moveCount = 0;
        }

        public void incrementMoveCount() {
            moveCount++;
        }

        public bool hasPossibleMoves() {
            bool[,] mat = possibleMoves();
            for (int i = 0; i < board.rows; i++)
                for (int j = 0; j < board.columns; j++)
                    if (mat[i, j]) return true;
            return false;
        }

        public bool canMoveTo(Position pos) {
            return possibleMoves()[pos.row, pos.column];
        }

        public abstract bool[,] possibleMoves();
    }
}
