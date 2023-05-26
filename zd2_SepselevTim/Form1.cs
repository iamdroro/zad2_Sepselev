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

namespace zad2_SepselevTim
{
    public partial class Form1 :Form
    {
        Contact ct = new Contact( );
        PhoneBook phonebook;

        public Form1 ()
        {
            InitializeComponent( );
            phonebook = new PhoneBook(listBox1);
        }

        private void button1_Click (object sender, EventArgs e)
        {
            ct.name = textBox1.Text;
            ct.phone = textBox2.Text;
            if ( ct.sc == true )
            {
                phonebook.AddContact(ct.name, ct.phone);
                listBox1.Items.Clear( );
                phonebook.GetAllContacts( );
                MessageBox.Show("Контакт добавлен");
            }

        }

        private void button2_Click (object sender, EventArgs e)
        {
            if ( textBox3.Text != "" )
            {
                phonebook.SearchContact(textBox3.Text);
                phonebook.GetAllContacts( );
            }
            else MessageBox.Show("Найдена пустая строка!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void button3_Click (object sender, EventArgs e)
        {
            if ( textBox4.Text != "" )
            {
                listBox1.Items.Clear( );
                phonebook.RemoveContact(textBox4.Text);
                listBox1.Items.Clear( );
                phonebook.GetAllContacts( );
            }
            else MessageBox.Show("Найдена пустая строка!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void textBox5_TextChanged (object sender, EventArgs e)
        {

        }

        private void button4_Click (object sender, EventArgs e)
        {
            if ( openFileDialog1.ShowDialog( ) == DialogResult.OK )
            {
                string fileName = openFileDialog1.FileName;
                PhoneBookLoader.Load(phonebook, fileName);
                listBox1.Items.Clear( );
                phonebook.GetAllContacts( );
                
                button5.Visible = true;
                MessageBox.Show("Выбран файл: " + fileName);
            }
            else
            {
                MessageBox.Show("Файл не выбран");
            }
        }

        private void textBox4_TextChanged (object sender, EventArgs e)
        {

        }

        private void button5_Click (object sender, EventArgs e)
        {  
                using ( StreamWriter writer = new StreamWriter("r2.txt") )
                {
                    foreach ( var item in listBox1.Items )
                    {
                        writer.WriteLine(item.ToString( ));
                    }
                }
                MessageBox.Show("Содержимое ListBox сохранено в файл r2.txt");
            
        }
    }
}
