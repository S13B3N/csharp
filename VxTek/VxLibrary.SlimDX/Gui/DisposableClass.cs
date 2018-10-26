using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VxLibrary.SlimDX.Gui
{
   public class DisposableClass : IDisposable
   {
      private bool m_Disposed;

      public void Dispose ()
      {
         Dispose ( true );

         GC.SuppressFinalize ( this );
      }
      ~DisposableClass ()
      {
         Dispose ( false );
      }

      protected virtual void Dispose ( bool Disposing )
      {
         if ( m_Disposed ) return;

         if ( Disposing )
         {
         }

         m_Disposed = true;
      }
   }
}
