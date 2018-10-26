using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VxLibraryData.Data.Common
{
   public class GetText
   {
      public static String DbErrorCodes ( long ErrorCode )
      {
         String Text;

         switch ( ErrorCode )
         {
            case GlobCons.m_DbErrorCode_DuplicateKeyValue :
            {
               Text = "Duplicate Key Value!";
            } break;

            case GlobCons.m_DbErrorCode_CantRemoveItem :
            {
               Text = "Can't remove item!";
            } break;

            case GlobCons.m_DbErrorCode_CantFindItem :
            {
               Text = "Can't find item!";
            } break;

            default :
            {
               Text = "???_{" + ErrorCode + "}_???";
            } break;
         }

         return Text;
      }
   }
}
