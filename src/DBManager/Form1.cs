using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using DBManager.DB;
using DBManager.DB.Scanning;
using DBManager.Infos;


//LAST WORKED ON: Start with Weapons Tab

namespace DBManager
{
    public partial class MainForm : Form
    {
        //Console Imports
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        //DB Controller
        private DBController DB_CTRL;

        public MainForm()
        {
            InitializeComponent();

            //Init DB Controller
            DB_CTRL = new DBController();
        }


        private void MainForm_Load(object sender, EventArgs e)
        {
            //Setup Win Console
            AllocConsole();
            Console.Title = "Database Manager - Console";

            //DB File doesnt exists
            if(!File.Exists(Path.Combine(Environment.CurrentDirectory, "DumpHelperDB.db")))
            {
                DialogResult ERRORMSG = MessageBox.Show("ERROR!", "Database File Not Found!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (ERRORMSG == DialogResult.OK)
                {
                    Environment.Exit(0);
                }
            }
        }



        //On Tab Changed
        private void tabControl_Main_SelectedIndexChanged(object sender, EventArgs e)
        {
            string CurrentPage = tabControl_Main.SelectedTab.Text;

            switch (CurrentPage)
            {
                case "Maps":
                    UpdateMapsTabInfos();
                break;

                case "Weapons":
                    Console.WriteLine("Weapons Tab Selected!");
                break;
            }
        }


        #region Overview Tab Page

        //Load Database Infos Button
        private void button_overview_loadDBInfos_Click(object sender, EventArgs e)
        {
            //Update Connection String Info Label
            label_info_connectionString.Text = DB_CTRL.GetConnectionString();

            //Get All Table Names
            List<string> TableNames = DB_CTRL.GetAllTableNames();

            //Update Table Count Info Label
            label_info_tableCount.Text = TableNames.Count.ToString();

            //Clear Table Overview Grid
            dataGridView_Info_DB_Tables.Rows.Clear();

            //Add Rows to Table Overview Grid
            foreach (string name in TableNames)
            {
                dataGridView_Info_DB_Tables.Rows.Add(name, DB_CTRL.GetTableItemCount(name));
            }

            Console.WriteLine("Database Infos Loaded!");
        }

        //Clear Database Button
        private void button_overview_clearDatabase_Click(object sender, EventArgs e)
        {
            DialogResult AYS = MessageBox.Show("Clear Database?", "Are You Sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (AYS == DialogResult.No)
            {
                return;
            }
            DB_CTRL.ClearDataBase();
            MessageBox.Show("Database Cleared!", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion Overview Tab Page


        #region Maps Tab Page

        //Update Infos
        private void UpdateMapsTabInfos()
        {
            //Load Maps from Database
            List<Infos.MapInfo> DB_Maps = DB_CTRL.GetMapsFromDB();

            if (DB_Maps == null)
            {
                label_info_MapsTab_TableItemCount.Text = "-";
                label_info_MapsTab_SPMapsCount.Text = "-";
                label_info_MapsTab_SOMapsCount.Text = "-";
                label_info_MapsTab_MPMapsCount.Text = "-";
                dataGridView_Info_Maps_Table.Rows.Clear();
            }
            else
            {
                //Update Table Item Count Info Label
                label_info_MapsTab_TableItemCount.Text = DB_Maps.Count.ToString();

                //Update SP,SO and MP Count Info Labels
                int SP_Count = 0;
                int SO_Count = 0;
                int MP_Count = 0;
                foreach (MapInfo mInfo in DB_Maps)
                {
                    //Add DatagridView Row
                    dataGridView_Info_Maps_Table.Rows.Add(mInfo.ID, mInfo.TYPE, mInfo.HAS_ALT_PATH, mInfo.ALT_PATH);

                    //Count Types
                    switch (mInfo.TYPE)
                    {
                        case ClientTypes.SP:
                            SP_Count++;
                            break;

                        case ClientTypes.SO:
                            SO_Count++;
                            break;

                        case ClientTypes.MP:
                            MP_Count++;
                            break;
                    }
                }
                label_info_MapsTab_SPMapsCount.Text = SP_Count.ToString();
                label_info_MapsTab_SOMapsCount.Text = SO_Count.ToString();
                label_info_MapsTab_MPMapsCount.Text = MP_Count.ToString();
            }

            Console.WriteLine("Infos: Maps Updated!");
        }


        //Clear Maps Table
        private void button_maps_clearTable_Click(object sender, EventArgs e)
        {
            DialogResult AYS = MessageBox.Show("Clear Maps Table?", "Are You Sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (AYS == DialogResult.No)
            {
                return;
            }
            DB_CTRL.DeleteTable("maps");
            MessageBox.Show("Maps Table Cleared!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            UpdateMapsTabInfos();
        }

        //Update Maps Table
        private void button_maps_updateTable_Click(object sender, EventArgs e)
        {
            DialogResult AYS = MessageBox.Show("Update Maps Table? \n This may take some time!", "Are You Sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (AYS == DialogResult.No)
            {
                return;
            }
            MapScanner Scanner = new MapScanner();
            List<MapInfo> Maps = Scanner.ScanMaps();
            DB_CTRL.UpdateMapsTable(Maps);
            MessageBox.Show("Maps Table Updated!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            UpdateMapsTabInfos();
        }
        #endregion Maps Tab Page
    }
}
