
namespace InfusionPump
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
            this.buttonPlus = new System.Windows.Forms.Button();
            this.buttonMinus = new System.Windows.Forms.Button();
            this.buttonNegAns = new System.Windows.Forms.Button();
            this.buttonPositiveAns = new System.Windows.Forms.Button();
            this.buttonOnOff = new System.Windows.Forms.Button();
            this.textBoxInfo = new System.Windows.Forms.TextBox();
            this.textBoxMode = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonPlus
            // 
            this.buttonPlus.Location = new System.Drawing.Point(12, 193);
            this.buttonPlus.Name = "buttonPlus";
            this.buttonPlus.Size = new System.Drawing.Size(95, 104);
            this.buttonPlus.TabIndex = 0;
            this.buttonPlus.Text = "+";
            this.buttonPlus.UseVisualStyleBackColor = true;
            this.buttonPlus.Click += new System.EventHandler(this.buttonPlus_Click);
            // 
            // buttonMinus
            // 
            this.buttonMinus.Location = new System.Drawing.Point(12, 303);
            this.buttonMinus.Name = "buttonMinus";
            this.buttonMinus.Size = new System.Drawing.Size(95, 104);
            this.buttonMinus.TabIndex = 1;
            this.buttonMinus.Text = "-";
            this.buttonMinus.UseVisualStyleBackColor = true;
            this.buttonMinus.Click += new System.EventHandler(this.buttonMinus_Click);
            // 
            // buttonNegAns
            // 
            this.buttonNegAns.Location = new System.Drawing.Point(113, 303);
            this.buttonNegAns.Name = "buttonNegAns";
            this.buttonNegAns.Size = new System.Drawing.Size(283, 104);
            this.buttonNegAns.TabIndex = 2;
            this.buttonNegAns.Text = "but";
            this.buttonNegAns.UseVisualStyleBackColor = true;
            this.buttonNegAns.Click += new System.EventHandler(this.buttonNegAns_Click);
            // 
            // buttonPositiveAns
            // 
            this.buttonPositiveAns.Location = new System.Drawing.Point(113, 193);
            this.buttonPositiveAns.Name = "buttonPositiveAns";
            this.buttonPositiveAns.Size = new System.Drawing.Size(283, 104);
            this.buttonPositiveAns.TabIndex = 3;
            this.buttonPositiveAns.Text = "Yes/Start";
            this.buttonPositiveAns.UseVisualStyleBackColor = true;
            this.buttonPositiveAns.Click += new System.EventHandler(this.buttonPositiveAns_Click);
            // 
            // buttonOnOff
            // 
            this.buttonOnOff.Location = new System.Drawing.Point(402, 193);
            this.buttonOnOff.Name = "buttonOnOff";
            this.buttonOnOff.Size = new System.Drawing.Size(210, 214);
            this.buttonOnOff.TabIndex = 4;
            this.buttonOnOff.Text = "Power On/Off";
            this.buttonOnOff.UseVisualStyleBackColor = true;
            this.buttonOnOff.Click += new System.EventHandler(this.executeOnOff);
            // 
            // textBoxInfo
            // 
            this.textBoxInfo.AcceptsReturn = true;
            this.textBoxInfo.AcceptsTab = true;
            this.textBoxInfo.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxInfo.Location = new System.Drawing.Point(12, 63);
            this.textBoxInfo.Multiline = true;
            this.textBoxInfo.Name = "textBoxInfo";
            this.textBoxInfo.ReadOnly = true;
            this.textBoxInfo.Size = new System.Drawing.Size(600, 124);
            this.textBoxInfo.TabIndex = 5;
            this.textBoxInfo.WordWrap = false;
            // 
            // textBoxMode
            // 
            this.textBoxMode.Location = new System.Drawing.Point(12, 34);
            this.textBoxMode.Name = "textBoxMode";
            this.textBoxMode.ReadOnly = true;
            this.textBoxMode.Size = new System.Drawing.Size(600, 23);
            this.textBoxMode.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 441);
            this.Controls.Add(this.textBoxMode);
            this.Controls.Add(this.textBoxInfo);
            this.Controls.Add(this.buttonOnOff);
            this.Controls.Add(this.buttonPositiveAns);
            this.Controls.Add(this.buttonNegAns);
            this.Controls.Add(this.buttonMinus);
            this.Controls.Add(this.buttonPlus);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonPlus;
        private System.Windows.Forms.Button buttonMinus;
        private System.Windows.Forms.Button buttonNegAns;
        private System.Windows.Forms.Button buttonPositiveAns;
        private System.Windows.Forms.Button buttonOnOff;
        private System.Windows.Forms.TextBox textBoxInfo;
        private System.Windows.Forms.TextBox textBoxMode;
    }
}

