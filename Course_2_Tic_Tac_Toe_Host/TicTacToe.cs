using System;
using System.Collections.Generic;
using System.Text;

namespace Course_2_Tic_Tac_Toe_Host
{
	internal class TicTacToe
	{
		private readonly string[,] _board = new string[3, 3];

		public TicTacToe()
		{
		}

		public bool MakeMove(int x, int y, string letter, string opponentLetter)
		{
			if (_board[x, y] == letter || _board[x, y] == opponentLetter)
			{
				return false;
			}

			_board[x, y] = letter;
			return true;
		}

		public bool IsWinner(string letter)
		{
			return RecursiveSolution(letter, 0, 0, 0);
		}

		private bool RecursiveSolution(string letter, int matches, int x, int y)
		{
			if (matches == 3)
			{
				return true;
			}

			//check horizontale winst
			while (y < _board.GetLength(1))
			{
				if (_board[x, y] == letter)
				{
					return RecursiveSolution(letter, matches++, x, y++);
				}

				break;
			}

			//check verticale winst
			while (x < _board.GetLength(0))
			{
				if (_board[x, y] == letter)
				{
					return RecursiveSolution(letter, matches++, x++, y);
				}

				break;
			}

			//check diagonale winst 1
			while (x < _board.GetLength(0) && y < _board.GetLength(1))
			{
				if (_board[x, y] == letter)
				{
					return RecursiveSolution(letter, matches++, x++, y++);
				}

				break;
			}

			//check diagonale winst
			if (x != 0 || y != 3) return false;
			while (x < _board.GetLength(0) && y < _board.GetLength(1))
			{
				if (_board[x, y] == letter)
				{
					return RecursiveSolution(letter, matches++, x--, y--);
				}

				break;
			}

			return false;
		}

		public override string ToString()
		{
			var visualBoard = "";
			for (var i = 0; i < _board.GetLength(0); i++)
			{
				for (var j = 0; j < _board.GetLength(1); j++)
				{
					if (_board[i, j] == null && j != 2)
					{
						visualBoard += "   | ";
					}
					else
					{
						switch (j)
						{
							case 2:
								visualBoard += _board[i, j];
								break;
							default:
								visualBoard += _board[i, j] + " | ";
								break;
						}
					}
				}

				if (i >= 2) continue;
				visualBoard += System.Environment.NewLine;
				visualBoard += "------------\r\n";
			}

			visualBoard += "\r\n";
			return visualBoard;
		}
	}
}
