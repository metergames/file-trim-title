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

namespace File_Trim_Title
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                foreach (string filePathins in files)
                {
                    if (label2.Text == "File Names: ")
                        label2.Text += Path.GetFileName(filePathins);
                    else
                        label2.Text += ", " + Path.GetFileName(filePathins);
                    File.Move(filePathins, Path.GetDirectoryName(filePathins) + "\\" + Path.GetFileName(filePathins).Replace(textBox1.Text, textBox2.Text));
                }
            }
        }
    }
}
