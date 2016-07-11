using NUnit.Framework;

namespace DynamicForms.Tests
{
    [TestFixture]
    public class FormManagerTests
    {
        [Test]
        public void CreateFormManager()
        {
            var fm = new FormManager();
            Assert.IsNotNull(fm);
        }

        [Test]
        public void CheckForms()
        {
            var fm = new FormManager();
            Assert.IsNotNull(fm.Forms);
            Assert.AreEqual(0, fm.Forms.Count);
        }
        
        [Test]
        public void AddForms()
        {
            var fm = new FormManager();
            var f = new Form();
            fm.Forms.Add(f);
        }
    }
}
