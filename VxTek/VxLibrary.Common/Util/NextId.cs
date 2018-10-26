using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VxLibraryData.Common.Util
{
   public class IdUtil
   {
      private long m_NextId;

      //------------------------------------------------------------------------

      public IdUtil ()
      {
         m_NextId = 1;
      }

      //------------------------------------------------------------------------
      // Properties
      //------------------------------------------------------------------------

      public long NextId { get { return m_NextId++; }}
   }
}
