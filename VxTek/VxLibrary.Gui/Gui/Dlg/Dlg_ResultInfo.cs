using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VxLibraryData.Common.Util;

namespace VxLibraryData.Gui.Dlg
{
   public partial class Dlg_ResultInfo : Form
   {
      private ResultInfo m_rInfo;

      //------------------------------------------------------------------------

      public Dlg_ResultInfo ()
      {
         InitializeComponent ();
      }

      public Dlg_ResultInfo ( ResultInfo rInfo )
      {
         m_rInfo = rInfo;

         InitializeComponent ();

         UpdateGui ();
      }

      //------------------------------------------------------------------------

      public void UpdateGui ()
      {
         m_txtClass.Text     = m_rInfo.Class                                                   ;
         m_txtMethod.Text    = m_rInfo.Method                                                  ;
         m_txtFile.Text      = m_rInfo.File                                                    ;
         m_txtLine.Text      = m_rInfo.Line                                                    ;
         m_txtLevel.Text     = VxLibraryData.Common.Common.GetText.ErrorLevel ( m_rInfo.Level );
         m_txtErrorCode.Text = m_rInfo.ErrorCode + ""                                          ;
         m_txtErrorText.Text = m_rInfo.ErrorText                                               ;
      }

      //------------------------------------------------------------------------

      public static void Show ( ResultInfo rInfo )
      {
         new Dlg_ResultInfo ( rInfo ).ShowDialog ();
      }
   }
}
