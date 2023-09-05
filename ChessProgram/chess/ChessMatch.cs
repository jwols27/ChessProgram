using board;

namespace chess {
    class ChessMatch {
        public Board board { get; private set;}
        private int turn;
        private Color currentPlayer;
        public bool isOver { get; private set; }

        public ChessMatch() {
            board = new Board(8, 8);
            turn = 1;
            currentPlayer = Color.White;
            isOver = false;
            placePieces();
        }

        public void movePiece(Position start, Position end) {
            Piece p = board.removePiece(start);
            p.incrementMoveCount();
            Piece captured = board.removePiece(end);
            board.placePiece(p, end);
        }

        private void placePieces() {
            board.placePiece(new Rook(Color.Black, board), new ChessPosition('a', 8).toPosition());
            board.placePiece(new Knight(Color.Black, board), new ChessPosition('b', 8).toPosition());
            board.placePiece(new Bishop(Color.Black, board), new ChessPosition('c', 8).toPosition());
            board.placePiece(new Queen(Color.Black, board), new ChessPosition('d', 8).toPosition());
            board.placePiece(new King(Color.Black, board), new ChessPosition('e', 8).toPosition());
            board.placePiece(new Bishop(Color.Black, board), new ChessPosition('f', 8).toPosition());
            board.placePiece(new Knight(Color.Black, board), new ChessPosition('g', 8).toPosition());
            board.placePiece(new Rook(Color.Black, board), new ChessPosition('h', 8).toPosition());

            board.placePiece(new Pawn(Color.Black, board), new ChessPosition('a', 7).toPosition());
            board.placePiece(new Pawn(Color.Black, board), new ChessPosition('b', 7).toPosition());
            board.placePiece(new Pawn(Color.Black, board), new ChessPosition('c', 7).toPosition());
            board.placePiece(new Pawn(Color.Black, board), new ChessPosition('d', 7).toPosition());
            board.placePiece(new Pawn(Color.Black, board), new ChessPosition('e', 7).toPosition());
            board.placePiece(new Pawn(Color.Black, board), new ChessPosition('f', 7).toPosition());
            board.placePiece(new Pawn(Color.Black, board), new ChessPosition('g', 7).toPosition());
            board.placePiece(new Pawn(Color.Black, board), new ChessPosition('h', 7).toPosition());

            board.placePiece(new Rook(Color.White, board), new ChessPosition('a', 1).toPosition());
            board.placePiece(new Knight(Color.White, board), new ChessPosition('b', 1).toPosition());
            board.placePiece(new Bishop(Color.White, board), new ChessPosition('c', 1).toPosition());
            board.placePiece(new Queen(Color.White, board), new ChessPosition('d', 1).toPosition());
            board.placePiece(new King(Color.White, board), new ChessPosition('e', 1).toPosition());
            board.placePiece(new Bishop(Color.White, board), new ChessPosition('f', 1).toPosition());
            board.placePiece(new Knight(Color.White, board), new ChessPosition('g', 1).toPosition());
            board.placePiece(new Rook(Color.White, board), new ChessPosition('h', 1).toPosition());

            board.placePiece(new Pawn(Color.White, board), new ChessPosition('a', 2).toPosition());
            board.placePiece(new Pawn(Color.White, board), new ChessPosition('b', 2).toPosition());
            board.placePiece(new Pawn(Color.White, board), new ChessPosition('c', 2).toPosition());
            board.placePiece(new Pawn(Color.White, board), new ChessPosition('d', 2).toPosition());
            board.placePiece(new Pawn(Color.White, board), new ChessPosition('e', 2).toPosition());
            board.placePiece(new Pawn(Color.White, board), new ChessPosition('f', 2).toPosition());
            board.placePiece(new Pawn(Color.White, board), new ChessPosition('g', 2).toPosition());
            board.placePiece(new Pawn(Color.White, board), new ChessPosition('h', 2).toPosition());
        }
    }
}
