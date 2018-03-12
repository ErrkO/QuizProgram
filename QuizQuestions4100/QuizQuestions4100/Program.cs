using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizQuestions4100
{
    public class Program
    {
        static void Main(string[] args)
        {

            int test = 1;
            int q = 1;
            bool flag = false;
            int number = 1;
            double numCorrect = 0.0;
            int answered = 0;
            List<bool> ansyn = new List<bool>();
            List <Questions> Quiz = new List<Questions>();
            string line;
            //StreamReader file = new StreamReader(@"questionList.txt");
            StreamReader file = new StreamReader(@"4400QQ.txt");
            while ((line = file.ReadLine()) != null)
            {
                Questions question = new Questions(line);

                test = 1;

                while (true)
                {
                    string ans = file.ReadLine();
                    if (ans == "####") break;
                    //Console.WriteLine("{0}.{1}",q,test);
                    bool correct = Convert.ToBoolean(file.ReadLine());
                    question.Add(ans, correct);
                    test++;
                }
                Quiz.Add(question);

                q++;             
            }

            for (int i = 0; i < Quiz.Count;i++)
            {

                ansyn.Add(false);

            }

            int choice = 97;
            string wantQuit = "";
            while (wantQuit != "q")
            {
                Random rnd = new Random();
                int ques = rnd.Next(Quiz.Count);

                while (flag != true)
                {

                    if (ansyn[ques] == true)
                    {

                        ques = rnd.Next(Quiz.Count);

                    }

                    else
                    {

                        flag = true;

                    }

                }

                flag = false;

                //Console.WriteLine("Quiz count  = {0}", Quiz.Count);
                Console.WriteLine("Question {0} out of {1}",number,Quiz.Count);
                Console.WriteLine(Quiz[ques].Question);
                Console.WriteLine();
                List<Answers> tempList = new List<Answers>();
                for (int i = 0; i < Quiz[ques].Answers.Count; i++)
                {
                    tempList.Add(Quiz[ques].Answers[i]);
                }

                List<bool> correctAnswers = new List<bool>();
                int count = tempList.Count;
                for (int i = 0; i < count; i++)
                {
                    //Console.WriteLine("Quiz answer count  = {0}", Quiz[ques].Answers.Count);
                    //Console.WriteLine("i = {0}", i);
                    int ans = rnd.Next(tempList.Count);
                    //Console.WriteLine("templist count  = {0}", tempList.Count);
                    //Console.WriteLine("ans = {0}", ans);
                    Console.WriteLine("{0} )   {1}", i + 1, tempList[ans].AnswerChoice);
                    correctAnswers.Add(tempList[ans].RightWrong);
                    tempList.RemoveAt(ans);
                }

                Console.WriteLine();
                Console.Write("Choice: ");
                choice = Convert.ToInt16(Console.ReadLine());
                if (correctAnswers[choice - 1])
                {
                    Console.WriteLine("CORRECT!");
                    answered++;
                    numCorrect++;
                }
                else
                {
                    answered++;
                    int index = 1;
                    foreach (bool attempt in correctAnswers)
                    {
                        if (attempt == true)
                        {
                            Console.WriteLine("The correct answer is {0}", index);
                        }
                        index++;
                    }
                }
                Console.WriteLine("Running Score is {0:P}", (numCorrect / answered));
                Console.WriteLine("Press 'q' to quit or any other key to continue.");
                wantQuit = (Console.ReadLine());
                number++;
            }
        }
    }
}
