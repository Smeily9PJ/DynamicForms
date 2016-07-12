using System;

namespace DynamicForms.Questions
{
    public class QuestionRoot : QuestionFolder
    {
        public Form Form { get; }

        public QuestionRoot(Form form, string title = "")
            : base(title)
        {
            if(form == null) throw new ArgumentNullException(nameof(form));
            this.Form = form;
        }
    }
}