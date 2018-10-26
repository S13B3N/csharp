using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace VxLibraryData.Common.Util
{
   public enum EErrorLevel
   {
      Info  = 1,
      Debug = 2,
      Warn  = 3,
      Error = 4,
      Fatal = 5
   }

   //---------------------------------------------------------------------------

   public partial class ResultInfo
   {
      protected long        m_ErrorCode;
      protected String      m_ErrorText;
      protected Object      m_Tag      ;

      protected String      m_Class    ;
      protected String      m_Method   ;
      protected String      m_File     ;
      protected String      m_Line     ;
      protected EErrorLevel m_Level    ;

      protected bool        m_bError   ;
      protected bool        m_bErrorDb ;

      //------------------------------------------------------------------------

      public ResultInfo ()
      {
         Reset ();
      }

      public void Reset ()
      {
         m_ErrorCode =     0;
         m_ErrorText =    "";
         m_Tag       =    "";

         m_Class     =    "";
         m_Method    =    "";
         m_File      =    "";
         m_Line      =    "";
         m_Level     =     0;

         m_bError    = false;
         m_bErrorDb  = false;
      }

      //------------------------------------------------------------------------

      public void SetError ( long ErrorCode, String ErrorText, Object Tag, EErrorLevel Level )
      {
         SetData ( ErrorCode, ErrorText, Tag, "", "", "", "", Level );

         m_bError = true;
      }

      public void SetError ( long ErrorCode, String ErrorText, Object Tag, StackFrame StackFrame, EErrorLevel Level )
      {
         SetData ( ErrorCode, ErrorText, Tag, StackFrame, Level );

         m_bError = true;
      }

      public void SetError ( long ErrorCode, String ErrorText, Object Tag, String Class, String Method, String File, String Line, EErrorLevel Level )
      {
         SetData ( ErrorCode, ErrorText, Tag, Class, Method, File, Line, Level );

         m_bError = true;
      }

      public void SetDbError ( long ErrorCode, String ErrorText, Object Tag, StackFrame StackFrame, EErrorLevel Level )
      {
         SetData ( ErrorCode, ErrorText, Tag, StackFrame, Level );

         m_bErrorDb = true;
      }

      public void SetDbError ( long ErrorCode, String ErrorText, Object Tag, String Class, String Method, String File, String Line, EErrorLevel Level )
      {
         SetData ( ErrorCode, ErrorText, Tag, Class, Method, File, Line, Level );

         m_bErrorDb = true;
      }

      private void SetData ( long ErrorCode, String ErrorText, Object Tag, StackFrame StackFrame, EErrorLevel Level )
      {
         SetData ( ErrorCode, ErrorText, Tag, "", StackFrame.GetMethod ().Name, StackFrame.GetFileName (), StackFrame.GetFileLineNumber ().ToString (), Level );
      }

      private void SetData ( long ErrorCode, String ErrorText, Object Tag, String Class, String Method, String File, String Line, EErrorLevel Level )
      {
         m_ErrorCode = ErrorCode;
         m_ErrorText = ErrorText;
         m_Tag       = Tag      ;
         m_Class     = Class    ;
         m_Method    = Method   ;
         m_File      = File     ;
         m_Line      = Line     ;
         m_Level     = Level    ;
      }

      //------------------------------------------------------------------------

      public bool IsOK ()
      {
         return !( m_bError || m_bErrorDb );
      }

      public bool IsNotOK ()
      {
         return ( m_bError || m_bErrorDb );
      }

      public bool IsDatabaseError ()
      {
         return m_bErrorDb;
      }

      //------------------------------------------------------------------------
      // Properties
      //------------------------------------------------------------------------

      public String      Class     { get { return m_Class    ; } set { m_Class     = value; }}
      public String      Method    { get { return m_Method   ; } set { m_Method    = value; }}
      public String      File      { get { return m_File     ; } set { m_File      = value; }}
      public String      Line      { get { return m_Line     ; } set { m_Line      = value; }}
      public EErrorLevel Level     { get { return m_Level    ; } set { m_Level     = value; }}
      public long        ErrorCode { get { return m_ErrorCode; } set { m_ErrorCode = value; }}
      public String      ErrorText { get { return m_ErrorText; } set { m_ErrorText = value; }}
      public Object      Tag       { get { return m_Tag      ; } set { m_Tag       = value; }}
   }
}
