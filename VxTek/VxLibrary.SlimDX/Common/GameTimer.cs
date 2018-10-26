using SlimDX;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VxLibrary.SlimDX.Common
{
   public class GameTimer
   {
      private double m_SecondsPerCount;
      private double m_DeltaTime      ;

      private long   m_BaseTime       ;
      private long   m_PausedTime     ;
      private long   m_StopTime       ;
      private long   m_PrevTime       ;
      private long   m_CurrTime       ;

      private bool   m_Stopped        ;

      public GameTimer ()
      {
        m_SecondsPerCount =  0.0 ;
        m_DeltaTime       = -1.0 ;
        m_BaseTime        = 0    ;
        m_PausedTime      = 0    ;
        m_PrevTime        = 0    ;
        m_CurrTime        = 0    ;
        m_Stopped         = false;

         var CountsPerSec = Stopwatch.Frequency;

         m_SecondsPerCount = 1.0 / CountsPerSec;
      }

      public float TotalTime
      {
         get
         {
            if ( m_Stopped )
            {
               return ( float )((( m_StopTime - m_PausedTime ) - m_BaseTime ) * m_SecondsPerCount );
            }
            else
            {
               return ( float )((( m_CurrTime - m_PausedTime ) - m_BaseTime ) * m_SecondsPerCount );
            }
         }
      }

      public float DeltaTime { get { return ( float ) m_DeltaTime; }}

      public void Reset ()
      {
         var CurTime = Stopwatch.GetTimestamp ();

         m_BaseTime = CurTime;
         m_PrevTime = CurTime;
         m_StopTime = 0      ;
         m_Stopped  = false  ;
      }

      public void Start ()
      {
         var StartTime = Stopwatch.GetTimestamp ();

         if ( m_Stopped )
         {
            m_PausedTime += ( StartTime - m_StopTime );
            m_PrevTime    = StartTime                 ;
            m_StopTime    = 0                         ;
            m_Stopped     = false                     ;
         }
      }

      public void Stop ()
      {
         if ( !m_Stopped )
         {
            var CurTime = Stopwatch.GetTimestamp ();

            m_StopTime  = CurTime                  ;
            m_Stopped   = true                     ;
         }
      }

      public void Tick ()
      {
         if ( m_Stopped )
         {
            m_DeltaTime = 0.0;
            return;
         }

         var CurTime = Stopwatch.GetTimestamp ();

         m_CurrTime  = CurTime                                       ;
         m_DeltaTime = ( m_CurrTime - m_PrevTime) * m_SecondsPerCount;
         m_PrevTime  = m_CurrTime                                    ;

         if ( m_DeltaTime < 0.0 )
         {
            m_DeltaTime = 0.0;
         }
      }
   }
}
