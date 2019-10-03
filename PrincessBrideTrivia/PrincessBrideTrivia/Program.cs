using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

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
            return Math.Floor((float)numberCorrectAnswers / (float)numberOfQuestions * 100) + "%";
            /*Issue 2: Integer division cannot be used here, that is why the function would only return 0% or 100%, because the number calculated would be floored to 0 every time n/7 questions were answered correctly where n < 7.*/
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

                string answer1 = lines[lineIndex + 1];
                string answer2 = lines[lineIndex + 2];
                string answer3 = lines[lineIndex + 3];

                string correctAnswerIndex = lines[lineIndex + 4];

                Question question = new Question();
                question.Text = questionText;
                question.Answers = new string[3];
                question.Answers[0] = answer1;
                question.Answers[1] = answer2;
                question.Answers[2] = answer3;
                question.CorrectAnswerIndex = correctAnswerIndex;

                /*Bonus:*/
                questions[i] = RandomizeQuestionAnswersOrder(question);

                //questions[i] = question;
                /*Issue 1: Function never added the populated question object to the questions array.*/
            }
            return questions;
        }

        /*Bonus - Using Knuth shuffle*/
        public static Question RandomizeQuestionAnswersOrder(Question question)
        {
            string correctAnswer = question.Answers[Convert.ToInt32(question.CorrectAnswerIndex) - 1];

            Random rand = new Random();

            for (int i = 0; i < question.Answers.Length; i++)
            {
                string temp = question.Answers[i];

                int randIndex = rand.Next(i, question.Answers.Length);

                question.Answers[i] = question.Answers[randIndex];
                question.Answers[randIndex] = temp;
            }

            question.CorrectAnswerIndex = (Array.IndexOf(question.Answers, correctAnswer) + 1).ToString();

            return question;
        }
    }
}
