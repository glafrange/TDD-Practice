using NUnit.Framework;
using Mastermind.Service;

namespace Tests
{
    public class Tests
    {
        [Test]
        public void ThrowExceptionIfAttemptLengthIsMoreThan4()
        {
			Game game = new Game(new CodeGenerator(), new GameStatus(), new GameInputValidator());
			game.code = new int[]{1,2,3,4};
            var guess = new int[]{1,2,3,4,5};
            Assert.Throws<System.ArgumentException>(() => game.CheckScore(guess));
        }

		[Test]
		public void ThrowExceptionIfAttemptLengthIsLessThan4()
		{
			Game game = new Game(new CodeGenerator(), new GameStatus(), new GameInputValidator());
			game.code = new int[] { 1, 2, 3, 4 };
			var guess = new int[] { 1, 2, 3 };
			Assert.Throws<System.ArgumentException>(() => game.CheckScore(guess));
		}

		[Test]
		public void ThrowExceptionIfNumberInAttemptArrayIsGreaterThan6()
		{
			Game game = new Game(new CodeGenerator(), new GameStatus(), new GameInputValidator());
			game.code = new int[] { 1, 2, 3, 4 };
			var guess = new int[] { 1, 2, 3, 7 };
			Assert.Throws<System.ArgumentException>(() => game.CheckScore(guess));
		}

		[Test]
		public void ThrowExceptionIfNumberInAttemptArrayIsLessThan1()
		{
			Game game = new Game(new CodeGenerator(), new GameStatus(), new GameInputValidator());
			game.code = new int[] { 1, 2, 3, 4 };
			var guess = new int[] { 0, 2, 3, 4 };
			Assert.Throws<System.ArgumentException>(() => game.CheckScore(guess));
		}

		[Test]
		public void ThrowExceptionIfAllNumbersInAttemptArrayAreNotUnique()
		{
			Game game = new Game(new CodeGenerator(), new GameStatus(), new GameInputValidator());
			game.code = new int[] { 1, 2, 3, 4 };
			var guess = new int[] { 1, 1, 2, 3 };
			Assert.Throws<System.ArgumentException>(() => game.CheckScore(guess));
		}

		[Test]
		public void IfGameIsWon_ReturnGameStatusIsWonTrue()
		{
			Game game = new Game(new CodeGenerator(), new GameStatus(), new GameInputValidator());
			game.code = new int[] { 1, 2, 3, 4 };
			var guess = new int[] { 1, 2, 3, 4 };
			GameStatus gameStatus = game.CheckScore(guess);
			Assert.IsTrue(gameStatus.GameIsWon);
		}

		[Test]
		public void If3NumbersAreCorrect_ReturnGameStatusCorrectNumsIs3()
		{
			Game game = new Game(new CodeGenerator(), new GameStatus(), new GameInputValidator());
			game.code = new int[] { 1, 2, 3, 4 };
			var guess = new int[] { 1, 2, 3, 5 };
			GameStatus gameStatus = game.CheckScore(guess);
			Assert.IsTrue(gameStatus.CorrectNumbers == 3);
		}

		[Test]
		public void If2NumbersAreInCorrectPosition_ReturnGameStatusCorrectPositionsIs2()
		{
			Game game = new Game(new CodeGenerator(), new GameStatus(), new GameInputValidator());
			game.code = new int[] { 1, 2, 3, 4 };
			var guess = new int[] { 1, 2, 5, 3 };
			GameStatus gameStatus = game.CheckScore(guess);
			Assert.IsTrue(gameStatus.CorrectPositions == 2);
		}

		[Test]
		public void CorrectNumbersShouldIgnoreCorrectPositions()
		{
			Game game = new Game(new CodeGenerator(), new GameStatus(), new GameInputValidator());
			game.code = new int[] { 1, 2, 3, 4 };
			var guess = new int[] { 1, 2, 4, 3 };
			GameStatus gameStatus = game.CheckScore(guess);
			Assert.IsTrue(gameStatus.CorrectNumbers == 4 && gameStatus.CorrectPositions == 2);
		}
	}
}