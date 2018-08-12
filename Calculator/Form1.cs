using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Calculator
{
    using System.Text.RegularExpressions;
    using DevExpress.XtraEditors;

    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        Regex pmmdString = new Regex("^[+\\-*/]$");

        private Boolean clearResult;
        public Form1()
        {
            this.InitializeComponent();
        }

        private void ButtonClick(object sender, EventArgs e)
        {
            if (this.CalcResult.Text.Equals("0"))
            {
                this.clearResult = true;
            }
            var button = (SimpleButton)sender;
            if (this.clearResult)
            {
                this.CalcResult.Text = string.Empty;
                this.clearResult = false;
            }
            
            if (this.pmmdString.IsMatch(button.Text))
            {
                this.clearResult = true;
                this.ButtonHistory.Text += this.CalcResult.Text;
                this.ButtonHistory.Text += button.Text;
            }
            else
            {
                this.CalcResult.Text += button.Text;
            }
        }

        private void ButtonEqual_Click(object sender, EventArgs e)
        {
            this.ButtonHistory.Text += this.CalcResult.Text;
            double result = Convert.ToDouble(new DataTable().Compute(this.ButtonHistory.Text, null));
            this.CalcResult.Text = result.ToString();
            this.ButtonHistory.Text = string.Empty;
        }

        private void ButtonCE_Click(object sender, EventArgs e)
        {
            this.CalcResult.Text = "0";
        }

        private void ButtonC_Click(object sender, EventArgs e)
        {
            this.ButtonCE_Click(sender, e);
            this.ButtonHistory.Text = string.Empty;
        }
    }
}
