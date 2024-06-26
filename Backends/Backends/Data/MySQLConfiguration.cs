namespace Backends.Data
{
    public class MySQLConfiguration
    {
        public MySQLConfiguration(string connectionString)
        {
            ConnectionString = connectionString;// ?? string.Empty;
        }

        public string ConnectionString { get; set; }

    }
}
