using System.Collections.Generic;
using System.Linq;
using IW4DumpHelperGUI.Core.Graphics.Interfaces;

namespace IW4DumpHelperGUI.Core
{
    public class RenderManager
    {
        private List<IRenderableElem> RenderList = new List<IRenderableElem>();

        public RenderManager()
        {
            RenderList.Clear();
        }

        //Return RenderList
        public List<IRenderableElem> GetRenderList()
        {
            return RenderList;
        }

        //Add Elem to RenderList
        public void AddToList(IRenderableElem elem)
        {
            foreach(IRenderableElem e in RenderList)//maybe remove this check
            {
                if(elem.Name == e.Name)
                {
                    App.Log.Print("Elem with Name: " + elem.Name + " already exsists!", Logging.LogTypes.ERROR);
                    return;
                }
            }
            RenderList.Add(elem);
            SortList();
        }

        //Remove Elem from RenderList
        public void RemoveFromList(IRenderableElem elem)
        {
            RenderList.Remove(elem);
            SortList();
        }

        //Sort RenderList by Elems RenderLayer(0 gets drawn first, 1 next and so on)
        public void SortList()
        {
            List<IRenderableElem> sortedList = RenderList.OrderBy(e => e.RenderLayer).ToList();
            RenderList = sortedList;
        }

        //Search a elem by its name
        public IRenderableElem GetElemByName(string ElemName)
        {
            foreach (IRenderableElem elem in RenderList)
            {
                if (elem.Name == ElemName)
                {
                    return elem;
                }
            }
            return null;
        }

        //Update and render elems
        public void Render()
        {
            foreach (IRenderableElem elem in RenderList)
            {
                if (elem.IsActive)
                {
                    if (elem.NeedsUpdate)
                    {
                        elem.Update();
                    }

                    if (elem is IClickableElem clickElem)
                    {
                        clickElem.UpdateSelection();
                    }

                    if (elem.IsVisible)
                    {
                        elem.Render();
                    }
                }
            }
        }
    }
}
