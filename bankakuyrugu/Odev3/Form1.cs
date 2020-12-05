using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Odev3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Liste liste = new Liste();
        private void listBoxTemizle()
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            liste.maxsize = Convert.ToInt32(numericUpDownSize.Value);
            listBoxTemizle();
            if (radioButton1.Checked==true)
            {
                liste.add_sira(textBox1.Text, 1, Convert.ToInt32(numericUpDownISURESI.Value));
            }
            else if (radioButton2.Checked==true)
            {
                liste.add_sira(textBox1.Text, 2, Convert.ToInt32(numericUpDownISURESI.Value));
            }
            else if (radioButton3.Checked == true)
            {
                liste.add_sira(textBox1.Text, 3, Convert.ToInt32(numericUpDownISURESI.Value));
            }
            else
            {
                MessageBox.Show("Seçim Yapınız");
            }
            liste.listBoxaEkle(listBox1,listBox2,listBox3);
            sizeLabel.Text = liste.size().ToString();
            
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            listBoxTemizle();
            liste.kisial();
            textBox2.Text = liste.son_alinan_kisi;
            liste.listBoxaEkle(listBox1,listBox2,listBox3);
            sizeLabel.Text = liste.size().ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("RadioButtondaki sayılar banka işlemlerini referans etmektedir.");
        }
    }
}
