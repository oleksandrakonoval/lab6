using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimCorp.IMS.PhoneBook.Calls;
using System;
using System.Collections.Generic;

namespace SimCorp.IMS.TestAddingSorting {
    [TestClass]
    public class TestAddingEqualEqual {
        [TestMethod]
        public void TestAdding_EqualEqualProp_GotDescending() {
            //Arrange
            SortedSet<Call> Calls = new SortedSet<Call>();
            List<Call> ObtainedCalls = new List<Call>();

            //Act
            DateTime now = DateTime.Now;
            Calls.Add(new Call("Contact1", "+380991234567", (Direction)0, TimeSpan.Zero, now));
            Calls.Add(new Call("Contact1", "+380991234567", (Direction)0, TimeSpan.Zero, now));

            //Assert

            Assert.IsTrue(Calls.Count == 1);
        }
    }
}
