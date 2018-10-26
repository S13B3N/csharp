using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VxLibraryData.Common.Util;
using VxLibraryData.Data;

namespace VxLibraryData.Gui.Gui
{
   public class VxForm : Form
   {
      public VxForm () : base ()
      {
      }

      //------------------------------------------------------------------------

      protected ResultInfo OpenFileDialog ( ref String FileName )
      {
         ResultInfo rInfo = new ResultInfo ();

         OpenFileDialog Dlg = new OpenFileDialog ();

         if ( Dlg.ShowDialog () == System.Windows.Forms.DialogResult.OK )
         {
            FileName = Dlg.FileName;
         }
         else
         {
            rInfo.SetError ( 0, "No file selected!", null, EErrorLevel.Info );
         }

         return rInfo;
      }

      //------------------------------------------------------------------------

      protected ResultInfo SaveFileDialog ( ref String FileName )
      {
         ResultInfo rInfo = new ResultInfo ();

         SaveFileDialog Dlg = new SaveFileDialog ();

         if ( Dlg.ShowDialog () == System.Windows.Forms.DialogResult.OK )
         {
            FileName = Dlg.FileName;
         }
         else
         {
            rInfo.SetError ( 0, "No file selected!", null, EErrorLevel.Info );
         }

         return rInfo;
      }

      //------------------------------------------------------------------------

      protected ResultInfo OpenDatabase<T> ( ref String FileName, ref T Database )
      {
         ResultInfo rInfo = new ResultInfo ();

         if ( FileName == null )
         {
            rInfo = OpenFileDialog ( ref FileName );
         }

         if ( rInfo.IsOK ())
         {
            rInfo = VxLibraryData.Data.Database.Load ( FileName, ref Database );
         }
         else
         {
            rInfo.Reset ();
         }

         return rInfo;
      }

      protected ResultInfo SaveDatabase<T> ( ref String FileName, T Database )
      {
         ResultInfo rInfo = new ResultInfo ();

         if ( FileName == null )
         {
            rInfo = SaveFileDialog ( ref FileName );
         }

         if  ( rInfo.IsOK ())
         {
            rInfo = VxLibraryData.Data.Database.Save ( FileName, Database );
         }
         else
         {
            rInfo.Reset ();
         }

         return rInfo;
      }
   }
}
