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
            SuspendLayout();
            // 
            // info
            // 
            info.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            info.AutoSize = true;
            info.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            info.Location = new Point(743, 408);
            info.Name = "info";
            info.Size = new Size(45, 30);
            info.TabIndex = 0;
            info.Text = "info";
            info.UseVisualStyleBackColor = true;
            info.UseWaitCursor = true;
            info.Click += info_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(info);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button info;
    }
}
