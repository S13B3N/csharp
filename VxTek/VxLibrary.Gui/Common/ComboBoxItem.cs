using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VxLibraryData.Gui.Common
{
   [Serializable()]
   public class ComboBoxItem<T>
   {
      protected T      m_Value;
      protected String m_Label;

      //------------------------------------------------------------------------

      public ComboBoxItem ()
      {
      }

      public ComboBoxItem ( T Value, String Label )
      {
         m_Value = Value;
         m_Label = Label;
      }

      //------------------------------------------------------------------------
      // Properties
      //------------------------------------------------------------------------

      public T      Value { get { return m_Value; } set { m_Value = value; }}
      public String Label { get { return m_Label; } set { m_Label = value; }}
   }
}
