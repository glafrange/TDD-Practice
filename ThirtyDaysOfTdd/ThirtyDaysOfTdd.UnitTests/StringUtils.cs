using System;
using System.Collections.Generic;
using System.Text;

namespace ThirtyDaysOfTdd.UnitTests
{
	class StringUtils
	{
		public int FindNumberOfOccurances(string sentenceToScan, string characterToScanFor)
		{
			if (characterToScanFor.Length != 1)
			{
				throw new ArgumentException();
			}
			var stringToCheckAsCharArray = sentenceToScan.ToCharArray();
			var characterToCheckFor = Char.Parse(characterToScanFor);
			var numberOfOccurances = 0;

			for (var charIdx = 0; charIdx < stringToCheckAsCharArray.GetUpperBound(0); charIdx++)
			{
				if (stringToCheckAsCharArray[charIdx] == characterToCheckFor)
				{
					numberOfOccurances++;
				}
			}

			return numberOfOccurances;
		}
	}
}
