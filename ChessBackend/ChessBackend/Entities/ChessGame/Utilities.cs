using System.Collections.Generic;

namespace ChessBackend.Entities.ChessGame
{
    /// <summary>
    /// The Utilities class provides a broad range of static helper functions that can be used throughout the whole application
    /// </summary>
    public class Utilities
    { 

        /// <summary>
        /// Converts a given position by row and column into a chess position
        /// </summary>
        /// <param name="row">Current row of the chessboard</param>
        /// <param name="column">Current column of the chessboard</param>
        /// <returns></returns>
        public static string GetPositionInPGN(int row, int column)
        {
            return ConvertColumnToPGN(column) + ConvertRowToPGN(row);
        }

        /// <summary>
        /// Converts a given row to the corresponding row notation
        /// </summary>
        /// <param name="row">Current row of the chessboard</param>
        /// <returns></returns>
        private static string ConvertRowToPGN(int row)
        {
            var convertedRow = "";
            
            switch (row)
            {
                case 0:
                    convertedRow = "8";
                    break;
                case 1:
                    convertedRow = "7";
                    break;
                case 2:
                    convertedRow = "6";
                    break;
                case 3:
                    convertedRow = "5";
                    break;
                case 4:
                    convertedRow = "4";
                    break;
                case 5:
                    convertedRow = "3";
                    break;
                case 6:
                    convertedRow = "2";
                    break;
                case 7:
                    convertedRow = "1";
                    break;
            }

            return convertedRow;
        }

        /// <summary>
        /// Converts a given column to the corresponding column notation
        /// </summary>
        /// <param name="column">Current column of the chessboard</param>
        /// <returns></returns>
        private static string ConvertColumnToPGN(int column)
        {
            var convertedColumn = "";

            switch (column)
            {
                case 0:
                    convertedColumn = "a";
                    break;
                case 1:
                    convertedColumn = "b";
                    break;
                case 2:
                    convertedColumn = "c";
                    break;
                case 3:
                    convertedColumn = "d";
                    break;
                case 4:
                    convertedColumn = "e";
                    break;
                case 5:
                    convertedColumn = "f";
                    break;
                case 6:
                    convertedColumn = "g";
                    break;
                case 7:
                    convertedColumn = "h";
                    break;
            }

            return convertedColumn;
        }

        public static string[,] ConvertChessBoardToArrayWithPieceNames(Square[,] chessBoard)
        {
            var pieces = new string[ChessGame.BOARDSIZE, ChessGame.BOARDSIZE];

            for(var row = 0; row < ChessGame.BOARDSIZE; row++)
            {
                for(var column = 0; column < ChessGame.BOARDSIZE; column++)
                {
                    if (chessBoard[row, column].HasChessPiece)
                        pieces[row, column] = chessBoard[row, column].ChessPiece.Name;
                    else
                        pieces[row, column] = "";
                }
            }
            return pieces;
        }
    }
}
