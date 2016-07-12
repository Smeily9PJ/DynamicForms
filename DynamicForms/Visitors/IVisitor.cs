namespace DynamicForms.Visitors
{
    public interface IVisitor<T>
    {
        T Visit(IVisitorObject obj);
    }

    public static class VisitorExtensions
    {
        public static T Visit<T>(this IVisitor<T> @this, IVisitorObject obj)
        {
            return obj.Accept(@this);
        }
    }
}