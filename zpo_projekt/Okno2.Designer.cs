namespace zpo_projekt
{
    partial class Okno2
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
            dodajKategorieTextBox = new TextBox();
            btnDodajKategorie = new Button();
            SuspendLayout();
            // 
            // dodajKategorieTextBox
            // 
            dodajKategorieTextBox.Location = new Point(202, 104);
            dodajKategorieTextBox.Name = "dodajKategorieTextBox";
            dodajKategorieTextBox.Size = new Size(125, 27);
            dodajKategorieTextBox.TabIndex = 0;
            dodajKategorieTextBox.TextChanged += dodajKategorieTextBox_TextChanged;
            // 
            // btnDodajKategorie
            // 
            btnDodajKategorie.AutoSize = true;
            btnDodajKategorie.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnDodajKategorie.Location = new Point(368, 102);
            btnDodajKategorie.Name = "btnDodajKategorie";
            btnDodajKategorie.Size = new Size(125, 30);
            btnDodajKategorie.TabIndex = 1;
            btnDodajKategorie.Text = "dodaj kategorie";
            btnDodajKategorie.UseVisualStyleBackColor = true;
            btnDodajKategorie.Click += button1_Click;
            // 
            // Okno2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnDodajKategorie);
            Controls.Add(dodajKategorieTextBox);
            Name = "Okno2";
            Text = "Okno2";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox dodajKategorieTextBox;
        private Button btnDodajKategorie;
    }
}