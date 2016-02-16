﻿namespace Zetta.ConfigMgr.QuickTools
{
    partial class ResultDriverComplianceControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listViewListDrivers = new Microsoft.ConfigurationManagement.AdminConsole.Common.SmsSearchableListView();
            this.columnHeaderVendor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderVersionRemote = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderVersionPackage = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxDriverPackage = new System.Windows.Forms.TextBox();
            this.buttonBrowse = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelManufacturer = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.labelProductName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listViewListDrivers
            // 
            this.listViewListDrivers.Activation = System.Windows.Forms.ItemActivation.Standard;
            this.listViewListDrivers.Alignment = System.Windows.Forms.ListViewAlignment.Top;
            this.listViewListDrivers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewListDrivers.AutoSort = true;
            this.listViewListDrivers.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.listViewListDrivers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderVendor,
            this.columnHeaderDescription,
            this.columnHeaderVersionRemote,
            this.columnHeaderVersionPackage});
            this.listViewListDrivers.CustomNoResultsText = null;
            this.listViewListDrivers.FullRowSelect = true;
            this.listViewListDrivers.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Clickable;
            this.listViewListDrivers.HideSelection = false;
            this.listViewListDrivers.IsLoading = false;
            this.listViewListDrivers.LargeImageList = null;
            this.listViewListDrivers.Location = new System.Drawing.Point(12, 33);
            this.listViewListDrivers.MultiSelect = true;
            this.listViewListDrivers.Name = "listViewListDrivers";
            this.listViewListDrivers.ShowSearchBar = true;
            this.listViewListDrivers.Size = new System.Drawing.Size(354, 257);
            this.listViewListDrivers.SmallImageList = null;
            this.listViewListDrivers.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listViewListDrivers.StateImageList = null;
            this.listViewListDrivers.TabIndex = 8;
            this.listViewListDrivers.TileSize = new System.Drawing.Size(0, 0);
            this.listViewListDrivers.UseCompatibleStateImageBehavior = false;
            this.listViewListDrivers.View = System.Windows.Forms.View.Details;
            this.listViewListDrivers.CopyKeyEvent += new System.EventHandler<System.EventArgs>(this.listViewListDrivers_CopyKeyEvent);
            // 
            // columnHeaderVendor
            // 
            this.columnHeaderVendor.Text = "Vendor";
            // 
            // columnHeaderDescription
            // 
            this.columnHeaderDescription.Text = "Description";
            // 
            // columnHeaderVersionRemote
            // 
            this.columnHeaderVersionRemote.Text = "Version";
            // 
            // columnHeaderVersionPackage
            // 
            this.columnHeaderVersionPackage.Text = "Version Package";
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRefresh.Location = new System.Drawing.Point(342, 3);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(24, 24);
            this.buttonRefresh.TabIndex = 9;
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(174, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Driver Compliance for this resource:";
            // 
            // textBoxDriverPackage
            // 
            this.textBoxDriverPackage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxDriverPackage.Enabled = false;
            this.textBoxDriverPackage.Location = new System.Drawing.Point(99, 323);
            this.textBoxDriverPackage.Name = "textBoxDriverPackage";
            this.textBoxDriverPackage.ReadOnly = true;
            this.textBoxDriverPackage.Size = new System.Drawing.Size(186, 20);
            this.textBoxDriverPackage.TabIndex = 11;
            // 
            // buttonBrowse
            // 
            this.buttonBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBrowse.Location = new System.Drawing.Point(291, 321);
            this.buttonBrowse.Name = "buttonBrowse";
            this.buttonBrowse.Size = new System.Drawing.Size(75, 23);
            this.buttonBrowse.TabIndex = 12;
            this.buttonBrowse.Text = "Browse...";
            this.buttonBrowse.UseVisualStyleBackColor = true;
            this.buttonBrowse.Click += new System.EventHandler(this.buttonBrowse_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 326);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Driver Package:";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 297);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Manufacturer:";
            // 
            // labelManufacturer
            // 
            this.labelManufacturer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelManufacturer.AutoSize = true;
            this.labelManufacturer.Location = new System.Drawing.Point(83, 297);
            this.labelManufacturer.Name = "labelManufacturer";
            this.labelManufacturer.Size = new System.Drawing.Size(10, 13);
            this.labelManufacturer.TabIndex = 15;
            this.labelManufacturer.Text = " ";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(180, 297);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Product Name:";
            // 
            // labelProductName
            // 
            this.labelProductName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelProductName.AutoSize = true;
            this.labelProductName.Location = new System.Drawing.Point(256, 297);
            this.labelProductName.Name = "labelProductName";
            this.labelProductName.Size = new System.Drawing.Size(10, 13);
            this.labelProductName.TabIndex = 17;
            this.labelProductName.Text = " ";
            // 
            // ResultDriverComplianceControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelProductName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.labelManufacturer);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonBrowse);
            this.Controls.Add(this.textBoxDriverPackage);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonRefresh);
            this.Controls.Add(this.listViewListDrivers);
            this.Name = "ResultDriverComplianceControl";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.ConfigurationManagement.AdminConsole.Common.SmsSearchableListView listViewListDrivers;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxDriverPackage;
        private System.Windows.Forms.Button buttonBrowse;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ColumnHeader columnHeaderVendor;
        private System.Windows.Forms.ColumnHeader columnHeaderDescription;
        private System.Windows.Forms.ColumnHeader columnHeaderVersionRemote;
        private System.Windows.Forms.ColumnHeader columnHeaderVersionPackage;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelManufacturer;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelProductName;
    }
}
