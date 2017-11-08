using System;
using System.Diagnostics;

using log4net;

namespace Cricker.Helper
{
    public static class Logger
    {
        public static void Fatal(string message)
        {
            var log = LogManager.GetLogger(new StackTrace().GetFrame(1).GetMethod().DeclaringType.FullName);
            if (log.IsErrorEnabled) log.Fatal(message);
        }

        public static void Fatal(string message, params object[] args)
        {
            Fatal(string.Format(message, args));
        }

        public static void Fatal(string message, Exception ex)
        {
            var log = LogManager.GetLogger(new StackTrace().GetFrame(1).GetMethod().DeclaringType.FullName);
            if (log.IsErrorEnabled) log.Fatal(message, ex);
        }

        public static void Error(string message)
        {
            var log = LogManager.GetLogger(new StackTrace().GetFrame(1).GetMethod().DeclaringType.FullName);
            if (log.IsErrorEnabled) log.Error(message);
        }

        public static void Error(string message, params object[] args)
        {
            Error(string.Format(message, args));
        }

        public static void Error(string message, Exception ex)
        {
            var log = LogManager.GetLogger(new StackTrace().GetFrame(1).GetMethod().DeclaringType.FullName);
            if (log.IsErrorEnabled) log.Error(message, ex);
        }

        public static void Warning(string message)
        {
            var log = LogManager.GetLogger(new StackTrace().GetFrame(1).GetMethod().DeclaringType.FullName);
            if (log.IsErrorEnabled) log.Warn(message);
        }

        public static void Warning(string message, params object[] args)
        {
            Warning(string.Format(message, args));
        }

        public static void Warning(string message, Exception ex)
        {
            var log = LogManager.GetLogger(new StackTrace().GetFrame(1).GetMethod().DeclaringType.FullName);
            if (log.IsErrorEnabled) log.Warn(message, ex);
        }

        public static void Info(string message)
        {
            //var log = LogManager.GetLogger(new StackTrace().GetFrame(1).GetMethod().DeclaringType.FullName);
            //if (log.IsErrorEnabled) log.Info(message);
        }

        public static void Info(string message, params object[] args)
        {
            Info(string.Format(message, args));
        }

        public static void Info(string message, Exception ex)
        {
            //var log = LogManager.GetLogger(new StackTrace().GetFrame(1).GetMethod().DeclaringType.FullName);
            //if (log.IsErrorEnabled) log.Info(message, ex);
        }

        public static void Debug(string message)
        {
            var log = LogManager.GetLogger(new StackTrace().GetFrame(1).GetMethod().DeclaringType.FullName);
            if (log.IsErrorEnabled) log.Debug(message);
        }

        public static void Debug(string message, params object[] args)
        {
            Debug(string.Format(message, args));
        }

        public static void Debug(string message, Exception ex)
        {
            var log = LogManager.GetLogger(new StackTrace().GetFrame(1).GetMethod().DeclaringType.FullName);
            if (log.IsErrorEnabled) log.Debug(message, ex);
        }
    }
}