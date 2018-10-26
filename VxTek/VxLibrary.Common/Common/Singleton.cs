using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VxLibraryData.Common.Common
{
   public partial class Singleton<T> where T : new ()
   {
      private static T s_Object;

      //------------------------------------------------------------------------

      public static T GetInstance ()
      {
         if ( s_Object == null )
         {
            s_Object = new T ();
         }

         return s_Object;
      }
   }
}
