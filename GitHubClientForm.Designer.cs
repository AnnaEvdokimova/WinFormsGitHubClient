namespace GitHubClientWinForm
{
    partial class GitHubClientForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.tbUserLogin = new System.Windows.Forms.TextBox();
            this.cbRepositoryList = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnGetUserData = new System.Windows.Forms.Button();
            this.tvRepositoryContent = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Пользователь";
            // 
            // tbUserLogin
            // 
            this.tbUserLogin.Location = new System.Drawing.Point(94, 10);
            this.tbUserLogin.Name = "tbUserLogin";
            this.tbUserLogin.Size = new System.Drawing.Size(100, 20);
            this.tbUserLogin.TabIndex = 1;
            // 
            // cbRepositoryList
            // 
            this.cbRepositoryList.FormattingEnabled = true;
            this.cbRepositoryList.Location = new System.Drawing.Point(94, 82);
            this.cbRepositoryList.Name = "cbRepositoryList";
            this.cbRepositoryList.Size = new System.Drawing.Size(121, 21);
            this.cbRepositoryList.TabIndex = 2;
            this.cbRepositoryList.SelectionChangeCommitted += new System.EventHandler(this.cbRepositoryList_SelectionChangeCommitted);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Репозитории";
            // 
            // btnGetUserData
            // 
            this.btnGetUserData.Location = new System.Drawing.Point(15, 45);
            this.btnGetUserData.Name = "btnGetUserData";
            this.btnGetUserData.Size = new System.Drawing.Size(138, 23);
            this.btnGetUserData.TabIndex = 4;
            this.btnGetUserData.Text = "Получить данные";
            this.btnGetUserData.UseVisualStyleBackColor = true;
            this.btnGetUserData.Click += new System.EventHandler(this.btnGetUserData_Click);
            // 
            // tvRepositoryContent
            // 
            this.tvRepositoryContent.BackColor = System.Drawing.SystemColors.Control;
            this.tvRepositoryContent.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tvRepositoryContent.FullRowSelect = true;
            this.tvRepositoryContent.Location = new System.Drawing.Point(16, 139);
            this.tvRepositoryContent.Name = "tvRepositoryContent";
            this.tvRepositoryContent.Size = new System.Drawing.Size(248, 171);
            this.tvRepositoryContent.TabIndex = 5;
            this.tvRepositoryContent.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvRepositoryContent_AfterSelect);
            // 
            // GitHubClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 381);
            this.Controls.Add(this.tvRepositoryContent);
            this.Controls.Add(this.btnGetUserData);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbRepositoryList);
            this.Controls.Add(this.tbUserLogin);
            this.Controls.Add(this.label1);
            this.Name = "GitHubClientForm";
            this.Text = "GitHubClientForm";
            this.Load += new System.EventHandler(this.GitHubClientForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbUserLogin;
        private System.Windows.Forms.ComboBox cbRepositoryList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnGetUserData;
        private System.Windows.Forms.TreeView tvRepositoryContent;
    }
}

