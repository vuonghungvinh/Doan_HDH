namespace FileExploer
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
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.next = new System.Windows.Forms.PictureBox();
            this.back = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.next)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.back)).BeginInit();
            this.panel2.SuspendLayout();
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
            this.treeDriver.Size = new System.Drawing.Size(210, 319);
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
            this.splitContainer1.Size = new System.Drawing.Size(633, 319);
            this.splitContainer1.SplitterDistance = 210;
            this.splitContainer1.TabIndex = 3;
            // 
            // lvcontainer
            // 
            this.lvcontainer.BackgroundImageTiled = true;
            this.lvcontainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvcontainer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvcontainer.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lvcontainer.LargeImageList = this.imglistview;
            this.lvcontainer.Location = new System.Drawing.Point(0, 0);
            this.lvcontainer.MultiSelect = false;
            this.lvcontainer.Name = "lvcontainer";
            this.lvcontainer.ShowItemToolTips = true;
            this.lvcontainer.Size = new System.Drawing.Size(419, 319);
            this.lvcontainer.SmallImageList = this.imglistview;
            this.lvcontainer.TabIndex = 0;
            this.lvcontainer.UseCompatibleStateImageBehavior = false;
            this.lvcontainer.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.lvcontainer_DrawItem);
            this.lvcontainer.DoubleClick += new System.EventHandler(this.lvcontainer_DoubleClick);
            this.lvcontainer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvcontainer_KeyDown);
            this.lvcontainer.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lvcontainer_MouseDown);
            // 
            // imglistview
            // 
            this.imglistview.ColorDepth = System.Windows.Forms.ColorDepth.Depth16Bit;
            this.imglistview.ImageSize = new System.Drawing.Size(64, 64);
            this.imglistview.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cutToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.pasteToolStripMenuItem1});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(103, 70);
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.cutToolStripMenuItem.Text = "Copy";
            this.cutToolStripMenuItem.Click += new System.EventHandler(this.cutToolStripMenuItem_Click);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.pasteToolStripMenuItem.Text = "Cut";
            // 
            // pasteToolStripMenuItem1
            // 
            this.pasteToolStripMenuItem1.Name = "pasteToolStripMenuItem1";
            this.pasteToolStripMenuItem1.Size = new System.Drawing.Size(102, 22);
            this.pasteToolStripMenuItem1.Text = "Paste";
            this.pasteToolStripMenuItem1.Click += new System.EventHandler(this.pasteToolStripMenuItem1_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.next);
            this.panel1.Controls.Add(this.back);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(635, 35);
            this.panel1.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.PaleVioletRed;
            this.label1.Location = new System.Drawing.Point(86, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Mycomputer";
            // 
            // next
            // 
            this.next.Cursor = System.Windows.Forms.Cursors.No;
            this.next.Image = global::FileExploer.Properties.Resources.next;
            this.next.Location = new System.Drawing.Point(43, 0);
            this.next.Name = "next";
            this.next.Size = new System.Drawing.Size(37, 32);
            this.next.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.next.TabIndex = 1;
            this.next.TabStop = false;
            this.next.Click += new System.EventHandler(this.next_Click);
            // 
            // back
            // 
            this.back.Cursor = System.Windows.Forms.Cursors.No;
            this.back.Image = global::FileExploer.Properties.Resources.back;
            this.back.Location = new System.Drawing.Point(0, 0);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(37, 32);
            this.back.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.back.TabIndex = 0;
            this.back.TabStop = false;
            this.back.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.splitContainer1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 35);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(635, 321);
            this.panel2.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(635, 356);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "FileExploer";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.next)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.back)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeDriver;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListView lvcontainer;
        private System.Windows.Forms.ImageList imglistview;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox back;
        private System.Windows.Forms.PictureBox next;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem1;
    }
}

