using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;
using VxLibrary.Net.Data;
using VxLibrary.Net.Protocol.VX.Interface;

namespace VxLibrary.Net.Common
{
   public partial class SocketClient
   {
      protected    long             m_IdClient       ;
      protected    Socket           m_Socket         ;
      protected    bool             m_IsAlive        ;
      protected    byte[]           m_Buffer         ;

      public event DMessageReceived e_MessageReceived;
      public event DPacketReceived  e_PacketReceived ;

      //------------------------------------------------------------------------

      protected SocketClient ( long IdClient, Socket Socket )
      {
         m_IdClient      = IdClient            ;
         m_Socket        = Socket              ;

         byte[] Buffer   = new byte[ 512 ];
                m_Buffer = new byte[   0 ];

         m_Socket.BeginReceive ( Buffer, 0, Buffer.Length, SocketFlags.None, Socket_ReceiveCallback, Buffer );
      }

      //------------------------------------------------------------------------

      public void Send ( Packet Pkt )
      {
         m_Socket.Send ( Packet.ToByte ( Pkt ));
      }

      public void Send ( byte[] Buffer )
      {
         m_Socket.Send ( Buffer );
      }

      protected void Socket_ReceiveCallback ( IAsyncResult Ar )
      {
         byte[] BufferReceive = ( byte[] ) Ar.AsyncState;

         try
         {
            int BytesReceived = m_Socket.EndReceive ( Ar );

            if ( BytesReceived > 0 )
            {
               if ( m_Buffer.Length > 0 )
               {
                  byte[] BufferHelper = new byte[ m_Buffer.Length + BytesReceived ];

                  Array.Copy ( m_Buffer,      0, BufferHelper,               0, m_Buffer.Length );
                  Array.Copy ( BufferReceive, 0, BufferHelper, m_Buffer.Length, BytesReceived   );

                  m_Buffer = BufferHelper;
               }
               else
               {
                  byte[] BufferHelper = new byte[ BytesReceived ];

                  Array.Copy ( BufferReceive, 0, BufferHelper, 0, BytesReceived );

                  m_Buffer = BufferHelper;
               }
            }

            //---------------------------------------------------------------------

            Packet Pkt = null;

            while ( Packet.CreatePacket ( ref m_Buffer, out Pkt ))
            {
               if ( e_MessageReceived != null )
               {
                  e_MessageReceived (( IMessage ) Pkt.PayLoad );
               }

               if ( e_PacketReceived != null )
               {
                  e_PacketReceived ( Pkt );
               }
            }

            //---------------------------------------------------------------------

            m_Socket.BeginReceive ( BufferReceive, 0, BufferReceive.Length, SocketFlags.None, Socket_ReceiveCallback, BufferReceive );
         }
         catch ( Exception )
         {
            
         }
      }

      public void Receive ()
      {
         byte[] Buffer = new byte[512];

         m_Socket.BeginReceive ( Buffer, 0, Buffer.Length, SocketFlags.None, Socket_ReceiveCallback, m_Socket );
      }

      public void Disconnect ()
      {
         m_Socket.Shutdown ( SocketShutdown.Send );
         m_Socket.Close    (                     );
      }

      //------------------------------------------------------------------------
      // Properties
      //------------------------------------------------------------------------

      public long IdClient { get { return m_IdClient; } set { m_IdClient = value; }}
   }

   //---------------------------------------------------------------------------

   public partial class SocketClient
   {
      protected static long m_NextIdClient = 1;

      //------------------------------------------------------------------------

      public static SocketClient Accept ( Socket Socket )
      {
         return new SocketClient ( m_NextIdClient++, Socket );
      }

      public static SocketClient Create ( String Ip, int Port )
      {
         Socket Sock = new Socket ( AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp );

         Sock.Connect ( Ip, Port );

         return new SocketClient ( m_NextIdClient++, Sock );
      }
   }
}
