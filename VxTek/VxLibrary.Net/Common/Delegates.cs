using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VxLibrary.Net.Protocol.VX.Interface;
using VxLibrary.Net.Data;
using System.Net.Sockets;

namespace VxLibrary.Net.Common
{
   public delegate void DLog             ( String   Text );
   public delegate void DMessageReceived ( IMessage IMsg );
   public delegate void DPacketReceived  ( Packet   Pkt  );
}
