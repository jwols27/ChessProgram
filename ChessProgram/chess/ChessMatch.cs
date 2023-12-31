﻿using System.Linq;
using System.Collections.Generic;
using board;


namespace chess {
    class ChessMatch {
        public Board board { get; private set;}
        public int turn { get; private set; }
        public Color currentPlayer { get; private set; }
        public bool isOver { get; private set; }
        public bool check { get; private set; }
        private HashSet<Piece> active;
        private HashSet<Piece> captured;
        public Piece enPassantable { get; private set; }

        public ChessMatch() {
            board = new Board(8, 8);
            turn = 1;
            currentPlayer = Color.White;
            isOver = false;
            check = false;
            active = new HashSet<Piece>();
            captured = new HashSet<Piece>();
            enPassantable = null;
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

        public void changePlayer() {
            if (currentPlayer == Color.White) {
                currentPlayer = Color.Black;
                return;
            }
            currentPlayer = Color.White;
        }

        public Color opponent(Color color) {
            if (color == Color.White)
                return Color.Black;
            return Color.White;
        }

        public King king(Color color) {
            foreach (Piece p in activePieces(color))
                if (p is King) return p as King;
            return null;
        }

        public bool isKingInCheck(Color color) {
            King K = king(color);
            if (K == null)
                throw new BoardException("There is no " + color + " king");
            foreach (Piece p in activePieces(opponent(color))) {
                bool[,] mat = p.possibleMoves();
                if (mat[K.position.row, K.position.column]) 
                    return true;          
            }
            return false;
        }

        public bool isKingInCheckmate(Color color) {
            if (!isKingInCheck(color))
                return false;
            foreach(Piece p in activePieces(color)) {
                bool[,] mat = p.possibleMoves();
                for(int i = 0; i < board.rows; i++)
                    for (int j = 0; j < board.columns; j++)
                        if (mat[i, j]) {
                            Position start = p.position;
                            Position end = new Position(i, j);
                            Piece capped = movePiece(start, end);
                            bool isChecked = isKingInCheck(color);
                            undoMove(start, end, capped);
                            if (!isChecked) return false;
                        }
            }
            return true;
        }

        private Piece promotePiece(Piece p, Position start, Position end, Piece capped) {
            System.Console.WriteLine("\nChoose a promotion:");
            System.Console.WriteLine("Q R B N");
            char promo = System.Console.ReadLine()[0];
            active.Remove(p);
            switch (promo) {
                case 'Q':
                    p = new Queen(p.color, board);
                    break;
                case 'R':
                    p = new Rook(p.color, board);
                    break;
                case 'B':
                    p = new Bishop(p.color, board);
                    break;
                case 'N':
                    p = new Knight(p.color, board);
                    break;
                default:
                    active.Add(p);
                    undoMove(start, end, capped);
                    throw new BoardException("Invalid promotion");
            }
            active.Add(p);
            return p;
        }

        public Piece movePiece(Position start, Position end) {
            Piece p = board.removePiece(start);
            p.incrementMoveCount();
            Piece capped = board.removePiece(end);
            if (capped != null)
                captured.Add(capped);

            // Castling
            if (p is King && end.column == start.column + 2)
                movePiece(start.setColumn(3), start.setColumn(1));

            if (p is King && end.column == start.column - 2)
                movePiece(start.setColumn(-4), start.setColumn(-1));

            // En passant
            if (p is Pawn && (end.row == start.row - 2 || end.row == start.row + 2))
                enPassantable = p;

            if(p is Pawn && end.column != start.column && capped == null) {
                int x = 0;
                if (p.color == Color.White)
                    x = 1;
                if (p.color == Color.Black)
                    x = -1;
                
                capped = board.removePiece(end.setRow(x));
                captured.Add(capped);
            }

            // Promotion
            if (p is Pawn && (end.row == board.rows - 1 || end.row == 0))
                p = promotePiece(p, start, end, capped);

            board.placePiece(p, end);

            return capped;
        }

        public void undoMove(Position start, Position end, Piece capped) {
            Piece p = board.removePiece(end);
            p.decreaseMoveCount();
            if(capped != null) {
                captured.Remove(capped);
                board.placePiece(capped, end);
            }
            board.placePiece(p, start);

            // Castling
            if (p is King && end.column == start.column + 2) {
                Piece T = board.removePiece(start.setColumn(1));
                T.decreaseMoveCount();
                board.placePiece(T, start.setColumn(3));
            }

            if (p is King && end.column == start.column - 2) {
                Piece T = board.removePiece(start.setColumn(-1));
                T.decreaseMoveCount();
                board.placePiece(T, start.setColumn(-4));
            }


            // En passant
            if (p is Pawn && end.column != start.column && capped == enPassantable) {
                int x = 0;
                Piece P = board.removePiece(end);
                if (P.color == Color.White)
                    x = -1;
                if (P.color == Color.Black)
                    x = 1;

                board.placePiece(P, end.setRow(x));
            }
        }

        public void play(Position start, Position end) {
            // En passant
            if (enPassantable != null && enPassantable.color == currentPlayer)
                enPassantable = null;

            // Game
            Piece capped = movePiece(start, end);

            // Check and checkmate
            if (isKingInCheck(currentPlayer)) {
                undoMove(start, end, capped);
                throw new BoardException("You can't put yourself in check");
            }

            check = isKingInCheck(opponent(currentPlayer));

            isOver = isKingInCheckmate(opponent(currentPlayer));
            if (isOver) return;

            turn++;
            changePlayer();
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
            if (!board.piece(start).isMovePossible(end))
                throw new BoardException("Invalid end position");
        }

        public void placeNewPiece(char col, int row, Piece piece) {
            board.placePiece(piece, new ChessPosition(col, row).toPosition());
            active.Add(piece);
        }

        public void placeNewPiece(Position pos, Piece piece) {
            board.placePiece(piece, pos);
            active.Add(piece);
        }

        private void placePieces() {
            placeNewPiece('a', 1, new Rook(Color.White, board));
            placeNewPiece('b', 1, new Knight(Color.White, board));
            placeNewPiece('c', 1, new Bishop(Color.White, board));
            placeNewPiece('d', 1, new Queen(Color.White, board));
            placeNewPiece('e', 1, new King(Color.White, board, this));
            placeNewPiece('f', 1, new Bishop(Color.White, board));
            placeNewPiece('g', 1, new Knight(Color.White, board));
            placeNewPiece('h', 1, new Rook(Color.White, board));

            placeNewPiece('a', 2, new Pawn(Color.White, board, this));
            placeNewPiece('b', 2, new Pawn(Color.White, board, this));
            placeNewPiece('c', 2, new Pawn(Color.White, board, this));
            placeNewPiece('d', 2, new Pawn(Color.White, board, this));
            placeNewPiece('e', 2, new Pawn(Color.White, board, this));
            placeNewPiece('f', 2, new Pawn(Color.White, board, this));
            placeNewPiece('g', 2, new Pawn(Color.White, board, this));
            placeNewPiece('h', 2, new Pawn(Color.White, board, this));

            placeNewPiece('a', 8, new Rook(Color.Black, board));
            placeNewPiece('b', 8, new Knight(Color.Black, board));
            placeNewPiece('c', 8, new Bishop(Color.Black, board));
            placeNewPiece('d', 8, new Queen(Color.Black, board));
            placeNewPiece('e', 8, new King(Color.Black, board, this));
            placeNewPiece('f', 8, new Bishop(Color.Black, board));
            placeNewPiece('g', 8, new Knight(Color.Black, board));
            placeNewPiece('h', 8, new Rook(Color.Black, board));

            placeNewPiece('a', 7, new Pawn(Color.Black, board, this));
            placeNewPiece('b', 7, new Pawn(Color.Black, board, this));
            placeNewPiece('c', 7, new Pawn(Color.Black, board, this));
            placeNewPiece('d', 7, new Pawn(Color.Black, board, this));
            placeNewPiece('e', 7, new Pawn(Color.Black, board, this));
            placeNewPiece('f', 7, new Pawn(Color.Black, board, this));
            placeNewPiece('g', 7, new Pawn(Color.Black, board, this));
            placeNewPiece('h', 7, new Pawn(Color.Black, board, this));
        }
    }
}
