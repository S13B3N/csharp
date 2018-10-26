using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VxLibraryData.Common.Util;

namespace VxLibraryData.Gui.Gui
{
   public class ContentPane : Panel
   {
      private Control                   m_ControlActive = null                           ;
      private Dictionary<long, Control> m_ContorlList   = new Dictionary<long,Control> ();

      //------------------------------------------------------------------------

      public ContentPane ()
      {
      }

      //------------------------------------------------------------------------

      public ResultInfo ShowPanel ( long Key )
      {
         ResultInfo ResultInfo = new ResultInfo ();

         if ( m_ContorlList.ContainsKey ( Key ) )
         {
            m_ControlActive.Hide ();

            m_ControlActive = m_ContorlList[ Key ];

            m_ControlActive.Size = this.Size;

            m_ControlActive.Show ();
         }

         return ResultInfo;
      }

      public ResultInfo Register ( long Key, Control Control )
      {
         ResultInfo ResultInfo = new ResultInfo ();

         if ( !m_ContorlList.ContainsKey ( Key ) )
         {
            m_ContorlList.Add ( Key, Control );
         }
         else
         {
            ResultInfo.SetError ( -1, "Control alreasy registered", null, EErrorLevel.Fatal );
         }

         return ResultInfo;
      }
   }
}
