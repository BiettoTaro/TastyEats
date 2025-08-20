using System;
using System.Collections.Generic;
using System.Data;

namespace TastyEats.Tests.UnitTests
{
    public static partial class DatabaseHandler
    {
        public static Func<string, Dictionary<string, object>, DataTable>? ExecuteQueryWithParamsStub;
        public static Func<string, DataTable>? ExecuteQueryStub;
        public static Func<string, Dictionary<string, object>, int>? ExecuteNonQueryWithParamsStub;

        public static DataTable ExecuteQuery(string sql, Dictionary<string, object> parameters)
        {
            if (ExecuteQueryWithParamsStub != null)
                return ExecuteQueryWithParamsStub(sql, parameters);
            throw new NotImplementedException("ExecuteQuery stub not set for unit test.");
        }

        public static int ExecuteNonQuery(string sql, Dictionary<string, object> parameters)
        {
            if (ExecuteNonQueryWithParamsStub != null)
                return ExecuteNonQueryWithParamsStub(sql, parameters);
            throw new NotImplementedException("ExecuteNonQuery stub not set for unit test.");
        }
    }
}
