namespace SWUF_DL
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
            this.buttonDL = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.groupBoxDL = new System.Windows.Forms.GroupBox();
            this.groupBoxDL.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonDL
            // 
            this.buttonDL.Location = new System.Drawing.Point(6, 19);
            this.buttonDL.Name = "buttonDL";
            this.buttonDL.Size = new System.Drawing.Size(75, 23);
            this.buttonDL.TabIndex = 0;
            this.buttonDL.Text = "Download";
            this.buttonDL.UseVisualStyleBackColor = true;
            this.buttonDL.Click += new System.EventHandler(this.buttonDL_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(119, 19);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 1;
            this.buttonSave.Text = "Save Links";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // groupBoxDL
            // 
            this.groupBoxDL.Controls.Add(this.buttonDL);
            this.groupBoxDL.Controls.Add(this.buttonSave);
            this.groupBoxDL.Location = new System.Drawing.Point(12, 12);
            this.groupBoxDL.Name = "groupBoxDL";
            this.groupBoxDL.Size = new System.Drawing.Size(200, 53);
            this.groupBoxDL.TabIndex = 2;
            this.groupBoxDL.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(232, 75);
            this.Controls.Add(this.groupBoxDL);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WWUF-DL";
            this.groupBoxDL.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonDL;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.GroupBox groupBoxDL;
    }
}

