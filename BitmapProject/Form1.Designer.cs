namespace BitmapProject
{
    partial class Form1
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
            this.GetPicture = new System.Windows.Forms.Button();
            this.pictureBoxOriginal = new System.Windows.Forms.PictureBox();
            this.pictureBoxForSaving = new System.Windows.Forms.PictureBox();
            this.ButtonGetNegative = new System.Windows.Forms.Button();
            this.ButtonTurnLeft = new System.Windows.Forms.Button();
            this.ButtonTurnRight = new System.Windows.Forms.Button();
            this.ButtonSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOriginal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxForSaving)).BeginInit();
            this.SuspendLayout();
            // 
            // GetPicture
            // 
            this.GetPicture.Location = new System.Drawing.Point(12, 12);
            this.GetPicture.Name = "GetPicture";
            this.GetPicture.Size = new System.Drawing.Size(75, 23);
            this.GetPicture.TabIndex = 0;
            this.GetPicture.Text = "Get Picture";
            this.GetPicture.UseVisualStyleBackColor = true;
            this.GetPicture.Click += new System.EventHandler(this.GetPictureB_Click);
            // 
            // pictureBoxOriginal
            // 
            this.pictureBoxOriginal.Location = new System.Drawing.Point(12, 70);
            this.pictureBoxOriginal.Name = "pictureBoxOriginal";
            this.pictureBoxOriginal.Size = new System.Drawing.Size(294, 320);
            this.pictureBoxOriginal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxOriginal.TabIndex = 1;
            this.pictureBoxOriginal.TabStop = false;
            // 
            // pictureBoxForSaving
            // 
            this.pictureBoxForSaving.Location = new System.Drawing.Point(312, 70);
            this.pictureBoxForSaving.Name = "pictureBoxForSaving";
            this.pictureBoxForSaving.Size = new System.Drawing.Size(294, 320);
            this.pictureBoxForSaving.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxForSaving.TabIndex = 2;
            this.pictureBoxForSaving.TabStop = false;
            // 
            // ButtonGetNegative
            // 
            this.ButtonGetNegative.Location = new System.Drawing.Point(12, 41);
            this.ButtonGetNegative.Name = "ButtonGetNegative";
            this.ButtonGetNegative.Size = new System.Drawing.Size(86, 23);
            this.ButtonGetNegative.TabIndex = 3;
            this.ButtonGetNegative.Text = "Get Negative";
            this.ButtonGetNegative.UseVisualStyleBackColor = true;
            this.ButtonGetNegative.Click += new System.EventHandler(this.GetNegative_Click);
            // 
            // ButtonTurnLeft
            // 
            this.ButtonTurnLeft.Location = new System.Drawing.Point(104, 41);
            this.ButtonTurnLeft.Name = "ButtonTurnLeft";
            this.ButtonTurnLeft.Size = new System.Drawing.Size(86, 23);
            this.ButtonTurnLeft.TabIndex = 4;
            this.ButtonTurnLeft.Text = "Turn Left";
            this.ButtonTurnLeft.UseVisualStyleBackColor = true;
            this.ButtonTurnLeft.Click += new System.EventHandler(this.TurnLeft_Click);
            // 
            // ButtonTurnRight
            // 
            this.ButtonTurnRight.Location = new System.Drawing.Point(196, 41);
            this.ButtonTurnRight.Name = "ButtonTurnRight";
            this.ButtonTurnRight.Size = new System.Drawing.Size(86, 23);
            this.ButtonTurnRight.TabIndex = 5;
            this.ButtonTurnRight.Text = "Turn Right";
            this.ButtonTurnRight.UseVisualStyleBackColor = true;
            this.ButtonTurnRight.Click += new System.EventHandler(this.TurnRight_Click);
            // 
            // ButtonSave
            // 
            this.ButtonSave.Location = new System.Drawing.Point(93, 12);
            this.ButtonSave.Name = "ButtonSave";
            this.ButtonSave.Size = new System.Drawing.Size(75, 23);
            this.ButtonSave.TabIndex = 6;
            this.ButtonSave.Text = "Save";
            this.ButtonSave.UseVisualStyleBackColor = true;
            this.ButtonSave.Click += new System.EventHandler(this.Save_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 400);
            this.Controls.Add(this.ButtonSave);
            this.Controls.Add(this.ButtonTurnRight);
            this.Controls.Add(this.ButtonTurnLeft);
            this.Controls.Add(this.ButtonGetNegative);
            this.Controls.Add(this.pictureBoxForSaving);
            this.Controls.Add(this.pictureBoxOriginal);
            this.Controls.Add(this.GetPicture);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOriginal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxForSaving)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button GetPicture;
        private System.Windows.Forms.PictureBox pictureBoxOriginal;
        private System.Windows.Forms.PictureBox pictureBoxForSaving;
        private System.Windows.Forms.Button ButtonGetNegative;
        private System.Windows.Forms.Button ButtonTurnLeft;
        private System.Windows.Forms.Button ButtonTurnRight;
        private System.Windows.Forms.Button ButtonSave;
    }
}

