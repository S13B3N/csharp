using System;

namespace VXRandomLib
{
   public class Dice
   {
      protected Random rnd;

      protected bool  stands = false;
      protected int   eye    = 1;

      public Dice( Random rnd )
      {
         this.rnd = rnd;
      }
      public void Role()
      {
         if( stands == false )
            this.eye = this.rnd.Next( 1, 7 );
      }

      public void SetStands()
      {
         if( stands )
            this.stands = false;
         else
            this.stands = true;
      }

      public bool GetHold()
      {
        return this.stands;
      }

      public void ResetHold()
      {
         stands = false;
      }

      public int GetEye()
      {
         return this.eye;
      }
      
      public void SetEye( int i )
      {
         this.eye = i;
      }   
   }
}