using System;

namespace Mastermind.Service
{
    public class GameStatus : IGameStatus
    {
        public bool GameIsWon;
        public int CorrectNumbers = 0;
        public int CorrectPositions = 0;

		public void UpdateStatus(int[] guess, int[] code)
		{
			CheckCorrectNumbers(guess, code);
			CheckCorrectPositions(guess, code);
			CheckForWin();
		}

		private void CheckForWin()
		{
			GameIsWon = CorrectNumbers == 4 && CorrectPositions == 4;
		}

		private void CheckCorrectNumbers(int[] guess, int[] code)
		{
			foreach (int num in guess)
			{
				if (Array.Exists(code, digit => digit == num))
					CorrectNumbers++;
			}
		}

		private void CheckCorrectPositions(int[] guess, int[] code)
		{
			for (int i = 0; i < guess.Length; i++)
			{
				if (guess[i] == code[i])
					CorrectPositions++;
			}
		}
	}
}