using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace VxLibrary.Net.Data
{
   public partial class Packet
   {
      protected long          m_Version       =  100;
      protected int           m_LengthPayload =    0;
      protected Object        m_Payload       = null;

      //------------------------------------------------------------------------

      public Packet ()
      {
      }

      public int MinLength ()
      {
         return 8 + 4;
      }

      public Object PayLoad { get { return m_Payload; } set { m_Payload = value; } }
   }

   public partial class Packet
   {
      protected static ASCIIEncoding   m_Encoder      = new ASCIIEncoding   ();
      protected static BinaryFormatter m_BinFormatter = new BinaryFormatter ();

      //------------------------------------------------------------------------

      public static bool CreatePacket ( ref byte[] Buffer, out Packet Pkt )
      {
         bool bPacketValid = false;

         Pkt = new Packet ();

         if ( Buffer.Length > Pkt.MinLength ())
         {
            Pkt.m_Version       = BitConverter.ToInt64  ( Buffer,  0                      );
            Pkt.m_LengthPayload = BitConverter.ToInt32  ( Buffer,  8                      );

            if ( Buffer.Length >= 12 + Pkt.m_LengthPayload )
            {
               MemoryStream MemStream = new MemoryStream ( Buffer, Pkt.MinLength (), Pkt.m_LengthPayload );

               Pkt.m_Payload = m_BinFormatter.Deserialize ( MemStream );

               //---------------------------------------------------------------
               // Clean up buffer
               //---------------------------------------------------------------

               byte[] BufferHelper = new byte[ Buffer.Length - ( 12 + Pkt.m_LengthPayload )];

               if ( BufferHelper.Length > 0 )
               {
                  Array.Copy ( Buffer, 12 + Pkt.m_LengthPayload, BufferHelper, 0, BufferHelper.Length );
               }

               Buffer = BufferHelper;

               bPacketValid = true;
            }
         }

         return bPacketValid;
      }

      public static Packet Create ( Object Obj )
      {
         Packet Pkt = new Packet ();

         Pkt.m_Payload = Obj;

         return Pkt;
      }

      public static byte[] ToByte ( Packet Pkt )
      {
         MemoryStream Stream = new MemoryStream ();

         m_BinFormatter.Serialize ( Stream, Pkt.m_Payload );

         byte[] BufferObject = Stream.ToArray ();

         Pkt.m_LengthPayload = BufferObject.Length;

         //---------------------------------------------------------------------

         byte[] Buffer = new byte[( Pkt.MinLength () + Pkt.m_LengthPayload )];

         Array.Copy ( BitConverter.GetBytes ( Pkt.m_Version       ), 0, Buffer,  0, 8                   );
         Array.Copy ( BitConverter.GetBytes ( Pkt.m_LengthPayload ), 0, Buffer,  8, 4                   );
         Array.Copy ( BufferObject                                 , 0, Buffer, 12, Pkt.m_LengthPayload );

         return Buffer;
      }
   }
}
