using System;
using System.Windows.Forms;

namespace JoelCounter
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            KeyboardHook.KeyboardAction += new EventHandler(Event_MouseClicked);
            UpdateLabels();
        }

        private void Event_MouseClicked(object sender, EventArgs e)
        {
            KeyboardClickData.TotalClicks++;
            if (KeyboardClickData.ClicksPerDay.ContainsKey(DateTime.Now.Date))
            {
                KeyboardClickData.ClicksPerDay[DateTime.Now.Date]++;
            }
            else
            {
                KeyboardClickData.ClicksPerDay[DateTime.Now.Date] = 1;
            }

            UpdateLabels();
        }

        private void UpdateLabels()
        {
            lblTotalClicks.Text = $"Total Clicks: {KeyboardClickData.TotalClicks}";
            lblClicksToday.Text = $"Clicks Today: {KeyboardClickData.GetClicksToday()}";
        }
    }
}
