using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using log4net.Appender;
using log4net.Core;
using Npgsql;

namespace Web.Infrastructure
{
    public class PostgresAppender : AppenderSkeleton
    {
        private const string TableName = "ErrorLog";
        private const string AppName = "AppName";
        private const string Thread = "Thread";
        private const string Level = "Level";
        private const string Location = "Location";
        private const string Message = "Message";
        private const string Exception = "Exception";
        private const string LogDate = "LogDate";

        protected override void Append(LoggingEvent loggingEvent)
        {
            using (var conn = new NpgsqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["AppContext"].ConnectionString))
            {
                conn.Open();
                using (var command = new NpgsqlCommand("insert into dbo.\"" + TableName+ "\"(\"" + AppName+"\",\""+ Thread+"\",\""+ Level+"\",\""+ Location+"\",\""+ Message+"\",\""+ LogDate+"\",\""+ Exception+"\") " +
                                                       "values(:"+AppName.ToLower()+",:"+ Thread.ToLower() + ",:"+ Level.ToLower() + ",:"+ Location.ToLower() + ",:"+ Message.ToLower() + ",:"+ LogDate.ToLower() + ",:"+ Exception.ToLower() + ")", conn))
                {
                    var appName = command.CreateParameter();
                    appName.Direction = System.Data.ParameterDirection.Input;
                    appName.DbType = System.Data.DbType.String;
                    appName.ParameterName = ":"+ AppName.ToLower();
                    appName.Value = "WebApp";
                    command.Parameters.Add(appName);

                    var thread = command.CreateParameter();
                    thread.Direction = System.Data.ParameterDirection.Input;
                    thread.DbType = System.Data.DbType.String;
                    thread.ParameterName = ":"+ Thread.ToLower();
                    thread.Value = loggingEvent.ThreadName;
                    command.Parameters.Add(thread);

                    var level = command.CreateParameter();
                    level.Direction = System.Data.ParameterDirection.Input;
                    level.DbType = System.Data.DbType.String;
                    level.ParameterName = ":"+ Level.ToLower();
                    level.Value = loggingEvent.Level;
                    command.Parameters.Add(level);

                    var location = command.CreateParameter();
                    location.Direction = System.Data.ParameterDirection.Input;
                    location.DbType = System.Data.DbType.String;
                    location.ParameterName = ":"+Location.ToLower();
                    location.Value = loggingEvent.LocationInformation.FullInfo;
                    command.Parameters.Add(location);

                    var message = command.CreateParameter();
                    message.Direction = System.Data.ParameterDirection.Input;
                    message.DbType = System.Data.DbType.String;
                    message.ParameterName = ":"+Message.ToLower();
                    message.Value = loggingEvent.RenderedMessage;
                    command.Parameters.Add(message);

                    var logDate = command.CreateParameter();
                    logDate.Direction = System.Data.ParameterDirection.Input;
                    logDate.DbType = System.Data.DbType.DateTime2;
                    logDate.ParameterName = ":"+LogDate.ToLower();
                    logDate.Value = loggingEvent.TimeStamp;
                    command.Parameters.Add(logDate);

                    var exception = command.CreateParameter();
                    exception.Direction = System.Data.ParameterDirection.Input;
                    exception.DbType = System.Data.DbType.String;
                    exception.ParameterName = ":"+ Exception.ToLower();
                    exception.Value = loggingEvent.GetExceptionString();
                    command.Parameters.Add(exception);

                    command.ExecuteNonQuery();
                }
                conn.Close();
            }
        }
    }
}