using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using VxLibraryData.Common.Util;
using VxLibraryData.IO.Xml;

namespace VxLibraryData.Util.Common
{
   public class FileLogger : Logger
   {
      private TextWriter m_TextWriter;
      private Config     m_Config    ;

      [Serializable()]
      public class Config
      {
         private String m_FileName;

         //---------------------------------------------------------------------

         public Config ()
         {
            m_FileName = "logging.xml";
         }

         public Config ( String FileName )
         {
            m_FileName = FileName;
         }

         //---------------------------------------------------------------------
         // Properties
         //---------------------------------------------------------------------

         public String FileName { get { return m_FileName; } set { m_FileName = value; }}
      }

      //------------------------------------------------------------------------

      public FileLogger ( ELogLevel LogLevel ) : base ( LogLevel )
      {
         String FileName = "logging.xml";

         if ( !File.Exists ( FileName ))
         {
            m_Config = new Config ( "logging.log" );

            XmlFile.Save ( FileName, m_Config );
         }

         XmlFile.Load ( FileName, ref m_Config );

         e_Log += new DLog ( Logger_e_Log );
      }

      public FileLogger ( ELogLevel LogLevel, String FileName ) : base ( LogLevel )
      {
         m_Config = new Config ( FileName );

         e_Log += new DLog ( Logger_e_Log );
      }

      //------------------------------------------------------------------------
      // Logger events
      //------------------------------------------------------------------------

      public void Logger_e_Log ( ELogLevel LogLevel, string Text )
      {
         m_TextWriter.WriteLine ( Text ); m_TextWriter.Flush ();
      }

      //------------------------------------------------------------------------

      public ResultInfo Open ()
      {
         ResultInfo rInfo = new ResultInfo ();

         try
         {
            m_TextWriter = File.CreateText ( m_Config.FileName );
         }
         catch ( Exception Ex )
         {
            rInfo.SetError ( 0, Ex.Message + " <" + Ex.InnerException + ">", m_Config.FileName, EErrorLevel.Fatal );
         }

         return rInfo;
      }

      public ResultInfo Close ()
      {
         ResultInfo rInfo = new ResultInfo ();

         try
         {
            m_TextWriter.Close ();
         }
         catch ( Exception Ex )
         {
            rInfo.SetError ( 0, Ex.Message + " <" + Ex.InnerException + ">", m_Config.FileName, EErrorLevel.Fatal );
         }

         return rInfo;
      }
   }
}
