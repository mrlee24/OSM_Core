using System;
using System.Collections.Generic;
using System.Text;

namespace OSM.Common
{
    public static class LoggingHelper
    {
        public static string GetExceptionalDetails(Exception ex)
        {
            StringBuilder errorString = new StringBuilder();
            errorString.AppendLine("An error occured. ");
            Exception inner = ex;
            while (inner != null)
            {
                errorString.Append("Error Message");
                errorString.AppendLine(ex.Message);
                errorString.Append("Stack trace");
                errorString.AppendLine(ex.StackTrace);
                inner = inner.InnerException;
            }
            return errorString.ToString();
        }
    }
}
