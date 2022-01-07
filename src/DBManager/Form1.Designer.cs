
namespace DBManager
{
    partial class MainForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl_Main = new System.Windows.Forms.TabControl();
            this.tabPage_Overview = new System.Windows.Forms.TabPage();
            this.button_overview_clearDatabase = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView_Info_DB_Tables = new System.Windows.Forms.DataGridView();
            this.table_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.table_itemCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button_overview_loadDBInfos = new System.Windows.Forms.Button();
            this.label_info_tableCount = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label_info_connectionString = new System.Windows.Forms.Label();
            this.info_label1 = new System.Windows.Forms.Label();
            this.tabPage_Maps = new System.Windows.Forms.TabPage();
            this.button_maps_clearTable = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label_info_MapsTab_MPMapsCount = new System.Windows.Forms.Label();
            this.label_info_MapsTab_SOMapsCount = new System.Windows.Forms.Label();
            this.label_info_MapsTab_SPMapsCount = new System.Windows.Forms.Label();
            this.label_info_MapsTab_TableItemCount = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPage_Weapons = new System.Windows.Forms.TabPage();
            this.button_maps_updateTable = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dataGridView_Info_Maps_Table = new System.Windows.Forms.DataGridView();
            this.MAP_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CLIENT_TYPE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HAS_ALTERNATE_RAWFILE_PATH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ALTERNATE_RAWFILE_PATH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl_Main.SuspendLayout();
            this.tabPage_Overview.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Info_DB_Tables)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tabPage_Maps.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Info_Maps_Table)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl_Main
            // 
            this.tabControl_Main.Controls.Add(this.tabPage_Overview);
            this.tabControl_Main.Controls.Add(this.tabPage_Maps);
            this.tabControl_Main.Controls.Add(this.tabPage_Weapons);
            this.tabControl_Main.Location = new System.Drawing.Point(12, 12);
            this.tabControl_Main.Name = "tabControl_Main";
            this.tabControl_Main.SelectedIndex = 0;
            this.tabControl_Main.Size = new System.Drawing.Size(1119, 624);
            this.tabControl_Main.TabIndex = 0;
            this.tabControl_Main.SelectedIndexChanged += new System.EventHandler(this.tabControl_Main_SelectedIndexChanged);
            // 
            // tabPage_Overview
            // 
            this.tabPage_Overview.Controls.Add(this.button_overview_clearDatabase);
            this.tabPage_Overview.Controls.Add(this.groupBox2);
            this.tabPage_Overview.Controls.Add(this.groupBox1);
            this.tabPage_Overview.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Overview.Name = "tabPage_Overview";
            this.tabPage_Overview.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Overview.Size = new System.Drawing.Size(1111, 598);
            this.tabPage_Overview.TabIndex = 0;
            this.tabPage_Overview.Text = "Overview";
            this.tabPage_Overview.UseVisualStyleBackColor = true;
            // 
            // button_overview_clearDatabase
            // 
            this.button_overview_clearDatabase.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_overview_clearDatabase.Location = new System.Drawing.Point(438, 6);
            this.button_overview_clearDatabase.Name = "button_overview_clearDatabase";
            this.button_overview_clearDatabase.Size = new System.Drawing.Size(155, 33);
            this.button_overview_clearDatabase.TabIndex = 8;
            this.button_overview_clearDatabase.Text = "Clear Database";
            this.button_overview_clearDatabase.UseVisualStyleBackColor = true;
            this.button_overview_clearDatabase.Click += new System.EventHandler(this.button_overview_clearDatabase_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridView_Info_DB_Tables);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(6, 181);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1093, 411);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Table Overview:";
            // 
            // dataGridView_Info_DB_Tables
            // 
            this.dataGridView_Info_DB_Tables.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_Info_DB_Tables.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView_Info_DB_Tables.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dataGridView_Info_DB_Tables.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Info_DB_Tables.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.table_ID,
            this.table_itemCount});
            this.dataGridView_Info_DB_Tables.Location = new System.Drawing.Point(6, 19);
            this.dataGridView_Info_DB_Tables.Name = "dataGridView_Info_DB_Tables";
            this.dataGridView_Info_DB_Tables.ReadOnly = true;
            this.dataGridView_Info_DB_Tables.RowHeadersVisible = false;
            this.dataGridView_Info_DB_Tables.RowHeadersWidth = 150;
            this.dataGridView_Info_DB_Tables.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView_Info_DB_Tables.Size = new System.Drawing.Size(1081, 386);
            this.dataGridView_Info_DB_Tables.TabIndex = 6;
            // 
            // table_ID
            // 
            this.table_ID.HeaderText = "Table ID";
            this.table_ID.Name = "table_ID";
            this.table_ID.ReadOnly = true;
            // 
            // table_itemCount
            // 
            this.table_itemCount.HeaderText = "Table Item Count";
            this.table_itemCount.Name = "table_itemCount";
            this.table_itemCount.ReadOnly = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button_overview_loadDBInfos);
            this.groupBox1.Controls.Add(this.label_info_tableCount);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label_info_connectionString);
            this.groupBox1.Controls.Add(this.info_label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(426, 169);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Infos: Database Overview";
            // 
            // button_overview_loadDBInfos
            // 
            this.button_overview_loadDBInfos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_overview_loadDBInfos.Location = new System.Drawing.Point(6, 130);
            this.button_overview_loadDBInfos.Name = "button_overview_loadDBInfos";
            this.button_overview_loadDBInfos.Size = new System.Drawing.Size(414, 33);
            this.button_overview_loadDBInfos.TabIndex = 4;
            this.button_overview_loadDBInfos.Text = "Load Infos";
            this.button_overview_loadDBInfos.UseVisualStyleBackColor = true;
            this.button_overview_loadDBInfos.Click += new System.EventHandler(this.button_overview_loadDBInfos_Click);
            // 
            // label_info_tableCount
            // 
            this.label_info_tableCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_info_tableCount.Location = new System.Drawing.Point(116, 43);
            this.label_info_tableCount.Name = "label_info_tableCount";
            this.label_info_tableCount.Size = new System.Drawing.Size(304, 21);
            this.label_info_tableCount.TabIndex = 3;
            this.label_info_tableCount.Text = "0";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "Table Count:";
            // 
            // label_info_connectionString
            // 
            this.label_info_connectionString.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_info_connectionString.Location = new System.Drawing.Point(116, 22);
            this.label_info_connectionString.Name = "label_info_connectionString";
            this.label_info_connectionString.Size = new System.Drawing.Size(304, 21);
            this.label_info_connectionString.TabIndex = 1;
            this.label_info_connectionString.Text = "-";
            // 
            // info_label1
            // 
            this.info_label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.info_label1.Location = new System.Drawing.Point(0, 22);
            this.info_label1.Name = "info_label1";
            this.info_label1.Size = new System.Drawing.Size(110, 21);
            this.info_label1.TabIndex = 0;
            this.info_label1.Text = "Connection String:";
            // 
            // tabPage_Maps
            // 
            this.tabPage_Maps.Controls.Add(this.groupBox4);
            this.tabPage_Maps.Controls.Add(this.button_maps_updateTable);
            this.tabPage_Maps.Controls.Add(this.button_maps_clearTable);
            this.tabPage_Maps.Controls.Add(this.groupBox3);
            this.tabPage_Maps.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Maps.Name = "tabPage_Maps";
            this.tabPage_Maps.Size = new System.Drawing.Size(1111, 598);
            this.tabPage_Maps.TabIndex = 2;
            this.tabPage_Maps.Text = "Maps";
            this.tabPage_Maps.UseVisualStyleBackColor = true;
            // 
            // button_maps_clearTable
            // 
            this.button_maps_clearTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_maps_clearTable.Location = new System.Drawing.Point(435, 3);
            this.button_maps_clearTable.Name = "button_maps_clearTable";
            this.button_maps_clearTable.Size = new System.Drawing.Size(155, 33);
            this.button_maps_clearTable.TabIndex = 9;
            this.button_maps_clearTable.Text = "Clear Table";
            this.button_maps_clearTable.UseVisualStyleBackColor = true;
            this.button_maps_clearTable.Click += new System.EventHandler(this.button_maps_clearTable_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label_info_MapsTab_MPMapsCount);
            this.groupBox3.Controls.Add(this.label_info_MapsTab_SOMapsCount);
            this.groupBox3.Controls.Add(this.label_info_MapsTab_SPMapsCount);
            this.groupBox3.Controls.Add(this.label_info_MapsTab_TableItemCount);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(426, 110);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Infos: Maps";
            // 
            // label_info_MapsTab_MPMapsCount
            // 
            this.label_info_MapsTab_MPMapsCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_info_MapsTab_MPMapsCount.Location = new System.Drawing.Point(116, 85);
            this.label_info_MapsTab_MPMapsCount.Name = "label_info_MapsTab_MPMapsCount";
            this.label_info_MapsTab_MPMapsCount.Size = new System.Drawing.Size(304, 21);
            this.label_info_MapsTab_MPMapsCount.TabIndex = 9;
            this.label_info_MapsTab_MPMapsCount.Text = "-";
            // 
            // label_info_MapsTab_SOMapsCount
            // 
            this.label_info_MapsTab_SOMapsCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_info_MapsTab_SOMapsCount.Location = new System.Drawing.Point(116, 64);
            this.label_info_MapsTab_SOMapsCount.Name = "label_info_MapsTab_SOMapsCount";
            this.label_info_MapsTab_SOMapsCount.Size = new System.Drawing.Size(304, 21);
            this.label_info_MapsTab_SOMapsCount.TabIndex = 8;
            this.label_info_MapsTab_SOMapsCount.Text = "-";
            // 
            // label_info_MapsTab_SPMapsCount
            // 
            this.label_info_MapsTab_SPMapsCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_info_MapsTab_SPMapsCount.Location = new System.Drawing.Point(116, 43);
            this.label_info_MapsTab_SPMapsCount.Name = "label_info_MapsTab_SPMapsCount";
            this.label_info_MapsTab_SPMapsCount.Size = new System.Drawing.Size(304, 21);
            this.label_info_MapsTab_SPMapsCount.TabIndex = 7;
            this.label_info_MapsTab_SPMapsCount.Text = "-";
            // 
            // label_info_MapsTab_TableItemCount
            // 
            this.label_info_MapsTab_TableItemCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_info_MapsTab_TableItemCount.Location = new System.Drawing.Point(116, 22);
            this.label_info_MapsTab_TableItemCount.Name = "label_info_MapsTab_TableItemCount";
            this.label_info_MapsTab_TableItemCount.Size = new System.Drawing.Size(304, 21);
            this.label_info_MapsTab_TableItemCount.TabIndex = 6;
            this.label_info_MapsTab_TableItemCount.Text = "-";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(0, 85);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 21);
            this.label5.TabIndex = 5;
            this.label5.Text = "MP Maps:";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(0, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 21);
            this.label4.TabIndex = 4;
            this.label4.Text = "SO Maps:";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(0, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "SP Maps:";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(0, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 21);
            this.label3.TabIndex = 2;
            this.label3.Text = "Table Item Count:";
            // 
            // tabPage_Weapons
            // 
            this.tabPage_Weapons.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Weapons.Name = "tabPage_Weapons";
            this.tabPage_Weapons.Size = new System.Drawing.Size(1111, 598);
            this.tabPage_Weapons.TabIndex = 1;
            this.tabPage_Weapons.Text = "Weapons";
            this.tabPage_Weapons.UseVisualStyleBackColor = true;
            // 
            // button_maps_updateTable
            // 
            this.button_maps_updateTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_maps_updateTable.Location = new System.Drawing.Point(435, 42);
            this.button_maps_updateTable.Name = "button_maps_updateTable";
            this.button_maps_updateTable.Size = new System.Drawing.Size(155, 33);
            this.button_maps_updateTable.TabIndex = 10;
            this.button_maps_updateTable.Text = "Update Table";
            this.button_maps_updateTable.UseVisualStyleBackColor = true;
            this.button_maps_updateTable.Click += new System.EventHandler(this.button_maps_updateTable_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dataGridView_Info_Maps_Table);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(6, 119);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1093, 476);
            this.groupBox4.TabIndex = 11;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Maps Table:";
            // 
            // dataGridView_Info_Maps_Table
            // 
            this.dataGridView_Info_Maps_Table.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_Info_Maps_Table.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView_Info_Maps_Table.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dataGridView_Info_Maps_Table.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Info_Maps_Table.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MAP_ID,
            this.CLIENT_TYPE,
            this.HAS_ALTERNATE_RAWFILE_PATH,
            this.ALTERNATE_RAWFILE_PATH});
            this.dataGridView_Info_Maps_Table.Location = new System.Drawing.Point(6, 19);
            this.dataGridView_Info_Maps_Table.Name = "dataGridView_Info_Maps_Table";
            this.dataGridView_Info_Maps_Table.ReadOnly = true;
            this.dataGridView_Info_Maps_Table.RowHeadersVisible = false;
            this.dataGridView_Info_Maps_Table.RowHeadersWidth = 150;
            this.dataGridView_Info_Maps_Table.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView_Info_Maps_Table.Size = new System.Drawing.Size(1081, 451);
            this.dataGridView_Info_Maps_Table.TabIndex = 6;
            // 
            // MAP_ID
            // 
            this.MAP_ID.HeaderText = "MAP ID";
            this.MAP_ID.Name = "MAP_ID";
            this.MAP_ID.ReadOnly = true;
            // 
            // CLIENT_TYPE
            // 
            this.CLIENT_TYPE.HeaderText = "CLIENT TYPE";
            this.CLIENT_TYPE.Name = "CLIENT_TYPE";
            this.CLIENT_TYPE.ReadOnly = true;
            // 
            // HAS_ALTERNATE_RAWFILE_PATH
            // 
            this.HAS_ALTERNATE_RAWFILE_PATH.HeaderText = "HAS ALT PATH";
            this.HAS_ALTERNATE_RAWFILE_PATH.Name = "HAS_ALTERNATE_RAWFILE_PATH";
            this.HAS_ALTERNATE_RAWFILE_PATH.ReadOnly = true;
            // 
            // ALTERNATE_RAWFILE_PATH
            // 
            this.ALTERNATE_RAWFILE_PATH.HeaderText = "ALT PATH";
            this.ALTERNATE_RAWFILE_PATH.Name = "ALTERNATE_RAWFILE_PATH";
            this.ALTERNATE_RAWFILE_PATH.ReadOnly = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1143, 648);
            this.Controls.Add(this.tabControl_Main);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "IW4DumpHelper Database Manager";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tabControl_Main.ResumeLayout(false);
            this.tabPage_Overview.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Info_DB_Tables)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.tabPage_Maps.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Info_Maps_Table)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl_Main;
        private System.Windows.Forms.TabPage tabPage_Overview;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_info_connectionString;
        private System.Windows.Forms.Label info_label1;
        private System.Windows.Forms.Label label_info_tableCount;
        private System.Windows.Forms.Button button_overview_loadDBInfos;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridView_Info_DB_Tables;
        private System.Windows.Forms.DataGridViewTextBoxColumn table_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn table_itemCount;
        private System.Windows.Forms.Button button_overview_clearDatabase;
        private System.Windows.Forms.TabPage tabPage_Weapons;
        private System.Windows.Forms.TabPage tabPage_Maps;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label_info_MapsTab_MPMapsCount;
        private System.Windows.Forms.Label label_info_MapsTab_SOMapsCount;
        private System.Windows.Forms.Label label_info_MapsTab_SPMapsCount;
        private System.Windows.Forms.Label label_info_MapsTab_TableItemCount;
        private System.Windows.Forms.Button button_maps_clearTable;
        private System.Windows.Forms.Button button_maps_updateTable;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView dataGridView_Info_Maps_Table;
        private System.Windows.Forms.DataGridViewTextBoxColumn MAP_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CLIENT_TYPE;
        private System.Windows.Forms.DataGridViewTextBoxColumn HAS_ALTERNATE_RAWFILE_PATH;
        private System.Windows.Forms.DataGridViewTextBoxColumn ALTERNATE_RAWFILE_PATH;
    }
}

