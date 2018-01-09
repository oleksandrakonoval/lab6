﻿using SimCorp.IMS.Messages;
using System;
using System.Threading;
using System.Windows.Forms;

namespace SimCorp.IMS.MobilePhoneLibrary.Provider {
    public abstract class SMSProvider {

        public delegate void SMSRecievedDelegate(MyMessage message);

        public event SMSRecievedDelegate SMSReceived;

        public void RaiseSMSReceivedEvent(MyMessage message) {
            SMSReceived?.Invoke(message);
        }

        public void ReceiveSMS(MyMessage message) {
            RaiseSMSReceivedEvent(message);
        }

        public void addUserToComboBox(ComboBox comboBox, MyMessage message) {
            if (comboBox.InvokeRequired) {
                comboBox.Invoke(new Action<ComboBox, MyMessage>(addUserCombo), comboBox, message);
            }
            else addUserCombo(comboBox, message);
        }

        public void addUserCombo(ComboBox comboBox, MyMessage message) {
            if (!comboBox.Items.Contains(message.User)) {
                comboBox.Items.Add(message.User);
            }
        }

        public object selectUser(ComboBox comboBox) {
            if (comboBox.InvokeRequired) {
                return (object)comboBox.Invoke(new Func<ComboBox, object> (selectUser), comboBox);
            }
            return comboBox.SelectedItem;
        }

        public abstract void generateMessages(CheckBox checkbox);

        public void createMessage(CheckBox checkbox) {
            while (checkbox.Checked) {
                MyMessage message = new MyMessage();
                if (message.Text != null) {
                    ReceiveSMS(message);
                    Thread.Sleep(1500);
                }
            }
        }
    }
}
