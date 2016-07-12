using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DynamicForms.Answers;
using DynamicForms.Questions;

namespace DynamicForms.Visitors
{
    public class HtmlVisitor : IVisitor<string>
    {
        public string Visit(FormManager f)
        {
            var forms = f.Forms.Select(x => $"<div><span>{x.Title}</span><button type='button'>Voir</button></div>");
            return $"<div>{string.Join("", forms)}</div>";
        }

        public string Visit(Form f)
        {
            var content = f.Root.Accept(this);
            return $"<div><h1>{f.Title}</h1>{content}</div>";
        }

        public string Visit(FormAnswer f)
        {
            throw new NotImplementedException();
        }

        public string Visit(QuestionFolder q)
        {
            var content = VisitAllQuestions(q.Questions);
            return $"<div><h3 class='label label-default'>{q.Title}</h3>{content}</div>";
        }

        public string Visit(QuestionRoot q)
        {
            var content = VisitAllQuestions(q.Questions);
            return $"<div><h2 class='label label-default'>{q.Title}</h2>{content}</div>";
        }

        public string Visit(OpenQuestion q)
        {
            return $"<div><h4 class='label label-default'>{q.Title}</h4><div>{q.Content}</div></div>";
        }

        public string Visit(OpenAnswer a)
        {
            return $"<textarea class='form-control'>{a.Content}</textarea>";
        }

        private string VisitAllQuestions(IEnumerable<QuestionBase> questions)
        {
            var sb = new StringBuilder();
            foreach (var question in questions)
            {
                sb.Append(question.Accept(this));
                sb.Append("");
            }
            return sb.ToString();
        }
    }
}