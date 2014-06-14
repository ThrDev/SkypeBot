using SKYPE4COMLib;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Drawing;

namespace Thr_SkypeBot
{
    class Hook
    {
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool SetForegroundWindow(IntPtr hWnd);

        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public int X;
            public int Y;
            public static implicit operator Point(POINT point)
            {
                return new Point(point.X, point.Y);
            }
        }

        [DllImport("user32.dll")]
        static extern bool SetCursorPos(int X, int Y);

        [DllImport("user32.dll")]
        public static extern bool GetCursorPos(out POINT lpPoint);

        [DllImport("user32.dll")]
        static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, UIntPtr dwExtraInfo);

        [DllImport("user32.dll")]
        static extern bool ClientToScreen(IntPtr hWnd, ref Point lpPoint);

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int wMsg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetWindowRect(IntPtr hwnd, out RECT lpRect);

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;        // x position of upper-left corner
            public int Top;         // y position of upper-left corner
            public int Right;       // x position of lower-right corner
            public int Bottom;      // y position of lower-right corner
        }

        [DllImport("user32.dll", SetLastError = true)]
        internal static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);

        [DllImport("user32.dll", SetLastError = true)]
        static extern bool ShowWindow(IntPtr hWnd, int cmdShow);

        private static void ClickOnPoint(IntPtr wndHandle, Point clientPoint)
        {
            POINT oldPoint;
            /// store old pos
            GetCursorPos(out oldPoint);

            /// get screen coordinates
            ClientToScreen(wndHandle, ref clientPoint);

            /// set cursor on coords, and press mouse
            SetCursorPos(clientPoint.X, clientPoint.Y);
            mouse_event(0x00000002, 0, 0, 0, UIntPtr.Zero); /// left mouse button down
            mouse_event(0x00000004, 0, 0, 0, UIntPtr.Zero); /// left mouse button up

            /// return mouse 
            SetCursorPos(oldPoint.X, oldPoint.Y);
        }
        static bool skypestatus()
        {
            //Make sure skype is running.
            Process[] f = Process.GetProcessesByName(Utils.XOR("䡿䡇䡈䡠䡢䡻䡢䡤䡿䡖䡺䡻䡾䠜䡟䠝䡿䡩䡈䡠䡢䡻䡶䡤䡿䡖䡹䠑", 419317804));
            if (f.Length <= 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public static bool HookSkype(SKYPE4COMLib.Skype skype)
        {
            try
            {
                Console.WriteLine(Utils.XOR("帬帠幼帤布帚帽帹帔帧帛帼帯帚帄幼帯广帡帤布帙帡帽帔帧帘帺帬帚帄幼帯帚帡帤布帚帛帽帔帧帛幽帯帚帄幼帬帚帡帤布帙帛帽帔帧帛帼帬帚帄幼帬广帡帤布帕帟帹帔帧帛帹帬帚帄幼帬帚帡帤布帚帡帽帔帧帛帊帬帚帄幼帩帊幼帤布帚帡帽帔帧帘幼帬帚帄幼帩帊幼帤布帕帋帽帔帧帛帼帬帚帄幼帬广帡帤布帙帛帽帔帧帘幸帬帚帄幼帗广帡帤布帚年帽帔帧帘幼帬帚帄幼布帚帡帤布帘幼帽帔帧帘幰", 300179021));
                if (!skypestatus()) return false;
                skype.Attach(7, false);
                int click = 0;
            ClickAttach:
                if (((ISkype)skype).AttachmentStatus != TAttachmentStatus.apiAttachSuccess)
                {
                    foreach (var process in Process.GetProcesses())
                    {
                        if (process.ProcessName == Utils.XOR("㋺㋦㋻㊞㋠㋩㋸㊟㋠㋪㋼㋷㋊㋺㋿㊞㋼㋀㋻㊞㋠㋪㋂㊟㋠㋪㋿㊓", 181875374))
                        {
                            RECT SkypeRect;
                            GetWindowRect(process.MainWindowHandle, out SkypeRect);
                            MoveWindow(process.MainWindowHandle, SkypeRect.Left, SkypeRect.Top, 940, 590, true);
                            IntPtr zappem = FindWindowEx(process.MainWindowHandle, IntPtr.Zero, Utils.XOR("", 571406404), null);
                            if (zappem != IntPtr.Zero)
                            {
                                ClickOnPoint(zappem, new Point(285, 60));
                                click++;
                                //Log.WriteConsole("Clicked point!", lvl.info);
                            }
                        }
                    }
                }
                //already attached.
                if (((ISkype)skype).AttachmentStatus != TAttachmentStatus.apiAttachSuccess)
                {
                    skype.Attach(5, false);
                }
                if (((ISkype)skype).AttachmentStatus == TAttachmentStatus.apiAttachSuccess)
                {
                    //log
                    Console.WriteLine(Utils.XOR("벒볮볦볭벐벴벺벒벐벤버볯벍벤벽볬벼벵벭볭벐벴벘벒벐벤버벑벍벤벽볬법볮볦볭벐벰벶벒벐벤버벦벍벤벽볬법볮볦볭벐벴버벒벐벤벇볭벍벤벽볬벓벵벭볭벐벴벲벒벐벤벇벨벍벤벽볬벽벋벭볭벐벰벘벒벐벤버벳벍벤벽볬법볮볦볭벐벳볫벒벐벤버볫벍벤벽볬벻벋벭볭벐벰범벒벐벤벇볮벍벤벽볬벺벛벭볭벐벰벌벒벐벤벇볭벍벤벽볬벑벋벭볭벐벴벲벒벐벤버벧벍벤벽볬벊벵벭볭벐벹볣볣", 132365534));
                    foreach(Process process in Process.GetProcesses())
                    {
                        if (process.ProcessName == Utils.XOR("橢樅樆橏橹橢機橃橔橣橡橧橕橯橲樆橮樅樆橏橹橠橃橃橔橣橢樊", 1104964151))
                        {
                            Console.WriteLine(Utils.XOR("", 1309665824));
                            SetForegroundWindow(Process.GetCurrentProcess().MainWindowHandle);
                        }
                    }
                }
                else
                {
                    if (click < 20)
                    {
                        Thread.Sleep(2000);
                        goto ClickAttach;
                    }
                    else
                    {

                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
