using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientCaro
{
    public enum GameState
    {
        DRAW, PLAYER_1, PLAYER_2, COM
    }
    public class ChessHelper
    {
        private SolidBrush soidBlue;
        private SolidBrush soidRed;

        private ChessCell[,] MatrixCell;
        private ChessBoard chessBoard;
        private Stack<ChessCell> listCell;

        private GameState gameState;
        public int RunTime { get; set; }

        public bool isReady { get; private set; }
        public int GameMode { get; private set; }
        public Graphics graphics { get; set; }

        public ChessHelper()
        {
            soidBlue = new SolidBrush(Color.Blue);
            soidRed = new SolidBrush(Color.Red);

            chessBoard = new ChessBoard();
            MatrixCell = new ChessCell[chessBoard.RowNum, chessBoard.ColNum];
            listCell = new Stack<ChessCell>();

            RunTime = 1;
            isReady = false;

            CreateMatrixCell();
        }

        /// <summary>
        /// Paint board for new game 
        /// </summary>
        public void PaintBoard() => chessBoard.PaintBoard(graphics);

        /// <summary>
        /// initialization a new matrix cell for new game 
        /// </summary>
        public void CreateMatrixCell()
        {
            for (int i = 0; i < chessBoard.RowNum; i++)
                for (int j = 0; j < chessBoard.ColNum; j++)
                    MatrixCell[i, j] = new ChessCell(i, j, new Point(j * ChessCell.CellWidth, i * ChessCell.CellHeight), 0);
        }

        /// <summary>
        /// Paint a cell "X" or "O" dependent on number of player
        /// </summary>
        public void PaintCell()
        {
            foreach (var item in listCell)
            {
                if (item.Parent == 1) chessBoard.CellX(graphics, item.CellLocal, soidBlue);
                else if (item.Parent == 2) chessBoard.CellO(graphics, item.CellLocal, soidRed);
            }
        }

        /// <summary>
        /// Make a cell with input coordinates of mouse when click on panel
        /// </summary>
        /// <returns></returns>
        public bool MakeCell(int X, int Y)
        {
            if (X % ChessCell.CellWidth == 0 || Y % ChessCell.CellHeight == 0) return false;
            int row = Y / ChessCell.CellHeight;
            int col = X / ChessCell.CellWidth;

            if (MatrixCell[row, col].Parent != 0) return false;

            if (RunTime == 1)
            {
                MatrixCell[row, col].Parent = 1;
                chessBoard.CellX(graphics, MatrixCell[row, col].CellLocal, soidBlue);
                RunTime = 2;
            }
            else if (RunTime == 2)
            {
                MatrixCell[row, col].Parent = 2;
                chessBoard.CellO(graphics, MatrixCell[row, col].CellLocal, soidRed);
                RunTime = 1;
            }
            else return false;

            ChessCell cell = new ChessCell(MatrixCell[row, col].CellRow, MatrixCell[row, col].CellCol, MatrixCell[row, col].CellLocal, MatrixCell[row, col].Parent);
            listCell.Push(cell);

            return true;
        }

        public void SetNewCell(int X,int Y)
        {
            int row = Y / ChessCell.CellHeight;
            int col = X / ChessCell.CellWidth;
            MatrixCell[row, col] = new ChessCell(row, col, new Point(col * ChessCell.CellWidth, row * ChessCell.CellHeight), 0);
        }

        /// <summary>
        /// Setup for game mode PvP
        /// </summary>
        public void PlayerVsPlayer(int runtime)
        {
            GameMode = 1;
            isReady = true;
            listCell = new Stack<ChessCell>();
            CreateMatrixCell();
            RunTime = runtime;
            PaintBoard();
        }

        /// <summary>
        /// End the game and show the result
        /// </summary>
        public int EndGame()
        {
            isReady = false;
            if (gameState == GameState.DRAW) return 0;
            if (gameState == GameState.PLAYER_1) return 1;
            if (gameState == GameState.PLAYER_2) return 2;
            return 4;
        }

        /// <summary>
        /// Check the game for make cell 
        /// </summary>
        /// <returns></returns>
        public bool GameChecker()
        {
            if (listCell.Count == chessBoard.ColNum * chessBoard.RowNum)
            {
                gameState = GameState.DRAW;
                return true;
            }
            foreach (var item in listCell)
            {
                if (CheckColumn(item.CellRow, item.CellCol, item.Parent) ||
                    CheckRow(item.CellRow, item.CellCol, item.Parent) ||
                    CheckDiagonal(item.CellRow, item.CellCol, item.Parent) ||
                    CheckDiagonalInv(item.CellRow, item.CellCol, item.Parent))
                {
                    gameState = item.Parent == 1 ? GameState.PLAYER_1 : GameState.PLAYER_2;
                    return true;
                }
            }
            return false;
        }

        private bool CheckColumn(int row, int col, int parent)
        {
            if (row > chessBoard.RowNum - 5) return false;
            int i;
            for (i = 0; i < 5; i++)
            {
                if (MatrixCell[row + i, col].Parent != parent) return false;
            }
            if (row == 0 || row + i == chessBoard.RowNum) return true;
            if (MatrixCell[row - 1, col].Parent == 0 || MatrixCell[row + i, col].Parent == 0) return true;
            return false;
        }

        private bool CheckRow(int row, int col, int parent)
        {
            if (col > chessBoard.ColNum - 5) return false;
            int i;
            for (i = 0; i < 5; i++)
            {
                if (MatrixCell[row, col + i].Parent != parent) return false;
            }
            if (col == 0 || col + i == chessBoard.ColNum) return true;
            if (MatrixCell[row, col - 1].Parent == 0 || MatrixCell[row, col + i].Parent == 0) return true;
            return false;
        }

        private bool CheckDiagonal(int row, int col, int paren)
        {
            if (row > chessBoard.RowNum - 5 || col > chessBoard.ColNum - 6) return false;
            int i;
            for (i = 0; i < 5; i++)
            {
                if (MatrixCell[row + i, col + i].Parent != paren) return false;
            }
            if (row == 0 || row + i == chessBoard.RowNum || col == 0 || col + i == chessBoard.ColNum) return true;
            if (MatrixCell[row - 1, col - 1].Parent == 0 || MatrixCell[row + i, col + i].Parent == 0) return true;
            return false;
        }
        private bool CheckDiagonalInv(int row, int col, int paren)
        {
            if (row < 4 || col > chessBoard.ColNum - 5) return false;
            int i;
            for (i = 0; i < 5; i++)
            {
                if (MatrixCell[row - i, col + i].Parent != paren) return false;
            }
            if (row == 4 || row == chessBoard.RowNum - 1 || col == 0 || col + i == chessBoard.ColNum) return true;
            if (MatrixCell[row + 1, col - 1].Parent == 0 || MatrixCell[row - i, col + i].Parent == 0) return true;
            return false;
        }
    }
}
