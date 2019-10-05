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
            Random randomGenerator = new Random();
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
                RandomizeAnswerOrder(question, randomGenerator);

                questions[i] = question;
            }
            return questions;
        }

        public static void RandomizeAnswerOrder(Question question, Random randomGenerator)
        {
            // create a sequence of ints from 0 to length-1 in random order
            // initialize to -1 to easily tell which indices have been mapped
            int[] randomMapping = new int[question.Answers.Length];
            for (int i = 0; i < randomMapping.Length; i++)
            {
                randomMapping[i] = -1;
            }

            // collisions on random index are solved by finding the first free index
            //    direction checked for first free index is randomly chosen
            for (int i = 0; i < randomMapping.Length; i++)
            {
                int newIndex = randomGenerator.Next(0, randomMapping.Length - 1);
                if (randomMapping[newIndex] == -1)
                {
                    randomMapping[newIndex] = i;
                }
                else
                {
                    int direction = (int)Math.Pow(-1, randomGenerator.Next(1, 2));
                    for (int j = 0; j < randomMapping.Length; j++)
                    {
                        // can't use modulo by itself here
                        // it's actually a remainder that returns negatives on modulo of negative numbers
                        newIndex = (newIndex + direction) % randomMapping.Length;
                        if (newIndex < 0)
                        {
                            newIndex = randomMapping.Length - 1;
                        }

                        if (randomMapping[newIndex] == -1)
                        {
                            randomMapping[newIndex] = i;
                            break;
                        }
                    }
                }
            }

            // answer is indexed naturally (starts at 1), need to adjust for that
            string[] oldAnswers = (string[])question.Answers.Clone();
            question.CorrectAnswerIndex = $"{randomMapping[int.Parse(question.CorrectAnswerIndex) - 1] + 1}";
            for (int i = 0; i < randomMapping.Length; i++)
            {
                question.Answers[i] = oldAnswers[randomMapping[i]];
            }
        }
    }
}
