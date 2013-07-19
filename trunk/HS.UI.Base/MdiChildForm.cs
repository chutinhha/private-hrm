using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HS.UI.Base
{
    public class MdiChildForm : System.Windows.Forms.Form, IEditableForm
    {
        private List<ToolbarItem> toolbarItems;
        /// <summary>
        /// Chứa các Item của Toolbar của form
        /// </summary>
        public List<ToolbarItem> ToolbarItems
        {
            get
            {
                if (toolbarItems == null)
                {
                    toolbarItems = new List<ToolbarItem>();
                }
                return toolbarItems;
            }
        }

        /// <summary>
        /// Form này chỉ hiển thị duy nhất 1 form trên MDIParentForm
        /// </summary>
        public bool IsUniqueForm = false;


        public virtual void DoAdd() { }
        public virtual void DoEdit() { }
        public virtual void DoPrint() { }
        public virtual void DoExport() { }
        public virtual void DoDelete() { }
        public virtual void DoActive() { }
        public virtual void DoInActive() { }
        public virtual void DoCancel() { }
        public virtual void DoSave() { }

    }

}
