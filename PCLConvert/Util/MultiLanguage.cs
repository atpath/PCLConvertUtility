using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PCLConvert.Util
{
    public static class MultiLanguage
    {
        public static void LoadLanguage(Form form, Type formType)
        {
            if (form != null)
            {
                var resources = new ComponentResourceManager(formType);
                resources.ApplyResources(form, "$this");
                Loading(form, resources);
            }
        }

        private static void Loading(Control control, ComponentResourceManager resources)
        {
            if (control is MenuStrip)
            {
                resources.ApplyResources(control, control.Name);
                var ms = control as MenuStrip;
                if (ms.Items.Count > 0)
                {
                    foreach (ToolStripMenuItem c in ms.Items)
                    {
                        Loading(c, resources);
                    }
                }
            }
 
            foreach (Control c in control.Controls)
            {
                resources.ApplyResources(c, c.Name);
                Loading(c, resources);
            }
        }

        private static void Loading(ToolStripMenuItem item, ComponentResourceManager resources)
        {

            if (item is ToolStripMenuItem)
            {
                resources.ApplyResources(item, item.Name);
                var tsmi = item as ToolStripMenuItem;
                if (tsmi.DropDownItems.Count > 0)
                {
                    foreach (ToolStripMenuItem c in tsmi.DropDownItems)
                    {
                        Loading(c, resources);
                    }
                }
            }
        }
    }
}
