using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VxLibraryData.Common.Util;

namespace VxLibraryData.Common.Common
{
public class GetText
   {
      public static String ErrorLevel ( EErrorLevel Level )
      {
         String Text;

         switch ( Level )
         {
            case EErrorLevel.Info  : { Text = "Information"; } break;
            case EErrorLevel.Debug : { Text = "Debug"      ; } break;
            case EErrorLevel.Warn  : { Text = "Warning"    ; } break;
            case EErrorLevel.Error : { Text = "Error"      ; } break;
            case EErrorLevel.Fatal : { Text = "Fatal error"; } break;

            default :
            {
               Text = "???_{" + Level + "}_???";
            } break;
         }

         return Text;
      }
   }
}
