using System.Data;

namespace Who_Wants_To_Be_A_Millionaire
{
    public class Question
    {
        // Attributes
        public string questionText;
        public string[] options;
        public string answer;
        //public int usrid { set; get; }
        int usrid = 1;

        // Constructor to set question, add options to array and set answer
        public Question(string questionText, string optionA, string optionB, string optionC, string optionD, string answer)
        {
            this.options = new string[4];
            this.questionText = questionText;
            this.options[0] = optionA;
            this.options[1] = optionB;
            this.options[2] = optionC;
            this.options[3] = optionD;
            this.answer = answer;
        }


        // Check if selected option is correct
        public bool checkAnswer(string selectedOption)
        {
            string answer = selectedOption.Substring(3, selectedOption.Length - 3);
            if (this.answer == answer)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Retrieve question text
        public string getQuestionText()
        {
            return questionText;
        }

        //Retrieve options
        public string[] getOptions()
        {
            return options;
        }
    }
}