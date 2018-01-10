using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SimCorp.IMS.PhoneBook.Calls {
    public class CallGroup: IComparable {
        public string Name { get; set; }
        public string Number { get; set; }
        public Direction CallDirection { get; set; }
        public DateTime lastCallTime { get; set; }
        public SortedSet<Call> Calls = new SortedSet<Call>();
        public TimeSpan lastCallDuration { get; set; }

        public CallGroup(Call call) {
            Name = call.ContactName;
            Number = call.ContactNumber;
            CallDirection = call.CallDirection;
            lastCallTime = call.CallTime;
            lastCallDuration = call.CallDuration;
            Calls.Add(call);
        }

        public void addCallToGroup(Call call) {
            Calls.Add(call);
        }

        public int CompareTo(object obj) {
            CallGroup other = obj as CallGroup;
            if (other == null) return 1;
            return -lastCallTime.CompareTo(other.lastCallTime);
        }

        public void AddCallToListView(ListView listview) {
            if (listview.InvokeRequired)
                listview.Invoke(new Action<ListView>(AddCallToListView), listview);
            else {
                if (Calls.Count > 1) {
                    listview.Items.RemoveAt(0);
                }
                listview.Items.Insert(0, new ListViewItem(new[] { Name, Number, CallDirection.ToString(), lastCallTime.ToString(), $"{lastCallDuration.Minutes.ToString()}:{lastCallDuration.Seconds.ToString()}", Calls.Count.ToString() }));
            }
                
        }
    }
}
