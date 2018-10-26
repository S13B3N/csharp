using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VxLibraryData.Common.Util;

namespace VxLibraryData.Data.Data
{
   public interface ICopy<T>
   {
      T    Clone (        );
   }

   public abstract class Item<T> : ICopy<T>
   {
      public T Clone ()
      {
         return ( T ) MemberwiseClone ();
      }

      public virtual long PrimaryKey { get { throw new NotImplementedException (); } set { throw new NotImplementedException (); }}
   }

   public class ItemComparer<T> : IEqualityComparer<Item<T>>
   {
      public bool Equals ( Item<T> Item1, Item<T> Item2 )
      {
         return Item1.PrimaryKey.Equals ( Item2.PrimaryKey );
      }

      public int GetHashCode ( Item<T> Item )
      {
         throw new NotImplementedException ();
      }
   }
}
