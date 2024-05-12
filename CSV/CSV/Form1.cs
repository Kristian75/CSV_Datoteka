using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSV
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSpremi_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIme.Text) ||
                string.IsNullOrWhiteSpace(txtPrezime.Text) ||
                string.IsNullOrWhiteSpace(txtGodinaRodjenja.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Molimo unesite sve podatke.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!IsValidEmail(txtEmail.Text))
            {
                MessageBox.Show("Molimo unesite ispravnu e-mail adresu.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string[] data = { txtIme.Text, txtPrezime.Text, txtGodinaRodjenja.Text, txtEmail.Text };
            string csvFilePath = "Korisnici.csv";
            using (StreamWriter writer = new StreamWriter(csvFilePath, true))
            {
                writer.WriteLine(string.Join(",", data));
            }

            MessageBox.Show("Podaci su uspješno spremljeni.", "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Information);

            ClearTextBoxes();
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void ClearTextBoxes()
        {
            txtIme.Clear();
            txtPrezime.Clear();
            txtGodinaRodjenja.Clear();
            txtEmail.Clear();
        }
    }
}