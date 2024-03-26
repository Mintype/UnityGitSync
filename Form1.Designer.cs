namespace UnityGitSync
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            FolderOpenerButton = new Button();
            label1 = new Label();
            ProjectName = new TextBox();
            SuspendLayout();
            // 
            // FolderOpenerButton
            // 
            FolderOpenerButton.Location = new Point(244, 92);
            FolderOpenerButton.Name = "FolderOpenerButton";
            FolderOpenerButton.Size = new Size(105, 30);
            FolderOpenerButton.TabIndex = 0;
            FolderOpenerButton.Text = "Open Project";
            FolderOpenerButton.UseVisualStyleBackColor = true;
            FolderOpenerButton.Click += FolderOpenerButton_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("UD Digi Kyokasho NK-B", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 128);
            label1.Location = new Point(113, 43);
            label1.Name = "label1";
            label1.Size = new Size(169, 26);
            label1.TabIndex = 1;
            label1.Text = "UnityGitSync";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // ProjectName
            // 
            ProjectName.Location = new Point(23, 93);
            ProjectName.Name = "ProjectName";
            ProjectName.ReadOnly = true;
            ProjectName.Size = new Size(125, 27);
            ProjectName.TabIndex = 2;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(382, 503);
            Controls.Add(ProjectName);
            Controls.Add(label1);
            Controls.Add(FolderOpenerButton);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "UnityGitSync";
            TopMost = true;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button FolderOpenerButton;
        private Label label1;
        private TextBox ProjectName;
    }
}
