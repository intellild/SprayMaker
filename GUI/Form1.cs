using ExplodingJelly.SprayGenerator;
using System;
using System.Windows.Forms;

namespace GUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "")
            {
                MessageBox.Show("图片1不能为空");
                return;
            }

            if (textBox2.Text == "")
            {
                MessageBox.Show("保存文件不能为空");
                return;
            }

            if (textBox3.Text == "")
            {
                var generator = new VTFGenerator(textBox1.Text, textBox2.Text);
                generator.ProcessProgress += process_process;
                generator.ProcessingComplete += process_comlete;
                generator.Process(checkBox1.Checked);
            }
            else
            {
                var generator = new VTFGenerator(textBox1.Text, textBox3.Text, textBox2.Text);
                generator.ProcessProgress += process_process;
                generator.ProcessingComplete += process_comlete;
                generator.Process(checkBox1.Checked);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "图片|*.jpg;*.png;*.gif|所有文件|*.*";
            openFileDialog.RestoreDirectory = true;
            openFileDialog.FilterIndex = 1;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFileDialog.FileName;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "vtf|*.vtf";
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.FilterIndex = 1;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = saveFileDialog.FileName;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "图片|*.jpg;*.png;*.gif|所有文件|*.*";
            openFileDialog.RestoreDirectory = true;
            openFileDialog.FilterIndex = 1;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                textBox3.Text = openFileDialog.FileName;
            }
        }

        private void process_comlete(object sender, ProcessCompleteEventArgs args)
        {
            label4.Text = "Complete";
        }

        private void process_process(object sender, ProcessProgressEventArgs args)
        {
            label4.Text = string.Format("{0:P}", args.PercentComplete);
        }
    }
}
