using System.ComponentModel;

namespace PasswordManager
{
    public partial class Form1 : Form
    {
        BindingList<Account> Accs = new BindingList<Account>();
        public Form1()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Account nAcc;
            if (Description.Text != "") nAcc = new Account(PlatformSelect.Text, UsernameSelect.Text, PasswordSelect.Text, EmailSelect.Text, Description.Text);
            else nAcc = new Account(PlatformSelect.Text, UsernameSelect.Text, PasswordSelect.Text, EmailSelect.Text);
            Accs.Add(nAcc);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listBox1.DisplayMember = "DisplayString";
            listBox1.ValueMember = "DisplayString";
            listBox1.DataSource = Accs;
            listBox1.BindingContext = this.BindingContext;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PlatformSelect.Text = ((Account)listBox1.SelectedItem).Platform;
            UsernameSelect.Text = ((Account)listBox1.SelectedItem).Username;
            PasswordSelect.Text = ((Account)listBox1.SelectedItem).Password;
            EmailSelect.Text = ((Account)listBox1.SelectedItem).Email;
            Description.Text = ((Account)listBox1.SelectedItem).description;
        }
    }
}