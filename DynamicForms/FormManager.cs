using System.Collections.Generic;

namespace DynamicForms
{
    public class FormManager
    {
        public List<Form> Forms { get; }

        public FormManager()
        {
            Forms = new List<Form>();
        }
    }
}