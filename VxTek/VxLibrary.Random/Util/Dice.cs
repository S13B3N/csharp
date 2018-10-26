using System;

namespace VXRandomLib
{
   public class Dice
   {
      protected Random m_Rnd     ;
      protected int    m_Value   ;

      protected int    m_MinValue;
      protected int    m_MaxValue;

      //------------------------------------------------------------------------

      public Dice ( int MinValue, int MaxValue )
      {
         m_MinValue = MinValue;
         m_MaxValue = MaxValue;

         m_Value    = MinValue;
      }

      public Dice ( int MinValue, int MaxValue, Random Rnd )
      {
         m_MinValue = MinValue;
         m_MaxValue = MaxValue;

         m_Value    = MinValue;

         m_Rnd      = Rnd     ;
      }

      //------------------------------------------------------------------------

      public void Roll ()
      {
         m_Value = m_Rnd.Next ( m_MinValue, m_MaxValue + 1 );
      }

      //------------------------------------------------------------------------
      // Properties
      //------------------------------------------------------------------------

      public int Value { get { return m_Value; }}
   }
}