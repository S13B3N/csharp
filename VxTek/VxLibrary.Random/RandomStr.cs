using System;
using System.Collections.Generic;
using System.Text;

namespace VXRandomLib
{
  public class RandomStr
  {
    protected static Random m_Rnd;
    protected static String m_StdLetters = "abcdefghijklmnopqrstuvwxyz";

    public static String GetRandomStr ()
    {
      return GetRandomStr ( 10 );
    }

    public static String GetRandomStr( long Length )
    {
      RandomStr.Init();

      String Str = "";

      for ( int i = 0; i < Length; i++ )
      {
        Str += RandomStr.m_StdLetters [ RandomStr.m_Rnd.Next ( 0, RandomStr.m_StdLetters.Length ) ];
      }

      return Str;
    }

    protected static void Init()
    {
      if ( RandomStr.m_Rnd == null )
      {
        RandomStr.m_Rnd = new Random ();
      }
    }
  }
}
