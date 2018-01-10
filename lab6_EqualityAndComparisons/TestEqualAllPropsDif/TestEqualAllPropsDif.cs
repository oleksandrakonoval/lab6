using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimCorp.IMS.PhoneBook.Calls;
using System;

namespace SimCorp.IMS.TestAddingSorting {
    [TestClass]
    public class TestEqualAllPropsDif {
        [TestMethod]
        public void TestEqual_AllDif_IsFalse() {
            //Arrange          
            Call Call1= new Call("Contact1", "+380991234127", (Direction)0, TimeSpan.Zero, DateTime.Now.AddDays(2));          
            Call Call2= new Call("Contact2", "+380998374127", (Direction)1, TimeSpan.Zero, DateTime.Now.AddDays(-2));

            //Act

            //Assert
            Assert.IsFalse(Call1.Equals(Call2));
        }
    }
}
