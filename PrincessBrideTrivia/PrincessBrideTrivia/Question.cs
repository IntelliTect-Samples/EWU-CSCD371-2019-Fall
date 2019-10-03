namespace PrincessBrideTrivia
{
    public class Question
    {
        public string Text;
        public string[] Answers;
        public string CorrectAnswerIndex;
        public string CorrectAnswer {
            get { return this.Answers[System.Int32.Parse(this.CorrectAnswerIndex)-1]; }
        }
    }
}
