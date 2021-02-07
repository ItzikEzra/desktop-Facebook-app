
namespace Desktop_Facebook
{
    partial class Proxy
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
            this.DarkModecheckBox = new System.Windows.Forms.CheckBox();
            this.SmallerButton = new System.Windows.Forms.Button();
            this.BiggerButton = new System.Windows.Forms.Button();
            this.bestPublishBtn.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.profileLoginPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bestTimePictureBox)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.inactivePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.BindingPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.albumBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageAlbumPictureBox)).BeginInit();
            this.SuspendLayout();
            this.BindingPanel.Controls.SetChildIndex(this.pictureAlbumURLLinkLabel, 0);
            this.BindingPanel.Controls.SetChildIndex(this.nameTextBox, 0);
            this.BindingPanel.Controls.SetChildIndex(this.linkLinkLabel, 0);
            this.BindingPanel.Controls.SetChildIndex(this.imageAlbumPictureBox, 0);
            this.BindingPanel.Controls.SetChildIndex(this.createdTimeDateTimePicker, 0);
            // 
            // DarkModecheckBox
            // 
            this.DarkModecheckBox.AutoSize = true;
            this.DarkModecheckBox.Location = new System.Drawing.Point(6, 471);
            this.DarkModecheckBox.Name = "DarkModecheckBox";
            this.DarkModecheckBox.Size = new System.Drawing.Size(95, 21);
            this.DarkModecheckBox.TabIndex = 1;
            this.DarkModecheckBox.Text = "DarkMode";
            this.DarkModecheckBox.UseVisualStyleBackColor = true;
            this.DarkModecheckBox.CheckedChanged += new System.EventHandler(this.darkModecheckBox_CheckedChanged);
            // 
            // SmallerButton
            // 
            this.SmallerButton.Location = new System.Drawing.Point(142, 471);
            this.SmallerButton.Name = "SmallerButton";
            this.SmallerButton.Size = new System.Drawing.Size(75, 23);
            this.SmallerButton.TabIndex = 3;
            this.SmallerButton.Text = "T--";
            this.SmallerButton.UseVisualStyleBackColor = true;
            this.SmallerButton.Click += new System.EventHandler(this.SmallerButton_Click);
            // 
            // BiggerButton
            // 
            this.BiggerButton.Location = new System.Drawing.Point(233, 471);
            this.BiggerButton.Name = "BiggerButton";
            this.BiggerButton.Size = new System.Drawing.Size(75, 23);
            this.BiggerButton.TabIndex = 4;
            this.BiggerButton.Text = "T++";
            this.BiggerButton.UseVisualStyleBackColor = true;
            this.BiggerButton.Click += new System.EventHandler(this.BiggerButton_Click);
            // 
            // Proxy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1127, 504);
            this.Controls.Add(this.BiggerButton);
            this.Controls.Add(this.SmallerButton);
            this.Controls.Add(this.DarkModecheckBox);
            this.Name = "Proxy";
            this.Text = "Form1";
            this.Controls.SetChildIndex(this.bestPublishBtn, 0);
            this.Controls.SetChildIndex(this.DarkModecheckBox, 0);
            this.Controls.SetChildIndex(this.SmallerButton, 0);
            this.Controls.SetChildIndex(this.BiggerButton, 0);
            this.bestPublishBtn.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.profileLoginPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bestTimePictureBox)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.inactivePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.BindingPanel.ResumeLayout(false);
            this.BindingPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.albumBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageAlbumPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox DarkModecheckBox;
        private System.Windows.Forms.Button SmallerButton;
        private System.Windows.Forms.Button BiggerButton;
    }
}