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
            var forms = f.Forms.Select(x => $"<div>\n<span>{x.Title}</span><button type='button'>Voir</button>\n</div>");
            return $"<div>{string.Join("", forms)}</div>\n";
        }

        public string Visit(Form f)
        {
            var content = f.Root.Accept(this);
            return $"<div>\n<h1>{f.Title}</h1>\n{content}\n</div>\n";
        }

        public string Visit(FormAnswer f)
        {
            throw new NotImplementedException();
        }

        public string Visit(QuestionFolder q)
        {
            var content = VisitAllQuestions(q.Questions);
            return $"<div>\n<h3 class='label label-default'>{q.Title}</h3>\n{content}\n</div>\n";
        }

        public string Visit(QuestionRoot q)
        {
            var content = VisitAllQuestions(q.Questions);
            return $"<div>\n<h2 class='label label-default'>{q.Title}</h2>\n{content}\n</div>\n";
        }

        public string Visit(OpenQuestion q)
        {
            return $"<div>\n<h4 class='label label-default'>{q.Title}</h4>\n<div>\n{q.Content}\n</div>\n</div>\n";
        }

        public string Visit(OpenAnswer a)
        {
            return $"<textarea class='form-control'>{a.Content}</textarea>\n";
        }

        private string VisitAllQuestions(IEnumerable<QuestionBase> questions)
        {
            var sb = new StringBuilder();
            foreach (var question in questions)
            {
                sb.Append(question.Accept(this));
                sb.Append("\n");
            }
            return sb.ToString();
        }
    }
}