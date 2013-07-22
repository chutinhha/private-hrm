using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Text.RegularExpressions;

namespace System.Windows.Forms.ExControls
{
    [ToolboxItem(typeof(System.Windows.Forms.TextBox))]
    public partial class NumericTextbox : System.Windows.Forms.TextBox
    {
        private int _decimalPlace;

        public int DecimalPlaces
        {
            get { return _decimalPlace; }
            set
            {
                if (_decimalPlace != value)
                {
                    _decimalPlace = value;
                }
            }
        }

        private decimal? _value;
        public decimal? Value
        {
            get
            {
                decimal value;

                if (decimal.TryParse(this.Text, out value))
                {
                    _value = value;
                }
                else
                {
                    _value = (decimal?)null;
                }

                return _value;
            }

            set
            {
                if (_value != value)
                {
                    _value = value;

                    this.Text = string.Format(string.Format("{{0:N{0}}}", _decimalPlace), _value);
                }
            }
        }

        public int? IntValue
        {
            get
            {
                decimal? val = Value;

                int? retVal = null;

                if (!val.HasValue)
                {
                    return retVal;
                }

                int valParse = 0;
                if (int.TryParse(val.Value.ToString(), out valParse))
                {
                    retVal = valParse;
                }

                return retVal;
            }
        }

        public NumericTextbox()
        {
            InitializeComponent();

            this.GotFocus += new EventHandler(NumericTextbox_GotFocus);
            this.LostFocus += new EventHandler(NumericTextbox_LostFocus);
            this.KeyDown += new KeyEventHandler(NumericTextbox_KeyDown);
        }

        void NumericTextbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab ||
                e.KeyCode == Keys.Left || e.KeyCode == Keys.Right ||
                e.KeyCode == Keys.Home || e.KeyCode == Keys.End)
            {
                return;
            }

            if ((48 <= e.KeyValue && e.KeyValue <= 57) || e.KeyValue == (int)'.')
            {
                e.SuppressKeyPress = false;
            }
            else
            {
                e.SuppressKeyPress = true;
            }
        }

        void NumericTextbox_LostFocus(object sender, EventArgs e)
        {
            this.Text = string.Format(string.Format("{{0:N{0}}}", _decimalPlace), Value);
        }

        void NumericTextbox_GotFocus(object sender, EventArgs e)
        {
            this.Text = string.Format("{0}", Value);

            this.SelectionStart = 0;
            this.SelectionLength = this.Text.Length;
        }
    }
}
