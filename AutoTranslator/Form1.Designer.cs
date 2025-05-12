namespace AutoTranslator
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
            panel1 = new Panel();
            isTranslationEnabled = new CheckBox();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(128, 255, 255);
            panel1.Controls.Add(isTranslationEnabled);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(320, 182);
            panel1.TabIndex = 0;
            // 
            // isTranslationEnabled
            // 
            isTranslationEnabled.AutoSize = true;
            isTranslationEnabled.Font = new Font("Times New Roman", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            isTranslationEnabled.Location = new Point(36, 144);
            isTranslationEnabled.Name = "isTranslationEnabled";
            isTranslationEnabled.Size = new Size(240, 26);
            isTranslationEnabled.TabIndex = 0;
            isTranslationEnabled.Text = "Автоматичский перевод";
            isTranslationEnabled.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(320, 182);
            Controls.Add(panel1);
            Name = "Form1";
            Text = "Windows";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private CheckBox isTranslationEnabled;
    }
}
