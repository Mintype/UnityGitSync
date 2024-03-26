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
        private bool gitInstalled;
        private string folderPath;
        public Form1()
        {
            InitializeComponent();

            gitInstalled = IsGitInstalled();
            if (gitInstalled)
            {
                Console.WriteLine("Git is installed.");
                //Console.WriteLine("Git Auth: " + isGitAuthed());
                if (isGitAuthed())
                {

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
        private string getFolderPath()
        {
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                folderBrowserDialog.Description = "Select your Unity Project folder.";
                folderBrowserDialog.RootFolder = Environment.SpecialFolder.MyComputer;

                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedFolder = folderBrowserDialog.SelectedPath;
                    // Now you have the path to the selected folder (selectedFolder)
                    // You can use this path to access files within the selected folder
                    return selectedFolder;
                }
            }
            return null;
        }

        private void FolderOpenerButton_Click(object sender, EventArgs e)
        {
            string folderPath = getFolderPath();
            if (folderPath != null)
            {
                ProjectName.Text = GetFolderNameFromPath(folderPath);
                this.folderPath = folderPath;
                MessageBox.Show("Selected folder: " + folderPath); // remove later, use: testing
            }
            else
            {
                ProjectName.Text = "";
                MessageBox.Show("Selected folder was null."); // notify user if folder was null
            }
        }
        public static string GetFolderNameFromPath(string path)
        {
            int lastBackSlash = path.LastIndexOf('\\');
            if (lastBackSlash == -1)
            {
                return path;
            }
            else
            {
                return path.Substring(lastBackSlash + 1);
            }
        }
    }
}
