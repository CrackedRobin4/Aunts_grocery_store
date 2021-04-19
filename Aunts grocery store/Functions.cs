using System;
using System.Collections.ObjectModel;
using System.Data;
using Npgsql;
using Npgsql.Schema;

namespace Aunts_grocery_store
{
    public class Functions
    {
        private NpgsqlConnection cn = new NpgsqlConnection("Host=localhost;Port=1770;Username=postgres;Password=123456789;Database=aunts_grocery_store");

        public Functions()
        {
            cn.Open(); 
        }
        public bool IsWork()
        {
            return cn != null && cn.State != ConnectionState.Broken &&
                   cn.State != ConnectionState.Closed;
        }

        public void Run()
        {
            NpgsqlCommand cmd;
            string query;
            NpgsqlDataReader reader;
            ReadOnlyCollection<NpgsqlDbColumn> cl;
            while (true)
            {
                Console.WriteLine("1) Get products");
                Console.WriteLine("2) Get best selling product");
                Console.WriteLine("3) Get best selling products by order");
                Console.WriteLine("4) Best customer");
                Console.WriteLine("5) Best customers by order");
                Console.WriteLine("6) Purchase history between dates");
                Console.WriteLine("7) Purchase history between dates and amount of purchases of specific person");
                Console.WriteLine("8) Check product on expiration date");
                Console.WriteLine("0) Exit");
                Console.WriteLine("Choose one");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        query = "Select * from get_products();";
                        cmd = new NpgsqlCommand(query, cn);
                        reader = cmd.ExecuteReader();
                        cl = reader.GetColumnSchema();
                        for (int i = 0; i < cl.Count; i++)
                        {
                            Console.Write(cl[i].ColumnName + " | ");
                        }
                        Console.WriteLine();
                        while(reader.Read())
                        {
                            string s = "";
                            for (int i = 0; i < reader.FieldCount; ++i)
                            {
                                s += reader[i] + " | ";
                            }
                            Console.WriteLine(s);
                        }
                        Console.WriteLine();
                        reader.Dispose();
                        break;
                    case 2:
                        query = "Select * from best_selling_product();";
                        cmd = new NpgsqlCommand(query, cn);
                        reader = cmd.ExecuteReader();
                        cl = reader.GetColumnSchema();
                        for (int i = 0; i < cl.Count; i++)
                        {
                            Console.Write(cl[i].ColumnName + " | ");
                        }
                        Console.WriteLine();
                        while(reader.Read())
                        {
                            string s = "";
                            for (int i = 0; i < reader.FieldCount; ++i)
                            {
                                s += reader[i] + " | ";
                            }
                            Console.WriteLine(s);
                        }
                        Console.WriteLine();
                        reader.Dispose();
                        break;
                    case 3:
                        query = "Select * from top_selling_products();";
                        cmd = new NpgsqlCommand(query, cn);
                        reader = cmd.ExecuteReader();
                        cl = reader.GetColumnSchema();
                        for (int i = 0; i < cl.Count; i++)
                        {
                            Console.Write(cl[i].ColumnName + " | ");
                        }
                        Console.WriteLine();
                        while(reader.Read())
                        {
                            string s = "";
                            for (int i = 0; i < reader.FieldCount; ++i)
                            {
                                s += reader[i] + " | ";
                            }
                            Console.WriteLine(s);
                        }
                        Console.WriteLine();
                        reader.Dispose();
                        break;
                    case 4:
                        query = "Select * from best_customer();";
                        cmd = new NpgsqlCommand(query, cn);
                        reader = cmd.ExecuteReader();
                        cl = reader.GetColumnSchema();
                        for (int i = 0; i < cl.Count; i++)
                        {
                            Console.Write(cl[i].ColumnName + " | ");
                        }
                        Console.WriteLine();
                        while(reader.Read())
                        {
                            string s = "";
                            for (int i = 0; i < reader.FieldCount; ++i)
                            {
                                s += reader[i] + " | ";
                            }
                            Console.WriteLine(s);
                        }
                        Console.WriteLine();
                        reader.Dispose();
                        break;
                    case 5:
                        query = "Select * from best_customers();";
                        cmd = new NpgsqlCommand(query, cn);
                        reader = cmd.ExecuteReader();
                        cl = reader.GetColumnSchema();
                        for (int i = 0; i < cl.Count; i++)
                        {
                            Console.Write(cl[i].ColumnName + " | ");
                        }
                        Console.WriteLine();
                        while(reader.Read())
                        {
                            string s = "";
                            for (int i = 0; i < reader.FieldCount; ++i)
                            {
                                s += reader[i] + " | ";
                            }
                            Console.WriteLine(s);
                        }
                        Console.WriteLine();
                        reader.Dispose();
                        break;
                    case 6:
                        Console.WriteLine("Write two dates. Write the first one. Example: 2020-01-01 Y-m-d format");
                        var date_1 = "'" + Console.ReadLine() + "'";
                        Console.WriteLine("Write the second one. Example: 2021-12-31 Y-m-d format");
                        var date_2 = "'" + Console.ReadLine() + "'";
                        query = $"Select * from purchase_history_between_dates({date_1}, {date_2})";
                        cmd = new NpgsqlCommand(query, cn);
                        reader = cmd.ExecuteReader();
                        cl = reader.GetColumnSchema();
                        for (int i = 0; i < cl.Count; i++)
                        {
                            Console.Write(cl[i].ColumnName + " | ");
                        }
                        Console.WriteLine();
                        while(reader.Read())
                        {
                            string s = "";
                            for (int i = 0; i < reader.FieldCount; ++i)
                            {
                                s += reader[i] + " | ";
                            }
                            Console.WriteLine(s);
                        }
                        Console.WriteLine();
                        reader.Dispose();
                        break;
                    case 7:
                        Console.WriteLine("Write two dates. Write the first one. Example: 2020-01-01 Y-m-d format");
                        date_1 = "'" + Console.ReadLine() + "'";
                        Console.WriteLine("Write the second one. Example: 2021-12-31 Y-m-d format");
                        date_2 = "'" + Console.ReadLine() + "'";
                        query = $"Select * from purchase_history_numbers_between_dates({date_1}, {date_2})";
                        cmd = new NpgsqlCommand(query, cn);
                        reader = cmd.ExecuteReader();
                        cl = reader.GetColumnSchema();
                        for (int i = 0; i < cl.Count; i++)
                        {
                            Console.Write(cl[i].ColumnName + " | ");
                        }
                        Console.WriteLine();
                        while(reader.Read())
                        {
                            string s = "";
                            for (int i = 0; i < reader.FieldCount; ++i)
                            {
                                s += reader[i] + " | ";
                            }
                            Console.WriteLine(s);
                        }
                        Console.WriteLine();
                        reader.Dispose();
                        break;
                    case 8:
                        query = "Select * from check_products_for_expiration_date();";
                        cmd = new NpgsqlCommand(query, cn);
                        reader = cmd.ExecuteReader();
                        cl = reader.GetColumnSchema();
                        for (int i = 0; i < cl.Count; i++)
                        {
                            Console.Write(cl[i].ColumnName + " | ");
                        }
                        Console.WriteLine();
                        while(reader.Read())
                        {
                            string s = "";
                            for (int i = 0; i < reader.FieldCount; ++i)
                            {
                                s += reader[i] + " | ";
                            }
                            Console.WriteLine(s);
                        }
                        Console.WriteLine();
                        reader.Dispose();
                        break;
                    case 0:
                        return;
                }
            }
        }
    }
}