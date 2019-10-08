using System;
using System.IO;

namespace PrincessBrideTrivia
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string filePath = GetFilePath();
            Question[] questions = LoadQuestions(filePath);

            int numberCorrect = 0;
            for (int i = 0; i < questions.Length; i++)
            {
                bool result = AskQuestion(questions[i]);
                if (result)
                {
                    numberCorrect++;
                }
            }
            Console.WriteLine("You got " + GetPercentCorrect(numberCorrect, questions.Length) + " correct");
        }

        public static string GetPercentCorrect(int numberCorrectAnswers, int numberOfQuestions)
        {
            return (numberCorrectAnswers / numberOfQuestions * 100) + "%";
        }

        public static bool AskQuestion(Question question)
        {
            DisplayQuestion(question);

            string userGuess = GetGuessFromUser();
            return DisplayResult(userGuess, question);
        }

        public static string GetGuessFromUser()
        {
            return Console.ReadLine();
        }

        public static bool DisplayResult(string userGuess, Question question)
        {
            if (userGuess == question.CorrectAnswerIndex)
            {
                Console.WriteLine("Correct");
                return true;
            }

            Console.WriteLine("Incorrect");
            return false;
        }

        public static void DisplayQuestion(Question question)
        {
            Console.WriteLine("Question: " + question.Text);
            for (int i = 0; i < question.Answers.Length; i++)
            {
                Console.WriteLine((i + 1) + ": " + question.Answers[i]);
            }
        }

        public static string GetFilePath()
        {
            return "Trivia.txt";
        }

        public static Question[] LoadQuestions(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);

            Question[] questions = new Question[lines.Length / 5];
            for (int i = 0; i < questions.Length; i++)
            {
                int lineIndex = i * 5;
                string questionText = lines[lineIndex];

                int[] randomizedIndexes = MakeRandomArray();

                string answer1 = lines[lineIndex + randomizedIndexes[0]];
                string answer2 = lines[lineIndex + randomizedIndexes[1]];
                string answer3 = lines[lineIndex + randomizedIndexes[2]];

                string correctAnswerIndex = lines[lineIndex + 4];
                int updatedCorrectAnswerIndex = Array.IndexOf(randomizedIndexes, int.Parse(correctAnswerIndex)) + 1;

                Question question = new Question();
                question.Text = questionText;
                question.Answers = new string[3];
                question.Answers[0] = answer1;
                question.Answers[1] = answer2;
                question.Answers[2] = answer3;
                question.CorrectAnswerIndex = updatedCorrectAnswerIndex.ToString();

                questions[i] = question;
            }
            return questions;
        }

        private static int[] MakeRandomArray()
        {
            int[] indexes = new int[3];
            for (int i = 0; i < 3; i++)
                indexes[i] = i + 1;

            Random r = new Random();
            for(int i = 3; i > 1; i--)
            {
                int indexToSwap = r.Next(i);
                int temp = indexes[indexToSwap];

                indexes[indexToSwap] = indexes[i - 1];
                indexes[i - 1] = temp;
            }

            return indexes;
        }
    }
}
