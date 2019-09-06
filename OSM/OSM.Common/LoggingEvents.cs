using System;

namespace OSM.Common
{
    public static class LoggingEvents
    {
        public const int GENERATE_ITEMS = 1000;

        public const int GET_ITEM = 1001;
        public const int GET_ITEMS = 1002;

        public const int INSERT_ITEM = 1003;
        public const int UPDATE_ITEM = 1004;
        public const int DELETE_ITEM = 1005;

        public const int DATABASE_ERROR = 2000;
        public const int SERVICE_ERROR = 2001;
        public const int ERROR = 2002;
        public const int ACCESS_METHOD = 3000;

        public const int GET_ITEM_NOTFOUND = 4000;
        public const int UPDATE_ITEM_NOTFOUND = 4001;
    }
}
