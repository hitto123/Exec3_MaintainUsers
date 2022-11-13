using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISpan.Utility;

namespace Exec3_MaintainUsers
{
	internal class Program
	{
		static void Main(string[] args)
		{
			using Ispan.Utility;
			using System;
			using System.Collections.Generic;
			using System.Data;
			using System.Data.SqlClient;
			using System.Linq;
			using System.Text;
			using System.Threading.Tasks;
			using System.Xml.Linq;

namespace Exec3_MaintainUsers
	{
		internal class Program
		{
			static void Main(string[] args)
			{
				
			}

			static void Insert(string name, string account, string password, DateTime dateTime, int height)
			{
				string sql = "INSERT INTO Users(Name, Account, Password, DateOfBirthd, Height) " +
					"VALUES(@Name, @Account, @Password, @DateOfBirthd, @Height)";

				SqlDbHelper dbHelper = new SqlDbHelper("default");
				SqlParameter[] parameters = new SqlParameterBuilder()
											.AddNVarchar("@Name", 50, name)
											.AddNVarchar("@Account", 50, account)
											.AddNVarchar("@Password", 50, password)
											.AddNDateTime("@DateOfBirthd", dateTime)
											.AddInt("@Height", height)
											.Builder();

				dbHelper.ExecuteNonQuery(sql, parameters);
				Console.WriteLine("Inserted!!");
			}

			static void Update(int Id, string name, int height)
			{
				string sql = "UPDATE Users SET Name = @Name, Height = @Height WHERE Id = @Id";

				SqlDbHelper dbHelper = new SqlDbHelper("default");
				SqlParameter[] parameters = new SqlParameterBuilder()
											.AddNInt("@Id", Id)
											.AddNVarchar("@Name", 50, name)
											.AddInt("@Height", height)
											.Builder();

				dbHelper.ExecuteNonQuery(sql, parameters);
				Console.WriteLine("Updated");

			}

			static void Delete(int Id)
			{
				
					string sql = "DELETE FROM Users WHERE Id = @Id";

					SqlDbHelper dbHelper = new SqlDbHelper("default");
					SqlParameter[] parameters = new SqlParameterBuilder()
												.AddInt("@Id", Id)
												.Builder();

					dbHelper.ExecuteNonQuery(sql, parameters);
					Console.WriteLine("Deleted");
				
			
			}

			static void Select(int Id)
			{
				string sql = "SELECT Name, Account, Password, DateOfBirthd, Height FROM Users WHERE Id > @Id";

				SqlDbHelper dbHelper = new SqlDbHelper("default");
				SqlParameter[] parameters = new SqlParameterBuilder()
											.AddInt("@Id", Id)
											.Builder();

				DataTable table = dbHelper.Select(sql, parameters);
				foreach (DataRow row in table.Rows)
				{
					string name = row.Field<string>("Name");
					string account = row.Field<string>("Account");
					string password = row.Field<string>("Password");
					DateTime dateOfBirthd = row.Field<DateTime>("DateOfBirthd");
					int height = row.Field<int>("Height");

					Console.WriteLine($"Name = {name}   Account = {account}   Password = {password}   DateOfBirthd = {dateOfBirthd}   Height = {height}");
				}
			}
		}
	}

}
	

