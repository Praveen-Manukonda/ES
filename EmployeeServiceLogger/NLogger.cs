using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeServiceLogger
{
    public static class NLogger
    {
        private readonly static Logger logger = LogManager.GetCurrentClassLogger();
        public static void Error(Exception exception, string message)
        {
            logger.Error(exception, message);
        }
    }
}
