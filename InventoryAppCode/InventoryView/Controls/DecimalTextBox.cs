using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace InventoryView.Controls
{
    class DecimalTextBox : TextBox
    {
        public DecimalTextBox()
        {
            this.Text = "0.0";
            //this.TextChanged += new EventHandler(NumericTextBox_TextChanged);
            this.KeyPress += new KeyPressEventHandler(DecimalTextBox_KeyPress);
            this.GotFocus += new EventHandler(DecimalTextBox_GotFocus);
        }

        void DecimalTextBox_GotFocus(object sender, EventArgs e)
        {
            this.SelectAll();
        }

        void DecimalTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '0' || e.KeyChar == '1' || e.KeyChar == '2' || e.KeyChar == '3' || e.KeyChar == '4' || e.KeyChar == '5' || e.KeyChar == '6' || e.KeyChar == '7' || e.KeyChar == '8' || e.KeyChar == '9' || e.KeyChar == '\b')
                e.Handled = false;
            else if (e.KeyChar == '.')
            {
                if (this.Text.Contains('.'))
                    e.Handled = true;
                else
                    e.Handled = false;
            }
            else
                e.Handled = true;
        }
    }
}
