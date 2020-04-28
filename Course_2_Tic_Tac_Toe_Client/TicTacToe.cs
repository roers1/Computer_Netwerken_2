using System;
using System.Collections.Generic;
using System.Text;

namespace Course_2_Tic_Tac_Toe_Client
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
			return recursiveSolution(letter, 0, 0, 0);
		}

		private Boolean recursiveSolution(string letter, int matches, int x, int y)
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
					return recursiveSolution(letter, matches++, x, y++);
				}
				break;
			}

			//check verticale winst
			while (x < board.GetLength(0))
			{
				if (board[x, y] == letter)
				{
					return recursiveSolution(letter, matches++, x++, y);
				}
				break;
			}

			//check diagonale winst 1
			while (x < board.GetLength(0) && y < board.GetLength(1))
			{
				if (board[x, y] == letter)
				{
					return recursiveSolution(letter, matches++, x++, y++);
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
						return recursiveSolution(letter, matches++, x--, y--);
					}
					break;
				}
			}

			return false;
		}
		public override string ToString()
		{
			string output = "";
			for (int i = 0; i < board.GetLength(0); i++)
			{
				for (int j = 0; j < board.GetLength(1); i++)
				{
					if(board[i,j] == null)
					{
						output += "   | ";
					}
					switch (j)
					{
						case 2:
							output += board[i, j];
							break;
						default:
							output += board[i, j] + " | ";
							break;
					}
				}
				if (i <= 2)
				{
					output += System.Environment.NewLine;
					output += "------------";
				}
			}
			return output;
		}
	}
}
