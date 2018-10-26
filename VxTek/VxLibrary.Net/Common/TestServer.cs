using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VxLibrary.Net.Protocol.VX.Interface;
using System.Net.Sockets;

namespace VxLibrary.Net.Common
{
   public class TestServer : SocketServer
   {
      public event DLog               e_Log           ;

      //------------------------------------------------------------------------

      protected void Log ( String Text )
      {
         if ( e_Log != null )
         {
            e_Log ( Text );
         }
      }

      public override void m_SocketClient_e_PacketReceived ( Data.Packet Pkt )
      {
         switch ((( IMessage ) Pkt.PayLoad ).MessageType ())
         {
            case 1 :
            {
            }
            break;

            case 2 :
            {
               foreach ( SocketClient SocCli in m_ClientList )
               {
                  SocCli.Send ( Pkt );
               }
            }
            break;
         }
      }
   }
}
