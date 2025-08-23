using Microsoft.Data.SqlClient;
using System.Data;

string connectionString = @"Data Source=HP\SQLEXPRESS;Initial Catalog=AuthDB;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False";

using (SqlConnection conn = new SqlConnection(connectionString))
{
    conn.Open();
    Console.WriteLine("Connection Opened Successfully");

    // Insert
    string insertQuery = "INSERT INTO Products (Name, Price) VALUES (@name, @price)";
    using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
    {
        cmd.Parameters.AddWithValue("@name", "Sample Product");
        cmd.Parameters.AddWithValue("@price", 19.99);
        int rowsAffected = cmd.ExecuteNonQuery();
        Console.WriteLine($"{rowsAffected} row(s) inserted.");
    }

    // Select
    string selectQuery = "SELECT * FROM Products";
    // Here we are selecting all products and displaying their details
    using (SqlCommand cmd = new SqlCommand(selectQuery, conn)) // here this command object is used to execute the query
    {
        SqlDataAdapter adapter = new SqlDataAdapter(cmd); // here this adapter is used to fill the dataset, adapter is a bridge between the DataSet and the database used to retrieve data
        DataSet dataSet = new DataSet(); // Here we are creating a new DataSet to hold the retrieved data, because a DataSet can contain multiple DataTables, and we want to keep our data organized
        adapter.Fill(dataSet); // here the adapter fills the DataSet with the results of the query

        foreach (DataRow row in dataSet.Tables[0].Rows) // here we are iterating through the rows of the first table in the DataSet
        {
            Console.WriteLine($"ID: {row["Id"]}, Name: {row["Name"]}, Price: {row["Price"]}");
        }
    }

    conn.Close();
    Console.WriteLine("Connection Closed Successfully");
}
