using System.Collections.Generic;
using SFML.Graphics;
using SFML.System;
using IW4DumpHelperGUI.Core.Graphics;

namespace IW4DumpHelperGUI.Menus
{
    class Menu
    {
        public string CurrentMenu { private set; get; } = "main";

        private RectElem TitleRect;
        private TextElem TitleText;


        private Dictionary<string, string> MenuTitles = new Dictionary<string, string>();
        private List<MenuButton> Buttons = new List<MenuButton>();

        public Menu()
        {

            //Create Menu Title
            Vector2f POS_LEFT_TOP = ElemUtils.GetPositionOnScreen(Alignment.LEFT_TOP);
            float Pos_Y = 50;
            TitleRect = new RectElem(CurrentMenu + "_menu_title_rect", Alignment.LEFT_CENTER, POS_LEFT_TOP.X, POS_LEFT_TOP.Y + 50, 420, 40, new Color(0, 0, 0, 180));
            TitleText = new TextElem(CurrentMenu + "_menu_title_text", Alignment.RIGHT_CENTER, POS_LEFT_TOP.X, Pos_Y, new Color(255, 255, 255, 255), "capture", 18, Text.Styles.Regular, "");
            TitleRect.RenderLayer = 2;
            TitleText.RenderLayer = 3;
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



            //Create Main Menu
            MenuTitles.Add("main", "IW4DUMPHELPER BY P!X");
            Buttons.Add(new MenuButton("mainMenu_Button_Weapons", "main", 0, "Weapons", LoadMenu_Weapons));
            Buttons.Add(new MenuButton("mainMenu_Button_Vehicles", "main", 1, "Vehicles"));
            Buttons.Add(new MenuButton("mainMenu_Button_Scripts", "main", 2, "Scripts"));
            Buttons.Add(new MenuButton("mainMenu_Button_Settings", "main", 3, "Settings", LoadMenu_Settings));
            Buttons.Add(new MenuButton("mainMenu_Button_Exit", "main", 4, "Exit", ExitApp));



            //Create Weapons Main Menu
            MenuTitles.Add("weps_main", "Weapons");
            Buttons.Add(new MenuButton("WeaponsMainMenu_Button_ScanWeapons", "weps_main", 0, "Scan Weapons"));
            Buttons.Add(new MenuButton("WeaponsMainMenu_Button_ConvertAllToGsc", "weps_main", 1, "Convert Weapons to GSC[ALL]"));
            Buttons.Add(new MenuButton("WeaponsMainMenu_Button_ConvertMapsToGsc", "weps_main", 2, "Convert Weapons to GSC[MAP]"));
            Buttons.Add(new MenuButton("WeaponsMainMenu_Button_ConvertAllToInfo", "weps_main", 3, "Convert Weapons to Info[ALL]"));
            Buttons.Add(new MenuButton("WeaponsMainMenu_Button_Back", "weps_main", 4, "BACK", LoadMenuMain));


            //Create Settings Menu
            MenuTitles.Add("settings_main", "Settings");
            Buttons.Add(new MenuButton("SettingsMainMenu_Button_ClearLogBackups", "settings_main", 0, "Clear LOG Backups", IW4DumpHelper.Log.ClearLogFiles));
            Buttons.Add(new MenuButton("SettingsMainMenu_Button_Back", "settings_main", 1, "BACK", LoadMenuMain));




            //Lock Some Options
            GetMenuButtonByName("mainMenu_Button_Vehicles", "main").Lock();
            GetMenuButtonByName("mainMenu_Button_Scripts", "main").Lock();

            GetMenuButtonByName("WeaponsMainMenu_Button_ConvertAllToGsc", "weps_main").Lock();
            GetMenuButtonByName("WeaponsMainMenu_Button_ConvertMapsToGsc", "weps_main").Lock();
            GetMenuButtonByName("WeaponsMainMenu_Button_ConvertAllToInfo", "weps_main").Lock();

            //Test Progress Stuff
            MenuButton tmp_testButton = GetMenuButtonByName("mainMenu_Button_Weapons", "main");
            tmp_testButton.ProgressbarShow();
            tmp_testButton.ChangeProgress(50);




            //Load Main Menu
            ChangeMenu("main");

            IW4DumpHelper.Log.Print("Menus Loaded!");
        }

        //Change/Update Current Menu Title
        private void ChangeMenuTitle(string title)
        {
            //Update Text
            TitleText.String = title;

            //Update Positions
            Vector2f POS_LEFT_TOP = ElemUtils.GetPositionOnScreen(Alignment.LEFT_TOP);
            float Pos_Y = 50;
            TitleText.Position = new Vector2f((POS_LEFT_TOP.X + TitleRect.Size.X) - 10, Pos_Y - 3);
        }


        //Get Menu Buttons by Name and/or Menu
        public MenuButton GetMenuButtonByName(string name)
        {
            foreach(MenuButton button in Buttons)
            {
                if(button.ButtonName == name)
                {
                    return button;
                }
            }
            return null;
        }
        public MenuButton GetMenuButtonByName(string name, string menuName)
        {
            foreach (MenuButton button in Buttons)
            {
                if(button.MenuName == menuName)
                {
                    if (button.ButtonName == name)
                    {
                        return button;
                    }
                }
            }
            return null;
        }


        //Change Current Menu
        private void ChangeMenu(string menu)
        {
            CurrentMenu = menu;


            //Get & Set Menu Title
            foreach (KeyValuePair<string,string> menuTitle in MenuTitles)
            {
                if(menuTitle.Key == CurrentMenu)
                {
                    ChangeMenuTitle(menuTitle.Value);
                }
            }

            //Update Buttons
            foreach(MenuButton button in Buttons)
            {
                if(button.MenuName != CurrentMenu)
                {
                    button.Hide();
                }
                else
                {
                    button.Show();
                }
            }
        }



        private void ExitApp()
        {
            IW4DumpHelper.Exit();
        }

        //Some Test function
        private void TestMenuAction()
        {
            /*GetMenuButtonByName("WeaponsMainMenu_Button_ConvertAllToGsc", "weps_main").Unlock();
            GetMenuButtonByName("WeaponsMainMenu_Button_ConvertMapsToGsc", "weps_main").Unlock();
            GetMenuButtonByName("WeaponsMainMenu_Button_ConvertAllToInfo", "weps_main").Unlock();*/
        }


        //Load Menu Functions
        private void LoadMenuMain()
        {
            ChangeMenu("main");
        }
        private void LoadMenu_Weapons()
        {
            ChangeMenu("weps_main");
        }
        private void LoadMenu_Settings()
        {
            ChangeMenu("settings_main");
        }

    }
}
