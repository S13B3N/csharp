using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VxLibraryData.Common.Common;

namespace VxLibraryData.Gui.Gui.Dlg
{
   public partial class Dlg_BackgroundWorker : Form
   {
      private BackgroundWorker m_Worker;

      //------------------------------------------------------------------------

      public Dlg_BackgroundWorker ()
      {
         InitializeComponent ();

         Close ();
      }

      public Dlg_BackgroundWorker ( BackgroundWorker Worker )
      {
         m_Worker = Worker;

         InitializeComponent ();

         m_Worker.e_WorkFinished += new DWorkFinished ( m_Worker_e_WorkFinished );
         m_Worker.e_WorkAborted  += new DWorkAborted  ( m_Worker_e_WorkAborted  );

         m_Worker.Start ();
         ShowDialog     ();
      }

      private void m_Worker_e_WorkAborted ()
      {
         if ( InvokeRequired )
         {
            Invoke ( new DWorkAborted ( m_Worker_e_WorkAborted )); return;
         }

         DeleteEvents ();
         Close        ();
      }

      private void m_Worker_e_WorkFinished ()
      {
         if ( InvokeRequired )
         {
            Invoke ( new DWorkFinished ( m_Worker_e_WorkFinished )); return;
         }

         DeleteEvents ();
         Close        ();
      }

      private void DeleteEvents ()
      {
         m_Worker.e_WorkFinished -= new DWorkFinished ( m_Worker_e_WorkFinished );
         m_Worker.e_WorkAborted  -= new DWorkAborted  ( m_Worker_e_WorkAborted  );
      }

      //------------------------------------------------------------------------

      private void m_btnAbort_Click ( object sender, EventArgs e )
      {
         m_Worker.Abort ();
      }
   }
}
