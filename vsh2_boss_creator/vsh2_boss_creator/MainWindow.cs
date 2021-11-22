using System.IO;
using System.Windows.Forms;

namespace vsh2_boss_creator
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, System.EventArgs e) // Model Directory button
        {
            using (FolderBrowserDialog dlg = new FolderBrowserDialog())
            {
                if (dlg.ShowDialog() == DialogResult.OK && Directory.Exists(dlg.SelectedPath))
                {
                    textBox3.Text = dlg.SelectedPath;
                    Data.sModelDir = dlg.SelectedPath;
                }
            }
        }

        private void button2_Click(object sender, System.EventArgs e) // Sound Directory button
        {
            using (FolderBrowserDialog dlg = new FolderBrowserDialog())
            {
                if (dlg.ShowDialog() == DialogResult.OK && Directory.Exists(dlg.SelectedPath))
                {
                    textBox4.Text = dlg.SelectedPath;
                    Data.sSoundDir = dlg.SelectedPath;
                }
            }
        }

        private void button3_Click(object sender, System.EventArgs e) // Skin Directory button
        {
            using (FolderBrowserDialog dlg = new FolderBrowserDialog())
            {
                if (dlg.ShowDialog() == DialogResult.OK && Directory.Exists(dlg.SelectedPath))
                {
                    textBox5.Text = dlg.SelectedPath;
                    Data.sSkinDir = dlg.SelectedPath;
                }
            }
        }

        private void button4_Click(object sender, System.EventArgs e)
        {
            using (FolderBrowserDialog dlg = new FolderBrowserDialog())
            {
                if (dlg.ShowDialog() == DialogResult.OK && Directory.Exists(dlg.SelectedPath))
                {
                    textBox5.Text = dlg.SelectedPath;
                    Data.sModel = dlg.SelectedPath;
                }
            }
        }

        private void textBox1_TextChanged(object sender, System.EventArgs e) // Change the author when a new character is added
        {
            Data.sAuthor = textBox1.Text;
        }

        private void textBox2_TextChanged(object sender, System.EventArgs e) // Change the boss name when a new character is added
        {
            Data.sBossName = textBox2.Text;
        }

        private void button5_Click(object sender, System.EventArgs e)
        {
            FileCreator.Create();
        }

        private void textBox6_TextChanged(object sender, System.EventArgs e)
        {
            Data.sModel = textBox6.Text + ".mdl";
        }

        private void button6_Click(object sender, System.EventArgs e)
        {
            comboBox1.Items.Clear();
            if (Data.IntrosListbox != null)
            {
                foreach (object obj in Data.ThemesListbox)
                {
                    comboBox1.Items.Add(obj.ToString());
                }
            }
        }

        private void button4_Click_1(object sender, System.EventArgs e)
        {
            if (Data.SoundTimings.ContainsKey(comboBox1.SelectedItem.ToString()))
            { // if its already there we dont want duplicates, so just set it
                Data.SoundTimings[comboBox1.SelectedItem.ToString()] = numericUpDown1.Value;
            }
            else
            { // otherwise add it with the value
                Data.SoundTimings.Add(comboBox1.SelectedItem.ToString(), numericUpDown1.Value);
            }
        }

        private void button7_Click(object sender, System.EventArgs e)
        {
            listBox1.Items.Clear();
            if (Directory.Exists(Data.sSoundDir)) // we'll get an error if we just try to getfiles in a directory
            {                                       // that doesnt exist
                if (Directory.GetFiles(Data.sSoundDir).Length > 0) // cant foreach something that has no files
                {
                    foreach (string file in Directory.GetFiles(Data.sSoundDir))
                    {
                        string[] fName = file.Split('\\'); // grab only filename.filetype
                        listBox1.Items.Add(fName[fName.Length - 1]);
                    }
                }
            }
        }

        private void button8_Click(object sender, System.EventArgs e)
        {
            listBox2.Items.Clear();
            if (Directory.Exists(Data.sSoundDir)) // we'll get an error if we just try to getfiles in a directory
            {                                       // that doesnt exist
                if (Directory.GetFiles(Data.sSoundDir).Length > 0) // cant foreach something that has no files
                {
                    foreach (string file in Directory.GetFiles(Data.sSoundDir))
                    {
                        string[] fName = file.Split('\\'); // grab only filename.filetype
                        listBox2.Items.Add(fName[fName.Length - 1]);
                    }
                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            Data.IntrosListbox = listBox1.SelectedItems;
        }

        private void listBox2_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            Data.ThemesListbox = listBox2.SelectedItems;
        }
    }
}
