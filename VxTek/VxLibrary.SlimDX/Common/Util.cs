using SlimDX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VxLibrary.SlimDX.Common
{
   public static class Util
   {
    public static void ReleaseCom ( ref ComObject ComObject )
    {
       if ( ComObject != null )
       {
          ComObject.Dispose ();

          ComObject = null;
       }
    }

      public static int LowWord ( this int Word )
      {
        return Word & 0xFFFF;
      }

      public static int HighWord ( this int Word )
      {
        return ( Word >> 16 ) & 0xFFFF;
      }
   }
}
