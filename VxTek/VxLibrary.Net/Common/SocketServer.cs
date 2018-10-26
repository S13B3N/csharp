using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using VxLibrary.Net.Data;
using VxLibrary.Net.Protocol.VX.Messages;
using VxLibrary.Net.Protocol.VX.Interface;

namespace VxLibrary.Net.Common
{
   public abstract class SocketServer
   {
      protected    IPEndPoint         m_IPEndPoint    ;
      protected    Socket             m_ListenerSocket;
      protected    Thread             m_WorkerThread  ;
      protected    bool               m_bStopped      ;

      protected    List<SocketClient> m_ClientList    ;
      protected    Mutex              m_Mutex         ;

      protected    IAsyncResult       m_AsyncResult   ;

      public SocketServer ()
      {
         m_bStopped   = true                     ;
         m_ClientList = new List<SocketClient> ();
         m_Mutex      = new Mutex              ();
      }

      public void Start ( int Port )
      {
         m_IPEndPoint = new IPEndPoint ( IPAddress.Any, Port );

         m_ListenerSocket = new Socket ( AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp );

         m_ListenerSocket.Bind ( m_IPEndPoint );

         m_ListenerSocket.Listen ( 5 );

         m_AsyncResult = m_ListenerSocket.BeginAccept ( Socket_AcceptCallback, m_ListenerSocket );
      }

      public void Stop ()
      {
         m_ListenerSocket.EndAccept ( m_AsyncResult );
         m_ListenerSocket.Close     (               );
      }

      protected void Socket_AcceptCallback ( IAsyncResult Ar )
      {
         Socket ListenerSocket = ( Socket ) Ar.AsyncState;

         SocketClient SockCli = SocketClient.Accept ( ListenerSocket.EndAccept ( Ar ));

         SockCli.e_PacketReceived += new DPacketReceived ( m_SocketClient_e_PacketReceived );

         m_ClientList.Add ( SockCli );

         Welcome Login = new Welcome ( SockCli.IdClient );

         Packet Pkt = new Packet ();

         Pkt.PayLoad = Login;

         Send ( Pkt );

         m_ListenerSocket.BeginAccept ( Socket_AcceptCallback, m_ListenerSocket );
      }

      public abstract void m_SocketClient_e_PacketReceived ( Packet Pkt );

      public void Send ( Packet Pkt )
      {
         Send ( Packet.ToByte ( Pkt ));
      }

      public void Send ( byte[] Buffer )
      {
         m_Mutex.WaitOne ();

         foreach ( SocketClient Sc in m_ClientList )
         {
            try
            {
               Sc.Send ( Buffer );
            }
            catch ( Exception Ex )
            {
            }
         }

         m_Mutex.ReleaseMutex ();
      }
   }
}
