using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace lab6_EqualityAndComparison {
    public class CallGroup: IComparable {
        public string Name { get; set; }
        public string Number { get; set; }
        public Direction CallDirection { get; set; }
        public DateTime lastCalllTime { get; set; }
        public SortedSet<Call> Calls = new SortedSet<Call>();

        public CallGroup(string name, string number, Direction direction, DateTime lastcalltime, Call call) {
            Name = name;
            Number = number;
            CallDirection = direction;
            lastCalllTime = lastcalltime;
            Calls.Add(call);
        }

        public void addCallToGroup(Call call) {
            Calls.Add(call);
        }

        public int CompareTo(object obj) {
            CallGroup other = obj as CallGroup;
            if (other == null) return 1;
            return -lastCalllTime.CompareTo(other.lastCalllTime);
        }

        public void AddCallToListView(ListView listview) {
            if (listview.InvokeRequired)
                listview.Invoke(new Action<ListView>(AddCallToListView), listview);
            else {
                if (Calls.Count > 1) {
                    listview.Items.RemoveAt(0);
                }
                listview.Items.Insert(0, new ListViewItem(new[] { Name, Number, CallDirection.ToString(), lastCalllTime.ToString(), "", Calls.Count.ToString() }));
            }
                
        }
    }
}
