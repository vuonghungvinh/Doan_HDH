﻿namespace FileExploer
{
    partial class Form1
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.treeDriver = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lvcontainer = new System.Windows.Forms.ListView();
            this.imglistview = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeDriver
            // 
            this.treeDriver.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeDriver.ImageIndex = 0;
            this.treeDriver.ImageList = this.imageList1;
            this.treeDriver.Location = new System.Drawing.Point(0, 0);
            this.treeDriver.Name = "treeDriver";
            this.treeDriver.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.treeDriver.SelectedImageIndex = 0;
            this.treeDriver.Size = new System.Drawing.Size(211, 356);
            this.treeDriver.TabIndex = 2;
            this.treeDriver.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeDriver_BeforeExpand);
            this.treeDriver.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeDriver_AfterSelect);
            this.treeDriver.Click += new System.EventHandler(this.treeDriver_Click);
            this.treeDriver.MouseClick += new System.Windows.Forms.MouseEventHandler(this.treeDriver_MouseClick);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "cd_drive.png");
            this.imageList1.Images.SetKeyName(1, "device cd empty.png");
            this.imageList1.Images.SetKeyName(2, "drive disk.png");
            this.imageList1.Images.SetKeyName(3, "drive error.png");
            this.imageList1.Images.SetKeyName(4, "drive link.png");
            this.imageList1.Images.SetKeyName(5, "drive locked.png");
            this.imageList1.Images.SetKeyName(6, "drive network.png");
            this.imageList1.Images.SetKeyName(7, "drive.png");
            this.imageList1.Images.SetKeyName(8, "folder.png");
            this.imageList1.Images.SetKeyName(9, "folder_open.png");
            this.imageList1.Images.SetKeyName(10, "mycomputer.png");
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeDriver);
            this.splitContainer1.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel1_Paint);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lvcontainer);
            this.splitContainer1.Size = new System.Drawing.Size(635, 356);
            this.splitContainer1.SplitterDistance = 211;
            this.splitContainer1.TabIndex = 3;
            // 
            // lvcontainer
            // 
            this.lvcontainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvcontainer.LargeImageList = this.imglistview;
            this.lvcontainer.Location = new System.Drawing.Point(0, 0);
            this.lvcontainer.Name = "lvcontainer";
            this.lvcontainer.ShowItemToolTips = true;
            this.lvcontainer.Size = new System.Drawing.Size(420, 356);
            this.lvcontainer.TabIndex = 0;
            this.lvcontainer.UseCompatibleStateImageBehavior = false;
            this.lvcontainer.DoubleClick += new System.EventHandler(this.lvcontainer_DoubleClick);
            // 
            // imglistview
            // 
            this.imglistview.ColorDepth = System.Windows.Forms.ColorDepth.Depth16Bit;
            this.imglistview.ImageSize = new System.Drawing.Size(48, 48);
            this.imglistview.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(635, 356);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "FileExploer";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeDriver;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListView lvcontainer;
        private System.Windows.Forms.ImageList imglistview;
    }
}

