using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace VxLibraryData.Gui.Gui.Ctrl
{
   public partial class UsrCtrl_FileSystemTree : UserControl
   {
      public UsrCtrl_FileSystemTree ()
      {
         InitializeComponent ();
      }

      public UsrCtrl_FileSystemTree ( String Path )
      {
         InitializeComponent ();
      }

      //------------------------------------------------------------------------
      // UpdateGui
      //------------------------------------------------------------------------

      //------------------------------------------------------------------------
      // Helper
      //------------------------------------------------------------------------
   }

   public class FileSystemUtil
   {
      public void ListDirectory ( String Path )
      {
          DirectoryInfo RootDirectoryInfo = new DirectoryInfo ( Path );

          //m_tvFileTree.Nodes.Add ( CreateDirectoryNode ( RootDirectoryInfo ));
      }

      private TreeNode CreateDirectoryNode ( DirectoryInfo RootDirectoryInfo )
      {
         TreeNode DirectoryNode = new TreeNode ( RootDirectoryInfo.Name );

         foreach ( DirectoryInfo DirectoryInfo in RootDirectoryInfo.GetDirectories ())
         {
            DirectoryNode.Nodes.Add ( CreateDirectoryNode ( DirectoryInfo ));
         }

         foreach ( FileInfo FileInfo in RootDirectoryInfo.GetFiles ())
         {
            DirectoryNode.Nodes.Add ( new TreeNode ( FileInfo.Name ));
         }

         return DirectoryNode;
      }
   }
}
