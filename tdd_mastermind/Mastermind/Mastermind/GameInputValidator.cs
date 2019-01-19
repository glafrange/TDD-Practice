using System;

namespace Mastermind.Service
{
    public class GameInputValidator
    {
        public bool isValid(int[] guess)
        {
			if (!inputOutofBounds(guess) || !inputNotUnique(guess))
				return false;

			for (int i = 0; i < guess.Length; i++)
			{
				if (guess[i] > 6 || guess[i] < 1)
					return false;
			}

			return true;
        }

        private bool inputOutofBounds(int[] guess)
        {
			if (guess.Length > 4 || guess.Length < 4)
				return false;

			return true;
        }

        private bool inputNotUnique(int[] guess)
        {
			for (int i = 0; i < guess.Length; i++)
			{
				for (int j = 0; j < guess.Length; j++)
				{
					if (i == j && i != guess.Length - 1)
						j++;

					if (i == guess.Length - 1)
						break;

					if (guess[i] == guess[j])
						return false;
				}
			}
			return true;
        }
    }
}