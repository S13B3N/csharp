using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using VxLibraryData.Common.Util;

namespace VxLibraryData.Util.Common
{
   public class ConsoleLogger : Logger
   {
      public ConsoleLogger ( ELogLevel LogLevel ) : base ( LogLevel )
      {
         e_Log += new DLog ( Logger_e_Log );
      }

      //------------------------------------------------------------------------
      // Logger events
      //------------------------------------------------------------------------

      public void Logger_e_Log ( ELogLevel LogLevel, string Text )
      {
         Console.WriteLine ( Text );
      }
   }
}
