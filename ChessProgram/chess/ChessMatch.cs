using System.Linq;
using System.Collections.Generic;
using board;


namespace chess {
    class ChessMatch {
        public Board board { get; private set;}
        public int turn { get; private set; }
        public Color currentPlayer { get; private set; }
        public bool isOver { get; private set; }
        private HashSet<Piece> active;
        private HashSet<Piece> captured;

        public ChessMatch() {
            board = new Board(8, 8);
            turn = 1;
            currentPlayer = Color.White;
            isOver = false;
            active = new HashSet<Piece>();
            captured = new HashSet<Piece>();
            placePieces();
        }

        public HashSet<Piece> activePieces(Color color) {
            HashSet<Piece> aux = active.Where(p => p.color == color).ToHashSet();
            aux.ExceptWith(capturedPieces(color));
            return aux;
        }

        public HashSet<Piece> capturedPieces(Color color) {
            return captured.Where(p => p.color == color).ToHashSet();
        }

        public void movePiece(Position start, Position end) {
            Piece p = board.removePiece(start);
            p.incrementMoveCount();
            Piece capped = board.removePiece(end);
            if (capped != null)
                captured.Add(capped);
            board.placePiece(p, end);
        }

        public void play(Position start, Position end) {
            movePiece(start, end);
            turn++;
            changePlayer();
        }

        public void changePlayer() {
            if (currentPlayer == Color.White) {
                currentPlayer = Color.Black;
                return;
            }
            currentPlayer = Color.White;
        }

        public void validateStart(Position pos) {
            if (board.piece(pos) == null)
                throw new BoardException("There are no pieces in the chosen position");
            if (currentPlayer != board.piece(pos).color)
                throw new BoardException("You cannot move your opponent's pieces");
            if (!board.piece(pos).hasPossibleMoves())
                throw new BoardException("This piece has no possible moves");
        }

        public void validateEnd(Position start, Position end) {
            if (!board.piece(start).canMoveTo(end))
                throw new BoardException("Invalid end position");
        }

        public void placeNewPiece(char col, int row, Piece piece) {
            board.placePiece(piece, new ChessPosition(col, row).toPosition());
            active.Add(piece);
        }

        private void placePieces() {
            placeNewPiece('a', 8, new Rook(Color.Black, board));
            placeNewPiece('b', 8, new Knight(Color.Black, board));
            placeNewPiece('c', 8, new Bishop(Color.Black, board));
            placeNewPiece('d', 8, new Queen(Color.Black, board));
            placeNewPiece('e', 8, new King(Color.Black, board));
            placeNewPiece('f', 8, new Bishop(Color.Black, board));
            placeNewPiece('g', 8, new Knight(Color.Black, board));
            placeNewPiece('h', 8, new Rook(Color.Black, board));

            //placeNewPiece('a', 7, new Pawn(Color.Black, board));
            //placeNewPiece('b', 7, new Pawn(Color.Black, board));
            //placeNewPiece('c', 7, new Pawn(Color.Black, board));
            //placeNewPiece('d', 7, new Pawn(Color.Black, board));
            //placeNewPiece('e', 7, new Pawn(Color.Black, board));
            //placeNewPiece('f', 7, new Pawn(Color.Black, board));
            //placeNewPiece('g', 7, new Pawn(Color.Black, board));
            //placeNewPiece('h', 7, new Pawn(Color.Black, board));

            placeNewPiece('a', 1, new Rook(Color.White, board));
            placeNewPiece('b', 1, new Knight(Color.White, board));
            placeNewPiece('c', 1, new Bishop(Color.White, board));
            placeNewPiece('d', 1, new Queen(Color.White, board));
            placeNewPiece('e', 1, new King(Color.White, board));
            placeNewPiece('f', 1, new Bishop(Color.White, board));
            placeNewPiece('g', 1, new Knight(Color.White, board));
            placeNewPiece('h', 1, new Rook(Color.White, board));

            //placeNewPiece('a', 2, new Pawn(Color.White, board));
            //placeNewPiece('b', 2, new Pawn(Color.White, board));
            //placeNewPiece('c', 2, new Pawn(Color.White, board));
            //placeNewPiece('d', 2, new Pawn(Color.White, board));
            //placeNewPiece('e', 2, new Pawn(Color.White, board));
            //placeNewPiece('f', 2, new Pawn(Color.White, board));
            //placeNewPiece('g', 2, new Pawn(Color.White, board));
            //placeNewPiece('h', 2, new Pawn(Color.White, board));

        }
    }
}
