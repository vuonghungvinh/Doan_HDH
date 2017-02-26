using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FileExploer
{
    public partial class Form1 : Form
    {
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
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private String processsize(long size)
        {
            if (size/(1024.0 * 1024 * 1024)>1)
            {
                Decimal rs = size/(Decimal)(1024.0 * 1024 * 1024);
                rs = Math.Round(rs, 2);
                return rs.ToString() + " GB";
            }
            else if (size / (1024 * 1024) > 1)
            {
                Decimal rs = size / (Decimal)(1024 * 1024);
                rs = Math.Round(rs, 2);
                return rs.ToString() + " MB";
            } else if (size / (1024.0 ) > 1)
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
            imglistview.Images.Clear();
            lvcontainer.Clear();
            try
            {
                foreach (string d in Directory.GetDirectories(path))
                {
                    imglistview.Images.Add(k.ToString(), SpyIcon.GetIcon(d));
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
                    lvcontainer.Items.Add(item);//Thêm item vào listview
                    k++;
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
                        imglistview.Images.Add(k.ToString(), ic);
                    }
                    else
                    {
                        imglistview.Images.Add(k.ToString(), Icon.FromHandle(((Bitmap)imageList1.Images[0]).GetHicon()));
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
                    lvcontainer.Items.Add(item);//Thêm item vào listview
                    k++;
                }
            }
            catch (Exception ex)
            {

            }
        }
        private void treeDriver_Click(object sender, EventArgs e)
        {
            
        }

        private void lvcontainer_DoubleClick(object sender, EventArgs e)
        {
            FileAttributes attr = File.GetAttributes(lvcontainer.SelectedItems[0].Tag.ToString());
            if ((attr & FileAttributes.Directory) == FileAttributes.Directory)
            {
                showListFile(lvcontainer.SelectedItems[0].Tag.ToString());
            }
            else
            {
                try
                {
                    System.Diagnostics.Process.Start(lvcontainer.SelectedItems[0].Tag.ToString());
                } catch(Exception ex)
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
                    showListFile(info.Node.Tag.ToString());
                }
            }
        }
    }
}
