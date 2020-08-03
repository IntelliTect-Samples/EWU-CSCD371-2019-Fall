﻿using System;
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

        public static void RandomizeAnswerOrder(Question question)
        {
            int correctIndex = int.Parse(question.CorrectAnswerIndex) - 1;
            Console.WriteLine("The correct answer is " + correctIndex);

            Random rand = new Random();
            //For each answer in answers, pick a random other one to swap with. Or stay put.
            for (int i  = 0; i < question.Answers.Length; i++)
            {
                //pick a random index to swap with
                int swapIndex = rand.Next(0, question.Answers.Length);
                if (swapIndex == i)
                {
                    //stay put
                    continue;

                }

                string temp = question.Answers[swapIndex];
                question.Answers[swapIndex] = question.Answers[i];
                question.Answers[i] = temp;

                if (correctIndex == i)
                {
                    correctIndex = swapIndex;
                    question.CorrectAnswerIndex = (swapIndex + 1).ToString();
                }
                else if (correctIndex == swapIndex)
                {
                    correctIndex = i;
                    question.CorrectAnswerIndex = (i + 1).ToString();
                }
            }
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
                RandomizeAnswerOrder(question);
                questions[i] = question;
            }
            return questions;
        }
    }
}
