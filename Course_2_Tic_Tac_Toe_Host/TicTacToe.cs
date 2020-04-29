using System;
using System.Collections.Generic;
using System.Text;

namespace Course_2_Tic_Tac_Toe_Host
{
	class TicTacToe
	{
		private string[,] board = new string[3, 3];

		public TicTacToe() { }

		public Boolean makeMove(int x, int y, string letter, string opponentLetter)
		{
			if (board[x, y] == letter || board[x, y] == opponentLetter)
			{
				return false;
			}

			board[x, y] = letter;
			return true;
		}

		public Boolean IsWinner(string letter)
		{
			return RecursiveSolution(letter, 0, 0, 0);
		}

		private Boolean RecursiveSolution(string letter, int matches, int x, int y)
		{
			if (matches == 3)
			{
				return true;
			}

			//check horizontale winst
			while (y < board.GetLength(1))
			{
				if (board[x, y] == letter)
				{
					return RecursiveSolution(letter, matches++, x, y++);
				}
				break;
			}

			//check verticale winst
			while (x < board.GetLength(0))
			{
				if (board[x, y] == letter)
				{
					return RecursiveSolution(letter, matches++, x++, y);
				}
				break;
			}

			//check diagonale winst 1
			while (x < board.GetLength(0) && y < board.GetLength(1))
			{
				if (board[x, y] == letter)
				{
					return RecursiveSolution(letter, matches++, x++, y++);
				}
				break;
			}

			//check diagonale winst
			if (x == 0 && y == 3)
			{
				while (x < board.GetLength(0) && y < board.GetLength(1))
				{
					if (board[x, y] == letter)
					{
						return RecursiveSolution(letter, matches++, x--, y--);
					}
					break;
				}
			}

			return false;
		}
		public override string ToString()
		{
			string visualBoard = "";
			for (int i = 0; i < board.GetLength(0); i++)
			{
				for (int j = 0; j < board.GetLength(1)-1; j++)
				{
					if (board[i, j] == null)
					{
						visualBoard += "   | ";
					}
					else
					{
						switch (j)
						{
							case 2:
								visualBoard += board[i, j];
								break;
							default:
								visualBoard += board[i, j] + " | ";
								break;
						}
					}

				}
				if (i < 2)
				{
					visualBoard += System.Environment.NewLine;
					visualBoard += "------------\r\n";
				}
			}
			return visualBoard;
		}
	}
}
