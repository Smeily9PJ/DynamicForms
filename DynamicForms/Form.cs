using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicForms
{
    public class Form
    {
        private Dictionary<string, FormAnswer> FormAnswers;
        public string Title { get; set; }
        public int FormAnswerCount => FormAnswers.Count;

        public QuestionRoot Questions { get; set; }

        public Form()
        {
            this.FormAnswers = new Dictionary<string, FormAnswer>();
            this.Questions = new QuestionRoot();
        }

        public FormAnswer FindOrCreateFormAnswer(string user)
        {
            if (string.IsNullOrEmpty(user))
            {
                return null;
            }

            if (this.FormAnswers.ContainsKey(user))
            {
                return this.FormAnswers[user];
            }

            var fa = new FormAnswer();
            this.FormAnswers.Add(user, fa);
            return fa;
        }
    }
}
