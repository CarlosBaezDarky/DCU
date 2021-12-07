using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace WindowsFormsApp
{
    public partial class FormSplash : FormMasterSinControlBox
    {
        public FormSplash()
        {
            InitializeComponent();
        }

        private void FormSplash_Load(object sender, EventArgs e)
        {
            Thread threadSplashCharge = new Thread(loadThreadProcess);
            threadSplashCharge.Start();        
        }

        public void loadThreadProcess() {

            Thread.Sleep(3000);

            this.Invoke((MethodInvoker)delegate { this.Close(); });
        
        }
    }
}
