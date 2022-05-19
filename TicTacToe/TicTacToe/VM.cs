//Author : Group 6
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace TicTacToe
{
    internal class VM : INotifyPropertyChanged
    {
        #region CONSTANTS
        const int SEC = 500;
        const int ROWS = 3;
        const int COLS = 3;
        const string NEW_GAME = "Click on Start Game!";
        const string GAME_WON = "You Won!";
        const string GAME_LOST = "Computer Won!";
        const string TIE_GAME = "It's a Tie!";
        const string USER_LOGO = "X";
        const string COMP_LOGO = "O";
        #endregion

        int[,] array2d = new int[ROWS, COLS];

        int iteration = 0;
        int centerFlag = 0;
        int winFlag = 0;
        int initialFlag = 1;
        int flag = 0;

        #region BUTTONS 
        //row*3 + col || row = index/3 |||  col= index%3
        private string __00;
        public string _00
        {
            get { return __00; }
            set { __00 = value; propertyChanged(); }
        }

        private string __01;
        public string _01
        {
            get { return __01; }
            set { __01 = value; propertyChanged(); }
        }

        private string __02;
        public string _02
        {
            get { return __02; }
            set { __02 = value; propertyChanged(); }
        }

        private string __10;
        public string _10
        {
            get { return __10; }
            set { __10 = value; propertyChanged(); }
        }

        private string __11;
        public string _11
        {
            get { return __11; }
            set { __11 = value; propertyChanged(); }
        }

        private string __12;
        public string _12
        {
            get { return __12; }
            set { __12 = value; propertyChanged(); }
        }

        private string __20;
        public string _20
        {
            get { return __20; }
            set { __20 = value; propertyChanged(); }
        }

        private string __21;
        public string _21
        {
            get { return __21; }
            set { __21 = value; propertyChanged(); }
        }

        private string __22;
        public string _22
        {
            get { return __22; }
            set { __22 = value; propertyChanged(); }
        }
        #endregion

        private string board = "";
        public string Board
        {
            get { return board; }
            set { board = value; propertyChanged(); }
        }

        public int CheckCenter()
        {
            if (array2d[1, 1] != -1)
                return 1; // center occupied
            else
                return 0; // center not occupied

        }

        public void UpdateComputerMove(int row, int col)
        {
            if (row == 0 && col == 0)
                _00 = COMP_LOGO;
            else if (row == 0 && col == 1)
                _01 = COMP_LOGO;
            else if (row == 0 && col == 2)
                _02 = COMP_LOGO;
            else if (row == 1 && col == 0)
                _10 = COMP_LOGO;
            else if (row == 1 && col == 1)
                _11 = COMP_LOGO;
            else if (row == 1 && col == 2)
                _12 = COMP_LOGO;
            else if (row == 2 && col == 0)
                _20 = COMP_LOGO;
            else if (row == 2 && col == 1)
                _21 = COMP_LOGO;
            else if (row == 2 && col == 2)
                _22 = COMP_LOGO;
        }

        public void FillRandomCorner()
        {
            List<int> list = new List<int> { 0, 2 };
            var random = new Random();

            while (true)
            {
                int indexListRow = random.Next(list.Count);
                int indexRow = list[indexListRow];

                int indexListCol = random.Next(list.Count);
                int indexCol = list[indexListCol];

                if (array2d[indexRow, indexCol] == -1)
                {
                    array2d[indexRow, indexCol] = 0;
                    UpdateComputerMove(indexRow, indexCol);
                    break;
                }
            }
            //list of empty ..
        }

        public int CheckCorners()
        {
            if (array2d[0, 0] == -1 && array2d[2, 2] == -1 && array2d[0, 2] == -1 && array2d[2, 0] == -1)
                return 0;
            else
                return 1;
        }

        public void BlockMove()
        {//loop
            if (array2d[1, 1] == 1 && array2d[1, 2] == 1 && array2d[1, 0] == -1)
            {
                array2d[1, 0] = 0;
                _10 = COMP_LOGO;
            }
            else if (array2d[1, 1] == 1 && array2d[1, 0] == 1 && array2d[1, 2] == -1)
            {
                array2d[1, 2] = 0;
                _12 = COMP_LOGO;
            }
            else if (array2d[0, 0] == 1 && array2d[0, 1] == 1 && array2d[0, 2] == -1)
            {
                array2d[0, 2] = 0;
                _02 = COMP_LOGO;
            }
            else if (array2d[0, 0] == 1 && array2d[1, 0] == 1 && array2d[2, 0] == -1)
            {
                array2d[2, 0] = 0;
                _20 = COMP_LOGO;
            }
            else if (array2d[0, 0] == 1 && array2d[1, 1] == 1 && array2d[2, 2] == -1)
            {
                array2d[2, 2] = 0;
                _22 = COMP_LOGO;
            }
            else if (array2d[0, 1] == 1 && array2d[0, 2] == 1 && array2d[0, 0] == -1)
            {
                array2d[0, 0] = 0;
                _00 = COMP_LOGO;
            }
            else if (array2d[0, 1] == 1 && array2d[1, 1] == 1 && array2d[2, 1] == -1)
            {
                array2d[2, 1] = 0;
                _21 = COMP_LOGO;
            }
            else if (array2d[0, 2] == 1 && array2d[1, 1] == 1 && array2d[2, 0] == -1)
            {
                array2d[2, 0] = 0;
                _20 = COMP_LOGO;
            }
            else if (array2d[0, 2] == 1 && array2d[1, 2] == 1 && array2d[2, 2] == -1)
            {
                array2d[2, 2] = 0;
                _22 = COMP_LOGO;
            }
            else if (array2d[1, 0] == 1 && array2d[1, 1] == 1 && array2d[1, 2] == -1)
            {
                array2d[1, 2] = 0;
                _12 = COMP_LOGO;
            }
            else if (array2d[1, 0] == 1 && array2d[2, 0] == 1 && array2d[0, 0] == -1)
            {
                array2d[0, 0] = 0;
                _00 = COMP_LOGO;
            }
            else if (array2d[1, 1] == 1 && array2d[2, 1] == 1 && array2d[0, 1] == -1)
            {
                array2d[0, 1] = 0;
                _01 = COMP_LOGO;
            }
            else if (array2d[1, 1] == 1 && array2d[1, 2] == 1 && array2d[1, 0] == -1)
            {
                array2d[1, 0] = 0;
                _10 = COMP_LOGO;
            }
            else if (array2d[1, 1] == 1 && array2d[2, 0] == 1 && array2d[0, 2] == -1)
            {
                array2d[0, 2] = 0;
                _02 = COMP_LOGO;
            }
            else if (array2d[1, 2] == 1 && array2d[2, 2] == 1 && array2d[0, 2] == -1)
            {
                array2d[0, 2] = 0;
                _02 = COMP_LOGO;
            }
            else if (array2d[1, 1] == 1 && array2d[2, 2] == 1 && array2d[0, 0] == -1)
            {
                array2d[0, 0] = 0;
                _00 = COMP_LOGO;
            }
            else if (array2d[2, 0] == 1 && array2d[2, 1] == 1 && array2d[2, 2] == -1)
            {
                array2d[2, 2] = 0;
                _22 = COMP_LOGO;
            }
            else if (array2d[2, 1] == 1 && array2d[2, 2] == 1 && array2d[2, 0] == -1)
            {
                array2d[2, 0] = 0;
                _20 = COMP_LOGO;
            }
            else if (array2d[0, 0] == 1 && array2d[0, 2] == 1 && array2d[0, 1] == -1)
            {
                array2d[0, 1] = 0;
                _01 = COMP_LOGO;
            }
            else if (array2d[0, 0] == 1 && array2d[2, 0] == 1 && array2d[1, 0] == -1)
            {
                array2d[1, 0] = 0;
                _10 = COMP_LOGO;
            }
            else if (array2d[0, 0] == 1 && array2d[2, 2] == 1 && array2d[1, 1] == -1)
            {
                array2d[1, 1] = 0;
                _11 = COMP_LOGO;
            }
            else if (array2d[0, 1] == 1 && array2d[2, 1] == 1 && array2d[1, 1] == -1)
            {
                array2d[1, 1] = 0;
                _11 = COMP_LOGO;
            }
            else if (array2d[0, 2] == 1 && array2d[2, 2] == 1 && array2d[1, 2] == -1)
            {
                array2d[1, 2] = 0;
                _12 = COMP_LOGO;
            }
            else if (array2d[0, 2] == 1 && array2d[2, 0] == 1 && array2d[1, 1] == -1)
            {
                array2d[1, 1] = 0;
                _11 = COMP_LOGO;
            }
            else if (array2d[1, 0] == 1 && array2d[1, 2] == 1 && array2d[1, 1] == -1)
            {
                array2d[1, 1] = 0;
                _11 = COMP_LOGO;
            }
            else if (array2d[2, 0] == 1 && array2d[2, 2] == 1 && array2d[2, 1] == -1)
            {
                array2d[2, 1] = 0;
                _21 = COMP_LOGO;
            }
            else
                FillRandomCorner();
        }

        public void CheckWinningMove()
        {
            if (array2d[0, 0] == 0 && array2d[0, 1] == 0 && array2d[0, 2] == -1)
            {
                array2d[0, 2] = 0;
                _02 = COMP_LOGO;
                winFlag = 1;
            }
            else if (array2d[1, 0] == 0 && array2d[1, 2] == 0 && array2d[1, 1] == -1)
            {
                array2d[1, 1] = 0;
                _11 = COMP_LOGO;
                winFlag = 1;
            }
            else if (array2d[0, 0] == 0 && array2d[1, 0] == 0 && array2d[2, 0] == -1)
            {
                Board = "xyz";
                array2d[2, 0] = 0;
                _20 = COMP_LOGO;
                winFlag = 1;
            }
            else if (array2d[0, 0] == 0 && array2d[1, 1] == 0 && array2d[2, 2] == -1)
            {
                array2d[2, 2] = 0;
                _22 = COMP_LOGO;
                winFlag = 1;
            }
            else if (array2d[0, 1] == 0 && array2d[0, 2] == 0 && array2d[0, 0] == -1)
            {
                array2d[0, 0] = 0;
                _00 = COMP_LOGO;
                winFlag = 1;
            }
            else if (array2d[0, 1] == 0 && array2d[1, 1] == 0 && array2d[2, 1] == -1)
            {
                array2d[2, 1] = 0;
                _21 = COMP_LOGO;
                winFlag = 1;
            }
            else if (array2d[0, 2] == 0 && array2d[1, 1] == 0 && array2d[2, 0] == -1)
            {
                array2d[2, 0] = 0;
                _20 = COMP_LOGO;
                winFlag = 1;
            }
            else if (array2d[0, 2] == 0 && array2d[1, 2] == 0 && array2d[2, 2] == -1)
            {
                array2d[2, 2] = 0;
                _22 = COMP_LOGO;
                winFlag = 1;
            }
            else if (array2d[1, 0] == 0 && array2d[1, 1] == 0 && array2d[1, 2] == -1)
            {
                array2d[1, 2] = 0;
                _12 = COMP_LOGO;
                winFlag = 1;
            }
            else if (array2d[1, 0] == 0 && array2d[2, 0] == 0 && array2d[0, 0] == -1)
            {
                array2d[0, 0] = 0;
                _00 = COMP_LOGO;
                winFlag = 1;
            }
            else if (array2d[1, 1] == 0 && array2d[2, 1] == 0 && array2d[0, 1] == -1)
            {
                array2d[0, 1] = 0;
                _01 = COMP_LOGO;
                winFlag = 1;
            }
            else if (array2d[1, 1] == 0 && array2d[1, 2] == 0 && array2d[1, 0] == -1)
            {
                array2d[1, 0] = 0;
                _10 = COMP_LOGO;
                winFlag = 1;
            }
            else if (array2d[1, 1] == 0 && array2d[2, 0] == 0 && array2d[0, 2] == -1)
            {
                array2d[0, 2] = 0;
                _02 = COMP_LOGO;
                winFlag = 1;
            }
            else if (array2d[1, 2] == 0 && array2d[2, 2] == 0 && array2d[0, 2] == -1)
            {
                array2d[0, 2] = 0;
                _02 = COMP_LOGO;
                winFlag = 1;
            }
            else if (array2d[1, 1] == 0 && array2d[2, 2] == 0 && array2d[0, 0] == -1)
            {
                array2d[0, 0] = 0;
                _00 = COMP_LOGO;
                winFlag = 1;
            }
            else if (array2d[2, 0] == 0 && array2d[2, 1] == 0 && array2d[2, 2] == -1)
            {
                array2d[2, 2] = 0;
                _22 = COMP_LOGO;
                winFlag = 1;
            }
            else if (array2d[2, 1] == 0 && array2d[2, 2] == 0 && array2d[2, 0] == -1)
            {
                array2d[2, 0] = 0;
                _20 = COMP_LOGO;
                winFlag = 1;
            }
            else if (array2d[0, 0] == 0 && array2d[0, 2] == 0 && array2d[0, 1] == -1)
            {
                array2d[0, 1] = 0;
                _01 = COMP_LOGO;
                winFlag = 1;
            }
            else if (array2d[0, 0] == 0 && array2d[2, 0] == 0 && array2d[1, 0] == -1)
            {
                array2d[1, 0] = 0;
                _10 = COMP_LOGO;
                winFlag = 1;
            }
            else if (array2d[0, 0] == 0 && array2d[2, 2] == 0 && array2d[1, 1] == -1)
            {
                array2d[1, 1] = 0;
                _11 = COMP_LOGO;
                winFlag = 1;
            }
            else if (array2d[0, 1] == 0 && array2d[2, 1] == 0 && array2d[1, 1] == -1)
            {
                array2d[1, 1] = 0;
                _11 = COMP_LOGO;
                winFlag = 1;
            }
            else if (array2d[0, 2] == 0 && array2d[2, 2] == 0 && array2d[1, 2] == -1)
            {
                array2d[1, 2] = 0;
                _12 = COMP_LOGO;
                winFlag = 1;
            }
            else if (array2d[0, 2] == 0 && array2d[2, 0] == 0 && array2d[1, 1] == -1)
            {
                array2d[1, 1] = 0;
                _11 = COMP_LOGO;
                winFlag = 1;
            }
            else if (array2d[2, 0] == 0 && array2d[2, 2] == 0 && array2d[2, 1] == -1)
            {
                array2d[2, 1] = 0;
                _21 = COMP_LOGO;
                winFlag = 1;
            }
        }

        public int CheckUserWinningMove()
        {
            if (array2d[0, 0] == 1 && array2d[1, 0] == 1 && array2d[2, 0] == 1 || array2d[0, 1] == 1 && array2d[1, 1] == 1 && array2d[2, 1] == 1
                || array2d[0, 2] == 1 && array2d[1, 2] == 1 && array2d[2, 2] == 1 || array2d[0, 1] == 1 && array2d[0, 2] == 1 && array2d[0, 0] == 1
                 || array2d[1, 1] == 1 && array2d[1, 2] == 1 && array2d[1, 0] == 1 || array2d[2, 1] == 1 && array2d[2, 2] == 1 && array2d[2, 0] == 1
                  || array2d[0, 0] == 1 && array2d[1, 1] == 1 && array2d[2, 2] == 1 || array2d[1, 1] == 1 && array2d[0, 2] == 1 && array2d[2, 0] == 1)
                return 1;
            else
                return 0;

        }

        public async void Move(string ButtonIndexName)
        {
            if (initialFlag == 0)
            {
                Board = "";

                iteration++;

                #region USER_MOVE

                if (ButtonIndexName == "_00" && array2d[0, 0] == -1)
                {
                    array2d[0, 0] = 1;
                    _00 = USER_LOGO;
                }
                else if (ButtonIndexName == "_01" && array2d[0, 1] == -1)
                {
                    array2d[0, 1] = 1;
                    _01 = USER_LOGO;
                }
                else if (ButtonIndexName == "_02" && array2d[0, 2] == -1)
                {
                    array2d[0, 2] = 1;
                    _02 = USER_LOGO;
                }
                else if (ButtonIndexName == "_10" && array2d[1, 0] == -1)
                {
                    array2d[1, 0] = 1;
                    _10 = USER_LOGO;
                }
                else if (ButtonIndexName == "_11" && array2d[1, 1] == -1)
                {
                    array2d[1, 1] = 1;
                    _11 = USER_LOGO;
                }
                else if (ButtonIndexName == "_12" && array2d[1, 2] == -1)
                {
                    array2d[1, 2] = 1;
                    _12 = USER_LOGO;
                }
                else if (ButtonIndexName == "_20" && array2d[2, 0] == -1)
                {
                    array2d[2, 0] = 1;
                    _20 = USER_LOGO;
                }
                else if (ButtonIndexName == "_21" && array2d[2, 1] == -1)
                {
                    array2d[2, 1] = 1;
                    _21 = USER_LOGO;
                }
                else if (ButtonIndexName == "_22" && array2d[2, 2] == -1)
                {
                    array2d[2, 2] = 1;
                    _22 = USER_LOGO;
                }
                else
                {
                    iteration--;
                    Board = "Field is already selected.";
                    flag = 1;
                }
                #endregion

                if (flag == 0)
                {
                    await Task.Delay(SEC);//comp thinking delay
                    if (iteration == 1)
                    {
                        centerFlag = CheckCenter();
                        if (centerFlag == 0)
                        {
                            array2d[1, 1] = 0;
                            _11 = COMP_LOGO;
                        }
                        else
                        {
                            FillRandomCorner();
                        }
                    }
                    else if (iteration < 9)//
                    {
                        int userFlag = CheckUserWinningMove();//
                        if (userFlag == 0)
                        {
                            CheckWinningMove();//

                            if (winFlag == 0)
                                BlockMove();
                            else
                            {
                                Board = GAME_LOST;
                                initialFlag = 1;
                            }
                        }
                        else
                        {
                            Board = GAME_WON;
                            initialFlag = 1;
                        }
                    }
                    else
                    {
                        initialFlag = 1;
                        Board = TIE_GAME;
                    }
                    iteration++;
                }
                else
                {
                    flag = 0;
                }
            }
            else
            {
                Board = NEW_GAME;
            }

        }

        public void EmptyBoard()
        {
            _00 = "";
            _01 = "";
            _02 = "";
            _10 = "";
            _11 = "";
            _12 = "";
            _20 = "";
            _21 = "";
            _22 = "";
        }

        public void StartGame()
        {
            initialFlag = 0;
            iteration = 0;
            centerFlag = 0;
            winFlag = 0;
            Board = "";

            for (int i = 0; i < ROWS; i++)
            {
                for (int j = 0; j < COLS; j++)
                {
                    array2d[i, j] = -1;
                }
            }
            EmptyBoard();
        }


        #region Property Changed
        public event PropertyChangedEventHandler PropertyChanged;

        private void propertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

    }
}
