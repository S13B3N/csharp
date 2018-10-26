using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VxLibraryData.Common.Util;
using VxLibraryData.Data.Data;
using VxLibraryData.Data.Common;
using System.Diagnostics;

namespace VxLibraryData.Data
{
   [Serializable]
   public abstract class TableData<T> where T : Item <T>, new ()
   {
      public    event DDataChanged e_DataChanged;

      protected       long         m_NextId     ;
      protected       List<T>      m_DataList   ;

      //------------------------------------------------------------------------

      public TableData ()
      {
         m_NextId   =              1;
         m_DataList = new List<T> ();
      }

      //------------------------------------------------------------------------

      public virtual ResultInfo SelectAll ( ref List<T> ListValue )
      {
         if ( ListValue == null ) { ListValue = new List<T> (); }
         else                     { ListValue.Clear         (); }

         //---------------------------------------------------------------------

         foreach ( T Item in m_DataList )
         {
            ListValue.Add ( Item.Clone ());
         }

         return new ResultInfo ();
      }

      //------------------------------------------------------------------------

      public ResultInfo SelectMatch ( Predicate<T> Match, ref T Item )
      {
         T SearchItem = m_DataList.Find ( Match );

         if ( SearchItem != null )
         {
            Item = SearchItem.Clone ();
         }

         return new ResultInfo ();
      }

      //------------------------------------------------------------------------

      public ResultInfo SelectMatch ( Predicate<T> Match, ref List<T> ListValue )
      {
         if ( ListValue == null ) { ListValue = new List<T> (); }
         else                     { ListValue.Clear         (); }

         //---------------------------------------------------------------------

         List<T> ResultList = m_DataList.FindAll ( Match );

         if ( ResultList != null )
         {
            foreach ( T SearchItem in ResultList )
            {
               ListValue.Add ( SearchItem.Clone ());
            }
         }

         return new ResultInfo ();
      }

      //------------------------------------------------------------------------

      public virtual ResultInfo Insert ( T Item )
      {
         ResultInfo rInfo = new ResultInfo ();

         SetPrimaryKey ( ref Item );

         if ( CheckDuplicates ( Item ))
         {
            m_DataList.Add ( Item );
         }
         else
         {
            rInfo.SetDbError ( GlobCons.m_DbErrorCode_DuplicateKeyValue, GetText.DbErrorCodes ( GlobCons.m_DbErrorCode_DuplicateKeyValue ), Item, new StackFrame ( true ), EErrorLevel.Error );
         }

         return rInfo;
      }

      public virtual ResultInfo Insert ( T[] ItemArr )
      {
         ResultInfo rInfo = new ResultInfo ();

         foreach ( T Item in ItemArr )
         {
            rInfo = Insert ( Item );

            if ( rInfo.IsNotOK ())
            {
               break;
            }
         }

         return rInfo;
      }

      public virtual ResultInfo Insert ( List<T> ItemList )
      {
         ResultInfo rInfo = new ResultInfo ();

         foreach ( T Item in ItemList )
         {
            rInfo = Insert ( Item );

            if ( rInfo.IsNotOK ())
            {
               break;
            }
         }

         return rInfo;
      }

      //------------------------------------------------------------------------

      public virtual ResultInfo Update ( List<T> ListT )
      {
         ResultInfo rInfo = new ResultInfo ();

         foreach ( T Item in ListT )
         {
            rInfo = Update ( Item );

            if ( rInfo.IsNotOK ())
            {
               break;
            }
         }

         return rInfo;
      }

      public virtual ResultInfo Update ( T Item )
      {
         ResultInfo rInfo = new ResultInfo ();

         T OriginItem = m_DataList.Find ( GetPrimaryKeyPredicate ( Item ));

         if ( OriginItem != null )
         {
            int nIndex = m_DataList.IndexOf ( OriginItem );

            m_DataList[nIndex] = Item;
         }
         else
         {
            rInfo.SetDbError ( VxLibraryData.Data.Common.GlobCons.m_DbErrorCode_CantFindItem, VxLibraryData.Data.Common.GetText.DbErrorCodes ( VxLibraryData.Data.Common.GlobCons.m_DbErrorCode_CantFindItem ), Item, new StackFrame ( true ), EErrorLevel.Error );
         }

         return rInfo;
      }

      //------------------------------------------------------------------------

      public virtual ResultInfo Remove ( List<T> ListT )
      {
         ResultInfo rInfo = new ResultInfo ();

         foreach ( T Item in ListT )
         {
            rInfo = Remove ( Item );

            if ( rInfo.IsNotOK ())
            {
               break;
            }
         }

         return rInfo;
      }

      public virtual ResultInfo Remove ( T Item )
      {
         ResultInfo rInfo = new ResultInfo ();

         T Helper = m_DataList.Find ( GetPrimaryKeyPredicate ( Item ));

         if ( Helper != null )
         {
            if ( !m_DataList.Remove ( Helper ))
            {
               rInfo.SetDbError ( VxLibraryData.Data.Common.GlobCons.m_DbErrorCode_CantRemoveItem, VxLibraryData.Data.Common.GetText.DbErrorCodes ( VxLibraryData.Data.Common.GlobCons.m_DbErrorCode_CantRemoveItem ), Helper, new StackFrame ( true ), EErrorLevel.Fatal );
            }
         }
         else
         {
            rInfo.SetDbError ( VxLibraryData.Data.Common.GlobCons.m_DbErrorCode_CantFindItem, VxLibraryData.Data.Common.GetText.DbErrorCodes ( VxLibraryData.Data.Common.GlobCons.m_DbErrorCode_CantFindItem ), Helper, new StackFrame ( true ), EErrorLevel.Error );
         }

         return rInfo;
      }

      //------------------------------------------------------------------------

      public void Clear ()
      {
         m_NextId = 1;

         m_DataList.Clear ();
      }

      //------------------------------------------------------------------------

      protected void FireDataChanged ()
      {
         if ( e_DataChanged != null ) { e_DataChanged (); }
      }

      //------------------------------------------------------------------------

      //protected abstract void         SetPrimaryKey          ( ref T Item );
      //protected abstract Predicate<T> GetPrimaryKeyPredicate (     T Item );
      //protected abstract bool         CheckDuplicates        (     T Item );

      protected virtual void SetPrimaryKey ( ref T Item )
      {
         Item.PrimaryKey = m_NextId++;
      }

      protected virtual Predicate<T> GetPrimaryKeyPredicate ( T Item )
      {
         return new Predicate<T> ( FindArg => FindArg.PrimaryKey == Item.PrimaryKey );
      }

      protected virtual bool CheckDuplicates ( T Item )
      {
         return !m_DataList.Contains ( Item, new ItemComparer<T> ());
      }

      //------------------------------------------------------------------------
      // Properties
      //------------------------------------------------------------------------

      /*
       !! Must be public for serialization !!
      */

      public long    NextId   { get { return m_NextId  ; } set { m_NextId   = value; }}
      public List<T> DataList { get { return m_DataList; } set { m_DataList = value; }}
   }
}
