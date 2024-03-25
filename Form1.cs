using System.Diagnostics;
using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.Security.Policy;
using System.Net;
using static System.Windows.Forms.DataFormats;

namespace UnityGitSync
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool gitInstalled = IsGitInstalled();

            if (gitInstalled)
            {
                Console.WriteLine("Git is installed.");
                //Console.WriteLine("Git Auth: " + isGitAuthed());
                if(isGitAuthed())
                {
                    button1.Enabled = false;
                    OpenNewWindow();
                }
                else
                {
                    DialogResult result = MessageBox.Show("Git is not authorized on this system. Do you want to authorize Git?", "Git Auth", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        AuthorizeGit();
                    }
                }
            }
            else
            {
                Console.WriteLine("Git is not installed.");
                DialogResult result = MessageBox.Show("Git is not installed on this system. Do you want to download and install it?", "Git Check", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    OpenGitDownloadPage();
                }
            }
        }
        private bool IsGitInstalled()
        {
            try
            {
                // Create a process to execute the "git --version" command
                using (Process process = new Process())
                {
                    process.StartInfo.FileName = "git";
                    process.StartInfo.Arguments = "--version";
                    process.StartInfo.UseShellExecute = false;
                    process.StartInfo.RedirectStandardOutput = true;
                    process.StartInfo.RedirectStandardError = true;
                    process.StartInfo.CreateNoWindow = true;

                    // Start the process
                    process.Start();

                    // Read the output and error streams
                    string output = process.StandardOutput.ReadToEnd();
                    string error = process.StandardError.ReadToEnd();

                    // Wait for the process to exit
                    process.WaitForExit();

                    // Check if Git was found based on the output
                    return !string.IsNullOrEmpty(output) && !error.Contains("not recognized");
                }
            }
            catch (Exception)
            {
                // Handle any exceptions (e.g., process not found)
                return false;
            }
        }
        private bool isGitAuthed()
        {
            try
            {
                // Create a process to execute the "git config --get user.name" command
                using (Process process = new Process())
                {
                    process.StartInfo.FileName = "git";
                    process.StartInfo.Arguments = "config --get user.name";
                    process.StartInfo.UseShellExecute = false;
                    process.StartInfo.RedirectStandardOutput = true;
                    process.StartInfo.RedirectStandardError = true;
                    process.StartInfo.CreateNoWindow = true;

                    // Start the process
                    process.Start();

                    // Read the output and error streams
                    string userName = process.StandardOutput.ReadToEnd().Trim();
                    string error = process.StandardError.ReadToEnd();

                    // Wait for the process to exit
                    process.WaitForExit();

                    // Check if the user name is not empty
                    if (!string.IsNullOrEmpty(userName))
                    {
                        // User is signed in
                        //MessageBox.Show($"User '{userName}' is signed in.", "Git User", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return true;
                    }
                    else
                    {
                        // User is not signed in
                        MessageBox.Show("User is not signed in.", "Git User", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
            }
            catch (Exception)
            {
                // Handle any exceptions (e.g., process not found)
                return false;
            }
        }
        private void AuthorizeGit()
        {
            Console.WriteLine("Authorizing Git...");
        }
        private void OpenGitDownloadPage()
        {
            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = "cmd",
                Arguments = $"/c start https://git-scm.com/download/win",
                UseShellExecute = true
            };
            Process.Start(psi);
        }
        private void OpenNewWindow()
        {
            Form2 form2 = new Form2();
            form2.Show();
        }
    }
}
