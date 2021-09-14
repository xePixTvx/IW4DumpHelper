using System;
using System.IO;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

using IW4DumpHelperGUI.Core.Assets;
using IW4DumpHelperGUI.Core.Logging;
using IW4DumpHelperGUI.Core.Graphics.Interfaces;

namespace IW4DumpHelperGUI.Core
{
    public abstract class App
    {
        //Window
        public static RenderWindow Window { get; private set; }
        public static VideoMode WindowSize { get; private set; }
        public Color WindowBackgroundColor { get; set; } = new Color(0, 0, 0);

        //Frame Time/Rate
        private Clock FrameTimeClock;
        private static uint FrameRateLimit = 60;
        private static float FrameTime;
        public static int FrameTicker { get; private set; }

        //Is App Active
        public static bool IsActive { get; private set; } = false;

        //Logger
        public static Logger Log;

        //App Update
        protected abstract void OnAppUpdate();

        //On App Close
        protected abstract void OnAppClosing();

        //Resource Folder
        public static string ResourceFolder { get; private set; } = Path.Combine(Environment.CurrentDirectory, "data");

        //Asset/Resource Manager
        public static AssetManager ResourceManager;

        //Renderer
        public static RenderManager Renderer;

        //Elem Click Clock
        private Clock ElemClickClock = new Clock();

        //Elem Click Wait Time(wait time between elem clicks in milliseconds)
        private float ElemClickWaitTime = 200;


        protected App(string ResourceFolderName, string WindowTitle, uint WindowWidth, uint WindowHeight)
        {
            //Set Resource Folder Path/Name
            ResourceFolder = Path.Combine(Environment.CurrentDirectory, ResourceFolderName);

            //Create Logger
            Log = new Logger(true, true);

            //Create Resource Manager
            ResourceManager = new AssetManager();

            //Set Window Size
            WindowSize = new VideoMode(WindowWidth, WindowHeight);

            //Create Window
            InitWindow(WindowTitle, Styles.Close);

            //Create Renderer
            Renderer = new RenderManager();
        }

        //Start App
        public void Start()
        {
            IsActive = true;
            MainLoop();
        }

        //Exit App
        public static void Exit()
        {
            Log.Print("Closing App!");
            IsActive = false;
        }


        //App Main Loop
        private void MainLoop()
        {
            Log.Print("App Main Loop Started!");
            FrameTimeClock = new Clock();
            while (IsActive)
            {
                Window.DispatchEvents();
                Window.Clear(WindowBackgroundColor);
                OnAppUpdate();
                Renderer.Render();
                Window.Display();
                FrameTime = FrameTimeClock.Restart().AsMilliseconds();
                FrameTicker++;//Not sure if i keep this
            }
            OnAppClosing();
            Log.Print("----------------- APP EXIT -----------------");
            Log.Print("LOGFUNC__EMPTY__LOGFUNC");
            Log.Print("LOGFUNC__EMPTY__LOGFUNC");
            Window.Close();
        }



        #region Frametime
        //Get Frametime
        public static float GetFrameTime()
        {
            return FrameTime;
        }

        //Get Fps
        public static uint GetFPS()
        {
            uint fps = FrameRateLimit * ((uint)FrameTime * FrameRateLimit) / 1000;
            return fps;
        }
        #endregion Frametime

        #region Init Window Stuff
        private void InitWindow(string title, Styles style)
        {
            Window = new RenderWindow(WindowSize, title, style);
            Window.SetVerticalSyncEnabled(false);
            Window.SetFramerateLimit(FrameRateLimit);

            InitWindowEventHandlers();

            Log.Print("Window Created(" + WindowSize.Width + "x" + WindowSize.Height + ")");
        }

        private void InitWindowEventHandlers()
        {
            Window.Closed += (_, __) => Exit();
            Window.MouseButtonReleased += new EventHandler<MouseButtonEventArgs>(OnMouseButtonReleased);
            Window.MouseButtonPressed += new EventHandler<MouseButtonEventArgs>(OnMouseButtonPressed);
            Window.KeyReleased += new EventHandler<KeyEventArgs>(OnKeyReleased);
            Window.KeyPressed += new EventHandler<KeyEventArgs>(OnKeyPressed);
            Window.MouseWheelScrolled += new EventHandler<MouseWheelScrollEventArgs>(OnMouseWheelScrolled);

            //Clickable Elems
            Window.MouseButtonPressed += new EventHandler<MouseButtonEventArgs>(OnMouseButtonPressed_ClickableElems);

            //Scrollable Elems
            Window.MouseWheelScrolled += new EventHandler<MouseWheelScrollEventArgs>(OnMouseWheelScrolled_ScrollableElems);
        }
        protected virtual void OnMouseButtonReleased(object sender, MouseButtonEventArgs e)
        {
        }
        protected virtual void OnMouseButtonPressed(object sender, MouseButtonEventArgs e)
        {
        }
        protected virtual void OnKeyReleased(object sender, KeyEventArgs e)
        {
        }
        protected virtual void OnKeyPressed(object sender, KeyEventArgs e)
        {
        }
        protected virtual void OnMouseWheelScrolled(object sender, MouseWheelScrollEventArgs e)
        {
        }
        public void OnMouseButtonPressed_ClickableElems(object sender, MouseButtonEventArgs e)
        {
            if (e.Button == Mouse.Button.Left)
            {
                foreach (IRenderableElem elem in Renderer.GetRenderList())
                {
                    if (elem.IsActive && elem is IClickableElem clickElem)
                    {
                        if (clickElem.IsSelected)
                        {
                            if(ElemClickClock.ElapsedTime.AsMilliseconds() >= ElemClickWaitTime)//a little wait between clicks is needed
                            {
                                clickElem.ExecuteAction();
                                ElemClickClock.Restart();
                            }
                        }
                    }
                }
            }
        }
        public void OnMouseWheelScrolled_ScrollableElems(object sender, MouseWheelScrollEventArgs e)
        {
            foreach (IRenderableElem elem in Renderer.GetRenderList())
            {
                if(elem.IsActive && elem is IScrollableElem scrollElem)
                {
                    scrollElem.UpdateMouseWheelMovement(e.Delta);
                }
            }
        }
        #endregion
    }
}
