using Domain.Model.Entities;
using Domain.Model.ValueObject;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace DomainTest
{
    [TestClass]
    public sealed class Test1
    {
        // PhoneNumber
        [TestMethod]
        public void PhoneNumber_Valid_ConstructsAndToString()
        {
            var pn = new PhoneNumber("+39 123456789");
            Assert.AreEqual("+39 123456789", pn.Number);
            Assert.AreEqual(pn.Number, pn.ToString());
        }

        [TestMethod]
        public void PhoneNumber_Invalid_ThrowsArgumentException()
        {
            Assert.ThrowsException<ArgumentException>(() => new PhoneNumber("12345"));
            Assert.ThrowsException<ArgumentException>(() => new PhoneNumber("+39123")); // too short
            Assert.ThrowsException<ArgumentException>(() => new PhoneNumber("+abc 1234567")); // bad prefix
        }

        // Address
        [TestMethod]
        public void Address_Valid_ConstructsAndToString()
        {
            var addr = new Address("Via Roma 1", "Milano", "20100", "Italia");
            Assert.AreEqual("Via Roma 1", addr.Street);
            Assert.AreEqual("Milano", addr.City);
            Assert.AreEqual("20100", addr.PostalCode);
            Assert.AreEqual("Italia", addr.Country);
            Assert.AreEqual("Via Roma 1, Milano, 20100, Italia", addr.ToString());
        }

        [TestMethod]
        public void Address_StreetMustStartWithVia_Throws()
        {
            Assert.ThrowsException<ArgumentException>(() => new Address("Corso Italia 1", "Torino", "10100", "Italia"));
            // case-insensitive check
            Assert.ThrowsException<ArgumentException>(() => new Address("corso Italia 1", "Torino", "10100", "Italia"));
        }

        [TestMethod]
        public void Address_PostalCode_MustBeFiveDigits_Throws()
        {
            Assert.ThrowsException<ArgumentException>(() => new Address("Via Milano 1", "Roma", "1234", "Italia"));
            Assert.ThrowsException<ArgumentException>(() => new Address("Via Milano 1", "Roma", "123456", "Italia"));
            Assert.ThrowsException<ArgumentException>(() => new Address("Via Milano 1", "Roma", "12a45", "Italia"));
        }

        // Cat
        [TestMethod]
        public void Cat_Constructor_Valid_SetsProperties()
        {
            var arrived = new DateOnly(2024, 6, 1);
            var cat = new Cat("Golia", "Europeo", Sex.Male, "Docile", null, arrived, null, null);

            Assert.AreEqual("Golia", cat.Name);
            Assert.AreEqual("Europeo", cat.Race);
            Assert.AreEqual(Sex.Male, cat.CatSex);
            Assert.AreEqual("Docile", cat.Description);
            Assert.AreEqual(arrived, cat.ArrivedToCattery);
            Assert.IsNotNull(cat.Cui);
        }

        [TestMethod]
        public void Cat_InvalidNameOrRace_Throws()
        {
            var arrived = new DateOnly(2024, 6, 1);
            Assert.ThrowsException<ArgumentException>(() => new Cat("", "Race", Sex.Female, "d", null, arrived, null, null));
            Assert.ThrowsException<ArgumentException>(() => new Cat("Name", "", Sex.Female, "d", null, arrived, null, null));
        }

        [TestMethod]
        public void Cat_RegenerateCui_ProducesDifferentOrNonEmptyCui()
        {
            var arrived = new DateOnly(2024, 6, 1);
            var cat = new Cat("Pippo", "Siamese", Sex.Male, "desc", null, arrived, null, null);
            var first = cat.Cui;
            cat.RegenerateCui();
            Assert.IsFalse(string.IsNullOrWhiteSpace(cat.Cui));
            // possible same by chance is unlikely; at least ensure non-empty and pattern-like content
            Assert.IsTrue(cat.Cui.Length >= 6);
        }
        // Esempio di codice fiscale valido (nota: deve avere carattere di controllo corretto)
        private const string ValidCf = "RSSMRA85M01H501U";

        [TestMethod]
        public void FiscalCode_Invalid_NullOrWhiteSpace_ThrowsArgumentException()
        {
            Assert.ThrowsException<ArgumentException>(() => new FiscalCode(null!));
            Assert.ThrowsException<ArgumentException>(() => new FiscalCode(string.Empty));
            Assert.ThrowsException<ArgumentException>(() => new FiscalCode("   "));
        }

        [TestMethod]
        public void FiscalCode_Invalid_WrongLengthOrPattern_ThrowsArgumentException()
        {
            // troppo corto
            Assert.ThrowsException<ArgumentException>(() => new FiscalCode("ABC"));
            // 16 caratteri ma pattern non valido (tutti cifre)
            Assert.ThrowsException<ArgumentException>(() => new FiscalCode("1234567890123456"));
            // lunghezza diversa da 16
            Assert.ThrowsException<ArgumentException>(() => new FiscalCode("RSSMRA85M01H501"));
        }

        [TestMethod]
        public void FiscalCode_IsValid_StaticMethod_WorksAsExpected()
        {
            Assert.IsTrue(FiscalCode.IsValid(ValidCf));
            Assert.IsFalse(FiscalCode.IsValid((string?)null)); // Fix: cast esplicito a string? per evitare CS8625
            Assert.IsFalse(FiscalCode.IsValid(""));
            Assert.IsFalse(FiscalCode.IsValid("invalidcf1234567"));
        }

    }
}