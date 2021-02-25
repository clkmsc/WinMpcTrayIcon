﻿using System.Collections.Generic;
using System.Windows.Forms;

namespace WinMpcTrayIcon.Menu
{
    public class ContextMenu
    {
        public List<MenuItem> Items { get; set; }

        public ContextMenu(List<MenuItem> items)
        {
            Items = items;
        }

        public ContextMenuStrip ToContextMenuStrip()
        {
            var m = new ContextMenuStrip();
            this.Build(m.Items);

            return m;
        }

        public void Build(ToolStripItemCollection items, List<MenuItem> commands = null)
        {
            if (commands == null)
                commands = Items;

            foreach(var command in commands)
            {
                ToolStripMenuItem i = command.ToToolStripMenuItem();;

                if (command.GetType() == typeof(GroupMenuItem))
                    Build(i.DropDownItems, ((GroupMenuItem)command).Items);
                else
                    i.Click += ((SysMenuItem)command).EventHandler;

                items.Add(i);
            }
        }
    }
}
