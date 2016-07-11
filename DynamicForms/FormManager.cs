using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicForms
{
    public class FormManager
    {
        private readonly List<Form> _forms;

        public List<Form> Forms { get; }

        public FormManager()
        {
            this.Forms = new List<Form>();
        }
    }
}
