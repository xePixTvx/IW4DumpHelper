using IW4DumpHelperGUI.Core.Graphics.Interfaces;

namespace IW4DumpHelperGUI.Core.Graphics.Bases
{
    public class RenderableElemBase : IRenderableElem
    {
        private string _Name = "UNDEFINED_NAME";
        private int _RenderLayer = 0;
        private bool _IsActive = true;
        private bool _IsVisible = true;
        private bool _NeedsUpdate = false;

        public virtual string Name
        {
            get
            {
                if (_Name == "UNDEFINED_NAME")
                {
                    App.Log.Print("Name not defined for " + this, Logging.LogTypes.WARNING);
                }
                return _Name;
            }
            set { _Name = value; }
        }

        public virtual int RenderLayer
        {
            get { return _RenderLayer; }
            set
            {
                _RenderLayer = value;
                App.Renderer.SortList();
            }
        }

        public virtual bool IsActive
        {
            get { return _IsActive; }
            set { _IsActive = value; }
        }

        public virtual bool IsVisible
        {
            get { return _IsVisible; }
            set { _IsVisible = value; }
        }

        public virtual bool NeedsUpdate
        {
            get { return _NeedsUpdate; }
            set { _NeedsUpdate = value; }
        }

        public virtual void Update()
        {
            App.Log.Print("Update() not defined for " + Name, Logging.LogTypes.WARNING);
        }

        public virtual void Render()
        {
            App.Log.Print("Render() not defined for " + Name, Logging.LogTypes.WARNING);
        }

        public virtual void Destroy()
        {
            App.Log.Print("Destroy() not defined for " + Name, Logging.LogTypes.WARNING);
        }

    }
}
