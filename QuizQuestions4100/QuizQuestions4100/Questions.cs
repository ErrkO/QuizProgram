using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizQuestions4100
{
    public class Questions
    {
        public List<Answers> Answers;
        public string Question { get; private set; }

        public Questions(string question)
        {
            this.Question = question;
            this.Answers = new List<Answers>();
        }

        public void Add(string answer, bool correct)
        {
            Answers ansChoice = new Answers(answer, correct);
            this.Answers.Add(ansChoice);
        }
    }
}
