
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using PrincessBrideTrivia;

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
        public void Question_IsNotNull() {

            // Arrange

            // Act
            Question[] questions = Program.LoadQuestions(Program.GetFilePath());

            // Assert
            Assert.IsNotNull(questions[0]);
        }

        [TestMethod]
        public void Answers_AreRandomized() {

            //Arrange

            // Act
            Question[] questions = Program.LoadQuestionsNonRandom(Program.GetFilePath());
            Question[] questions2 = Program.LoadQuestions(Program.GetFilePath());

            //Assert
                Assert.AreNotEqual(Question.ToString(questions), Question.ToString(questions2));
        }

        [TestMethod]
        public void CorrectAnswerIndex_IsCorrect() {
            // Arrange

            // Act
            Question[] random = Program.LoadQuestions(Program.GetFilePath());
            Question[] nonRandom = Program.LoadQuestionsNonRandom(Program.GetFilePath());

            // Assert
            for (int i = 0; i < random.Length; i++) {
                Assert.AreEqual(random[i].Answers[int.Parse(random[i].CorrectAnswerIndex)-1], nonRandom[i].Answers[int.Parse(nonRandom[i].CorrectAnswerIndex)-1]);
            }
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
