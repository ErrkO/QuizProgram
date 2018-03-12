using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizQuestions4100
{
    public class Answers
    {
        public string AnswerChoice;
        public bool RightWrong;

        public Answers(string ans, bool correct)
        {
            this.AnswerChoice = ans;
            this.RightWrong = correct;
        }

    }
}
