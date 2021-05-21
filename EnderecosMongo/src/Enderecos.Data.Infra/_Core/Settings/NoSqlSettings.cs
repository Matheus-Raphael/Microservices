namespace Enderecos.Data.Infra._Core.Settings {
    public class NoSqlSettings {
        public string connection { get; set; }
        public string database { get; set; }
        public bool flagAllowInsecureTls { get; set; }
        public bool flagTls { get; set; }

        public NoSqlSettings(string _connection, string _database) {
            connection = _connection;
            database = _database;
        }
    }
}