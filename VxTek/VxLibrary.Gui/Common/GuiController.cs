using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using VxLibraryData.Gui.Delegates;

namespace VxLibraryData.Gui.Common
{
   public partial class GuiController
   {
      protected  Panel                      m_ContentPane                                    ;
      protected  Dictionary<Enum, IUsrCtrl> m_UsrCtrlList = new Dictionary<Enum, IUsrCtrl> ();

      //------------------------------------------------------------------------

      protected GuiController ()
      {
      }

      public GuiController ( Panel ContentPane )
      {
         m_ContentPane = ContentPane;
      }

      //------------------------------------------------------------------------

      public void AddCtrlToPanel ( Enum IdUsrCtrl, IUsrCtrl UsrCtrl )
      {
         UsrCtrl.e_ButtonClicked += new DButtonClicked ( ShowUsrCtrl );

         m_UsrCtrlList.Add          ( IdUsrCtrl, UsrCtrl     );
         m_ContentPane.Controls.Add (( UserControl ) UsrCtrl );

         (( UserControl ) UsrCtrl ).Hide ();
      }

      public void _RegisterControl ( Enum IdUsrCtrl, IUsrCtrl UsrCtrl )
      {
         AddCtrlToPanel ( IdUsrCtrl, UsrCtrl );
      }

      //------------------------------------------------------------------------

      public void ShowUsrCtrl ( Enum IdUsrCtrl )
      {
         ShowUsrCtrl ( IdUsrCtrl, null );
      }

      public void ShowUsrCtrl ( Enum IdUsrCtrl, GuiData Data )
      {
         if ( m_UsrCtrlList.ContainsKey ( IdUsrCtrl ) )
         {
            UserControl UsrCtrl = ( UserControl ) m_UsrCtrlList[ IdUsrCtrl ];

            UsrCtrl.Size = new Size ( m_ContentPane.Size.Width, m_ContentPane.Size.Height );

            UsrCtrl.Anchor = AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom;

            m_UsrCtrlList[ IdUsrCtrl ].SetGuiData   ( Data );
            m_UsrCtrlList[ IdUsrCtrl ].UpdateGui    (      );
            UsrCtrl                   .Show         (      );
            UsrCtrl                   .BringToFront (      );
            UsrCtrl                   .Focus        (      );
         }
         else
         {
            throw new Exception ( "User Control does not exists! (" + IdUsrCtrl + ")" );
         }
      }

      //------------------------------------------------------------------------

      public void UpdateGui ()
      {
         foreach ( IUsrCtrl UsrCtrl in m_UsrCtrlList.Values )
         {
            UsrCtrl.UpdateGui ();
         }
      }
   }

   //---------------------------------------------------------------------------
   // Static part
   //---------------------------------------------------------------------------

   public partial class GuiController
   {
      enum EGuiController
      {
         NoType
      }

      protected static Dictionary<Enum, GuiController> s_DictGuiController = new Dictionary<Enum, GuiController> ();

      //------------------------------------------------------------------------

      protected static GuiController GetInstance ( Enum EdGuiController )
      {
         if ( !s_DictGuiController.ContainsKey ( EdGuiController ))
         {
            s_DictGuiController[EdGuiController] = new GuiController ();
         }

         return s_DictGuiController[EdGuiController];
      }

      //------------------------------------------------------------------------

      public static void RegisterTargetPanel ( Enum EGuiController, Panel Panel )
      {
         GuiController.GetInstance ( EGuiController ).m_ContentPane = Panel;
      }

      public static void RegisterTargetPanel ( Panel Panel )
      {
         GuiController.RegisterTargetPanel ( EGuiController.NoType, Panel );
      }

      public static void RegisterControl ( Enum EGuiController, Enum IdUsrCtrl, IUsrCtrl UsrCtrl )
      {
         GuiController.GetInstance ( EGuiController ).AddCtrlToPanel ( IdUsrCtrl, UsrCtrl );
      }

      public static void RegisterControl ( Enum IdUsrCtrl, IUsrCtrl UsrCtrl )
      {
         RegisterControl ( EGuiController.NoType, IdUsrCtrl, UsrCtrl );
      }

      //------------------------------------------------------------------------

      public static void ShowControl ( Enum EGuiController, Enum IdUsrCtrl )
      {
         GuiController.GetInstance ( EGuiController ).ShowUsrCtrl ( IdUsrCtrl );
      }

      public static void ShowControl ( Enum IdUsrCtrl )
      {
         GuiController.ShowControl ( EGuiController.NoType, IdUsrCtrl );
      }

      public static void ShowControl ( Enum EGuiController, Enum IdUsrCtrl, GuiData Data )
      {
         GuiController.GetInstance ( EGuiController ).ShowUsrCtrl ( IdUsrCtrl, Data );
      }

      public static void ShowControl ( Enum IdUsrCtrl, GuiData Data )
      {
         GuiController.ShowControl ( EGuiController.NoType, IdUsrCtrl, Data );
      }
   }
}
