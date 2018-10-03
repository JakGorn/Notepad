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

namespace Notepad
{
    public partial class Form1 : Form
    {
        string a;

        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            a = string.Empty;
            textBox1.Clear();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "Text Documents|*.txt", ValidateNames = true, Multiselect = false })
            {
                if(ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (StreamReader sr = new StreamReader(ofd.FileName))
                        {
                            a = ofd.FileName;
                            Task<string> text = sr.ReadToEndAsync();
                            textBox1.Text = text.Result;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private async void saveToolStripMenuItem_ClickAsync(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(a))
            {
                using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Text Documents|*.txt", ValidateNames = true })
                {
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {

                        try
                        {
                            a = sfd.FileName;
                            using (StreamWriter sw = new StreamWriter(sfd.FileName))
                            {
                                await sw.WriteLineAsync(textBox1.Text);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                try
                {
                    using (StreamWriter sw = new StreamWriter(a))
                    {
                        await sw.WriteLineAsync(textBox1.Text);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
        }

        private async void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Text Documents|*.txt", ValidateNames = true })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (StreamWriter sw = new StreamWriter(sfd.FileName))
                        {
                            await sw.WriteLineAsync(textBox1.Text);


                        }
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string message = "Notepad made by Jakub Górniak from class 3B";
            string caption = "Info";
            MessageBoxButtons buttons = MessageBoxButtons.OK;

            MessageBox.Show(message, caption, buttons);
        }

        private void authorToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
