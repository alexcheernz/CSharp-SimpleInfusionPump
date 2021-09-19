using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InfusionPump
{
    public partial class Form1 : Form
    {
        private static int VOLUME_MAX = 800; //maximum of volume, ml
        private static int VOLUME_MIN = 100;
        private static int DURATION_MAX = 80; //maximum of duration, mins
        private static int DURATION_MIN = 10;
        private static int VOLUME_STEP = 100; //increment or decrement when change volume
        private static int DURATION_STEP = 10; //increment or decrement when change duration

        private int pumpID; //default value is 1
        private int batteryPercent = 0; // value is 100 when power on
        private int volume = 0;
        private int duration = 0;
        private int oldVolume = 0; //used when cancel settings
        private int oldDuration = 0; //used when cancel settings
        private string displayContent = " ";

        enum Status
        {
            Off, // power off
            Initial, // initial status after powered on or stop infusion
            SetVolume,
            SetDuration,
            SettingsConfirmed,
            QStartInfusion, //double check before start infusion
            Infusing, // infusion is ongoing
            Paused,  // infusion is paused
            SettingsCancelled // configuration is cancelled
        }
        private Status status = Status.Off;

        public Form1()
        {
            InitializeComponent();

        }

        private void initialiseValue()
        {
            batteryPercent = 100;
            duration = 10;
            volume = 100;
            duration = 10;
            oldVolume = volume;
            oldDuration = duration;

            status = Status.Initial;
            setDisplay();
		}

        private void setDisplay()
        {
            if (status == Status.Off)
            {
                textBoxMode.Text = "Powered Off";
                textBoxInfo.Text = "";
            }
            else
            {
                switch (status)
                {
                    case Status.Off:
                        textBoxMode.Text = "Powered Off";
                        textBoxInfo.Text = "";
                        break;
                    case Status.Initial:
                        textBoxMode.Text = "Powered On";
                        textBoxInfo.Text = "";
                        break;
                    case Status.SetVolume:
                        textBoxMode.Text = "Volume:";
                        textBoxInfo.Text = volume + "mL";
                        break;
                    case Status.SetDuration:
                        textBoxMode.Text = "Duration";
                        textBoxInfo.Text = duration + " minutes";
                        break;
                    case Status.SettingsConfirmed:
                        textBoxMode.Text = "Start Infusion?";
                        textBoxInfo.Text = "Yes/No";
                        break;
                    case Status.QStartInfusion:
                        textBoxMode.Text = "Starting Infusion...";
                        textBoxInfo.Text = "";
                        break;
                    case Status.Infusing:
                        textBoxMode.Text = "RUNNING";
                        textBoxInfo.Text = "Infusing...";
                        break;
                    case Status.Paused:
                        textBoxMode.Text = "Infusion Paused";
                        textBoxInfo.Text = "PAUSED";
                        break;
                    case Status.SettingsCancelled:
                        textBoxMode.Text = "Operation Cancelled";
                        textBoxInfo.Text = "RESET";
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }


                //textBoxInfo.Text = "Pump ID: " + pumpID + "\r\nBattery Percentage: " + batteryPercent + "\r\n\r\nVolume (mL): " + volume + "\r\nDuration(mins): " + duration + "\r\nRate(mL/mins): " + String.Format("%.2f", (double) volume / duration) + "\r\n\r\nStatus: " + status;
            }
        }



		/*
		 * Power on or power off
		 */
		private void executeOnOff(object sender, EventArgs e)
		{
			if (status == Status.Off)
			{
				status = Status.Initial;
				initialiseValue();
                buttonPlus.Enabled = true;
                buttonMinus.Enabled = true;
                buttonNegAns.Enabled = true;
                buttonPositiveAns.Enabled = true;
                Console.WriteLine("**** Powered on ****");
			}
			else
			{
				status = Status.Off;
                buttonPlus.Enabled = false;
                buttonMinus.Enabled = false;
                buttonNegAns.Enabled = false;
                buttonPositiveAns.Enabled = false;
				Console.WriteLine("**** Powered off ****");
			}
			setDisplay();
		}

        private void buttonPositiveAns_Click(object sender, EventArgs e)
        {
            switch (status)
            {
                case Status.Initial:
                case Status.Infusing:
                case Status.SettingsCancelled:
                    status = Status.SetVolume;
                    Console.WriteLine("**** Set volume ****");
                    break;
                case Status.SetVolume:
                    status = Status.SetDuration;
                    Console.WriteLine("**** Set duration ****");
                    break;
                case Status.SetDuration:
                    status = Status.SettingsConfirmed;
                    oldVolume = volume;
                    oldDuration = duration;
                    Console.WriteLine("**** Confirm settings ****");
                    break;
                case Status.SettingsConfirmed:
                    status = Status.Infusing;
                    Console.WriteLine("**** Start infusion ? ****");
                    break;
                case Status.QStartInfusion:
                case Status.Paused:
                    status = Status.Infusing;
                    Console.WriteLine("**** Start infusion ... ****");
                    break;
                default:
                    break;
            }
            setDisplay();
		}

        private void buttonNegAns_Click(object sender, EventArgs e)
        {
            switch (status)
            {
                case Status.SetVolume:
                case Status.SettingsConfirmed:
                case Status.SetDuration:
                    status = Status.SettingsCancelled;
                    volume = oldVolume;
                    duration = oldDuration;
                    Console.WriteLine("**** Cancel settings ****");
                    break;
                case Status.Paused:
                case Status.SettingsCancelled:
                    initialiseValue();
                    Console.WriteLine("**** Status: paused/settingsCancelled -> Initial ****");
                    break;
                case Status.Initial:
                    Console.WriteLine("Do Nothing");
                    break;
                default:
                    status = Status.Paused;
                    Console.WriteLine("**** Status: infusing -> paused ****");
                    break;
            }
            setDisplay();
		}

        private void buttonMinus_Click(object sender, EventArgs e)
        {
            if (status == Status.SetVolume)
            {
                if (volume > VOLUME_MIN)
                {
                    volume -= VOLUME_STEP;
                }
                else
                {
                    volume = VOLUME_MIN;
                }
                Console.WriteLine("Decrease volume to: " + volume);
            }
            else if (status == Status.SetDuration)
            {
                if (duration > DURATION_MIN)
                {
                    duration -= DURATION_STEP;
                }
                else
                {
                    duration = DURATION_MIN;
                }
                Console.WriteLine("Decrease duration to: " + duration);
            }
            setDisplay();
        }

        private void buttonPlus_Click(object sender, EventArgs e)
        {
            if (status == Status.SetVolume)
            {
                if (volume < VOLUME_MAX)
                {
                    volume += VOLUME_STEP;
                }
                else
                {
                    volume = VOLUME_MAX;
                }
                Console.WriteLine("Increase volume to: " + volume);
            }
            else if (status == Status.SetDuration)
            {
                if (duration < DURATION_MAX)
                {
                    duration += DURATION_STEP;
                }
                else
                {
                    duration = DURATION_MAX;
                }
                Console.WriteLine("Increase duration to: " + duration);
            }
            setDisplay();
        }
    }
}
