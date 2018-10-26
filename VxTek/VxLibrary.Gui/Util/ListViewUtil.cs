using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VxLibraryData.Gui.Util
{
   public class ListViewUtil
   {
      private static List<ListViewItem> s_ListLvItem = new List<ListViewItem> ();
      private static List<String      > s_ListString = new List<String      > ();
      private static Object             s_Tag        = null                     ;

      //------------------------------------------------------------------------

      public static void Add ( String Str ) { s_ListString.Add ( Str            ); }
      public static void Add ( int    Str ) { s_ListString.Add ( Str.ToString ()); }
      public static void Add ( double Str ) { s_ListString.Add ( Str.ToString ()); }
      public static void Add ( float  Str ) { s_ListString.Add ( Str.ToString ()); }
      public static void Tag ( Object Tag ) { s_Tag = Tag                        ; }

      //------------------------------------------------------------------------

      public static void Next ()
      {
         ListViewItem LvItem = null;

         for ( int nIndex = 0; nIndex < s_ListString.Count; nIndex++ )
         {
            String Str = s_ListString[nIndex];

            if ( nIndex == 0 )
            {
               LvItem  = new ListViewItem ( Str );
            }
            else
            {
               LvItem.SubItems.Add ( Str );
            }
         }

         LvItem.Tag = s_Tag;

         s_ListLvItem.Add ( LvItem );

         s_ListString.Clear ();
      }

      public static void Apply ( ListView Lv )
      {
         Lv.Items.Clear ();

         Lv.Items.AddRange ( s_ListLvItem.ToArray ());

         Clear ();
      }

      public static void Clear ()
      {
         s_ListString.Clear ();
         s_ListLvItem.Clear ();
      }

      //------------------------------------------------------------------------

      public static bool SelectedItem<T> ( ListView Lv, ref T Item )
      {
         bool bItem = false;

         if ( Lv.SelectedItems.Count > 0 )
         {
            bItem = true;

            Item = ( T ) Lv.SelectedItems[0].Tag;
         }

         return bItem;
      }
   }
}
