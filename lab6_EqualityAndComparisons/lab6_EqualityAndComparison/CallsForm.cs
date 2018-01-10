using SimCorp.IMS.PhoneBook.Calls;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace SimCorp.IMS.Calls {
    public partial class CallsForm : Form {
        ExampleContacts myContacts;
        bool lineIsBusy = false;
        Call currentCall=new Call();
        SortedSet<Call> Calls;
        Thread t;
        SortedSet<CallGroup> CallGroups = new SortedSet<CallGroup>();

        public CallsForm() {
            InitializeComponent();
            button3.Enabled = false;
            button4.Enabled = false;
            myContacts = new ExampleContacts();
            foreach (Contact item in myContacts.ExampleContactList) {
                comboBox1.Items.Add(item.name);
            }
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = false;
        }


        private void Form1_Load(object sender, EventArgs e) {
            Calls = new SortedSet<Call>();
            generateCalls();
        }

        private void generateCalls() {
            if (t == null) {
                t = new Thread(new ThreadStart(() => createCall())) { IsBackground = true };
                t.Start();
            }
        }

        private void createCall() {
          while (true)  {
                if (lineIsBusy==false) {
                    Thread.Sleep(1000);
                    Random rand = new Random();
                    int userIK = rand.Next(0, myContacts.ExampleContactList.Count);
                    int phoneIK = rand.Next(0, myContacts.ExampleContactList[userIK].phoneNumbers.Count);
                    currentCall = new Call();
                    currentCall.ContactName = myContacts.ExampleContactList[userIK].name;
                    currentCall.CallDirection = (Direction)0;
                    currentCall.CallTime = DateTime.Now;
                    currentCall.ContactNumber = myContacts.ExampleContactList[userIK].phoneNumbers[phoneIK];
                    currentCall.AddCallToLabel(label3);
                    currentCall.buttonEnablerChange(button1, true);
                    Thread.Sleep(5000);
                }             
            }
        }

        public Call createOutgoingCall(string name, string number) {
            Call newCall = new Call();
            newCall.ContactName = name;
            newCall.ContactNumber = number;
            newCall.CallTime = DateTime.Now;
            newCall.CallDirection = (Direction)1;
            return newCall;
        }

        private void button5_Click(object sender, EventArgs e) {
            lineIsBusy = true;

            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = true;
            button5.Enabled = false;

            currentCall=createOutgoingCall(comboBox1.Text,comboBox2.Text);
            label3.Text = "";
            label6.Text = currentCall.ToString();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {
            comboBox2.Items.Clear();
            foreach (string number in myContacts.ExampleContactList[comboBox1.SelectedIndex].phoneNumbers) {
                comboBox2.Items.Add(number);
            }
        }

        private void button4_Click(object sender, EventArgs e) {
            lineIsBusy = false;

            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = true;

            currentCall.clearLabel(label3);
            currentCall.clearLabel(label6);

            currentCall.CallDuration = DateTime.Now.Subtract(currentCall.CallTime);
            CallAdded(currentCall);
        }

        public void CallAdded(Call currentCall) {
            if (Calls.Count == 0 || !currentCall.Equals(Calls.Min)) {
                CallGroups.Add(new CallGroup(currentCall));
            }
            else {
                CallGroups.Min.lastCallTime = currentCall.CallTime;
                CallGroups.Min.lastCallDuration = currentCall.CallDuration;
                CallGroups.Min.addCallToGroup(currentCall);
            }

            //currentCall.AddCallToListView(listView1); //to monitor separate calls
            CallGroups.Min.AddCallToListView(listView1); //to monitor groups of calls
            Calls.Add(currentCall);
        }

        private void button1_Click(object sender, EventArgs e) {
            lineIsBusy = true;

            currentCall.CallTime = DateTime.Now;

            currentCall.buttonEnablerChange(button3, true);
            currentCall.buttonEnablerChange(button2, false);
            currentCall.buttonEnablerChange(button1, false);
            currentCall.buttonEnablerChange(button5, false);

            currentCall.AddCallToLabel(label6);
            generateCalls();
        }

        private void button3_Click(object sender, EventArgs e) {
            lineIsBusy = false;

            currentCall.buttonEnablerChange(button1, true);
            currentCall.buttonEnablerChange(button2, true);
            currentCall.buttonEnablerChange(button5, true);
            currentCall.buttonEnablerChange(button3, false);

            currentCall.clearLabel(label3);
            currentCall.clearLabel(label6);

            currentCall.CallDuration = DateTime.Now.Subtract(currentCall.CallTime);
            CallAdded(currentCall);
        }

        private void button2_Click(object sender, EventArgs e) {
            lineIsBusy = false;


            CallAdded(currentCall);

            currentCall.clearLabel(label3);
            Thread.Sleep(1000);
        }
    }
        
}
