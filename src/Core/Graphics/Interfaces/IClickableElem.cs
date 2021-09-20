using System;

namespace IW4DumpHelperGUI.Core.Graphics.Interfaces
{
    public interface IClickableElem
    {
        bool IsSelected { get; set; }
        Action Action { get; set; }
        void UpdateSelection();
        void ExecuteAction();
    }
}
