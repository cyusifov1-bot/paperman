
using System;
using System.IO;
using System.Windows.Forms;

namespace paperman
{
    public partial class Form1 : Form
    {
        string path = "";

        public Form1()
        {
            InitializeComponent();

            pictureBox1.Click += pictureBox1_Click;
            pictureBox2.Click += pictureBox2_Click;
            pictureBox3.Click += pictureBox3_Click;
            pictureBox4.Click += pictureBox4_Click;
        }

        // ADD FILE
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            SaveFileDialog s = new SaveFileDialog();
            s.Filter = "Text files (*.txt)|*.txt";
            s.FileName = "file.txt";

            if (s.ShowDialog() == DialogResult.OK)
            {
                path = s.FileName;

                if (!File.Exists(path))
                    File.WriteAllText(path, "");

                richTextBox1.Clear();
                MessageBox.Show("Fayl yaradildi!");
            }
        }

        // READ FILE
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            OpenFileDialog o = new OpenFileDialog();
            o.Filter = "Text files (*.txt)|*.txt";

            if (o.ShowDialog() == DialogResult.OK)
            {
                path = o.FileName;
                richTextBox1.Text = File.ReadAllText(path);
            }
        }

        // REMOVE FILE
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            OpenFileDialog o = new OpenFileDialog();
            o.Filter = "Text files (*.txt)|*.txt";

            if (o.ShowDialog() == DialogResult.OK)
            {
                DialogResult result = MessageBox.Show(
                    "Fayli silmek isteyirsiniz?",
                    "Tesdiq",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    File.Delete(o.FileName);

                    if (path == o.FileName)
                    {
                        path = "";
                        richTextBox1.Clear();
                    }

                    MessageBox.Show("Fayl silindi!");
                }
            }
        }

        // WRITE FILE
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (path == "")
            {
                SaveFileDialog s = new SaveFileDialog();
                s.Filter = "Text files (*.txt)|*.txt";
                s.FileName = "file.txt";

                if (s.ShowDialog() != DialogResult.OK)
                    return;

                path = s.FileName;
            }

            File.WriteAllText(path, richTextBox1.Text);
            MessageBox.Show("Fayl yadda saxlanildi!");
        }
    }
}