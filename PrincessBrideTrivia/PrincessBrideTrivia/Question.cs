using System;

namespace PrincessBrideTrivia
{
    public class Question
    {
        public string Text;
        public string[] Answers;
        public string CorrectAnswerIndex;

        override
        public string ToString() {
            string stringy = this.Text + "\n";
            for (int i = 0; i < Answers.Length; i++) {
                stringy += Answers[i] + "\n";
            }
            stringy += CorrectAnswerIndex;
            return stringy;
        }

        public static string ToString(Question[] questions) {
            string stringy = "";
            for(int i = 0; i < questions.Length; i++) {
                stringy += "\n" + questions[i].ToString();
            }
            return stringy;
        }
    }
}