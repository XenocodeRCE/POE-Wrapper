using System;
using System.Threading;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;


namespace POE {
    internal class Program {

        [DllImport("user32.dll")]
        static extern bool SetCursorPos(int X, int Y);

        [DllImport("user32.dll")]
        static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, int dwExtraInfo);

        const int MOUSEEVENTF_LEFTDOWN = 0x02;
        const int MOUSEEVENTF_LEFTUP = 0x04;
        const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        const int MOUSEEVENTF_RIGHTUP = 0x10;

        static void LeftClick()
        {
            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
            Thread.Sleep(100);
        }

        static void RightClick()
        {
            mouse_event(MOUSEEVENTF_RIGHTDOWN, 0, 0, 0, 0);
            mouse_event(MOUSEEVENTF_RIGHTUP, 0, 0, 0, 0);
            Thread.Sleep(100);
        }

        private static string GetClipboardData()
        {
            try
            {
                string clipboardData = null;
                Exception threadEx = null;
                Thread staThread = new Thread(
                    delegate ()
                    {
                        try
                        {
                            clipboardData = Clipboard.GetText(TextDataFormat.Text);
                        }

                        catch (Exception ex)
                        {
                            threadEx = ex;
                        }
                    });
                staThread.SetApartmentState(ApartmentState.STA);
                staThread.Start();
                staThread.Join();
                return clipboardData;
            }
            catch (Exception exception)
            {
                return string.Empty;
            }
        }

        static string RemovePatternFromString(string input, string pattern)
        {
            return Regex.Replace(input, pattern, "");
        }

        static void Main(string[] args)
        {

            if (args.Length != 3)
            {
                Console.WriteLine("Usage: poe.exe \"the prompt\" \"https url of the AI\" \"name_of_the_output_file\"");
                return;
            }

            string prompt = args[0];
            string urlofBot = args[1];
            string outputFileName = args[2];

            System.Diagnostics.Process.Start($"microsoft-edge:{urlofBot}");
            SetCursorPos(714, 687);
            Thread.Sleep(5000);
            LeftClick();
            LeftClick();
            LeftClick();
            LeftClick();
            SendKeys.SendWait($"{prompt}");
            SendKeys.SendWait("{ENTER}");
            Thread.Sleep(15000);
            SetCursorPos(791, 387);
            LeftClick();
            RightClick();
            SetCursorPos(872, 496);
            LeftClick();
            Thread.Sleep(1000);
            string clipboardText = GetClipboardData();
            Console.WriteLine("Text from clipboard: " + clipboardText);            
            string processedText = RemovePatternFromString(clipboardText, @"\[\[\d+\]\]\(https:\/\/poe\.com\/citation\?message_id=\d+&citation=\d+\)");
            System.IO.File.WriteAllText(outputFileName, processedText);
            Console.ReadKey();
        }
    }
}
