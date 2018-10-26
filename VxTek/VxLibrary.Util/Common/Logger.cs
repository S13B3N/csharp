using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;

namespace VxLibraryData.Util.Common
{
   public delegate void DLog ( ELogLevel LogLevel, String Text );

   public enum ELogLevel
   {
      Debug,
      Info ,
      Warn ,
      Error,
      Fatal
   }

   //---------------------------------------------------------------------------

   public class Logger
   {
      private      ELogLevel m_LogLevel;
      public event DLog      e_Log     ;

      //------------------------------------------------------------------------

      public Logger ( ELogLevel LogLevel )
      {
         m_LogLevel = LogLevel;
      }

      //------------------------------------------------------------------------

      [MethodImpl ( MethodImplOptions.Synchronized )]
      public void Info ( String Text )
      {
         Log ( ELogLevel.Info, Text );
      }

      [MethodImpl ( MethodImplOptions.Synchronized )]
      public void Warn ( String Text )
      {
         Log ( ELogLevel.Warn, Text );
      }

      [MethodImpl ( MethodImplOptions.Synchronized )]
      public void Error ( String Text )
      {
         Log ( ELogLevel.Error, Text );
      }

      [MethodImpl ( MethodImplOptions.Synchronized )]
      public void Fatal ( String Text )
      {
         Log ( ELogLevel.Fatal, Text );
      }

      [MethodImpl ( MethodImplOptions.Synchronized )]
      public void Debug ( String Text )
      {
         Log ( ELogLevel.Debug, Text );
      }

      [MethodImpl ( MethodImplOptions.Synchronized )]
      private void Log ( ELogLevel LogLevel, String Text )
      {
         if ( m_LogLevel <= LogLevel )
         {
            if ( e_Log != null )
            {
               e_Log ( m_LogLevel, DateTime.Now.ToShortDateString () + " " + DateTime.Now.ToLongTimeString () + " | " + GetText ( LogLevel ) + " | "  + Text );
            }
         }
      }

      //------------------------------------------------------------------------

      private String GetText ( ELogLevel LogLevel )
      {
         String Text = "???";

         switch ( LogLevel )
         {
            case ELogLevel.Debug : Text = "Debug"; break;
            case ELogLevel.Info  : Text = "Info "; break;
            case ELogLevel.Warn  : Text = "Warn "; break;
            case ELogLevel.Error : Text = "Error"; break;
            case ELogLevel.Fatal : Text = "Fatal"; break;
         }

         return Text;
      }
   }
}
