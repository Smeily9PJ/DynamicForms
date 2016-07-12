namespace DynamicForms.Visitors
{
    public interface IVisitorObject
    {
        T Accept<T>(IVisitor<T> obj);
    }
}