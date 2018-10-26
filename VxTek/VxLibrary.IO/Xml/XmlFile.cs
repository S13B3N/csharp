using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using VxLibraryData.Common.Util;
using System.IO;
using System.Windows.Forms;

namespace VxLibraryData.IO.Xml
{
   public class XmlFile
   {
      private static String s_FileName = null;

      //------------------------------------------------------------------------

      public static ResultInfo Load<T> ( String FileName, ref T Data )
      {
         ResultInfo ResultInfo = new ResultInfo ();

         StreamReader Streamer = null;

         try
         {
            XmlSerializer XmlSealer = new XmlSerializer ( typeof ( T ) );

            Streamer = new StreamReader ( FileName );

            Data = ( T ) XmlSealer.Deserialize ( Streamer ); Streamer.Close ();
         }
         catch ( Exception Exp )
         {
            if ( Streamer != null )
            {
               Streamer.Close ();
            }

            ResultInfo.SetError ( 0, Exp.Message, FileName, 0 );
         }

         return ResultInfo;
      }

      //------------------------------------------------------------------------

      public static ResultInfo Save<T> ( String FileName, T Data )
      {
         ResultInfo ResultInfo = new ResultInfo ();

         TextWriter Streamer = null;

         try
         {
            XmlSerializer XmlSealer = new XmlSerializer ( typeof ( T ));

            Streamer = new StreamWriter ( FileName );

            XmlSealer.Serialize ( Streamer, Data ); Streamer.Close ();
         }
         catch ( Exception Exp)
         {
            if ( Streamer != null )
            {
               Streamer.Close ();
            }

            ResultInfo.SetError ( 0, Exp.Message + "\r\n" + Exp.InnerException, FileName, 0 );
         }

         return ResultInfo;
      }

      //------------------------------------------------------------------------

      public static ResultInfo Load<T> ( ref T Data )
      {
         ResultInfo ResultInfo = new ResultInfo ();

         if ( s_FileName == null )
         {
            OpenFileDialog Dlg = new OpenFileDialog ();

            if ( Dlg.ShowDialog () == DialogResult.OK )
            {
               s_FileName = Dlg.FileName;
            }
            else
            {
               ResultInfo.SetError ( 0, "Keine Datei ausgewählt!", null, EErrorLevel.Error );
            }
         }

         if ( ResultInfo.IsOK ())
         {
            StreamReader Streamer = null;

            try
            {
               XmlSerializer XmlSealer = new XmlSerializer ( typeof ( T ) );

               Streamer = new StreamReader ( s_FileName );

               Data = ( T ) XmlSealer.Deserialize ( Streamer ); Streamer.Close ();
            }
            catch ( Exception Exp )
            {
               if ( Streamer != null )
               {
                  Streamer.Close ();
               }

               ResultInfo.SetError ( 0, Exp.Message, s_FileName, 0 );
            }
         }

         return ResultInfo;
      }

      //------------------------------------------------------------------------

      public static ResultInfo Save<T> ( T Data )
      {
         ResultInfo ResultInfo = new ResultInfo ();

         if ( s_FileName == null )
         {
            SaveFileDialog Dlg = new SaveFileDialog ();

            if ( Dlg.ShowDialog () == DialogResult.OK )
            {
               s_FileName = Dlg.FileName;
            }
            else
            {
               ResultInfo.SetError ( 0, "Keine Datei ausgewählt!", null, EErrorLevel.Error );
            }
         }

         if ( ResultInfo.IsOK ())
         {
            TextWriter Streamer = null;

            try
            {
               XmlSerializer XmlSealer = new XmlSerializer ( typeof ( T ));

               Streamer = new StreamWriter ( s_FileName );

               XmlSealer.Serialize ( Streamer, Data ); Streamer.Close ();
            }
            catch ( Exception Exp)
            {
               if ( Streamer != null )
               {
                  Streamer.Close ();
               }

               ResultInfo.SetError ( 0, Exp.Message + "\r\n" + Exp.InnerException, s_FileName, 0 );
            }
         }

         return ResultInfo;
      }

      //------------------------------------------------------------------------
      // Properties
      //------------------------------------------------------------------------

      public static String FileName { get { return s_FileName; } set { s_FileName = value; }}
   }
}
