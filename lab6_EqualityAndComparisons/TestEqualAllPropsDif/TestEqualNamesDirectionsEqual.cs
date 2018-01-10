using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using SimCorp.IMS.PhoneBook.Calls;

namespace TestEqualAllPropsDif {
    [TestClass]
    public class TestEqualNamesDirectionsEqual {
        [TestMethod]
        public void TestEqual_NamesDirectionsEqual_IsFalse() {
            //Arrange          
            Call Call1 = new Call("Contact1", "+380997654321", (Direction)1, TimeSpan.Zero, DateTime.Now.AddDays(2));
            Call Call2 = new Call("Contact1", "+380998374127", (Direction)1, TimeSpan.Zero, DateTime.Now.AddDays(-2));

            //Act

            //Assert
            Assert.IsFalse(Call1.Equals(Call2));
        }
    }
}
