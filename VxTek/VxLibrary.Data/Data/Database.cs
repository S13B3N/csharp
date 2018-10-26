using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VxLibraryData.Common.Util;
using VxLibraryData.IO.Xml;
using VxLibraryData.Data.Data;

namespace VxLibraryData.Data
{
   [Serializable]
   public partial class Database
   {
      public event  DDataChanged e_DataChanged ;

      protected     String       m_FileName    ;
      protected     bool         m_DataNotSaved;

      //------------------------------------------------------------------------

      public Database ()
      {
      }

      //------------------------------------------------------------------------

      public void DataChanged ()
      {
         if ( e_DataChanged != null )
         {
            e_DataChanged ();
         }
      }
   }

   //------------------------------------------------------------------------
   // Static part
   //------------------------------------------------------------------------

   public partial class Database
   {
      public static ResultInfo Load<T> ( String FileName, ref T Database )
      {
         ResultInfo ResultInfo = XmlFile.Load ( FileName, ref Database );

         return ResultInfo;
      }

      public static ResultInfo Save<T> ( String FileName, T Database )
      {
         ResultInfo ResultInfo = XmlFile.Save ( FileName, Database );

         return ResultInfo;
      }
   }
}
