using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimCorp.IMS.PhoneBook.Calls {
    public class Contact {
        public string name { get; set; }
        public List<string> phoneNumbers = new List<string>();
    }
}
