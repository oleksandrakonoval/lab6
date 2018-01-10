using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using SimCorp.IMS.PhoneBook.Calls;

namespace TestEqualAllPropsDif {
    [TestClass]
    public class TestEqualNamesNumbersDirectionsEqual {
        [TestMethod]
        public void TestEqual_NamesnumbersDirectionsEqual_IsTrue() {
            //Arrange          
            Call Call1 = new Call("Contact1", "+380997654321", (Direction)1, TimeSpan.Zero, DateTime.Now.AddDays(2));
            Call Call2 = new Call("Contact1", "+380997654321", (Direction)1, TimeSpan.Zero, DateTime.Now.AddDays(-2));

            //Act

            //Assert
            Assert.IsTrue(Call1.Equals(Call2));
        }
    }
}
