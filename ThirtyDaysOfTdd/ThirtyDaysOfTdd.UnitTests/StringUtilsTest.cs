using System;
using System.Linq;
using NUnit.Framework;

namespace ThirtyDaysOfTdd.UnitTests
{
	[TestFixture]
	public class StringUtilsTest
	{
		[Test]
		public void ShouldBeAbleToCountNumberOfLettersInSimpleSentence()
		{
			var sentenceToScan = "TDD is awesome!";
			var characterToScanFor = "e";
			var expectedResult = 2;
			var stringUtils = new StringUtils();

			int result = stringUtils.FindNumberOfOccurances(sentenceToScan, characterToScanFor);

			Assert.AreEqual(expectedResult, result);
		}

		[Test]
		public void ShouldBeAbltToCountNumberOfLettersInComplexSentence()
		{
			var sentenceToScan = "Once is unique, twice is a coincidence, three times is a pattern.";
			var characterToScanFor = "n";
			var expectedResult = 5;
			var stringUtils = new StringUtils();

			int result = stringUtils.FindNumberOfOccurances(sentenceToScan, characterToScanFor);

			Assert.AreEqual(expectedResult, result);
		}

		[Test]
		public void ShouldGetArgumentExceptionWhenCharacterToScanForIsLargerThanOneCharacter()
		{
			var sentenceToScan = "This text should throw an exception";
			var characterToScanFor = "xx";
			var stringUtils = new StringUtils();
			
			// Assert.That(() => stringUtils.FindNumberOfOccurances(sentenceToScan, characterToScanFor), Throws.ArgumentException);
			Assert.Throws<ArgumentException>(delegate()
			{
				stringUtils.FindNumberOfOccurances(sentenceToScan, characterToScanFor);
			});
		}
	}
}
