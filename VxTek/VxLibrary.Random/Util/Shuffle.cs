using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VXRandomLib;

namespace VxLibraryData.Random.Util
{
   public class Shuffle
   {
      public static void List<T> ( ref List<T> List )
      {
         int MaxIndex = List.Count;

         while ( MaxIndex-- > 0 )
         {
            int RandomInteger = RandomInt.GetRandomInt ( 0, MaxIndex );

            T Helper = List[ RandomInteger ];

            List[ RandomInteger ] = List[ MaxIndex ];

            List[ MaxIndex ] = Helper;
         }
      }
   }
}
