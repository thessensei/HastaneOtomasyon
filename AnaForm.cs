using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HastaneOtomasyon
{
    public partial class AnaForm: Form
    {
        public AnaForm()
        {
            InitializeComponent();
        }
        internal static Hastane hastane = new Hastane();
        private void button1_Click(object sender, EventArgs e)
        {
            Randevuİslemleri randevuİslemleri = new Randevuİslemleri();
            randevuİslemleri.Show();
            this.Hide();
        }
    }
}
