using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace PrincessBrideTrivia.Tests
{
    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void LoadQuestions_RetrievesQuestionsFromFile()
        {
            string filePath = Path.GetRandomFileName();
            try
            {
                // Arrange
                GenerateQuestionsFile(filePath, 2);

                // Act
                Question[] questions = Program.LoadQuestions(filePath);

                // Assert 
                Assert.AreEqual(2, questions.Length);
            }
            finally
            {
                File.Delete(filePath);
            }
        }

        [TestMethod]
        public void LoadQuestions_ReturnNotNull()
        {
            string filePath = Path.GetRandomFileName();
            try
            {
                // Arrange
                GenerateQuestionsFile(filePath, 2);

                // Act
                Question[] questions = Program.LoadQuestions(filePath);

                // Assert 
                Assert.IsNotNull(questions[0].Text);
                Assert.IsNotNull(questions[0].Answers[0]);
                Assert.IsNotNull(questions[0].Answers[1]);
                Assert.IsNotNull(questions[0].Answers[2]);
                Assert.IsNotNull(questions[0].CorrectAnswerIndex);
            }
            finally
            {
                File.Delete(filePath);
            }
        }

        [TestMethod]
        public void QuestionsAreRandom()
        {
            string filePath = Path.GetRandomFileName();
            try
            {
                // Arrange
                GenerateQuestionsFileRandomTest(filePath, 15);

                // Act
                Question[] questionsNotRandom = Program.LoadQuestions(filePath);
                Question[] questionRandom = Program.QuestionsRandomizer(questionsNotRandom);

                // Assert 
                Assert.AreNotEqual(questionsNotRandom, questionRandom);
            }
            finally
            {
                File.Delete(filePath);
            }
        }

        [DataTestMethod]
        [DataRow("1", true)]
        [DataRow("2", false)]
        public void DisplayResult_ReturnsTrueIfCorrect(string userGuess, bool expectedResult)
        {
            // Arrange
            Question question = new Question();
            question.CorrectAnswerIndex = "1";

            // Act
            bool displayResult = Program.DisplayResult(userGuess, question);

            // Assert
            Assert.AreEqual(expectedResult, displayResult);
        }

        [TestMethod]
        public void GetFilePath_ReturnsFileThatExists()
        {
            // Arrange

            // Act
            string filePath = Program.GetFilePath();

            // Assert
            Assert.IsTrue(File.Exists(filePath));
        }

        [DataTestMethod]
        [DataRow(1, 1, "100%")]
        [DataRow(5, 10, "50%")]
        [DataRow(1, 10, "10%")]
        [DataRow(0, 10, "0%")]
        public void GetPercentCorrect_ReturnsExpectedPercentage(double numberOfCorrectGuesses, 
            double numberOfQuestions, string expectedString)
        {
            // Arrange

            // Act
            string percentage = Program.GetPercentCorrect(numberOfCorrectGuesses, numberOfQuestions);

            // Assert
            Assert.AreEqual(expectedString, percentage);
        }


        private static void GenerateQuestionsFile(string filePath, int numberOfQuestions)
        {
            for (int i = 0; i < numberOfQuestions; i++)
            {
                string[] lines = new string[5];
                lines[0] = "Question " + i + " this is the question text";
                lines[1] = "Answer 1";
                lines[2] = "Answer 2";
                lines[3] = "Answer 3";
                lines[4] = "2";
                File.AppendAllLines(filePath, lines);
            }
        }

        private static void GenerateQuestionsFileRandomTest(string filePath, int numberOfQuestions)
        {
            Random rnd = new Random();
            for (int i = 0; i < numberOfQuestions; i++)
            {
                string[] lines = new string[5];
                lines[0] = "Question " + i + " this is the question text";
                lines[1] = "Answer 1";
                lines[2] = "Answer 2";
                lines[3] = "Answer 3";
                lines[4] = rnd.Next(3).ToString();
                File.AppendAllLines(filePath, lines);
            }
        }
    }
}
