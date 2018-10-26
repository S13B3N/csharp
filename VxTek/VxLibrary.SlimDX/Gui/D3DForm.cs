using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VxLibrary.SlimDX.Gui
{
   public delegate bool MyWndProc ( ref Message Message );

   public class D3DForm : Form
   {
      public MyWndProc MyWndProc;

      protected override void WndProc ( ref Message Message )
      {
         if ( MyWndProc != null )
         {
            if ( MyWndProc ( ref Message )) return;
        }

        base.WndProc ( ref Message );
      }
   }
}
