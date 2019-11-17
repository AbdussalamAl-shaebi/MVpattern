using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LibraryMVpattern.View
{
    public partial class BooksForm : Form
    {
        Models.BookModel BookModel = new Models.BookModel();

        public BooksForm()
        {
            InitializeComponent();
        }

        private void buttonInsert_Click(object sender, EventArgs e)
        {
            try
            {
                BookModel.Id = int.Parse(textBoxBookId.Text);
                BookModel.Name = textBoxBookName.Text;
               if(BookModel.Insert())
                {
                    MessageBox.Show(":)");
                }

            }catch(Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                BookModel.Id = int.Parse(textBoxBookId.Text);
                BookModel.Name = textBoxBookName.Text;
                if (BookModel.Updaet())
                {
                    MessageBox.Show(":)");
                }

            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                BookModel.Id = int.Parse(textBoxBookId.Text);
                BookModel.Name = textBoxBookName.Text;
                if (BookModel.Delete())
                {
                    MessageBox.Show(":)");
                }

            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        private void buttonSelect_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridViewBooks.DataSource = BookModel.Select().OfType<Models.BookModel>().ToList();
                dataGridViewBooks.Columns[0].Visible = false;
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }
    }
}
