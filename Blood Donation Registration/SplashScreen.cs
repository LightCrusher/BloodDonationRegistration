using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Blood_Donation_Registration
{
    public partial class SplashScreen : Form
    {
        public SplashScreen()
        {
            InitializeComponent();
        }

        public async void awaitCaller()
        {
            string result = await WaitSynchronously();
        }

        public void form_registration_opener()
        {

            this.Hide();

            Form st = new Registration();
            st.Show();

        }

        String directorysave = @"C:/Softech/Creative Club/Blood Donation/data/";
        String directorybackup = @"C:/Softech/Creative Club/Blood Donation/backup/";


        public async Task<string> WaitSynchronously()
        {
         
            try
            {

                if (!Directory.Exists(directorysave))
                {
                    Directory.CreateDirectory(directorysave);
                }
                if (!Directory.Exists(directorybackup))
                {
                    Directory.CreateDirectory(directorybackup);
                }
             
                
                Random rnd = new Random();
                int waitforxordiag = rnd.Next(1000, 3000);
                System.Threading.Thread.Sleep(waitforxordiag);
            
            }
            catch (Exception)
            {
                MessageBox.Show("Error occurred on creating directory! Contact developer.");
            }

            return "Finished";
        }


        private void SplashScreen_Shown(object sender, EventArgs e)
        {
            awaitCaller();
            form_registration_opener();
        }
    }
}
