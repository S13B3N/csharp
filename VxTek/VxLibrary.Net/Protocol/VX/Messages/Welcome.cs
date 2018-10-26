using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VxLibrary.Net.Protocol.VX.Interface;

namespace VxLibrary.Net.Protocol.VX.Messages
{
   [Serializable()]
   public class Welcome : IMessage
   {
      protected long m_IdClient;

      //------------------------------------------------------------------------

      public Welcome ( long IdClient )
      {
         m_IdClient = IdClient;
      }

      public int MessageType ()
      {
         return 1;
      }

      public long IdClient { get { return m_IdClient; } set { m_IdClient = value; }}
   }
}
