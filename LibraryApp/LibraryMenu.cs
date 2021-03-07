using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryApp
{
    public partial class LibraryMenu : Form
    {
        public LibraryMenu()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            readBooks();// Calling the readbook method.
        }

        // Adding Book objects to the dictionary
        public void readBooks()
        {
            DictionaryWorker.bookDictionary.Add("9780140385724", new Book("The Outsiders", "S.E.Hinton", "Dell Publishing", "1967", "9780140385724"));
            DictionaryWorker.bookDictionary.Add("9780190405755", new Book("An introduction to scholarship", "Cheryl Siewierski", "Juta", "2015", "9780190405755"));
            DictionaryWorker.bookDictionary.Add("9780316909655", new Book("Long Walk to Freedom", "Nelson Mandela", "Back Bay Books", "1994", "9780316909655"));

            //Displaying the data stored in the dictionary in the listbox
            lstBooks.Items.Clear();
            foreach (KeyValuePair<string, Book> b in DictionaryWorker.bookDictionary)
            {
                lstBooks.Items.Add(b.Value.Name);
            }

        }

        // Adding data to the dictionary based on user inputs
        private void btnAdd_Click(object sender, EventArgs e)
        {

            Book newBook = new Book(txtBookname.Text, txtAuthor.Text, txtPublisher.Text, txtYear.Text, txtIsbn.Text);
            DictionaryWorker.bookDictionary.Add(txtIsbn.Text, newBook);

            //foreach (KeyValuePair<string, Book> b in DictionaryWorker.bookDictionary)
            //{
            //    lstBooks.Items.Add(b.Value.Name);
            //}
            txtBookname.Clear();
            txtAuthor.Clear();
            txtPublisher.Clear();
            txtYear.Clear();
            txtIsbn.Clear();
        }

        // This method allows you to query the dictionary for specific data
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchTerm = txtSearch.Text;
            lstBooks.Items.Clear();
            try
            {
                lstBooks.Items.Add(DictionaryWorker.bookDictionary[searchTerm].Isbn + " - " + DictionaryWorker.bookDictionary[searchTerm].Name);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        // This method updates the dictionary after data has been added and clears the textboxes
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            lstBooks.Items.Clear();
            foreach (KeyValuePair<string, Book> b in DictionaryWorker.bookDictionary)
            {
                lstBooks.Items.Add(b.Value.Name);
            }
            txtBookname.Clear();
            txtAuthor.Clear();
            txtPublisher.Clear();
            txtYear.Clear();
            txtIsbn.Clear();
        }

        // This method allows you to edit selected data from the listbox
        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstBooks.SelectedIndex == -1)
                {
                    MessageBox.Show("Please Select the Book you Wish to Edit from the List");
                }
                else
                {
                    string selectedName = lstBooks.SelectedItem.ToString();
                    Book selectedBook = new Book();

                    foreach (KeyValuePair<string, Book> b in DictionaryWorker.bookDictionary)
                    {
                        if ((b.Value.Name).Equals(selectedName))
                        {
                            txtBookname.Text = b.Value.Name;
                            txtAuthor.Text = b.Value.Author;
                            txtPublisher.Text = b.Value.Publisher;
                            txtYear.Text = b.Value.Year;
                            txtIsbn.Text = b.Value.Isbn;
                            break;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
    }
}
