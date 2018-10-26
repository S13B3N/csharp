using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VxLibrary.Net.Protocol.VX.Interface;

namespace VxLibrary.Net.Protocol.VX.Messages
{
   [Serializable()]
   public class Text : IMessage
   {
      protected long   m_IdClient;
      protected String m_Text    ;

      //------------------------------------------------------------------------

      public Text ( long IdClient, String Text )
      {
         m_IdClient = IdClient;
         m_Text     = Text    ;
      }

      public int MessageType ()
      {
         return 2;
      }

      public long   IdClient { get { return m_IdClient; } set { m_IdClient = value; }}
      public String TextStr  { get { return m_Text    ; } set { m_Text     = value; }}
   }
}
