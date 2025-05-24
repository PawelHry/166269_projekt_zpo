namespace zpo_projekt
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
            info = new Button();
            btnDodaj = new Button();
            kategorieComboBox = new ComboBox();
            iloscTextBox = new TextBox();
            dataGridViewWydatki = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridViewWydatki).BeginInit();
            SuspendLayout();
            // 
            // info
            // 
            info.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            info.AutoSize = true;
            info.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            info.Location = new Point(663, 12);
            info.Name = "info";
            info.Size = new Size(125, 30);
            info.TabIndex = 0;
            info.Text = "dodaj kategorie";
            info.UseVisualStyleBackColor = true;
            info.UseWaitCursor = true;
            info.Click += info_Click;
            // 
            // btnDodaj
            // 
            btnDodaj.Location = new Point(458, 10);
            btnDodaj.Name = "btnDodaj";
            btnDodaj.Size = new Size(94, 29);
            btnDodaj.TabIndex = 5;
            btnDodaj.Text = "Dodaj";
            btnDodaj.UseVisualStyleBackColor = true;
            btnDodaj.Click += btnDodaj_Click;
            // 
            // kategorieComboBox
            // 
            kategorieComboBox.FormattingEnabled = true;
            kategorieComboBox.Location = new Point(291, 10);
            kategorieComboBox.Name = "kategorieComboBox";
            kategorieComboBox.Size = new Size(151, 28);
            kategorieComboBox.TabIndex = 4;
            kategorieComboBox.SelectedIndexChanged += kategorieComboBox_SelectedIndexChanged;
            // 
            // iloscTextBox
            // 
            iloscTextBox.Location = new Point(160, 12);
            iloscTextBox.Name = "iloscTextBox";
            iloscTextBox.Size = new Size(125, 27);
            iloscTextBox.TabIndex = 3;
            iloscTextBox.TextChanged += iloscTextBox_TextChanged;
            // 
            // dataGridViewWydatki
            // 
            dataGridViewWydatki.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewWydatki.Dock = DockStyle.Bottom;
            dataGridViewWydatki.Location = new Point(0, 63);
            dataGridViewWydatki.Name = "dataGridViewWydatki";
            dataGridViewWydatki.RowHeadersWidth = 51;
            dataGridViewWydatki.Size = new Size(800, 387);
            dataGridViewWydatki.TabIndex = 6;
            dataGridViewWydatki.CellContentClick += this.dataGridView1_CellContentClick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dataGridViewWydatki);
            Controls.Add(btnDodaj);
            Controls.Add(kategorieComboBox);
            Controls.Add(iloscTextBox);
            Controls.Add(info);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewWydatki).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button info;
        private Button btnDodaj;
        private ComboBox kategorieComboBox;
        private TextBox iloscTextBox;
        private DataGridView dataGridViewWydatki;
    }
}
