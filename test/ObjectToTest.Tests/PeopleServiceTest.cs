using ObjectToTest.Models;
using ObjectToTest.Services;
using System.Collections;

namespace ObjectToTest.Tests
{
    public class PeopleServiceTests
    {

        [Test]
        [TestCaseSource(typeof(PeopleServiceTestsDataSource), nameof(PeopleServiceTestsDataSource.ListPrivateEntity))]
        [Category("Emprestimos")]
        public void Verifica_Se_Uma_Pessoa_Fisica_Pode_Solicitar_Emprestimo(IFinancialMoment person, decimal expectedValue)
        {
            // Arrange
            IPeopleService svc = new PeopleService();

            // Act
            var actualValue = svc.GetLimit(person);

            // Asset
            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }

        [Test]
        [TestCaseSource(typeof(PeopleServiceTestsDataSource), nameof(PeopleServiceTestsDataSource.ListCorporateEntity))]
        [Category("Emprestimos")]
        public void Verifica_Se_Uma_Pessoa_Juridica_Pode_Solicitar_Emprestimo(IFinancialMoment person, decimal expectedValue)
        {
            // Arrange
            IPeopleService svc = new PeopleService();

            // Act
            var actualValue = svc.GetLimit(person);

            // Asset
            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }

        [Test]
        [Category("Restricoes")]
        public void Verifica_Se_Uma_Pessoa_Fisica_Possui_Restricao()
        {
            Assert.IsTrue(1 == 1);
        }

        [Test]
        [Category("Restricoes")]
        public void Verifica_Se_Uma_Pessoa_Juridica_Possui_Restricao()
        {
            Assert.IsTrue(1 == 1);
        }

    }

    public static class PeopleServiceTestsDataSource
    {
        public static IEnumerable ListCorporateEntity
        {
            get
            {
                yield return new TestCaseData(new CorporateEntity(24323.23M), 34052.522M);
                yield return new TestCaseData(new CorporateEntity(32424.42M), 45394.188M);
            }
        }

        public static IEnumerable ListPrivateEntity
        {
            get
            {
                yield return new TestCaseData(new PrivateEntity(6500), 3900.0M);
                yield return new TestCaseData(new PrivateEntity(500), 300M);
            }
        }
    }
}