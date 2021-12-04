
namespace RaceAdmin
{
	partial class About
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(About));
			this.aboutPictureBox = new System.Windows.Forms.PictureBox();
			this.raceAdminAboutLabel = new System.Windows.Forms.Label();
			this.versionLabel = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.aboutPictureBox)).BeginInit();
			this.SuspendLayout();
			// 
			// aboutPictureBox
			// 
			this.aboutPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.aboutPictureBox.BackgroundImage = global::RaceAdmin.Properties.Resources._2021_vApex_Flag_Logo4_RG_Black;
			this.aboutPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.aboutPictureBox.Location = new System.Drawing.Point(12, 1);
			this.aboutPictureBox.Name = "aboutPictureBox";
			this.aboutPictureBox.Size = new System.Drawing.Size(216, 87);
			this.aboutPictureBox.TabIndex = 0;
			this.aboutPictureBox.TabStop = false;
			// 
			// raceAdminAboutLabel
			// 
			this.raceAdminAboutLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.raceAdminAboutLabel.AutoSize = true;
			this.raceAdminAboutLabel.Font = new System.Drawing.Font("Arial Black", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.raceAdminAboutLabel.Location = new System.Drawing.Point(3, 92);
			this.raceAdminAboutLabel.Margin = new System.Windows.Forms.Padding(1);
			this.raceAdminAboutLabel.Name = "raceAdminAboutLabel";
			this.raceAdminAboutLabel.Size = new System.Drawing.Size(234, 30);
			this.raceAdminAboutLabel.TabIndex = 1;
			this.raceAdminAboutLabel.Text = "Race Administrator";
			this.raceAdminAboutLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// versionLabel
			// 
			this.versionLabel.AutoSize = true;
			this.versionLabel.Location = new System.Drawing.Point(96, 195);
			this.versionLabel.Name = "versionLabel";
			this.versionLabel.Size = new System.Drawing.Size(42, 13);
			this.versionLabel.TabIndex = 2;
			this.versionLabel.Text = "Version";
			this.versionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// About
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(240, 217);
			this.Controls.Add(this.versionLabel);
			this.Controls.Add(this.raceAdminAboutLabel);
			this.Controls.Add(this.aboutPictureBox);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(256, 256);
			this.Name = "About";
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.Text = "About";
			((System.ComponentModel.ISupportInitialize)(this.aboutPictureBox)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox aboutPictureBox;
		private System.Windows.Forms.Label raceAdminAboutLabel;
		public System.Windows.Forms.Label versionLabel;
	}
}