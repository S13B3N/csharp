using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace VxLibraryData.Common.Common
{
   public delegate void DWorkFinished (              );
   public delegate void DWorkAborted  (              );
   public delegate void DWorkProgress ( int Progress );
   //public delegate void DWorkProgress ( int Progress );

   //---------------------------------------------------------------------------

   public interface IBackgroundWorker
   {
      event DWorkProgress e_Progress;

      void  Work       ();
      void  Abort      ();
      bool  IsAborted  ();
   }

   //---------------------------------------------------------------------------

   public class BackgroundWorker
   {
      private      Thread            m_Thread      ;
      private      IBackgroundWorker m_WorkObject  ;

      public event DWorkFinished     e_WorkFinished;
      public event DWorkAborted      e_WorkAborted ;

      //------------------------------------------------------------------------

      public BackgroundWorker ( IBackgroundWorker WorkObject )
      {
         m_WorkObject = WorkObject;
      }

      //------------------------------------------------------------------------

      public void Start ()
      {
         m_Thread = new Thread ( new ThreadStart ( Work ));

         m_Thread.Start ();
      }

      public void Abort ()
      {
         m_WorkObject.Abort ();
      }

      private void Work ()
      {
         m_WorkObject.Work ();

         if ( !m_WorkObject.IsAborted ())
         {
            if ( e_WorkFinished != null )
            {
               e_WorkFinished ();
            }
         }
         else
         {
            if ( e_WorkAborted != null )
            {
               e_WorkAborted ();
            }
         }
      }
   }
}
