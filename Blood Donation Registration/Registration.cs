using System;
using System.Windows.Forms;
using System.IO;
using System.Linq;

namespace Blood_Donation_Registration
{
    public partial class Registration : Form
    {

        String logforlogger; //Experimental | A class or two not open-source. Hence, code changed. 

        String directorysave = @"C:/Softech/Creative Club/Blood Donation/data/";
        String directorybackup = @"C:/Softech/Creative Club/Blood Donation/backup/";


        public Registration()
        {
            InitializeComponent();
        }

        private void Registration_Load(object sender, EventArgs e)
        {
            listbox_sex_populator();
            listbox_bloodgroup_populator();
            lastValuefiller();
            listbox_bloodgroup.SelectedIndex = 0;
            listbox_sex.SelectedIndex = 0;
        }

        public void listbox_sex_populator()
        {
            listbox_sex.Items.Add("Male");
            listbox_sex.Items.Add("Female");
        }

        private void textbox_age_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textbox_age.Text, "[^0-9]"))
            {
                textbox_age.Text = textbox_age.Text.Remove(textbox_age.Text.Length - 1);
            }
        }

        public void listbox_bloodgroup_populator()
        {
            listbox_bloodgroup.Items.Add("A+");
            listbox_bloodgroup.Items.Add("A-");
            listbox_bloodgroup.Items.Add("B+");
            listbox_bloodgroup.Items.Add("B-");
            listbox_bloodgroup.Items.Add("AB+");
            listbox_bloodgroup.Items.Add("AB-");
            listbox_bloodgroup.Items.Add("O+");
            listbox_bloodgroup.Items.Add("O-");
            listbox_bloodgroup.Items.Add("UNKNOWN");
        }

        private void textbox_contactno_1_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textbox_contactno_1.Text, "[^0-9]"))
            {
                textbox_contactno_1.Text = textbox_contactno_1.Text.Remove(textbox_contactno_1.Text.Length - 1);
            }
        }

        private void textbox_contactno_2_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textbox_contactno_2.Text, "[^0-9]"))
            {
                textbox_contactno_2.Text = textbox_contactno_2.Text.Remove(textbox_contactno_2.Text.Length - 1);
            }
        }

        private void button_exit_Click(object sender, EventArgs e)
        {
              Application.Exit();
        }

        public void datawriter()
        {
            string location = directorysave + "donorid.txt";
            try
            {
                using (StreamWriter donordatawriter = new StreamWriter(location, true))
                {
                    donordatawriter.WriteLine();
                    donordatawriter.WriteLine("<<------------------------------" + DateTime.Now + "------------------------------>>");
                    donordatawriter.WriteLine("Name = " + textbox_name.Text + " | " + "Sex = " + listbox_sex.Text + " | " + "Age = " + textbox_age.Text);
                    donordatawriter.WriteLine("Blood group = " + listbox_bloodgroup.Text + " | " + "Address = " + textbox_address.Text);
                    donordatawriter.WriteLine("Email = " + textbox_email_1.Text + " , " + "" + textbox_email_2.Text);
                    donordatawriter.WriteLine("Contact No. = " + textbox_contactno_1.Text + " , " + "" + textbox_contactno_2.Text);
                    donordatawriter.WriteLine("Notes = " + textbox_notes.Text);
                    donordatawriter.WriteLine("Inspected by = " + textbox_inspectedby_1.Text + " , " + textbox_inspectedby_2.Text);
                    donordatawriter.WriteLine("<<------------------------------" + DateTime.Now + "------------------------------>>");
                    donordatawriter.WriteLine();
                }
                }catch (Exception ex) {
                MessageBox.Show("Error occurred on creating directory! Contact developer." + ex);
                logforlogger = "!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!";
                logforlogger = "Error occured on - '" + System.Reflection.MethodBase.GetCurrentMethod() + "'.";
                logforlogger = "Getting high level code....";
                logforlogger = "'" + ex.Message + "'";
                logforlogger = "Returning to previous state...";
                logforlogger = "!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!";
            }
        }

        private string getNextFileName(string fileName)
        {
            string extension = Path.GetExtension(fileName);

            int i = 0;
            while (File.Exists(fileName))
            {
                if (i == 0)
                    fileName = fileName.Replace(extension, "(" + ++i + ")" + extension);
                else
                    fileName = fileName.Replace("(" + i + ")" + extension, "(" + ++i + ")" + extension);
            }

            return fileName;
        }

        private void button_save_Click(object sender, EventArgs e)
        {

            if(String.IsNullOrEmpty(textbox_name.Text) || String.IsNullOrWhiteSpace(textbox_name.Text))
            {
                MessageBox.Show("Name cannot be empty!");
            }
            else if (textbox_name.Text != null)
            {
                String backupSavePath = directorybackup + textbox_name.Text + ".txt";
                datawriter();
                nameChecker(backupSavePath);
            }

        }

        public void nameChecker(String backupSavePath)
        {
          
            if (File.Exists(backupSavePath)){
                nameIncrement(backupSavePath);
            }
            else {
                backupdatawriter(backupSavePath);
            }

            valueReset();
        }

        public void nameIncrement(String location)
        {

            string extension = Path.GetExtension(location);

            int i = 0;
            while (File.Exists(location))
            {
                if (i == 0)
                    location = location.Replace(extension, "(" + ++i + ")" + extension);
                else
                    location = location.Replace("(" + i + ")" + extension, "(" + ++i + ")" + extension);
            }

            nameChecker(location);
        }

        public void backupdatawriter(String location)
        {
          
            try
            {
                using (StreamWriter donordatawriter = new StreamWriter(location, true))
                {
                    donordatawriter.WriteLine();
                    donordatawriter.WriteLine("<<------------------------------" + DateTime.Now + "------------------------------>>");

                    donordatawriter.WriteLine("Name = " + textbox_name.Text + " | " + "Sex = " + listbox_sex.Text + " | " + "Age = " + textbox_age.Text);
                    donordatawriter.WriteLine("Blood group = " + listbox_bloodgroup.Text + " | " + "Address = " + textbox_address.Text);

                    donordatawriter.WriteLine("Email = " + textbox_email_1.Text + " , " + "" + textbox_email_2.Text);
                    donordatawriter.WriteLine("Contact No. = " + textbox_contactno_1.Text + " , " + "" + textbox_contactno_2.Text);

                    donordatawriter.WriteLine("Notes = " + textbox_notes.Text);

                    donordatawriter.WriteLine("Inspected by = " + textbox_inspectedby_1.Text + " , " + textbox_inspectedby_2.Text);
                    donordatawriter.WriteLine("<<------------------------------" + DateTime.Now + "------------------------------>>");
                    donordatawriter.WriteLine();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred on creating directory! Contact developer.");
                logforlogger = "!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!";
                logforlogger = "Error occured on - '" + System.Reflection.MethodBase.GetCurrentMethod() + "'.";
                logforlogger = "Getting high level code....";
                logforlogger = "'" + ex.Message + "'";
                logforlogger = "Returning to previous state...";
                logforlogger = "!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!";
            }
        }

        public void lastValuefiller()
        {
            try
            {
                if (Directory.GetFileSystemEntries(directorybackup).Length != 0)
                {
                    var directorySaveQuery = new DirectoryInfo(directorybackup);

                    var lastFile = directorySaveQuery.GetFiles().OrderByDescending(f => f.LastWriteTime).First();

                    textbox_lastsavedname.Text = Convert.ToString(lastFile);
                }
                       
            } catch (Exception ex)
            {
                MessageBox.Show("Error occured on getting last saved file: " + ex);
                logforlogger = "!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!";
                logforlogger = "Error occured on - '" + System.Reflection.MethodBase.GetCurrentMethod() + "'.";
                logforlogger = "Getting high level code....";
                logforlogger = "'" + ex.Message + "'";
                logforlogger = "Returning to previous state...";
                logforlogger = "!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!";
            }
        }

        public void valueReset()
        {
            textbox_name.Text = "";
            textbox_age.Text = "";
            textbox_address.Text = "";
            textbox_email_1.Text = "";
            textbox_email_2.Text = "";
            textbox_contactno_1.Text = "";
            textbox_contactno_2.Text = "";
            textbox_notes.Text = "";
            lastValuefiller();
        }

        public void openFile()
        {
            try
            {
                string dataLocation = directorysave + "donorid.txt";
                if (File.Exists(dataLocation))
                {
                    System.Diagnostics.Process.Start(dataLocation);
                }
                else if (!File.Exists(dataLocation))
                {
                    MessageBox.Show("Data file doesn't exists.");
                }
            } catch (Exception ex) {
                MessageBox.Show("Error occurred on opening data file! Contact developer." + ex);
                logforlogger = "Error on opening data file. Getting high level code.";
                logforlogger = ex.Message;
                logforlogger = "Returning to previous state...";
            }
        }

        private void button_openfile_Click(object sender, EventArgs e)
        {
            openFile(); 
        
        }

        private void Registration_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                logforlogger = "Close request has been transmitted.";
                logforlogger = "Requirement for closing evasion not found on the application.";
                logforlogger = "The application will now close.";
            }
            catch (IOException)
            {
                Application.Exit();
            }
         }

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Left += e.X;
                Top += e.Y;
            }
        }
    }
}
