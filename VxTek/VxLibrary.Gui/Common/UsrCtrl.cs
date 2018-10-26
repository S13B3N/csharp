using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VxLibraryData.Gui.Delegates;
using System.Windows.Forms;

namespace VxLibraryData.Gui.Common
{
   public interface IUsrCtrl
   {
      event DButtonClicked e_ButtonClicked;

      void SetGuiData ( GuiData Data );
      void UpdateGui  (              );
   }

   //---------------------------------------------------------------------------

   public class UsrCtrl : UserControl, IUsrCtrl
   {
      public event DButtonClicked e_ButtonClicked;

      //------------------------------------------------------------------------

      protected void ShowUsrCtrl ( Enum IdUsrCtrl )
      {
         if ( e_ButtonClicked != null )
         {
            e_ButtonClicked ( IdUsrCtrl );
         }
      }

      public virtual void SetGuiData ( GuiData Data )
      {
      }

      public virtual void UpdateGui ()
      {
         throw new NotImplementedException ();
      }

      /*
       * Tipparbeit
       * 

      public override void SetGuiData ( GuiData Data )
      {
         m_GuiData = ( GuiData ) Data;
      }

      //------------------------------------------------------------------------
      // UpdateGui
      //------------------------------------------------------------------------

      public override void UpdateGui ()
      {

      }
       */
   }
}
