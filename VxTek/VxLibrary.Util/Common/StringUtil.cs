using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using VxLibraryData.Common.Util;

namespace VxLibraryData.Util.Common
{
   public class StringUtil
   {
      public static String FormatCurrency ( float Number )
      {
         return String.Format ( "{0:0,0.00}", Number );
      }

      public static String FormatCurrency ( double Number )
      {
         return String.Format ( "{0:0,0.00}", Number );
      }
   }
}
