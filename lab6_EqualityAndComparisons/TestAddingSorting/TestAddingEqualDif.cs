using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimCorp.IMS.PhoneBook.Calls;
using System;
using System.Collections.Generic;

namespace SimCorp.IMS.TestAddingSorting {
    [TestClass]
    public class TestAddingEqualDif {
        [TestMethod]
        public void TestAdding_EqualDifProp_GotDescending() {
            //Arrange
            SortedSet<Call> Calls = new SortedSet<Call>();
            List<Call> ObtainedCalls = new List<Call>();

            //Act
            DateTime now = DateTime.Now;
            Calls.Add(new Call("Contact1", "+380991234567", (Direction)0, TimeSpan.Zero, now));
            Calls.Add(new Call("Contact2", "+380991234568", (Direction)1, DateTime.Now.Subtract(DateTime.Today), now));

            //Assert

            Assert.IsTrue(Calls.Count==1);
        }
    }
}
