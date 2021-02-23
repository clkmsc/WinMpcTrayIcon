﻿using System.Diagnostics;

namespace WinMpcTrayIcon.Mpc
{
    public class MpcClient
    {
        private string _mpcPath;

        public MpcClient(string mpcPath)
        {
            _mpcPath = mpcPath;
        }

        public Process SendCommand(Command cmd)
        {
            var p = new Process
            {
                StartInfo = new ProcessStartInfo(_mpcPath, cmd.ToString().ToLower())
                {
                    RedirectStandardOutput = true,
                    UseShellExecute = false
                }
            };

            return p;
        }

        public string GetStatus()
        {
            var p = SendCommand(Command.Status);
            p.Start();
            string q = "";

            while ( ! p.HasExited ) {
                q += p.StandardOutput.ReadToEnd();
            }

            return q.Split("[")[1].Split("]")[0];
        }

        public string GetInfo()
        {
            var p = SendCommand(Command.Status);
            p.Start();
            string q = "";

            while ( ! p.HasExited ) {
                q += p.StandardOutput.ReadToEnd();
            }

            return q;
        }
    }
}
