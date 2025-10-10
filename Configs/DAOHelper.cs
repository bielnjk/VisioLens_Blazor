using MySql.Data.MySqlClient;

namespace VisioLens_Blazor.Configs
{
    public class DAOHelper
    {
        public static string GetString(MySqlDataReader reader, string collumn_name)
        {
            string text = string.Empty;

            if(!reader.IsDBNull(reader.GetOrdinal(collumn_name)))
                text = reader.GetString(collumn_name);

            return text;
        }

        public static double GetDouble(MySqlDataReader reader, string collumn_name)
        {
            double value = 0.0;

            if(!reader.IsDBNull(reader.GetOrdinal(collumn_name))) 
                value = reader.GetDouble(collumn_name);

            return value;
        }

        public static DateTime? GetDateTime(MySqlDataReader reader, string collumn_name)
        {
            DateTime? value = null;

            if(!reader.IsDBNull(reader.GetOrdinal(collumn_name)))
                value = reader.GetDateTime(collumn_name);

            return value;
        }

        public static bool IsNull(MySqlDataReader reader, string collumn_name)
        {
            return reader.IsDBNull(reader.GetOrdinal(collumn_name));
        }
    }
}
