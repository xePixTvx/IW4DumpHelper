using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;

using IW4DumpHelperWinForms.DEV;
using IW4DumpHelperWinForms.Info;


//LAST WORKED ON: DO DB STUFF ASYNC????

namespace IW4DumpHelperWinForms
{
    public partial class MainForm : Form
    {
        private ConsoleController CMD;
        private DatabaseController DB;

        //DEV
        private DatabaseStuff DB_DEV;

        //Map List
        private List<MapInfo> Maps;

        public MainForm()
        {
            InitializeComponent();

            //Init Console Controller
            CMD = new ConsoleController(ConsoleTextBox);

            //Init Database Controller
            DB = new DatabaseController();

            //DEV
            DB_DEV = new DatabaseStuff(DB, CMD);

            //Console Welcome Msg
            CMD.Println("IW4DumpHelper By P!X");

            //Check if Database file exists otherwise exit program
            if(!File.Exists(Path.Combine(Environment.CurrentDirectory,"DumpHelperDB.db")))
            {
                DialogResult DBNotFoundMsg = MessageBox.Show("ERROR!", "Database not found!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if(DBNotFoundMsg == DialogResult.OK)
                {
                    Environment.Exit(0);
                }
            }


            //Check for DevMode
            if(!Program.DeveloperMode)
            {
                tabControl_Main.TabPages.Remove(tabControl_Main.TabPages[0]);
            }
            else
            {
                if (!Directory.Exists(Path.Combine(Environment.CurrentDirectory,"dev")))
                {
                    DialogResult DevFolderNotFoundMsg = MessageBox.Show("ERROR!", "Developer Folder Not Found!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (DevFolderNotFoundMsg == DialogResult.OK)
                    {
                        Environment.Exit(0);
                    }
                }
            }







            //Load Map Infos from Database
            Maps = DB.GetMapsFromDB();

            //Update Map Selection Combobox
            UpdateMapSelectionComboboxItems();


        }

        //Console Tab
        #region Console Tab Forms
        private void Button_Console_Clear_Click(object sender, EventArgs e)
        {
            CMD.Clear(true);
        }

        private void Button_Console_Save_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Unfinished!", "Unfinished Feature!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion Console Forms

        //Database Tab = DEV ONLY
        #region Database Tab Forms
        private void button_LoadDBInfo_Click(object sender, EventArgs e)
        {
            //Update Connection String Label
            label_ConnectionStringInfo.Text = DB.GetConnectionString();

            //Get All Table Names
            List<string> TableNames = DB_DEV.DEV_GetAllTableNames();

            //Update Table Count Label
            label_TableCountInfo.Text = TableNames.Count.ToString();

            //Clear Grid
            dataGridView_DB_Tables.Rows.Clear();

            //Add Grid Rows
            foreach (string name in TableNames)
            {
                dataGridView_DB_Tables.Rows.Add(name, DB_DEV.DEV_GetTableItemCount(name));
            }







            CMD.Println("Database Info Loaded!");
        }

        private void button_DB_Clear_Click(object sender, EventArgs e)
        {
            DialogResult AYS = MessageBox.Show("Clear Database?", "Are You Sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (AYS == DialogResult.No)
            {
                return;
            }
            tabControl_Main.SelectedTab = tabPage_Console;
            CMD.Println("DEV: Clearing Database!");
            DB_DEV.DEV_ClearDataBase();
            MessageBox.Show("Database Cleared!", "DEV INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void button_DB_AddMaps_Click(object sender, EventArgs e)
        {
            DialogResult AYS = MessageBox.Show("This may take some time!", "Are You Sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (AYS == DialogResult.No)
            {
                return;
            }
            tabControl_Main.SelectedTab = tabPage_Console;
            CMD.Println("DEV: Updating Maps Table!");
            DB_DEV.DEV_AddMapsToMapsTable();
            MessageBox.Show("Maps Table Updated!", "DEV INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void button_DB_AddWeaponMapTables_Click(object sender, EventArgs e)
        {
            DialogResult AYS = MessageBox.Show("This may take some time!", "Are You Sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (AYS == DialogResult.No)
            {
                return;
            }
            tabControl_Main.SelectedTab = tabPage_Console;
            CMD.Println("DEV: Updating Weapon Tables!");
            DB_DEV.DEV_AddWeaponsToDB();
            MessageBox.Show("Weapon Tables Updated!", "DEV INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button_DB_Test_Click(object sender, EventArgs e)
        {
        }

        #endregion Database Tab Forms

        //Weapons Tab
        #region Weapons Tab Forms

        //Update Current map selection combobox items/options
        private void UpdateMapSelectionComboboxItems()
        {
            comboBox_Weapons_MapSelection.DataSource = Maps;
            comboBox_Weapons_MapSelection.DisplayMember = "ID";
            CMD.Println("Map Selection Combobox Updated!");
        }

        //Load Current Map Weapons into the datagrid
        private void Button_Weapons_LoadSelectedMap_Click(object sender, EventArgs e)
        {
            //Selected map infos
            MapInfo currentInfo = comboBox_Weapons_MapSelection.SelectedItem as MapInfo;

            //Current Map Id
            string MapId = "";
            if (currentInfo.TYPE == "MP")
            {
                MapId = "MULTIPLAYER";
            }
            else
            {
                MapId = currentInfo.ID;
            }

            //Weapon Count
            int wepCount = 0;

            //weapon infos for selected map
            List<WeaponInfo> weapons = DB.GetWeaponInfosFromDBTable(currentInfo);


            //Clear Grid Rows
            dataGridView_Weapons.Rows.Clear();

            //Add rows
            foreach (WeaponInfo weapon in weapons)
            {
                dataGridView_Weapons.Rows.Add(((weapon.MAP.TYPE == "MP") ? MapId : weapon.MAP.ID), weapon.ID, weapon.LOCALIZEDSTRING, weapon.WEAPONCLASS);
                wepCount++;
            }

            CMD.Println("WeaponGrid loaded for Map: " + MapId + "(" + wepCount + " Weapons)");
        }



        #endregion Weapons Tab Forms


    }
}
