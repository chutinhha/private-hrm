using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HS.UI.Base
{
    public interface IEditableForm
    {
        void DoAdd();
        void DoEdit();
        void DoSave();
        void DoCancel();
        void DoDelete();
        void DoActive();
        void DoInActive();
        void DoPrint();
        void DoExport();
    }
}
