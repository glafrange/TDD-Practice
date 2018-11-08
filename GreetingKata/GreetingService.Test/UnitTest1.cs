using NUnit.Framework;
using GreetingService;

namespace Tests
{
    public class Tests
    {
        Class1 _greetingService = new Class1();

        [Test]
        public void return_string()
        {
            string str = "";
            var output = _greetingService.Greet(str);
            var outputIsString = output.GetType() == typeof(string);
            Assert.IsTrue(outputIsString);
        }

        [Test]
        public void simpleGreeting()
        {
            string str = "Bob";
            var expected = "Hello, Bob.";

            var output = _greetingService.Greet(str);

            Assert.AreEqual(expected, output);
        }

        [Test]
        public void emptyGreeting()
        {
            var expected = "Hello, my friend.";

            var output = _greetingService.Greet();

            Assert.AreEqual(expected, output);
        }

        [Test]
        public void shoutedGreeting()
        {
            string str = "JERRY";
            var expected = "HELLO JERRY!";

            var output = _greetingService.Greet(str);

            Assert.AreEqual(expected, output); 
        }

        [Test]
        public void twoNameGreeting()
        {
            string[] strArray = new string[] { "Jill", "Jane" };
            var expected = "Hello, Jill and Jane.";

            var output = _greetingService.Greet(strArray);

            Assert.AreEqual(expected, output);
        }

        [Test]
        public void moreThanTwoNames()
        {
            string[] strArray = new string[] { "Amy", "Brian", "Charlotte" };
            var expected = "Hello, Amy, Brian, and Charlotte.";

            var output = _greetingService.Greet(strArray);

            Assert.AreEqual(expected, output);
        }

        [Test]
        public void multipleNamesOneShouted()
        {
            string[] strArray = new string[] { "Amy", "BRIAN", "Charlotte" };
            var expected = "Hello, Amy and Charlotte. AND HELLO BRIAN!";

            var output = _greetingService.Greet(strArray);

            Assert.AreEqual(expected, output);
        }

        [Test]
        public void multipleNamesWithComma()
        {
            string[] strArray = new string[] { "Bob", "Charlie, Dianne" };
            var expected = "Hello, Bob, Charlie, and Dianne.";

            var output = _greetingService.Greet(strArray);

            Assert.AreEqual(expected, output);
        }

        [Test]
        public void multipleNameValue()
        {
            string[] strArray = new string[] { "Bob", "\"Charlie, Dianne\"" };
            var expected = "Hello, Bob and Charlie, Dianne.";

            var output = _greetingService.Greet(strArray);

            Assert.AreEqual(expected, output);
        }
    }
}