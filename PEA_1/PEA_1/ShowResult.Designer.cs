namespace PEA_1
{
    partial class ShowResult
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
            this.Results_txt = new System.Windows.Forms.RichTextBox();
            this.Close_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Results_txt
            // 
            this.Results_txt.Location = new System.Drawing.Point(12, 12);
            this.Results_txt.Name = "Results_txt";
            this.Results_txt.ReadOnly = true;
            this.Results_txt.Size = new System.Drawing.Size(776, 383);
            this.Results_txt.TabIndex = 0;
            this.Results_txt.Text = "";
            // 
            // Close_btn
            // 
            this.Close_btn.Location = new System.Drawing.Point(658, 401);
            this.Close_btn.Name = "Close_btn";
            this.Close_btn.Size = new System.Drawing.Size(130, 46);
            this.Close_btn.TabIndex = 1;
            this.Close_btn.Text = "Zamknij";
            this.Close_btn.UseVisualStyleBackColor = true;
            this.Close_btn.Click += new System.EventHandler(this.Close_btn_Click);
            // 
            // ShowResult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Close_btn);
            this.Controls.Add(this.Results_txt);
            this.Name = "ShowResult";
            this.Text = "Podgląd wyników";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox Results_txt;
        private System.Windows.Forms.Button Close_btn;
    }
}