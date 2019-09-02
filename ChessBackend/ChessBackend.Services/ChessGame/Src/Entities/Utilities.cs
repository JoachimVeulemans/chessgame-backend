using System;
using System.Collections.Generic;
using System.Text;

namespace ChessBackend.Services.ChessGame.Src.Entities
{
    public class Utilities
    {
        public static string GetPositionInPGN(int row, int column)
        {
            return ConvertColumnToPGN(column) + ConvertRowToPGN(row);
        }

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
    }
}
