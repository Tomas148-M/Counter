using System;
using System.Windows.Forms;

namespace Counter_train_Potucek
{
    
    public partial class Setting : Form
    {
        public int interval_get=0;
        public int size_get=0;

        Form1 iMainForm;
        public Setting(Form1 aForm)
        {
            InitializeComponent();
            speed_count.Text = Convert.ToString(aForm.interval);
            //size_font.Text = Convert.ToString(aForm);
            iMainForm = aForm;
            //size_font.Text = Convert.ToString(form.la);

        }


        private void button1_Click(object sender, EventArgs e)
        {
            iMainForm.interval = Convert.ToInt16(speed_count.Text);
            iMainForm.zmena();
            this.Close();
        }
    }
}
