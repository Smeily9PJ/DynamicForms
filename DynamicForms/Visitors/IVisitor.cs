using DynamicForms.Answers;
using DynamicForms.Questions;

namespace DynamicForms.Visitors
{
    public interface IVisitor<T>
    {
        T Visit(Form f);
        T Visit(FormAnswer f);

        T Visit(QuestionFolder q);
        T Visit(QuestionRoot q);
        T Visit(OpenQuestion q);

        T Visit(OpenAnswer a);
    }

    public static class VisitorExtensions
    {
        public static T Visit<T>(this IVisitor<T> @this, IVisitorObject obj)
        {
            return obj.Accept(@this);
        }
    }
}