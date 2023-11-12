using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProgrammingLanguageAssignment;

namespace UnitTests
{
    /// <summary>
    /// Represents a test class for testing the CommandParser class.
    /// </summary>
    [TestClass]
    public class CommandParserTests
    {
        /// <summary>
        /// Test method to verify the parsing of a command with multiple arguments.
        /// </summary>
        [TestMethod]
        public void ParseCommandAndArguments()
        {
            // Arrange
            string commandText = "drawto 100 50";

            // Act
            var parser = new CommandParser(commandText);

            // Assert
            Assert.AreEqual("drawto", parser.Command);
            CollectionAssert.AreEqual(new string[] { "100", "50" }, parser.Args);
        }

        /// <summary>
        /// Test method to verify parsing an empty command text results in an empty command and no arguments.
        /// </summary>
        [TestMethod]
        public void EmptyCommandText_ParsesEmptyCommandAndNoArguments()
        {
            // Arrange
            string commandText = "";

            // Act
            var parser = new CommandParser(commandText);

            // Assert
            Assert.AreEqual("", parser.Command);
            CollectionAssert.AreEqual(new string[0], parser.Args);
        }

        /// <summary>
        /// Test method to verify parsing a command without arguments results in the command and no arguments.
        /// </summary>
        [TestMethod]
        public void CommandWithoutArguments_ParsesCommandAndNoArguments()
        {
            // Arrange
            string commandText = "clear";

            // Act
            var parser = new CommandParser(commandText);

            // Assert
            Assert.AreEqual("clear", parser.Command);
            CollectionAssert.AreEqual(new string[0], parser.Args);
        }

        /// <summary>
        /// Test method to verify parsing a command with a single argument results in the command and a single argument.
        /// </summary>
        [TestMethod]
        public void CommandWithSingleArgument_ParsesCommandAndSingleArgument()
        {
            // Arrange
            string commandText = "pen red";

            // Act
            var parser = new CommandParser(commandText);

            // Assert
            Assert.AreEqual("pen", parser.Command);
            CollectionAssert.AreEqual(new string[] { "red" }, parser.Args);
        }
    }
}
