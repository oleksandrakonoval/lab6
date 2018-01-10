using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimCorp.IMS.PhoneBook.Calls;
using System;
using System.Collections.Generic;

namespace SimCorp.IMS.TestAddingSorting {
    [TestClass]
    public class TestRemoving {
        [TestMethod]
        public void TestRemoving_GotDescending() {
            //Arrange
            SortedSet<Call> Calls = new SortedSet<Call>();
            //List<Call> ObtainedCalls = new List<Call>();
            DateTime now = DateTime.Now;
            Call Call1 = new Call("Contact1", "+380991234567", (Direction)0, TimeSpan.Zero, now);
            Call Call2 = new Call("Contact2", "+380991234567", (Direction)0, TimeSpan.Zero, now);
            Call Call3 = new Call("Contact3", "+380991234127", (Direction)0, TimeSpan.Zero, DateTime.Now.AddDays(2));
            Call Call4 = new Call("Contact4", "+380991234127", (Direction)1, TimeSpan.Zero, DateTime.Now.AddDays(2));
            Call Call5 = new Call("Contact5", "+380923423427", (Direction)1, TimeSpan.Zero, DateTime.Now.AddHours(5));
            Call Call6 = new Call("Contact4", "+380991234127", (Direction)0, TimeSpan.Zero, DateTime.Now.AddDays(-2));
            Call Call7 = new Call("Contact5", "+380923423427", (Direction)1, TimeSpan.Zero, DateTime.Now.AddHours(-5));

            //Act
            Calls.Add(Call1);
            Calls.Add(Call2);
            Calls.Add(Call3);
            Calls.Add(Call4);
            Calls.Add(Call5);
            Calls.Add(Call6);
            Calls.Add(Call7);

            Calls.Remove(Call1);
            Calls.Remove(Call4);

            //Assert
            Assert.IsTrue(Calls.Min.CompareTo(Calls.Max) <=0);
        }
    }
}
