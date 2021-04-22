using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RandomNumber
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtUserInput.Text = "";
            lstNumbers.Items.Clear();
            txtTotal.Text = "";
            txtNumber.Text = "";
            txtUserInput.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                Random random = new Random();
                int Random = 0;
                int number = Convert.ToInt32(txtUserInput.Text.Trim());

                SaveFileDialog saveFile = new SaveFileDialog();
                saveFile.ShowDialog();
                string filePath = saveFile.FileName;

                StreamWriter outputFile = File.CreateText(filePath);
                MessageBox.Show("File Saved :" + filePath);

                while (number > 0)
                {
                    Random = random.Next(0, 101);
                    outputFile.WriteLine(Random.ToString());
                    number--;
                }

                outputFile.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            try
            {
                int number = 0;
                int count = 0;
                int sum = 0;

                OpenFileDialog loadfile = new OpenFileDialog();
                loadfile.ShowDialog();
                string filepath = loadfile.FileName;

                StreamReader inputfile = File.OpenText(filepath);

                lstNumbers.Items.Clear();
                MessageBox.Show("file loaded :" + filepath);
                lstNumbers.Items.Add("random#");

                while (!inputfile.EndOfStream)
                {
                    number = int.Parse(inputfile.ReadLine());
                    count = count + 1;
                    sum = number + sum;
                    lstNumbers.Items.Add(number);
                }

                inputfile.Close();

                txtTotal.Text = count.ToString();
                txtNumber.Text = sum.ToString();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

