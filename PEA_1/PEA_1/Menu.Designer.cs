namespace PEA_1
{
    partial class Menu
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.ReadFromFile_btn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.WorkTime_txt = new System.Windows.Forms.TextBox();
            this.StartTesting_btn = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.CityQua_txt = new System.Windows.Forms.TextBox();
            this.Generate_btn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.From_txt = new System.Windows.Forms.TextBox();
            this.To_txt = new System.Windows.Forms.TextBox();
            this.EndTestingMode_btn = new System.Windows.Forms.Button();
            this.testStatus_label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ReadFromFile_btn
            // 
            this.ReadFromFile_btn.Location = new System.Drawing.Point(315, 215);
            this.ReadFromFile_btn.Name = "ReadFromFile_btn";
            this.ReadFromFile_btn.Size = new System.Drawing.Size(130, 46);
            this.ReadFromFile_btn.TabIndex = 0;
            this.ReadFromFile_btn.Text = "Wczytaj z pliku";
            this.ReadFromFile_btn.UseVisualStyleBackColor = true;
            this.ReadFromFile_btn.Click += new System.EventHandler(this.ReadFromFile_btn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(547, 421);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 17);
            this.label1.TabIndex = 44;
            this.label1.Text = "Czas operacji [ms]";
            // 
            // WorkTime_txt
            // 
            this.WorkTime_txt.Cursor = System.Windows.Forms.Cursors.No;
            this.WorkTime_txt.Location = new System.Drawing.Point(676, 416);
            this.WorkTime_txt.Name = "WorkTime_txt";
            this.WorkTime_txt.ReadOnly = true;
            this.WorkTime_txt.Size = new System.Drawing.Size(112, 22);
            this.WorkTime_txt.TabIndex = 43;
            // 
            // StartTesting_btn
            // 
            this.StartTesting_btn.Location = new System.Drawing.Point(658, 364);
            this.StartTesting_btn.Name = "StartTesting_btn";
            this.StartTesting_btn.Size = new System.Drawing.Size(130, 46);
            this.StartTesting_btn.TabIndex = 68;
            this.StartTesting_btn.Text = "Rozpocznij 100 - krotny test";
            this.StartTesting_btn.UseVisualStyleBackColor = true;
            this.StartTesting_btn.Click += new System.EventHandler(this.StartTesting_btn_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label11.Location = new System.Drawing.Point(523, 337);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(73, 25);
            this.label11.TabIndex = 67;
            this.label11.Text = "Testy:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label9.Location = new System.Drawing.Point(12, 294);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(203, 25);
            this.label9.TabIndex = 69;
            this.label9.Text = "Generowanie miast:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 322);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 17);
            this.label7.TabIndex = 71;
            this.label7.Text = "Ilość miast";
            // 
            // CityQua_txt
            // 
            this.CityQua_txt.Location = new System.Drawing.Point(117, 319);
            this.CityQua_txt.Name = "CityQua_txt";
            this.CityQua_txt.Size = new System.Drawing.Size(98, 22);
            this.CityQua_txt.TabIndex = 70;
            this.CityQua_txt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CityQua_txt_KeyPress);
            // 
            // Generate_btn
            // 
            this.Generate_btn.Location = new System.Drawing.Point(85, 392);
            this.Generate_btn.Name = "Generate_btn";
            this.Generate_btn.Size = new System.Drawing.Size(130, 46);
            this.Generate_btn.TabIndex = 72;
            this.Generate_btn.Text = "Generuj";
            this.Generate_btn.UseVisualStyleBackColor = true;
            this.Generate_btn.Click += new System.EventHandler(this.Generate_btn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 344);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 17);
            this.label2.TabIndex = 73;
            this.label2.Text = "Zakres odległości";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 364);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 17);
            this.label3.TabIndex = 74;
            this.label3.Text = "Od";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(114, 364);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 17);
            this.label4.TabIndex = 75;
            this.label4.Text = "Do";
            // 
            // From_txt
            // 
            this.From_txt.Location = new System.Drawing.Point(47, 364);
            this.From_txt.Name = "From_txt";
            this.From_txt.Size = new System.Drawing.Size(61, 22);
            this.From_txt.TabIndex = 76;
            this.From_txt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.From_txt_KeyPress);
            // 
            // To_txt
            // 
            this.To_txt.Location = new System.Drawing.Point(146, 364);
            this.To_txt.Name = "To_txt";
            this.To_txt.Size = new System.Drawing.Size(61, 22);
            this.To_txt.TabIndex = 77;
            this.To_txt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.To_txt_KeyPress);
            this.To_txt.Leave += new System.EventHandler(this.To_txt_Leave);
            // 
            // EndTestingMode_btn
            // 
            this.EndTestingMode_btn.Location = new System.Drawing.Point(522, 364);
            this.EndTestingMode_btn.Name = "EndTestingMode_btn";
            this.EndTestingMode_btn.Size = new System.Drawing.Size(130, 46);
            this.EndTestingMode_btn.TabIndex = 78;
            this.EndTestingMode_btn.Text = "Wyjdź z trybu testowego";
            this.EndTestingMode_btn.UseVisualStyleBackColor = true;
            this.EndTestingMode_btn.Click += new System.EventHandler(this.EndTestingMode_btn_Click);
            // 
            // testStatus_label
            // 
            this.testStatus_label.AutoSize = true;
            this.testStatus_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.testStatus_label.ForeColor = System.Drawing.Color.Red;
            this.testStatus_label.Location = new System.Drawing.Point(592, 341);
            this.testStatus_label.Name = "testStatus_label";
            this.testStatus_label.Size = new System.Drawing.Size(104, 20);
            this.testStatus_label.TabIndex = 79;
            this.testStatus_label.Text = "Nieaktywne";
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.testStatus_label);
            this.Controls.Add(this.EndTestingMode_btn);
            this.Controls.Add(this.To_txt);
            this.Controls.Add(this.From_txt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Generate_btn);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.CityQua_txt);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.StartTesting_btn);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.WorkTime_txt);
            this.Controls.Add(this.ReadFromFile_btn);
            this.Name = "Menu";
            this.Text = "Menu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ReadFromFile_btn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox WorkTime_txt;
        private System.Windows.Forms.Button StartTesting_btn;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox CityQua_txt;
        private System.Windows.Forms.Button Generate_btn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox From_txt;
        private System.Windows.Forms.TextBox To_txt;
        private System.Windows.Forms.Button EndTestingMode_btn;
        private System.Windows.Forms.Label testStatus_label;
    }
}

