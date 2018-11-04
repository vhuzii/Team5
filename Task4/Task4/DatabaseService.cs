namespace Task4
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Service to work with database.
    /// </summary>
    public class DatabaseService
    {
        private SqlConnection connection;

        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseService"/> class.
        /// </summary>
        /// <param name="connectionString">Connection string.</param>
        public DatabaseService(string connectionString)
        {
            this.connection = new SqlConnection(connectionString);
        }

        /// <summary>
        /// Show data by sql command.
        /// </summary>
        /// <param name="command">sql command.</param>
        public void ShowData(string command)
        {
            using (this.connection)
            {
                SqlCommand sqlCommand = new SqlCommand(command, this.connection);
                this.connection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine("{0}", reader.GetString(0));
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }

                reader.Close();
            }
        }
    }
}
