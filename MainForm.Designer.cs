using System.Windows.Forms;

namespace JoelCounter
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTotalClicks;
        private Label lblClicksToday;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
                KeyboardHook.KeyboardAction -= Event_MouseClicked;
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTotalClicks = new System.Windows.Forms.Label();
            this.lblClicksToday = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTotalClicks
            // 
            this.lblTotalClicks.AutoSize = true;
            this.lblTotalClicks.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblTotalClicks.Location = new System.Drawing.Point(30, 30);
            this.lblTotalClicks.Name = "lblTotalClicks";
            this.lblTotalClicks.Size = new System.Drawing.Size(109, 20);
            this.lblTotalClicks.TabIndex = 0;
            this.lblTotalClicks.Text = "Total Clicks: 0";
            // 
            // lblClicksToday
            // 
            this.lblClicksToday.AutoSize = true;
            this.lblClicksToday.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblClicksToday.Location = new System.Drawing.Point(30, 70);
            this.lblClicksToday.Name = "lblClicksToday";
            this.lblClicksToday.Size = new System.Drawing.Size(116, 20);
            this.lblClicksToday.TabIndex = 1;
            this.lblClicksToday.Text = "Clicks Today: 0";
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 131);
            this.Controls.Add(this.lblClicksToday);
            this.Controls.Add(this.lblTotalClicks);
            this.Name = "MainForm";
            this.Text = "Mouse Click Counter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
