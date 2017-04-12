using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace FileExploer
{
    public partial class Form1 : Form
    {
        bool iscopy = false;
        bool iscut = false;
        Thread thread;
        String frompath = "";
        String topath = "";
        bool isread = false;
        List<String> links = new List<string>();
        int index = -1;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //get a list of the drives
            string[] drives = Environment.GetLogicalDrives();
            TreeNode mp = new TreeNode("My Computer", 10, 10);
            mp.Tag = "con";
            foreach (string drive in drives)
            {
                DriveInfo di = new DriveInfo(drive);
                int driveImage;

                switch (di.DriveType)    //set the drive's icon
                {
                    case DriveType.CDRom:
                        driveImage = 0;
                        break;
                    case DriveType.Network:
                        driveImage = 6;
                        break;
                    case DriveType.NoRootDirectory:
                        driveImage = 3;
                        break;
                    case DriveType.Unknown:
                        driveImage = 3;
                        break;
                    default:
                        driveImage = 7;
                        break;
                }

                TreeNode node = new TreeNode(drive.Substring(0, 1), driveImage, driveImage);
                node.Tag = drive;

                if (di.IsReady == true)
                    node.Nodes.Add("...");
                mp.Nodes.Add(node);
            }
            treeDriver.Nodes.Add(mp);
        }

        private void treeDriver_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void treeDriver_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            treeDriver.UseWaitCursor = true;
            if (e.Node.Nodes.Count > 0)
            {
                if (e.Node.Nodes[0].Text == "..." && e.Node.Nodes[0].Tag == null)
                {
                    e.Node.Nodes.Clear();

                    //get the list of sub direcotires
                    string[] dirs = Directory.GetDirectories(e.Node.Tag.ToString());

                    foreach (string dir in dirs)
                    {
                        DirectoryInfo di = new DirectoryInfo(dir);
                        TreeNode node = new TreeNode(di.Name, 8, 9);

                        try
                        {
                            node.Tag = dir;  //keep the directory's full path in the tag for use later

                            //if the directory has any sub directories add the place holder
                            if (di.GetDirectories().Count() > 0)
                                node.Nodes.Add(null, "...", 8, 8);
                        }
                        catch (UnauthorizedAccessException)
                        {
                            //if an unauthorized access exception occured display a locked folder
                            node.ImageIndex = 5;
                            node.SelectedImageIndex = 5;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "DirectoryLister", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                        }
                        finally
                        {
                            e.Node.Nodes.Add(node);
                        }
                    }
                }
            }
            treeDriver.UseWaitCursor = false;
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private String processsize(long size)
        {
            if (size / (1024.0 * 1024 * 1024) > 1)
            {
                Decimal rs = size / (Decimal)(1024.0 * 1024 * 1024);
                rs = Math.Round(rs, 2);
                return rs.ToString() + " GB";
            }
            else if (size / (1024 * 1024) > 1)
            {
                Decimal rs = size / (Decimal)(1024 * 1024);
                rs = Math.Round(rs, 2);
                return rs.ToString() + " MB";
            }
            else if (size / (1024.0) > 1)
            {
                Decimal rs = size / (Decimal)(1024);
                rs = Math.Round(rs, 2);
                return rs.ToString() + " Kb";
            }
            else
            {
                return size.ToString() + " byte";
            }
        }
        private void showListFile(string path)
        {
            int k = 0;
            string fi;
            //isread = true;
            label1.Invoke(new Action(() =>
            {
                label1.Text = path;
            }));
            lvcontainer.Invoke(new Action(() =>
            {
                lvcontainer.UseWaitCursor = true;
                lvcontainer.Clear();
            }));
            int len = 10;
            int dem = 0;
            ListViewItem[] lvi = new ListViewItem[len];
            //lvcontainer.UseWaitCursor = true;
            try
            {
                foreach (string d in Directory.GetDirectories(path))
                {
                    lvcontainer.Invoke(new Action(() =>
                    {
                        try
                        {
                            imglistview.Images.Add(k.ToString(), SpyIcon.GetIcon(d));
                        }
                        catch (Exception ex)
                        {
                            imglistview.Images.Add(k.ToString(), imageList1.Images[8]);
                        }
                    }));
                    fi = d.Substring(Directory.GetParent(d).ToString().Length + 1);//Lấy tên file
                    ListViewItem item = new ListViewItem(fi, k);//Tạo item mới
                    FileInfo finfo = new FileInfo(d);
                    try
                    {
                        item.ToolTipText = "created: " + finfo.CreationTime.ToString() + "\n Size: " + processsize(finfo.Length);
                    }
                    catch (Exception ex)
                    {
                        item.ToolTipText = "created: " + finfo.CreationTime.ToString() + "\n Size: None";
                    }
                    item.Tag = d;//Đánh dấu đường dẫn file cho item
                    lvi.SetValue(item, dem++);
                    if (dem > len-1)
                    {
                        lvcontainer.Invoke(new Action(() =>
                        {
                            lvcontainer.Items.AddRange(lvi);
                            lvi = new ListViewItem[len];
                            dem = 0;
                            //lvcontainer.Items.Add(item);//Thêm item vào listview
                        }));
                    }
                    
                    k++;
                    Thread.Sleep(1);
                }
            }
            catch (Exception ex)
            {

            }
            try
            {
                foreach (string f in Directory.GetFiles(path))
                {
                    Icon ic = SpyIcon.GetIcon(f);
                    if (ic != null)
                    {
                        lvcontainer.Invoke(new Action(() =>
                        {
                            imglistview.Images.Add(k.ToString(), ic);
                        }));
                    }
                    else
                    {
                        lvcontainer.Invoke(new Action(() =>
                        {
                            imglistview.Images.Add(k.ToString(), Icon.FromHandle(((Bitmap)imageList1.Images[8]).GetHicon()));
                        }));
                    }
                    FileInfo finfo = new FileInfo(f);
                    fi = f.Substring(Directory.GetParent(f).ToString().Length + 1);//Lấy tên file
                    ListViewItem item = new ListViewItem(fi, k);//Tạo item mới
                    try
                    {
                        item.ToolTipText = "created: " + finfo.CreationTime.ToString() + "\n Size: " + processsize(finfo.Length);
                    }
                    catch (Exception ex)
                    {
                        item.ToolTipText = "created: " + finfo.CreationTime.ToString() + "\n Size: None";
                    }
                    //item.ToolTipText = "created: " + finfo.CreationTime.ToString() + "\n Size: " + (di.TotalSize.ToString());
                    item.Tag = f;//Đánh dấu đường dẫn file cho item
                    lvi.SetValue(item, dem++);
                    if (dem > len-1)
                    {
                        lvcontainer.Invoke(new Action(() =>
                        {
                            lvcontainer.Items.AddRange(lvi);
                            lvi = new ListViewItem[len];
                            dem = 0;
                            //lvcontainer.Items.Add(item);//Thêm item vào listview
                        }));
                    }
                    //lvcontainer.Invoke(new Action(() =>
                    //{
                     //   lvcontainer.Items.Add(item);//Thêm item vào listview
                    ///}));
                    k++;
                    Thread.Sleep(1);
                }
            }
            catch (Exception ex)
            {

            }
            if (dem > 0)
            {
                lvcontainer.Invoke(new Action(() =>
                {
                    ListViewItem[] tmp = new ListViewItem[dem];
                    for (int i = 0; i < dem; i++)
                    {
                        tmp.SetValue(lvi.GetValue(i), i);
                    }
                    lvcontainer.Items.AddRange(tmp);
                    dem = 0;
                    //lvcontainer.Items.Add(item);//Thêm item vào listview
                }));
            }
            lvcontainer.Invoke(new Action(() =>
            {
                lvcontainer.UseWaitCursor = false;
            }));
        }
        private void treeDriver_Click(object sender, EventArgs e)
        {

        }

        private void lvcontainer_DoubleClick(object sender, EventArgs e)
        {
            FileAttributes attr = File.GetAttributes(lvcontainer.SelectedItems[0].Tag.ToString());
            if ((attr & FileAttributes.Directory) == FileAttributes.Directory)
            {
                imglistview.Images.Clear();
                if (thread != null)
                {
                    thread.Abort();
                    thread = null;
                    //thread.Abort();
                }
                String path = "";
                lvcontainer.Invoke(new Action(() =>
                {
                    path = lvcontainer.SelectedItems[0].Tag.ToString();
                }));
                List<String> tmp = new List<string>();
                for (int i = 0; i < links.Count; i++)
                {
                    if (links.ElementAt(i).Equals(label1.Text))
                    {
                        tmp.Add(links.ElementAt(i));
                        break;
                    }
                    tmp.Add(links.ElementAt(i));
                }
                links = tmp;
                links.Add(path);
                index = links.Count - 1;
                back.Cursor = Cursors.No;
                next.Cursor = Cursors.No;
                if (links.Count > 1)
                {
                    back.Cursor = Cursors.Hand;
                }
                thread = new Thread(() => showListFile(path));
                thread.Start();
                //showListFile(lvcontainer.SelectedItems[0].Tag.ToString());
            }
            else
            {
                try
                {
                    System.Diagnostics.Process.Start(lvcontainer.SelectedItems[0].Tag.ToString());
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Can't open file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    System.Diagnostics.Process.Start(new FileInfo(lvcontainer.SelectedItems[0].Tag.ToString()).Directory.FullName);
                }
            }
        }

        private void treeDriver_MouseClick(object sender, MouseEventArgs e)
        {
            var hitTest = treeDriver.HitTest(e.Location);
            if (hitTest.Location != TreeViewHitTestLocations.PlusMinus)
            {
                TreeViewHitTestInfo info = treeDriver.HitTest(treeDriver.PointToClient(Cursor.Position));
                if (info != null && info.Node.Tag != "con")
                {
                    if (thread != null && thread.IsAlive)
                    {
                        thread.Abort();
                    }
                    imglistview.Images.Clear();
                    thread = new Thread(() => showListFile(info.Node.Tag.ToString()));
                    thread.Start();
                    links.Add(info.Node.Tag.ToString());
                    index = links.Count - 1;
                    back.Cursor = Cursors.No;
                    next.Cursor = Cursors.No;
                    if (links.Count > 1)
                    {
                        back.Cursor = Cursors.Hand;
                    }
                    //showListFile(info.Node.Tag.ToString());
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (links.Count > 1 && index > 0)
            {
                thread = new Thread(() => showListFile(links.ElementAt(--index)));
                thread.Start();
                next.Cursor = Cursors.Hand;
                if (index <= 1)
                {
                    back.Cursor = Cursors.No;
                }
            }
        }

        private void next_Click(object sender, EventArgs e)
        {
            if (links.Count > 1 && index < links.Count-1)
            {
                thread = new Thread(() => showListFile(links.ElementAt(++index)));
                thread.Start();
                back.Cursor = Cursors.Hand;
                if (index >= (links.Count-1))
                {
                    next.Cursor = Cursors.No;
                }
            }
        }

        private void lvcontainer_MouseDown(object sender, MouseEventArgs e)
        {
            bool match = false;

            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                foreach (ListViewItem item in lvcontainer.Items)
                {
                    if (item.Bounds.Contains(new Point(e.X, e.Y)))
                    {
                        MenuItem[] mi = new MenuItem[] { new MenuItem("Copy"), new MenuItem("Cut"), new MenuItem("Paste") };
                        FileAttributes attr = File.GetAttributes(item.Tag.ToString());
                        if (!iscopy && !iscut || !((attr & FileAttributes.Directory) == FileAttributes.Directory))
                        {
                            mi[2].Enabled = false;
                            frompath = item.Tag.ToString();
                        }
                        else
                        {
                            mi[2].Click += item_Click;
                            topath = item.Tag.ToString();
                        }
                        lvcontainer.ContextMenu = new ContextMenu(mi);
                        mi[0].Click +=  item_Click;
                        mi[1].Click += item_Click;
                        break;
                    }
                }
            }
        }

        public void item_Click(Object sender, EventArgs e)
        {
            MenuItem mi = (MenuItem)sender;
            if (mi.Text.ToLower().Equals("copy"))
            {
                iscopy = true;
                iscut = false;
            }
            else if (mi.Text.ToLower().Equals("cut"))
            {
                iscopy = true;
                iscut = false;
            }
            else if (mi.Text.ToLower().Equals("paste"))
            {
                Console.Write(frompath);
                Console.Write(topath);
                FileAttributes attr = File.GetAttributes(topath);
                if ((attr & FileAttributes.Directory) == FileAttributes.Directory)
                {
                    try
                    {
                        if (iscut)
                        {
                            System.IO.File.Move(@frompath, @topath);
                        }
                        if (iscopy)
                        {
                            System.IO.File.Copy(@frompath, @topath, true);
                        }
                    }
                    catch (Exception ex)
                    {
                        String message = "cut";
                        if (iscopy)
                        {
                            message = "coppy";
                        }
                        Console.Write(ex.Message);
                        MessageBox.Show("Can't " +message+ " file or folder", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
