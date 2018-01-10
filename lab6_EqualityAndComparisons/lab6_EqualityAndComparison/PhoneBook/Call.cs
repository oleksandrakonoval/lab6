using System;
using System.Windows.Forms;

namespace SimCorp.IMS.PhoneBook.Calls {
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

        public Call() {

        }

        public Call(string name, string number, Direction direction, TimeSpan duration, DateTime time) {
            ContactName = name;
            ContactNumber = number;
            CallDirection = direction;
            CallDuration = duration;
            CallTime = time;
        }

        public int CompareTo(Call other) {
            if (other == null) return 1;
            return -CallTime.CompareTo(other.CallTime);
        }

        public override bool Equals(object obj) {
            if (obj==null) {
                return false;
            }
            Call previousCall=obj as Call;
            return this == previousCall || (CallDirection == previousCall.CallDirection && ContactName == previousCall.ContactName && ContactNumber == previousCall.ContactNumber);
        }

        public override int GetHashCode() {
            return base.GetHashCode();
        }

        public void AddCallToListView(ListView listview) {
            if (listview.InvokeRequired)
                listview.Invoke(new Action<ListView>(AddCallToListView), listview);
            else
                listview.Items.Insert(0, new ListViewItem(new[] { ContactName, ContactNumber, CallDirection.ToString(), CallTime.ToString(), $"{CallDuration.Minutes.ToString()}:{CallDuration.Seconds.ToString()}" }));
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
