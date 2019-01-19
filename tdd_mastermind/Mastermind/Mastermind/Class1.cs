using System;

namespace Mastermind.Service
{
    public class Game
    {
    private readonly ICodeGenerator _codeGenerator;
    private readonly GameStatus _gameStatus;

    private readonly GameInputValidator _validator;
    public int[]code;


		public Game(ICodeGenerator generator, GameStatus gameStatus, GameInputValidator validator)
        {
            _codeGenerator = generator;
            code = _codeGenerator.Generate();
            _gameStatus = gameStatus;
            _validator = validator;
        }
		
		public GameStatus CheckScore(int[] guess)
		{
			if (!_validator.isValid(guess))
				throw new ArgumentException("guess invalid");

			for (int i = 0; i < guess.Length; i++)
			{
				if (guess[i] != code[i])
					_gameStatus.GameIsWon = false;
			}
			_gameStatus.GameIsWon = true;


			return _gameStatus;
		}

       
    }
}