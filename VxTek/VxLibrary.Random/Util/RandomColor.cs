using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using VXRandomLib;

namespace VxLibraryData.Random.Util
{
   public class RandomColor
   {
      public static Color GetRandomColor ()
      {
         return Color.FromArgb ( RandomInt.GetRandomInt ( 0, 255 ), RandomInt.GetRandomInt ( 0, 255 ), RandomInt.GetRandomInt ( 0, 255 ));
      }
      public static Color GetRandomColor ( int Min, int Max )
      {
         Color rColor;

         switch ( RandomInt.GetRandomInt ( Min, Max ))
         {
            case 1: rColor = Color.Red   ; break;
            case 2: rColor = Color.Blue  ; break;
            case 3: rColor = Color.Green ; break;
            case 4: rColor = Color.Yellow; break;
            case 5: rColor = Color.Orange; break;
            case 6: rColor = Color.Gray  ; break;
            case 7: rColor = Color.Pink  ; break;
            default: rColor = Color.White; break;
         }

         return rColor;
    }
  }
}
