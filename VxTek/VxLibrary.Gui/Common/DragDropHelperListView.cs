using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VxLibraryData.Gui.Delegates;

namespace VxLibraryData.Gui.Common
{
   public class DragDropHelperListView
   {
      private ListView m_Lv1;
      private ListView m_Lv2;

      public event DDragDropFinished e_DragDropFinished;

      //------------------------------------------------------------------------

      public DragDropHelperListView ( ListView Lv1, ListView Lv2 )
      {
         m_Lv1 = Lv1;
         m_Lv2 = Lv2;

         m_Lv1.ItemDrag  += new ItemDragEventHandler ( m_Lv_ItemDrag  );
         m_Lv1.DragDrop  += new DragEventHandler     ( m_Lv_DragDrop  );
         m_Lv1.DragEnter += new DragEventHandler     ( m_Lv_DragEnter );

         m_Lv2.ItemDrag  += new ItemDragEventHandler ( m_Lv_ItemDrag  );
         m_Lv2.DragDrop  += new DragEventHandler     ( m_Lv_DragDrop  );
         m_Lv2.DragEnter += new DragEventHandler     ( m_Lv_DragEnter );
      }

      //------------------------------------------------------------------------
      // Listview events
      //------------------------------------------------------------------------

      private void m_Lv_ItemDrag ( object sender, ItemDragEventArgs e )
      {
         ListView Lv = ( ListView ) sender;

         Lv.DoDragDrop ( sender, DragDropEffects.Move );
      }

      private void m_Lv_DragDrop ( object sender, DragEventArgs e )
      {
         if ( e.Data.GetDataPresent ( typeof ( ListView )))
         {
            ListView LvSource = ( ListView ) e.Data.GetData ( typeof ( ListView ));
            ListView LvSender = ( ListView ) sender                               ;

            if (( LvSource != LvSender ) && (( LvSource == m_Lv1 ) || ( LvSource == m_Lv2 )))
            {
               foreach ( ListViewItem LvItem in LvSource.SelectedItems )
               {
                  LvSender.Items.Add    ((( ListViewItem )LvItem.Clone ()));
                  LvSource.Items.Remove ( LvItem )                         ;
               }

               LvSender.Sort ();
               LvSource.Sort ();

               if ( e_DragDropFinished != null )
               {
                  e_DragDropFinished ();
               }
            }
         }
      }

      private void m_Lv_DragEnter ( object sender, DragEventArgs e )
      {
         if ( e.Data.GetDataPresent ( typeof ( ListView )))
         {
            ListView LvSource = ( ListView ) e.Data.GetData ( typeof ( ListView ));
            ListView LvSender = ( ListView ) sender                               ;

            if (( LvSource != LvSender ) && (( LvSource == m_Lv1 ) || ( LvSource == m_Lv2 )))
            {
               e.Effect = DragDropEffects.Move;
            }
         }
         else
         {
            e.Effect = DragDropEffects.None;
         }
      }
   }
}
