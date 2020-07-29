using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace PrincessBrideTrivia.Tests
{
    [TestClass]
    public class ProgramTests
    {

        [TestMethod]
        public void RandomizeQuestionOrder_CheckOrderRandomized()
        {
            string filePath = Path.GetRandomFileName();
            try
            {
                // Arrange
                GenerateQuestionsFile(filePath, 5);

                // Act
                Question[] questions = Program.LoadQuestions(filePath);
                string[] answerIndices = new string[questions.Length];


                for (int i = 0; i < questions.Length; i++)
                {
                    answerIndices[i] = questions[i].CorrectAnswerIndex;
                    Program.RandomizeAnswerOrder(questions[i]);
                }

                bool answerIndexChanged = false;

                for (int i = 0;  i < questions.Length; i++)
                {
                    if (answerIndices[i] != questions[i].CorrectAnswerIndex)
                    {
                        answerIndexChanged = true;
                        break;
                    }
                }

                //Assert
                Assert.IsTrue(answerIndexChanged);

            }
            finally
            {
                File.Delete(filePath);
            }
        }

        [TestMethod]
        public void RandomizeQuestionOrder_CheckAnswerNotChanged()
        {
            string filePath = Path.GetRandomFileName();
            try
            {
                // Arrange
                GenerateQuestionsFile(filePath, 1);

                // Act
                Question[] questions = Program.LoadQuestions(filePath);

                string originalAnswerIndex = questions[0].CorrectAnswerIndex;
                string originalAnswer = questions[0].Answers[int.Parse(originalAnswerIndex) - 1];
                string newAnswerIndex;
                string newAnswer;

                do
                {
                    Program.RandomizeAnswerOrder(questions[0]);

                    newAnswerIndex = questions[0].CorrectAnswerIndex;
                    newAnswer = questions[0].Answers[int.Parse(newAnswerIndex) - 1];
                } while (newAnswerIndex == originalAnswerIndex);

                // Assert
                Assert.IsTrue(newAnswer == originalAnswer);
            }
            finally
            {
                File.Delete(filePath);
            }
        }

        [TestMethod]
        public void LoadQuestions_CheckForNull()
        {
            string filePath = Path.GetRandomFileName();
            try
            {
                // Arrange
                GenerateQuestionsFile(filePath, 2);

                // Act
                Question[] questions = Program.LoadQuestions(filePath);

                // Assert
                for (int i = 0; i < questions.Length; i++)
                {
                    Assert.IsNotNull(questions[i]);
                }
            }
            finally
            {
                File.Delete(filePath);
            }
        }


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
    }
}
