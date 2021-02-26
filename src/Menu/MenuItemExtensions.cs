﻿using System.Drawing;
using System.Windows.Forms;

namespace WinMpcTrayIcon.Menu
{
    public static class MenuItemExtensions
    {
        public static ToolStripMenuItem ToToolStripMenuItem(this MenuItem command)
        {
            var i = new ToolStripMenuItem();
            i.Text = command.Text;
            i.Image = command.Image != null ? Image.FromFile(command.Image) : null;

            return i;
        }
    }
}
