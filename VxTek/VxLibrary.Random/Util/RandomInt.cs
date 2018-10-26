using System;
using System.Collections.Generic;
using System.Text;

namespace VXRandomLib
{
   public class RandomInt
   {
      protected static Random m_Rnd;

      public static int GetRandomInt ( int Min, int Max )
      {
         RandomInt.Init ();

         return RandomInt.m_Rnd.Next ( Min, Max + 1 );
    }

    protected static void Init ()
    {
      if ( RandomInt.m_Rnd == null )
         RandomInt.m_Rnd = new Random ();
    }
  }
}
