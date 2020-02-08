using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsInput;

namespace RSLFightReplayer
{
    public static class AutoInput
    {
        public static void ReplayInput()
        {
            Console.WriteLine("Sending Replay input...");
            var keyboard = new KeyboardSimulator(new InputSimulator());
            keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.VK_R);
        }
    }
}