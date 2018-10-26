using System;
using System.Collections.Generic;
using System.Text;

namespace VXRandomLib
{
  public class RandomInt
  {
    protected static Random rnd;

    public static int GetRandomInt( int min, int max )
    {
      RandomInt.Init();
      int x = -1;

      x = RandomInt.rnd.Next(min, max+1);

      return x;
    }

    protected static void Init()
    {
      if (RandomInt.rnd == null)
        RandomInt.rnd = new Random();
    }
  }
}
