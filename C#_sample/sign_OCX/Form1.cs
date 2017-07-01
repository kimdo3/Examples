using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace sign_OCX
{
    public partial class Form1 : Form
    {
        SKCOMMAXLib.SKCommAX CertManager = new SKCOMMAXLib.SKCommAX();

        public Form1()
        {
            InitializeComponent();
        }

        String dn;
        private void button1_Click(object sender, EventArgs e)
        {
            String dn = CertManager.SetMatchedContextExt("", "", "", 256 + 0 + 1);
            if (dn.Equals(""))
            {
                MessageBox.Show("SetMatchedContextExt 실패" + CertManager.GetLastErrorCode() + CertManager.GetLastErrorMsg());
                return;
            }

            String plaintext = textBox1.Text;
            String signdata = CertManager.SignDataB64("", plaintext, 1);

            if (signdata.Equals(""))
            {
                MessageBox.Show("SignDataB64 실패" + CertManager.GetLastErrorCode() + CertManager.GetLastErrorMsg());
                return;
            }
            textBox2.Text = CertManager.GetToken(signdata, "data");
            textBox3.Text = CertManager.GetToken(signdata, "data");
            dn = CertManager.GetToken(signdata, "dn");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String signdata = textBox3.Text;
            String ve = CertManager.VerifyDataB64(signdata, 1);
            if (ve.Equals(""))
            {
                MessageBox.Show("VerifyDataB64 실패" + CertManager.GetLastErrorCode() + CertManager.GetLastErrorMsg());
                return;
            }
            textBox4.Text = CertManager.GetToken(ve, "data");

        }

     


  
    }
}