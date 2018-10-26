using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VxLibrary.Net.Interface;

namespace VxLibrary.Net.Data
{
   [Serializable()]
   public class WelcomePacket : IPacket
   {
      protected long m_IdClient;

      //------------------------------------------------------------------------

      public WelcomePacket ( long IdClient )
      {
         m_IdClient = IdClient;
      }

      public int PacketType ()
      {
         return 1;
      }

      public long IdClient { get { return m_IdClient; } set { m_IdClient = value; }}
   }
}
