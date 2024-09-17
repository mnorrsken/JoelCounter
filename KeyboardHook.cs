using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace JoelCounter
{
    static class KeyboardHook
    {
        private static IntPtr hookId = IntPtr.Zero;
        public static event EventHandler KeyboardAction = delegate { };

        public static void Start()
        {
            hookId = SetHook(HookCallback);
        }

        public static void Stop()
        {
            UnhookWindowsHookEx(hookId);
        }

        private static IntPtr SetHook(LowLevelKeyboardProc proc)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                //return SetWindowsHookEx(WH_MOUSE_LL, proc,
                //  GetModuleHandle(curModule.ModuleName), 0);
                return SetWindowsHookEx(WH_KEYBOARD_LL, proc,
                  GetModuleHandle(curModule.ModuleName), 0);
            }
        }

        private delegate IntPtr LowLevelKeyboardProc(
            int nCode, IntPtr wParam, IntPtr lParam);

        private static LowLevelKeyboardProc HookCallback = HookFunc;

        private static IntPtr HookFunc(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0)
            {

                //if (wParam.ToInt32() == WM_MOUSEDOWN || wParam.ToInt32() == WM_RMOUSEDOWN)
                //{
                //    MouseAction(null, new EventArgs());
                //}
                if (wParam.ToInt32() == WM_KEYDOWN || wParam.ToInt32() == WM_SYSKEYDOWN)
                {
                    KeyboardAction(null, new EventArgs());
                }
            }
            return CallNextHookEx(hookId, nCode, wParam, lParam);
        }

        private const int WH_MOUSE_LL = 14;
        private const int WH_KEYBOARD_LL = 13;

        private const int WM_MOUSEDOWN = 0x0201;
        private const int WM_MOUSEUP = 0x0202;
        private const int WM_RMOUSEDOWN = 0x0204;
        private const int WM_RMOUSEUP = 0x0205;

        private const int WM_KEYDOWN = 0x100;
        private const int WM_KEYUP = 0x101;
        private const int WM_SYSKEYDOWN = 0x104;
        private const int WM_SYSKEYUP = 0x105;

        // Import necessary functions from user32.dll
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook,
            LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto,
            CallingConvention = CallingConvention.StdCall)]
        private static extern bool UnhookWindowsHookEx(IntPtr idHook);

        [DllImport("user32.dll", CharSet = CharSet.Auto,
            CallingConvention = CallingConvention.StdCall)]
        private static extern IntPtr CallNextHookEx(IntPtr idHook,
            int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto,
            SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);
    }
}
