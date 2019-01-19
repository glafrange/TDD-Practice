using System;

namespace Mastermind.Service
{
    public class GameInputValidator
    {
        public bool IsValid(int[] guess)
        {
			if (!InputOutofBounds(guess) || !InputNotUnique(guess))
				return false;

			for (int i = 0; i < guess.Length; i++)
			{
				if (guess[i] > 6 || guess[i] < 1)
					return false;
			}

			return true;
        }

        private bool InputOutofBounds(int[] guess)
        {
			if (guess.Length > 4 || guess.Length < 4)
				return false;

			return true;
        }

        private bool InputNotUnique(int[] guess)
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