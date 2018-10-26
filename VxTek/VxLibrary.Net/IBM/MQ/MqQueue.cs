using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IBM.WMQ;

namespace VxLibrary.Net.IBM.MQ
{
   public class MqQueue
   {
      MQQueueManager      m_QueueManager          ;
      MQQueue             m_Queue                 ;
      MQMessage           m_QueueMessage          ;
      MQPutMessageOptions m_QueuePutMessageOptions;
      MQGetMessageOptions m_QueueGetMessageOptions;

      //------------------------------------------------------------------------

      static string       m_QueueName       ;
      static string       m_QueueManagerName;
      static string       m_ChannelInfo     ;
      string              m_ChannelName     ;
      string              m_TransportType   ;
      string              m_ConnectionName  ;
      string              m_Message         ;

      //------------------------------------------------------------------------

      public MqQueue ()
      {
         //Initialisation

         m_QueueManagerName = "QM_dev_cob_v4_0020";
         m_QueueName        = "SimulatorFix2Trs_Hvb";
         m_ChannelInfo      = "SYSTEM.DEF.SVRCONN/TCP/dev-cob-vm-0032(2004)";
      }

      public string ConnectMQ ( string StrQueueManagerName, string StrQueueName, string StrChannelInfo )
      {
         m_QueueManagerName = StrQueueManagerName;
         m_QueueName        = StrQueueName       ;
         m_ChannelInfo      = StrChannelInfo     ;

         char  [] separator = {'/'};
         string[] ChannelParams    ;

         ChannelParams = m_ChannelInfo.Split ( separator );

         m_ChannelName    = ChannelParams[0];
         m_TransportType  = ChannelParams[1];
         m_ConnectionName = ChannelParams[2];

         String StrReturn = "";

         try
         {
            m_QueueManager = new MQQueueManager ( m_QueueManagerName, m_ChannelName, m_ConnectionName );

            StrReturn = "Connected Successfully";
         }
         catch ( MQException Exp )
         {
            StrReturn = "Exception: " + Exp.Message ;
         }

         return StrReturn;
      }

       public string WriteMsg ( string strInputMsg )
       {
         string StrReturn = "";

         try
         {
            //MQOO_INPUT_AS_Q_DEF | MQOO_FAIL_IF_QUIESCING
            m_Queue = m_QueueManager.AccessQueue ( m_QueueName, MQC.MQOO_OUTPUT + MQC.MQOO_FAIL_IF_QUIESCING );

            m_Message = strInputMsg;

            m_QueueMessage = new MQMessage ();

            m_QueueMessage.WriteString ( m_Message );

            m_QueueMessage.Format = MQC.MQFMT_STRING;

            m_QueuePutMessageOptions = new MQPutMessageOptions ();

            m_Queue.Put ( m_QueueMessage, m_QueuePutMessageOptions );

            StrReturn = "Message sent to the queue successfully";
         }
         catch ( MQException MQexp )
         {
            StrReturn = "Exception: " + MQexp.Message ;
         }
         catch ( Exception Exp )
         {
            StrReturn = "Exception: " + Exp.Message ;
         }

         return StrReturn;
      }

      public string ReadMsg ()
      {
         String StrReturn = "";

         try
         {
            m_Queue = m_QueueManager.AccessQueue ( m_QueueName, MQC.MQOO_INPUT_AS_Q_DEF + MQC.MQOO_FAIL_IF_QUIESCING );

            m_QueueMessage = new MQMessage ();

            m_QueueMessage.Format = MQC.MQFMT_STRING;

            m_QueueGetMessageOptions = new MQGetMessageOptions ();

            m_Queue.Get ( m_QueueMessage, m_QueueGetMessageOptions );

            StrReturn = m_QueueMessage.ReadString ( m_QueueMessage.MessageLength );
         }
         catch ( MQException MQexp )
         {
            StrReturn = "Exception : " + MQexp.Message ;
         }
         catch ( Exception Exp )
         {
            StrReturn = "Exception: " + Exp.Message ;
         }

         return StrReturn;
      }
   }
}
