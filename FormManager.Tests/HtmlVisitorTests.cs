using DynamicForms.Questions;
using DynamicForms.Visitors;
using NUnit.Framework;

namespace DynamicForms.Tests
{
    [TestFixture]
    public class HtmlVisitorTests
    {
        [TestCase(@"<div><h1>Notre premier formulaire</h1><div><h2 class='label label-default'></h2><div><h3 class='label label-default'>Repas</h3><div><h3 class='label label-default'>Sommeil</h3><div><h3 class='label label-default'>Jeux</h3></div></div><div><h4 class='label label-default'></h4><div>Qu'avez-vous mangé ce midi ?</div></div></div><div><h4 class='label label-default'></h4><div>Quel age avez-vous ?</div></div></div></div>")]
        public void GenerateQuestionsToHtml(string expected)
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
            
            var v = new HtmlVisitor();
            var result = f.Accept(v);
            Assert.AreEqual(result, expected);
        }
    }
}