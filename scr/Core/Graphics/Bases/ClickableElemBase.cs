using System;
using IW4DumpHelperGUI.Core.Graphics.Interfaces;

namespace IW4DumpHelperGUI.Core.Graphics.Bases
{
    public class ClickableElemBase : RenderableElemBase, IClickableElem
    {
        private bool _IsSelected = false;
        private Action _Action = null;

        public virtual bool IsSelected
        {
            get { return _IsSelected; }
            set { _IsSelected = value; }
        }

        public virtual Action Action
        {
            get { return _Action; }
            set { _Action = value; }
        }

        public virtual void UpdateSelection()
        {
            App.Log.Print("UpdateSelection() not defined for " + Name, Logging.LogTypes.WARNING);
        }

        public virtual void ExecuteAction()
        {
            if (Action == null)
            {
                App.Log.Print("Action not defined for " + Name, Logging.LogTypes.WARNING);
            }
            else
            {
                Action();
            }
        }
    }
}
