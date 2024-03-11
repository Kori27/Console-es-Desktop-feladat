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

namespace Book
{
    public partial class Form1 : Form
        
    {
        List<Books> books_list = new List<Books>();
        public Form1()


        {

            InitializeComponent();

            
            string[] lines = File.ReadAllLines("books.txt");
            foreach (var item in lines)
            {
                string[] values = item.Split(',');
                Books books_object = new Books(values[0], values[1], values[2], values[3], values[4]);
                books_list.Add(books_object);
            }
            int osszdb = 0;
            foreach (var item in books_list)
            {

                osszdb += item.db;


            }
            label1.Text=($"Az össz darabszám: {osszdb} db");
            List<Books> legdrágábbak = new List<Books>(); 
            Books legdrágább = books_list[0];
            legdrágábbak.Add(legdrágább); 

            foreach (var termek in books_list)
            {
                if (termek.ar > legdrágább.ar)
                {
                    legdrágább = termek;
                    legdrágábbak.Clear(); 
                    legdrágábbak.Add(legdrágább);
                }
                else if (termek.ar == legdrágább.ar)
                {
                    legdrágábbak.Add(termek);
                }
            }
            foreach (var legdrágábbTermek in legdrágábbak)
            {
                dataGridView1.Rows.Add(legdrágábbTermek.kategoria, legdrágábbTermek.konyv,  legdrágábbTermek.ar);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string selectedCategory = comboBox1.SelectedItem?.ToString();
            if (!string.IsNullOrEmpty(selectedCategory))
            {
                var selectedProducts = books_list.Where(t => t.kategoria.Equals(selectedCategory)).ToList();

                listBox1.Items.Clear();

                foreach (var termek in selectedProducts)
                {
                    listBox1.Items.Add($"Cím: {termek.konyv}, Ár: {termek.ar}, Darabszám: {termek.db}");
                }
            }
        }
    }
   }
