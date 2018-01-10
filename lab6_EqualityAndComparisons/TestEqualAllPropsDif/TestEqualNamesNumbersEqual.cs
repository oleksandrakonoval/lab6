using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using SimCorp.IMS.PhoneBook.Calls;

namespace TestEqualAllPropsDif {
    [TestClass]
    public class TestEqualNamesNumbersEqual {
        [TestMethod]
        public void TestEqual_NamesNumbersEqual_IsFalse() {
            //Arrange          
            Call Call1 = new Call("Contact1", "+380991234127", (Direction)0, TimeSpan.Zero, DateTime.Now.AddDays(2));
            Call Call2 = new Call("Contact1", "+380991234127", (Direction)1, TimeSpan.Zero, DateTime.Now.AddDays(-2));

            //Act

            //Assert
            Assert.IsFalse(Call1.Equals(Call2));
        }
    }
}
