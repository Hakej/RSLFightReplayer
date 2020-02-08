using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsInput;

namespace RSLFightReplayer
{
    public partial class MainForm : Form
    {
        private bool _hasBattleFinished = false;
        private bool _enabled = false;
        private int _battlesWon = 0;
        private Thread _loopThread;

        public MainForm()
        {
            InitializeComponent();
        }

        private void BtnToggle_Click(object sender, EventArgs e)
        {
            Toggle();
        }

        private void Toggle()
        {
            _enabled = !_enabled;

            var btnMsg = _enabled ? "Stop" : "Start";
            WriteUninvokedText(btnToggle, btnMsg);

            if (_enabled)
            {
                _loopThread = new Thread(Loop);
                _loopThread.Start();
            }
            else
            {
                var labelMsg = $"Finished. Battles won: {_battlesWon}";
                WriteUninvokedText(BattlesWonLabel, labelMsg);

                _battlesWon = 0;

                if (_loopThread.IsAlive)
                {
                    _loopThread.Abort();
                }
            }
        }

        private void Loop()
        {
            while (_enabled)
            {
                var wasPreviousBattleFinished = _hasBattleFinished;
                DetectVictory();

                var labelMsg = $"Battles won: {_battlesWon}.";
                WriteUninvokedText(BattlesWonLabel, labelMsg);

                if (_hasBattleFinished)
                {
                    AutoInput.ReplayInput();
                    if (wasPreviousBattleFinished != _hasBattleFinished)
                    {
                        _battlesWon++;
                    }
                }

                try
                {
                    var fightsLimit = int.Parse(textBox1.Text);
                    if (_battlesWon >= fightsLimit)
                    {
                        Toggle();
                    }
                }
                catch (FormatException e)
                {
                    var popup = new IncorrectNumberOfFightsPopup($"Incorrect number of fights: {e.Message}");
                    popup.ShowDialog();

                    if (_enabled)
                    {
                        Toggle();
                    }
                }

                Thread.Sleep(1000);
            }
        }

        private void DetectVictory()
        {
            var screenMap = new Bitmap(952, 119);
            var graphics = Graphics.FromImage(screenMap);
            graphics.CopyFromScreen(830, 897, 0, 0, screenMap.Size);

            var img = Image.FromFile("../../Screenshots/victory_buttons.png");
            var victoryMap = new Bitmap(img);

            _hasBattleFinished = BitmapComparator.CompareBitmapsLazy(screenMap, victoryMap, 0.5f);
        }

        private void WriteUninvokedText(Control element, string content)
        {
            if (element.InvokeRequired)
            {
                element.BeginInvoke((MethodInvoker)delegate () { element.Text = content; });
            }
            else
            {
                element.Text = content;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Text = "R:SL Fight Replayer";
        }
    }
}