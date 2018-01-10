using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimCorp.IMS.Calls;
using SimCorp.IMS.PhoneBook.Calls;
using System;
using System.Collections.Generic;

namespace SimCorp.IMS.TestAddingSorting {
    [TestClass]
    public class TestAddingEarlierLaterDif {
        [TestMethod]
        public void TestAdding_EarlierLaterDifProp_GotDescending() {
            //Arrange
            SortedSet<Call> Calls = new SortedSet<Call>();
            List<Call> ObtainedCalls = new List<Call>();

            //Act
            Calls.Add(new Call("Contact1", "+380991234567", (Direction)0, TimeSpan.Zero, DateTime.Now));
            Calls.Add(new Call("Contact2", "+380991234587", (Direction)1, DateTime.Now.Subtract(DateTime.Today), DateTime.Now.AddDays(2)));
            foreach (Call call in Calls) { ObtainedCalls.Add(call); }

            //Assert

            Assert.IsTrue(ObtainedCalls[1].CallTime <= ObtainedCalls[0].CallTime);
        }
    }
}
