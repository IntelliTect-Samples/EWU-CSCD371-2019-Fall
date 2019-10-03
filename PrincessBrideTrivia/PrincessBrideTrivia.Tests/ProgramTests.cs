using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System;

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
        public void GetPercentCorrect_ReturnsExpectedPercentage(int numberOfCorrectGuesses, 
            int numberOfQuestions, string expectedString)
        {
            // Arrange

            // Act
            string percentage = Program.GetPercentCorrect(numberOfCorrectGuesses, numberOfQuestions);

            // Assert
            Assert.AreEqual(expectedString, percentage);
        }

        [TestMethod]
        public void LoadQuestions_ChecksIfQuestionsAreNotNull()
        {
            string filePath = Path.GetRandomFileName();
            try
            {
                // Arrange
                GenerateQuestionsFile(filePath, 2);

                // Act
                Question[] questions = Program.LoadQuestions(filePath);

                // Assert 
                foreach(Question question in questions)
                {
                    Assert.IsNotNull(question);
                }
                
            }
            finally
            {
                File.Delete(filePath);
            }
        }

        /*Bonus*/
        [TestMethod]
        public void CheckIfRandom_ChecksIfAnswersAreRandomized()
        {
            //Arrange
            Question question = GenerateAQuestion();
            Question questionCopy = question;

            //Act
            question = Program.RandomizeQuestionAnswersOrder(question);

            //Assert
            CollectionAssert.AreEqual(question.Answers, questionCopy.Answers);
        }

        /*Bonus*/
        [TestMethod]
        public void CheckCorrectAnswerIndex_CheckCorrectAnswerIndexAfterAnswerRandomization()
        {
            //Arrange
            Question question = GenerateAQuestion();
            string correctAnswer = question.Answers[Convert.ToInt32(question.CorrectAnswerIndex) - 1];

            //Act
            question = Program.RandomizeQuestionAnswersOrder(question);

            //Assert
            Assert.AreEqual(question.Answers[Convert.ToInt32(question.CorrectAnswerIndex) - 1], correctAnswer);
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

        private static Question GenerateAQuestion()
        {
            Question question = new Question();
            question.Text = "This is the question text";
            question.Answers = new string[3];
            question.Answers[0] = "Question 1";
            question.Answers[1] = "Question 2";
            question.Answers[2] = "Question 3";
            question.CorrectAnswerIndex = "1";

            return question;
        }
    }
}
