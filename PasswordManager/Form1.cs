using System.ComponentModel;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace PasswordManager
{
    public partial class Form1 : Form
    {
        SaveF SaveFile = new SaveF();
        BindingList<Account> Accs = new BindingList<Account>();
        BindingList<string> PlatformsList = new BindingList<string>();
        bool wipe = false;
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
            LoadSaveFile();

            Accs = SaveFile.accList;
            PlatformsList = SaveFile.PlatList;

            listBox1.DisplayMember = "DisplayString";
            listBox1.ValueMember = "DisplayString";
            listBox1.DataSource = Accs;
            listBox1.BindingContext = this.BindingContext;
            PlatformSelect.DataSource = PlatformsList;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            PlatformSelect.Text = ((Account)listBox1.SelectedItem).Platform;
            UsernameSelect.Text = ((Account)listBox1.SelectedItem).Username;
            PasswordSelect.Text = ((Account)listBox1.SelectedItem).Password;
            EmailSelect.Text = ((Account)listBox1.SelectedItem).Email;
            Description.Text = ((Account)listBox1.SelectedItem).description;
        }

        void LoadSaveFile()
        {
            if (File.Exists("Myaccounts.saveFile"))
            {
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream("MyAccounts.saveFile", FileMode.Open, FileAccess.Read, FileShare.Read);
                SaveFile = (SaveF)formatter.Deserialize(stream);
                stream.Close();
            }
        }
        void SaveSaveFile(bool dontSave)
        {
            if (!dontSave)
            {
                SaveFile.accList = Accs;
                SaveFile.PlatList = PlatformsList;
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream("MyAccounts.saveFile", FileMode.Create, FileAccess.Write, FileShare.None);
                formatter.Serialize(stream, SaveFile);
                stream.Close();
            }
            else
            {
                SaveFile.accList = null;
                SaveFile.PlatList = PlatformsList;
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream("MyAccounts.saveFile", FileMode.Create, FileAccess.Write, FileShare.None);
                formatter.Serialize(stream, SaveFile);
                stream.Close();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveSaveFile(wipe);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PlatformsList.Add(textBox1.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            wipe = true;
            File.Delete("MyAccounts.saveFile");
            Application.Exit();
        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            button2.PerformClick();
        }
    }
}