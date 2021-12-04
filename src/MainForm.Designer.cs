
namespace IW4DumpHelperWinForms
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
            this.tabPage_Database = new System.Windows.Forms.TabPage();
            this.button_DB_Clear = new System.Windows.Forms.Button();
            this.button_DB_Test = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button_DB_AddWeaponMapTables = new System.Windows.Forms.Button();
            this.button_DB_AddMaps = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label_TableCountInfo = new System.Windows.Forms.Label();
            this.label_ConnectionStringInfo = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button_LoadDBInfo = new System.Windows.Forms.Button();
            this.tabPage_Weapons = new System.Windows.Forms.TabPage();
            this.dataGridView_Weapons = new System.Windows.Forms.DataGridView();
            this.col_wep_mapID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_wep_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_wep_locstring = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_wep_class = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox_Weapons_MapSelection = new System.Windows.Forms.ComboBox();
            this.Button_Weapons_LoadSelectedMap = new System.Windows.Forms.Button();
            this.tabPage_Console = new System.Windows.Forms.TabPage();
            this.Button_Console_Save = new System.Windows.Forms.Button();
            this.Button_Console_Clear = new System.Windows.Forms.Button();
            this.ConsoleTextBox = new System.Windows.Forms.TextBox();
            this.dataGridView_DB_Tables = new System.Windows.Forms.DataGridView();
            this.table_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.table_itemCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl_Main.SuspendLayout();
            this.tabPage_Database.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage_Weapons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Weapons)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.tabPage_Console.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_DB_Tables)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl_Main
            // 
            this.tabControl_Main.Controls.Add(this.tabPage_Database);
            this.tabControl_Main.Controls.Add(this.tabPage_Weapons);
            this.tabControl_Main.Controls.Add(this.tabPage_Console);
            this.tabControl_Main.Location = new System.Drawing.Point(12, 12);
            this.tabControl_Main.Name = "tabControl_Main";
            this.tabControl_Main.SelectedIndex = 0;
            this.tabControl_Main.Size = new System.Drawing.Size(1119, 624);
            this.tabControl_Main.TabIndex = 0;
            // 
            // tabPage_Database
            // 
            this.tabPage_Database.Controls.Add(this.button_DB_Clear);
            this.tabPage_Database.Controls.Add(this.button_DB_Test);
            this.tabPage_Database.Controls.Add(this.groupBox2);
            this.tabPage_Database.Controls.Add(this.groupBox1);
            this.tabPage_Database.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Database.Name = "tabPage_Database";
            this.tabPage_Database.Size = new System.Drawing.Size(1111, 598);
            this.tabPage_Database.TabIndex = 2;
            this.tabPage_Database.Text = "Database(DEV)";
            this.tabPage_Database.UseVisualStyleBackColor = true;
            // 
            // button_DB_Clear
            // 
            this.button_DB_Clear.Location = new System.Drawing.Point(875, 3);
            this.button_DB_Clear.Name = "button_DB_Clear";
            this.button_DB_Clear.Size = new System.Drawing.Size(233, 34);
            this.button_DB_Clear.TabIndex = 7;
            this.button_DB_Clear.Text = "Clear Database";
            this.button_DB_Clear.UseVisualStyleBackColor = true;
            this.button_DB_Clear.Click += new System.EventHandler(this.button_DB_Clear_Click);
            // 
            // button_DB_Test
            // 
            this.button_DB_Test.Location = new System.Drawing.Point(258, 340);
            this.button_DB_Test.Name = "button_DB_Test";
            this.button_DB_Test.Size = new System.Drawing.Size(257, 109);
            this.button_DB_Test.TabIndex = 6;
            this.button_DB_Test.Text = "THE TEST BUTTON";
            this.button_DB_Test.UseVisualStyleBackColor = true;
            this.button_DB_Test.Click += new System.EventHandler(this.button_DB_Test_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button_DB_AddWeaponMapTables);
            this.groupBox2.Controls.Add(this.button_DB_AddMaps);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(3, 325);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(249, 124);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "1:";
            // 
            // button_DB_AddWeaponMapTables
            // 
            this.button_DB_AddWeaponMapTables.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_DB_AddWeaponMapTables.Location = new System.Drawing.Point(6, 75);
            this.button_DB_AddWeaponMapTables.Name = "button_DB_AddWeaponMapTables";
            this.button_DB_AddWeaponMapTables.Size = new System.Drawing.Size(237, 30);
            this.button_DB_AddWeaponMapTables.TabIndex = 4;
            this.button_DB_AddWeaponMapTables.Text = "Add Weapon/Map Tables";
            this.button_DB_AddWeaponMapTables.UseVisualStyleBackColor = true;
            this.button_DB_AddWeaponMapTables.Click += new System.EventHandler(this.button_DB_AddWeaponMapTables_Click);
            // 
            // button_DB_AddMaps
            // 
            this.button_DB_AddMaps.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_DB_AddMaps.Location = new System.Drawing.Point(6, 39);
            this.button_DB_AddMaps.Name = "button_DB_AddMaps";
            this.button_DB_AddMaps.Size = new System.Drawing.Size(237, 30);
            this.button_DB_AddMaps.TabIndex = 3;
            this.button_DB_AddMaps.Text = "Add Maps to Table";
            this.button_DB_AddMaps.UseVisualStyleBackColor = true;
            this.button_DB_AddMaps.Click += new System.EventHandler(this.button_DB_AddMaps_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.dataGridView_DB_Tables);
            this.groupBox1.Controls.Add(this.label_TableCountInfo);
            this.groupBox1.Controls.Add(this.label_ConnectionStringInfo);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.button_LoadDBInfo);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(866, 302);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Database Info";
            // 
            // label_TableCountInfo
            // 
            this.label_TableCountInfo.Location = new System.Drawing.Point(109, 81);
            this.label_TableCountInfo.Name = "label_TableCountInfo";
            this.label_TableCountInfo.Size = new System.Drawing.Size(751, 23);
            this.label_TableCountInfo.TabIndex = 4;
            this.label_TableCountInfo.Text = "0";
            this.label_TableCountInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_ConnectionStringInfo
            // 
            this.label_ConnectionStringInfo.Location = new System.Drawing.Point(106, 58);
            this.label_ConnectionStringInfo.Name = "label_ConnectionStringInfo";
            this.label_ConnectionStringInfo.Size = new System.Drawing.Size(754, 23);
            this.label_ConnectionStringInfo.TabIndex = 4;
            this.label_ConnectionStringInfo.Text = "--------------";
            this.label_ConnectionStringInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(6, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 23);
            this.label3.TabIndex = 3;
            this.label3.Text = "Table Count:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 23);
            this.label1.TabIndex = 3;
            this.label1.Text = "Connection String:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // button_LoadDBInfo
            // 
            this.button_LoadDBInfo.Location = new System.Drawing.Point(6, 19);
            this.button_LoadDBInfo.Name = "button_LoadDBInfo";
            this.button_LoadDBInfo.Size = new System.Drawing.Size(239, 28);
            this.button_LoadDBInfo.TabIndex = 1;
            this.button_LoadDBInfo.Text = "Load Database Info";
            this.button_LoadDBInfo.UseVisualStyleBackColor = true;
            this.button_LoadDBInfo.Click += new System.EventHandler(this.button_LoadDBInfo_Click);
            // 
            // tabPage_Weapons
            // 
            this.tabPage_Weapons.Controls.Add(this.dataGridView_Weapons);
            this.tabPage_Weapons.Controls.Add(this.groupBox3);
            this.tabPage_Weapons.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Weapons.Name = "tabPage_Weapons";
            this.tabPage_Weapons.Size = new System.Drawing.Size(1111, 598);
            this.tabPage_Weapons.TabIndex = 3;
            this.tabPage_Weapons.Text = "Weapons";
            this.tabPage_Weapons.UseVisualStyleBackColor = true;
            // 
            // dataGridView_Weapons
            // 
            this.dataGridView_Weapons.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_Weapons.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView_Weapons.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dataGridView_Weapons.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Weapons.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_wep_mapID,
            this.col_wep_id,
            this.col_wep_locstring,
            this.col_wep_class});
            this.dataGridView_Weapons.Location = new System.Drawing.Point(6, 3);
            this.dataGridView_Weapons.Name = "dataGridView_Weapons";
            this.dataGridView_Weapons.ReadOnly = true;
            this.dataGridView_Weapons.RowHeadersVisible = false;
            this.dataGridView_Weapons.RowHeadersWidth = 150;
            this.dataGridView_Weapons.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView_Weapons.Size = new System.Drawing.Size(1105, 510);
            this.dataGridView_Weapons.TabIndex = 2;
            // 
            // col_wep_mapID
            // 
            this.col_wep_mapID.HeaderText = "MAP ID";
            this.col_wep_mapID.Name = "col_wep_mapID";
            this.col_wep_mapID.ReadOnly = true;
            // 
            // col_wep_id
            // 
            this.col_wep_id.HeaderText = "WEAPON ID";
            this.col_wep_id.Name = "col_wep_id";
            this.col_wep_id.ReadOnly = true;
            // 
            // col_wep_locstring
            // 
            this.col_wep_locstring.HeaderText = "LOCALIZED STRING";
            this.col_wep_locstring.Name = "col_wep_locstring";
            this.col_wep_locstring.ReadOnly = true;
            // 
            // col_wep_class
            // 
            this.col_wep_class.HeaderText = "WEAPON CLASS";
            this.col_wep_class.Name = "col_wep_class";
            this.col_wep_class.ReadOnly = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.comboBox_Weapons_MapSelection);
            this.groupBox3.Controls.Add(this.Button_Weapons_LoadSelectedMap);
            this.groupBox3.Location = new System.Drawing.Point(3, 519);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(252, 76);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Current Map";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(6, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 23);
            this.label4.TabIndex = 4;
            this.label4.Text = "Map:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboBox_Weapons_MapSelection
            // 
            this.comboBox_Weapons_MapSelection.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBox_Weapons_MapSelection.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox_Weapons_MapSelection.FormattingEnabled = true;
            this.comboBox_Weapons_MapSelection.Location = new System.Drawing.Point(57, 19);
            this.comboBox_Weapons_MapSelection.Name = "comboBox_Weapons_MapSelection";
            this.comboBox_Weapons_MapSelection.Size = new System.Drawing.Size(189, 21);
            this.comboBox_Weapons_MapSelection.TabIndex = 1;
            // 
            // Button_Weapons_LoadSelectedMap
            // 
            this.Button_Weapons_LoadSelectedMap.Location = new System.Drawing.Point(9, 46);
            this.Button_Weapons_LoadSelectedMap.Name = "Button_Weapons_LoadSelectedMap";
            this.Button_Weapons_LoadSelectedMap.Size = new System.Drawing.Size(237, 23);
            this.Button_Weapons_LoadSelectedMap.TabIndex = 0;
            this.Button_Weapons_LoadSelectedMap.Text = "Load";
            this.Button_Weapons_LoadSelectedMap.UseVisualStyleBackColor = true;
            this.Button_Weapons_LoadSelectedMap.Click += new System.EventHandler(this.Button_Weapons_LoadSelectedMap_Click);
            // 
            // tabPage_Console
            // 
            this.tabPage_Console.Controls.Add(this.Button_Console_Save);
            this.tabPage_Console.Controls.Add(this.Button_Console_Clear);
            this.tabPage_Console.Controls.Add(this.ConsoleTextBox);
            this.tabPage_Console.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Console.Name = "tabPage_Console";
            this.tabPage_Console.Size = new System.Drawing.Size(1111, 598);
            this.tabPage_Console.TabIndex = 1;
            this.tabPage_Console.Text = "Console";
            this.tabPage_Console.UseVisualStyleBackColor = true;
            // 
            // Button_Console_Save
            // 
            this.Button_Console_Save.Location = new System.Drawing.Point(133, 564);
            this.Button_Console_Save.Name = "Button_Console_Save";
            this.Button_Console_Save.Size = new System.Drawing.Size(124, 31);
            this.Button_Console_Save.TabIndex = 2;
            this.Button_Console_Save.Text = "Save Console Output";
            this.Button_Console_Save.UseVisualStyleBackColor = true;
            this.Button_Console_Save.Click += new System.EventHandler(this.Button_Console_Save_Click);
            // 
            // Button_Console_Clear
            // 
            this.Button_Console_Clear.Location = new System.Drawing.Point(3, 564);
            this.Button_Console_Clear.Name = "Button_Console_Clear";
            this.Button_Console_Clear.Size = new System.Drawing.Size(124, 31);
            this.Button_Console_Clear.TabIndex = 1;
            this.Button_Console_Clear.Text = "Clear Console";
            this.Button_Console_Clear.UseVisualStyleBackColor = true;
            this.Button_Console_Clear.Click += new System.EventHandler(this.Button_Console_Clear_Click);
            // 
            // ConsoleTextBox
            // 
            this.ConsoleTextBox.Location = new System.Drawing.Point(3, 3);
            this.ConsoleTextBox.Multiline = true;
            this.ConsoleTextBox.Name = "ConsoleTextBox";
            this.ConsoleTextBox.ReadOnly = true;
            this.ConsoleTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ConsoleTextBox.Size = new System.Drawing.Size(1105, 555);
            this.ConsoleTextBox.TabIndex = 0;
            this.ConsoleTextBox.WordWrap = false;
            // 
            // dataGridView_DB_Tables
            // 
            this.dataGridView_DB_Tables.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_DB_Tables.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView_DB_Tables.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dataGridView_DB_Tables.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_DB_Tables.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.table_ID,
            this.table_itemCount});
            this.dataGridView_DB_Tables.Location = new System.Drawing.Point(6, 107);
            this.dataGridView_DB_Tables.Name = "dataGridView_DB_Tables";
            this.dataGridView_DB_Tables.ReadOnly = true;
            this.dataGridView_DB_Tables.RowHeadersVisible = false;
            this.dataGridView_DB_Tables.RowHeadersWidth = 150;
            this.dataGridView_DB_Tables.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView_DB_Tables.Size = new System.Drawing.Size(854, 189);
            this.dataGridView_DB_Tables.TabIndex = 5;
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1143, 648);
            this.Controls.Add(this.tabControl_Main);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "IW4DumpHelper By P!X";
            this.tabControl_Main.ResumeLayout(false);
            this.tabPage_Database.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tabPage_Weapons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Weapons)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.tabPage_Console.ResumeLayout(false);
            this.tabPage_Console.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_DB_Tables)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl_Main;
        private System.Windows.Forms.TabPage tabPage_Console;
        private System.Windows.Forms.TextBox ConsoleTextBox;
        private System.Windows.Forms.Button Button_Console_Clear;
        private System.Windows.Forms.Button Button_Console_Save;
        private System.Windows.Forms.TabPage tabPage_Database;
        private System.Windows.Forms.Button button_LoadDBInfo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label_ConnectionStringInfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_DB_AddMaps;
        private System.Windows.Forms.Button button_DB_AddWeaponMapTables;
        private System.Windows.Forms.Label label_TableCountInfo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button_DB_Test;
        private System.Windows.Forms.Button button_DB_Clear;
        private System.Windows.Forms.TabPage tabPage_Weapons;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox_Weapons_MapSelection;
        private System.Windows.Forms.DataGridView dataGridView_Weapons;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_wep_mapID;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_wep_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_wep_locstring;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_wep_class;
        private System.Windows.Forms.Button Button_Weapons_LoadSelectedMap;
        private System.Windows.Forms.DataGridView dataGridView_DB_Tables;
        private System.Windows.Forms.DataGridViewTextBoxColumn table_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn table_itemCount;
    }
}

