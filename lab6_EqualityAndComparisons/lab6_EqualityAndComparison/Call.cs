using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab6_EqualityAndComparison {
    public enum Direction  {
        Incoming,
        Outgoing
    }

    public class Call : IComparable<Call> {
        public string ContactName { get; set; }
        public string ContactNumber { get; set; }
        public Direction CallDirection { get; set; }
        public TimeSpan CallDuration { get; set; }
        public DateTime CallTime { get; set; }

        public delegate void CallRecievedDelegate(Call myCall);

        public event CallRecievedDelegate CallReceived;

        public void RaiseCallReceivedEvent(Call myCall) {
            CallReceived?.Invoke(myCall);
        }

        public void ReceiveCall() {
            RaiseCallReceivedEvent(this);
        }

        public int CompareTo(Call other) {
            if (other == null) return 1;
            return -CallTime.CompareTo(other.CallTime);
        }

        public void AddCallToListView(ListView listview) {
            if (listview.InvokeRequired)
                listview.Invoke(new Action<ListView>(AddCallToListView), listview);
            else
                listview.Items.Insert(0, new ListViewItem(new[] { ContactName, ContactNumber, CallDirection.ToString(), CallTime.ToString(), CallDuration.ToString() }));
        }

        public void AddCallToLabel(Label label) {
            if (label.InvokeRequired)
                label.Invoke(new Action<Label>(AddCallToLabel), label);
            else
                label.Text = ToString();
        }

        public void buttonEnablerChange(Button button, bool state) {
            if (button.InvokeRequired)
                button.Invoke(new Action<Button, bool>(buttonEnablerChange), button, state);
            else
                button.Enabled = state;
        }

        public void clearLabel(Label label) {
            if (label.InvokeRequired)
                label.Invoke(new Action<Label>(clearLabel), label);
            else
                label.Text = "";
        }

        public override string ToString() {
            return $"{CallDirection} call {ContactName} : {ContactNumber}";
        }
    }
}
