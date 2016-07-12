using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamicForms.Questions;
using DynamicForms.Visitors;
using NUnit.Framework;

namespace DynamicForms.Tests
{
    [TestFixture]
    public class HtmlVisitorTests
    {
        [Test]
        public void GenerateQuestionsToHtml()
        {
            var f = new Form("Notre premier formulaire");
            var r = f.Root;

            var f1 = r.CreateQuestionFolder("Repas");
            var f2 = f1.CreateQuestionFolder("Sommeil");
            var f3 = f2.CreateQuestionFolder("Jeux");

            var q2 = f1.CreateQuestion(typeof(OpenQuestion));
            q2.Content = "Qu'avez-vous mangé ce midi ?";
            var q1 = r.CreateQuestion(typeof(OpenQuestion));
            q1.Content = "Quel age avez-vous ?";

            var path = @"C:\Temp\FormGen.html";
            using (var s = new StreamWriter(path))
            {
                var v = new HtmlVisitor();
                s.Write(f.Accept(v));
            }
        }
    }
}