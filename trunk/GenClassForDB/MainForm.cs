using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace GenClassForDB
{
	public partial class MainForm : Form
	{
		#region Variables

		const string CONNECTION_STRING = "Server={0};Database={1};User Id={2};Password={3};";
		private SqlConnection _SqlConnection;
		private string _CurentDB = "master";

		private DataTable _dtbTableList, _dtbColumnList;

		private Dictionary<string, string> DataTypeMaping = new Dictionary<string, string>() { 
			{"UNIQUEIDENTIFIER", "System.Guid"},
			{"BIGINT", "System.Int64"},
			{"INT", "System.Int32"},
			{"SMALLINT", "System.Int16"},
			{"TINYINT", "System.Byte"}, 
			{"DATE", "System.DateTime"},
			{"DATETIME", "System.DateTime"}, 
			{"DATETIME2", "System.DateTime"},            
			{"BIT", "System.Boolean"},
			{"REAL", "System.Single"},
			{"DECIMAL", "System.Decimal"},
			{"NUMERIC", "System.Decimal"},
			{"MONEY", "System.Decimal"},
			{"VARCHAR", "System.String"},
			{"CHAR", "System.String"},
			{"NCHAR", "System.String"},
			{"NVARCHAR", "System.String"},
			{"TEXT", "System.String"},
			{"NTEXT", "System.String"}
		};

		private Dictionary<string, string> DataTypeConvertMaping = new Dictionary<string, string>() { 
			{"UNIQUEIDENTIFIER", "Guid.Parse"},
			{"BIGINT", "System.Convert.ToInt64"},
			{"INT", "System.Convert.ToInt32"},
			{"SMALLINT", "System.Convert.ToInt16"},
			{"TINYINT", "System.Convert.ToByte"},
			{"DATE", "System.Convert.ToDateTime"}, 
			{"DATETIME", "System.Convert.ToDateTime"},  
			{"DATETIME2", "System.Convert.ToDateTime"},            
			{"BIT", "System.Convert.ToBoolean"},
			{"REAL", "System.Convert.ToSingle"},
			{"DECIMAL", "System.Convert.ToDecimal"},
			{"NUMERIC", "System.Convert.ToDecimal"},
			{"MONEY", "System.Convert.ToDecimal"},
			{"VARCHAR", "System.Convert.ToString"},
			{"CHAR", "System.Convert.ToString"},
			{"NCHAR", "System.Convert.ToString"},
			{"NVARCHAR", "System.Convert.ToString"},
			{"TEXT", "System.Convert.ToString"},
			{"NTEXT", "System.Convert.ToString"}
		};

		private string shortTableName = "";

		#endregion

		#region Initial

		public MainForm()
		{
			InitializeComponent();
			//InitialConnection();

			txtCode_usp_Delete.ConfigurationManager.Language =
			txtCode_usp_Insert.ConfigurationManager.Language =
			txtCode_usp_Select_All.ConfigurationManager.Language =
			txtCode_usp_Select_ByID.ConfigurationManager.Language =
			txtCode_usp_Select_Count.ConfigurationManager.Language =
			txtCode_usp_Select_Dynamic.ConfigurationManager.Language =
			txtCode_usp_Select_Top_Dynamic.ConfigurationManager.Language =
			txtCode_usp_Select_Paging.ConfigurationManager.Language =
			txtCode_usp_Update.ConfigurationManager.Language = "mssql";

			txtCodeData.ConfigurationManager.Language =
			txtCodeDomainObject.ConfigurationManager.Language =
			txtCodeService.ConfigurationManager.Language =
			txtCodeIService.ConfigurationManager.Language =
			txtCodeClientService.ConfigurationManager.Language = "cs";
		}

		private void InitialConnection()
		{

			try
			{
				if (txtServer.Text.Trim() != "" && txtUsername.Text.Trim() != "" && txtPassword.Text != "")
				{
					_SqlConnection = new SqlConnection(string.Format(CONNECTION_STRING, txtServer.Text.Trim(), _CurentDB, txtUsername.Text.Trim(), txtPassword.Text));
				}

				_SqlConnection.Open();
				_SqlConnection.Close();
			}
			catch (SqlException ex)
			{
				MessageBox.Show("Không kết nối tới Server. Kiểm tra lại tham số");
			}

			// select all database in server
			DataTable dtbDatabase = SelectDB("SELECT NAME FROM SYS.DATABASES ORDER BY NAME");

			cboDatabase.SelectedIndexChanged -= cboDatabase_SelectedIndexChanged;

			cboDatabase.Items.Clear();

			foreach (DataRow r in dtbDatabase.Rows)
			{
				cboDatabase.Items.Add(r[0]);
			}

			if (cboDatabase.Items.Count > 0)
				cboDatabase.SelectedIndex = 0;

			cboDatabase.SelectedIndexChanged += cboDatabase_SelectedIndexChanged;

			InitialComboDatabase();
		}

		private void InitialComboDatabase()
		{
			btnConnect.Text = "Disconnect";

			try
			{
				_SqlConnection = new SqlConnection(string.Format(CONNECTION_STRING, txtServer.Text.Trim(), _CurentDB, txtUsername.Text.Trim(), txtPassword.Text));
				_SqlConnection.Open();
				_SqlConnection.Close();
			}
			catch (SqlException ex)
			{
				MessageBox.Show("#InitialComboDatabase: Bạn không có quyền truy cập Database này.");
				return;
			}

			InitialListTable();
		}

		private void InitialListTable()
		{
			DataTable dtbTables = SelectDB("SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE' ORDER BY TABLE_NAME");
			lstTable.SelectedIndexChanged -= lstTable_SelectedIndexChanged;

			//lstTable.Items.Clear();

			_dtbTableList = dtbTables;

			sourceTableList.DataSource = _dtbTableList;

			//foreach (DataRow r in dtbTables.Rows)
			//{
			//    lstTable.Items.Add(r[0]);
			//}

			lstTable.SelectedIndexChanged += lstTable_SelectedIndexChanged;

			if (lstTable.Items.Count > 0)
				lstTable.SelectedIndex = 0;

			GengerateCodeForCurrentTable();
		}

		private void GengerateCodeForCurrentTable()
		{
			if (lstTable.Items.Count == 0)
			{
				return;
			}

			if (lstTable.SelectedItem == null)
			{
				return;
			}

			lstTable.Enabled = false;


			string tableName = ((DataRowView)lstTable.SelectedItem).Row["TABLE_NAME"].ToString();

			FormatTabName(tableName);
			shortTableName = RegenerateShortTableNameForStore(tableName);

			// get column in table

			_dtbColumnList = SelectDB(string.Format("SELECT TABLE_NAME, COLUMN_NAME, IS_NULLABLE, DATA_TYPE, CHARACTER_MAXIMUM_LENGTH FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{0}'", tableName));

			FormatTextBoxState(false);

			Gen_usp_Insert(tableName);
			Gen_usp_Update(tableName);
			Gen_usp_Delete(tableName);
			Gen_usp_Select_All(tableName);
			Gen_usp_Select_ByID(tableName);
			Gen_usp_Select_Top_Dynamic(tableName);
			Gen_usp_Select_Dynamic(tableName);
			Gen_usp_Select_Paging(tableName);
			Gen_usp_Select_Count(tableName);

			Gen_TableData(tableName);
			Gen_DomainObject(tableName);
			Gen_IData(tableName);
			Gen_IService(tableName);
			Gen_Service(tableName);
			Gen_ClientWraper(tableName);
			Gen_FillProperties(tableName);

			FormatTextBoxState(true);

			lstTable.Enabled = true;
		}

		#endregion

		#region Gen code

		private void Gen_usp_Insert(string tableName)
		{
			// tab usp_Insert
			StringBuilder textStoreInsert = new StringBuilder();

			textStoreInsert.Append(string.Format(
@"GO
/****** Object:  StoredProcedure [dbo].[{0}_Insert]    Script Date: {1} ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- This stored procedure was created 
-- on {1} .
-- Template: Insert Row
-- Purpose: Insert one row in table {2}.

",
									   RegenerateTableNameForStore(tableName),
										DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"),
										tableName));


			textStoreInsert.AppendLine(string.Format("     ALTER PROCEDURE [dbo].[{0}_Insert]", RegenerateTableNameForStore(tableName)));

			string columnDetailInsert = "";
			for (int i = 0; i < _dtbColumnList.Rows.Count; i++)
			{
				DataRow row = _dtbColumnList.Rows[i];

                //if (row["COLUMN_NAME"] + "" == "ID")
                //    continue;

				textStoreInsert.AppendLine(string.Format("       @{0}  {1}{2}{3}", row["COLUMN_NAME"], row["DATA_TYPE"], row["CHARACTER_MAXIMUM_LENGTH"] != DBNull.Value ? string.Format("({0})", (row["CHARACTER_MAXIMUM_LENGTH"] + "" != "-1" ? row["CHARACTER_MAXIMUM_LENGTH"] : "MAX")) : "", i < _dtbColumnList.Rows.Count - 1 ? "," : ""));
				columnDetailInsert += string.Format("      @[{0}].[{1}]{2}\n", row["TABLE_NAME"], row["COLUMN_NAME"], i < _dtbColumnList.Rows.Count - 1 ? "," : "");
			}

			textStoreInsert.AppendLine("AS");

			textStoreInsert.AppendLine(string.Format("INSERT INTO [{0}]", tableName));

			textStoreInsert.AppendLine("     (");

			textStoreInsert.Append(columnDetailInsert.Replace("@", ""));

			textStoreInsert.AppendLine(
@"      ) 
		VALUES 
		(");

			textStoreInsert.Append(columnDetailInsert.Replace("[" + tableName + "].", "").Replace("[", "").Replace("]", ""));

			textStoreInsert.AppendLine(")");

			txtCode_usp_Insert.Text = textStoreInsert.ToString();
		}

		private void Gen_usp_Update(string tableName)
		{
			// tab usp_Insert
			StringBuilder textStoreInsert = new StringBuilder();

			textStoreInsert.Append(string.Format(
@"GO
/****** Object:  StoredProcedure [dbo].[{0}_Update]    Script Date: {1} ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- This stored procedure was created 
-- on {1} .
-- Template: Update Row
-- Purpose: Update an existing row in table {2}.

",
										RegenerateTableNameForStore(tableName),
										DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"),
										tableName));


			textStoreInsert.AppendLine(string.Format("     ALTER PROCEDURE [dbo].[{0}_Update]", RegenerateTableNameForStore(tableName)));

			string columnDetailInsert = "";
			for (int i = 0; i < _dtbColumnList.Rows.Count; i++)
			{
				DataRow row = _dtbColumnList.Rows[i];

				textStoreInsert.AppendLine(string.Format("       @{0}  {1}{2}{3}", row["COLUMN_NAME"], row["DATA_TYPE"], row["CHARACTER_MAXIMUM_LENGTH"] != DBNull.Value ? string.Format("({0})", (row["CHARACTER_MAXIMUM_LENGTH"] + "" != "-1" ? row["CHARACTER_MAXIMUM_LENGTH"] : "MAX")) : "", i < _dtbColumnList.Rows.Count - 1 ? "," : ""));
				columnDetailInsert += string.Format("      [{1}] = @{1}{2}\n", row["TABLE_NAME"], row["COLUMN_NAME"], i < _dtbColumnList.Rows.Count - 1 ? "," : "");
			}

			textStoreInsert.AppendLine("AS");

			textStoreInsert.AppendLine(string.Format("UPDATE [{0}] SET", tableName));

			textStoreInsert.Append(columnDetailInsert);

			textStoreInsert.AppendLine(string.Format("WHERE [ID] = @ID"));

			txtCode_usp_Update.Text = textStoreInsert.ToString();
		}

		private void Gen_usp_Delete(string tableName)
		{
			// tab usp_Insert
			StringBuilder textStoreInsert = new StringBuilder();

			textStoreInsert.Append(string.Format(
@"GO
/****** Object:  StoredProcedure [dbo].[{0}_Delete]    Script Date: {1} ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- This stored procedure was created 
-- on {1} .
-- Template: Delete Rows
-- Purpose: Generates a stored procedure to delete a data row.

",
										RegenerateTableNameForStore(tableName),
										DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"),
										tableName));


			textStoreInsert.AppendLine(string.Format("     ALTER PROCEDURE [dbo].[{0}_Delete]", RegenerateTableNameForStore(tableName)));

			for (int i = 0; i < _dtbColumnList.Rows.Count; i++)
			{
				DataRow row = _dtbColumnList.Rows[i];

				textStoreInsert.AppendLine(string.Format("       @{0}  {1}{2}{3}", row["COLUMN_NAME"], row["DATA_TYPE"], row["CHARACTER_MAXIMUM_LENGTH"] != DBNull.Value ? string.Format("({0})", (row["CHARACTER_MAXIMUM_LENGTH"] + "" != "-1" ? row["CHARACTER_MAXIMUM_LENGTH"] : "MAX")) : "", i < _dtbColumnList.Rows.Count - 1 ? "," : ""));
			}

			textStoreInsert.AppendLine("AS");

			textStoreInsert.AppendLine(string.Format("DELETE FROM [{0}] ", tableName));

			textStoreInsert.AppendLine(string.Format("WHERE [ID] = @ID"));

			txtCode_usp_Delete.Text = textStoreInsert.ToString();
		}

		private void Gen_usp_Select_All(string tableName)
		{
			// tab usp_Insert
			StringBuilder textStoreInsert = new StringBuilder();

			textStoreInsert.Append(string.Format(
@"GO
/****** Object:  StoredProcedure [dbo].[{0}_Select_All]    Script Date: {1} ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- This stored procedure was created 
-- on {1} .
-- Template: Retrieve All Rows
-- Purpose: Get rows from the table  {2}.

",
										RegenerateTableNameForStore(tableName),
										DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"),
										tableName));


			textStoreInsert.AppendLine(string.Format("     ALTER PROCEDURE [dbo].[{0}_Select_All]", RegenerateTableNameForStore(tableName)));

			string columnDetailInsert = "";
			for (int i = 0; i < _dtbColumnList.Rows.Count; i++)
			{
				DataRow row = _dtbColumnList.Rows[i];

				columnDetailInsert += string.Format("      {0}.[{1}]{2}\n", shortTableName, row["COLUMN_NAME"], i < _dtbColumnList.Rows.Count - 1 ? "," : "");
			}

			textStoreInsert.AppendLine("AS");

			textStoreInsert.AppendLine(string.Format("SELECT {0} FROM [{1}] {2}", columnDetailInsert, tableName, shortTableName));

			txtCode_usp_Select_All.Text = textStoreInsert.ToString();
		}

		private void Gen_usp_Select_ByID(string tableName)
		{
			// tab usp_Insert
			StringBuilder textStoreInsert = new StringBuilder();

			textStoreInsert.Append(string.Format(
@"GO
/****** Object:  StoredProcedure [dbo].[{0}_Select_ByID]    Script Date: {1} ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- This stored procedure was created 
-- on {1} .
-- Template: Retrieve Row by Primary Key
-- Purpose: Get an existing row in table {2}.

",
										RegenerateTableNameForStore(tableName),
										DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"),
										tableName));


			textStoreInsert.AppendLine(string.Format(
@"     ALTER PROCEDURE [dbo].[{0}_Select_ByID]
	@ID BIGINT
", RegenerateTableNameForStore(tableName)));

			string columnDetailInsert = "";
			for (int i = 0; i < _dtbColumnList.Rows.Count; i++)
			{
				DataRow row = _dtbColumnList.Rows[i];

				columnDetailInsert += string.Format("      {0}.[{1}]{2}\n", shortTableName, row["COLUMN_NAME"], i < _dtbColumnList.Rows.Count - 1 ? "," : "");
			}

			textStoreInsert.AppendLine(
@"  AS
");

			textStoreInsert.Append(string.Format("SELECT {0} FROM [{1}] {2}  WHERE [ID] = @ID ", columnDetailInsert, tableName, shortTableName));

			txtCode_usp_Select_ByID.Text = textStoreInsert.ToString();
		}

		private void Gen_usp_Select_Dynamic(string tableName)
		{
			// tab usp_Insert
			StringBuilder textStoreInsert = new StringBuilder();

			textStoreInsert.Append(string.Format(
@"GO
/****** Object:  StoredProcedure [dbo].[{0}_Select_Dynamic]    Script Date: {1} ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- This stored procedure was created 
-- on {1} .
-- Template: Retrieve Rows
-- Purpose: Get rows from the table  {2}.

",
										RegenerateTableNameForStore(tableName),
										DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"),
										tableName));


			textStoreInsert.AppendLine(string.Format(
@"     ALTER PROCEDURE [dbo].[{0}_Select_Dynamic]
	@WhereCondition nvarchar(500) = ''
", RegenerateTableNameForStore(tableName)));

			string columnDetailInsert = "";
			for (int i = 0; i < _dtbColumnList.Rows.Count; i++)
			{
				DataRow row = _dtbColumnList.Rows[i];

				columnDetailInsert += string.Format("      {0}.[{1}]{2}\n", shortTableName, row["COLUMN_NAME"], i < _dtbColumnList.Rows.Count - 1 ? "," : "");
			}

			textStoreInsert.AppendLine(
@"  AS
	EXEC('");

			textStoreInsert.Append(string.Format("SELECT {0} FROM [{1}] {2}  WHERE (1 = 1) ' + @WhereCondition )", columnDetailInsert, tableName, shortTableName));

			txtCode_usp_Select_Dynamic.Text = textStoreInsert.ToString();
		}

		private void Gen_usp_Select_Top_Dynamic(string tableName)
		{
			// tab usp_Insert
			StringBuilder textStoreInsert = new StringBuilder();

			textStoreInsert.Append(string.Format(
@"GO
/****** Object:  StoredProcedure [dbo].[{0}_Select_Top_Dynamic]    Script Date: {1} ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- This stored procedure was created 
-- on {1} .
-- Template: Retrieve top Rows
-- Purpose: Get top rows from the table {2}.

",
										RegenerateTableNameForStore(tableName),
										DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"),
										tableName));


			textStoreInsert.AppendLine(string.Format(
@"     ALTER PROCEDURE [dbo].[{0}_Select_Top_Dynamic]
	@Size int,
	@WhereCondition nvarchar(500) = ''
", RegenerateTableNameForStore(tableName)));

			string columnDetailInsert = "";
			for (int i = 0; i < _dtbColumnList.Rows.Count; i++)
			{
				DataRow row = _dtbColumnList.Rows[i];

				columnDetailInsert += string.Format("      {0}.[{1}]{2}\n", shortTableName, row["COLUMN_NAME"], i < _dtbColumnList.Rows.Count - 1 ? "," : "");
			}

			textStoreInsert.AppendLine(
@"  AS
	EXEC('  ");

			textStoreInsert.Append(string.Format("SELECT TOP ' + @Size + '\n {0} FROM [{1}] {2}  WHERE (1 = 1) ' + @WhereCondition )", columnDetailInsert, tableName, shortTableName));

			txtCode_usp_Select_Top_Dynamic.Text = textStoreInsert.ToString();
		}

		private void Gen_usp_Select_Paging(string tableName)
		{
			// tab usp_Insert
			StringBuilder textStoreInsert = new StringBuilder();

			textStoreInsert.Append(string.Format(
@"GO
/****** Object:  StoredProcedure [dbo].[{0}_Select_Paging]    Script Date: {1} ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- This stored procedure was created 
-- on {1} .
-- Template: Retrieve paging rows
-- Purpose: Get rows from the table {2}.

",
										RegenerateTableNameForStore(tableName),
										DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"),
										tableName));


			textStoreInsert.AppendLine(string.Format(
@"     ALTER PROCEDURE [dbo].[{0}_Select_Paging]
	@WhereCondition nvarchar(500),
	@PageSize int,
	@CurrentPage int,
	@SortByColumns varchar(255)
", RegenerateTableNameForStore(tableName)));

			string columnDetailInsert = "";
			for (int i = 0; i < _dtbColumnList.Rows.Count; i++)
			{
				DataRow row = _dtbColumnList.Rows[i];

				columnDetailInsert += string.Format("      {0}.[{1}]{2}\n", shortTableName, row["COLUMN_NAME"], i < _dtbColumnList.Rows.Count - 1 ? "," : "");
			}

			textStoreInsert.AppendLine(
@"  AS
	EXEC('");

			textStoreInsert.Append(string.Format(
@"WITH PAGING AS 
	(
		SELECT 
			ROW_NUMBER() OVER (ORDER BY ' + @SortByColumns + ') AS ROWNUM,
			{0} 
		FROM [{1}] {2}
		WHERE (1 = 1) ' + @WhereCondition +'
	)
	SELECT * 
	FROM [PAGING] 
	WHERE ([PAGING].ROWNUM >= ((' + @CurrentPage + ' - 1) * ' + @PageSize + ' + 1)) AND ([PAGING].ROWNUM <= (' + @CurrentPage + ' * ' + @PageSize + '))')
", columnDetailInsert, tableName, shortTableName));

			txtCode_usp_Select_Paging.Text = textStoreInsert.ToString();
		}

		private void Gen_usp_Select_Count(string tableName)
		{
			// tab usp_Insert
			StringBuilder textStoreInsert = new StringBuilder();

			textStoreInsert.Append(string.Format(
@"GO
/****** Object:  StoredProcedure [dbo].[{0}_Select_Count]    Script Date: {1} ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- This stored procedure was created 
-- on {1} .
-- Template: Retrieve paging rows
-- Purpose: Get rows from the table {2}.

",
										RegenerateTableNameForStore(tableName),
										DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"),
										tableName));


			textStoreInsert.AppendLine(string.Format(
@"     ALTER PROCEDURE [dbo].[{0}_Select_Count]
	@WhereCondition nvarchar(500) = ''
", RegenerateTableNameForStore(tableName)));

			textStoreInsert.AppendLine(
@"  AS
	EXEC('");

			textStoreInsert.Append(string.Format(
@"SELECT 
		COUNT([{0}].[ID])
	FROM {0}
	WHERE (1 = 1) ' + @WhereCondition)", tableName));

			txtCode_usp_Select_Count.Text = textStoreInsert.ToString();
		}

		private void Gen_IData(string tableName)
		{
			// tab usp_Insert
			StringBuilder textStoreInsert = new StringBuilder();

			textStoreInsert.Append(string.Format(
@"using System;
using System.Collections.Generic;
using VCiStock.Data;

namespace VCiStock.Data.DataAccess
{{
	/// <summary>
	/// I{2} interface for Data Access Layer mapped table {0}.
	/// CODE:
	///     - Author:    BangDV
	///     - Generated Date:  {1}
	/// </summary>
	public interface I{2}
	{{
		/// <summary>
		/// 
		/// </summary>
		/// <param name=""obj""></param>
		/// <returns></returns>
		System.Int32 Add({2}Data obj);

		/// <summary>
		/// 
		/// </summary>
		/// <param name=""obj""></param>
		/// <returns></returns>
		System.Int32 Change({2}Data obj);

		/// <summary>
		/// 
		/// </summary>
		/// <param name=""obj""></param>
		/// <returns></returns>
		System.Int32 Remove({2}Data obj);

		/// <summary>
		/// 
		/// </summary>
		/// <param name=""objId""></param>
		/// <returns></returns>
		{2}Data Get{2}ByID(System.Int64 iD);

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		IList<{2}Data> Get{2}s();

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		IList<{2}Data> Get{2}s(System.String whereCondition);

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		IList<{2}Data> Get{2}s(System.Int32 size, System.String whereCondition);

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		System.Int32 Get{2}Count(System.String whereCondition);
	}}
}}
",
				   tableName,
				   DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"),
				   RegenerateTableNameForStore(tableName)));

			txtCodeI.Text = textStoreInsert.ToString();
		}

		private void Gen_TableData(string tableName)
		{
			// tab usp_Insert
			StringBuilder textStoreInsert = new StringBuilder();

			textStoreInsert.Append(string.Format(
@"using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace VCiStock.Data
{{
	/// <summary>
	/// {2}Data object for Entity mapped table {0}.
	/// CODE:
	///     - Author:    BangDV
	///     - Generated Date:  {1}
	/// </summary>
",
				   tableName,
				   DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"),
				   RegenerateTableNameForStore(tableName)));

			textStoreInsert.Append(string.Format(
@"     [DataContract]
	public class {0}Data: INotifyPropertyChanged
	{{", RegenerateTableNameForStore(tableName)));

			string privateMember = "";
			string publicMember = "";
			for (int i = 0; i < _dtbColumnList.Rows.Count; i++)
			{
				DataRow row = _dtbColumnList.Rows[i];

				privateMember += string.Format("        private {0}{2} _{1};\n", DataTypeMaping[row["DATA_TYPE"].ToString().ToUpper() + ""], row["COLUMN_NAME"], row["IS_NULLABLE"].ToString() == "YES" && !row["DATA_TYPE"].ToString().ToUpper().Contains("CHAR") ? "?" : "");
				publicMember += string.Format(
@"        [DataMember]
		public {0}{3} {1}
		{{
			get {{ return _{1}; }}
			set
			{{
				if({1} != value)
				{{
					_{1} = value;
					{2}
				}}
			}}
		}}
", DataTypeMaping[row["DATA_TYPE"].ToString().ToUpper() + ""], row["COLUMN_NAME"], string.Format("OnPropertyChanged(\"{0}\");", row["COLUMN_NAME"]), row["IS_NULLABLE"].ToString() == "YES" && !row["DATA_TYPE"].ToString().ToUpper().Contains("CHAR") ? "?" : "");
			}

			textStoreInsert.AppendLine(privateMember);

			textStoreInsert.Append(string.Format(
@"
		#region INotifyPropertyChanged Members

		protected virtual void OnPropertyChanged(string propertyName)
		{{
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}}

		public event PropertyChangedEventHandler PropertyChanged;
		#endregion

		public {0}Data()
		{{
		}}
", RegenerateTableNameForStore(tableName)));


			textStoreInsert.AppendLine(publicMember);

			textStoreInsert.Append(@"
		
	 }
}");

			txtCodeData.Text = textStoreInsert.ToString();
		}

		private void Gen_DomainObject(string tableName)
		{
			// tab usp_Insert
			StringBuilder textStoreInsert = new StringBuilder();


			string fieldConvert = "";

			string genParameter = "";
			for (int i = 0; i < _dtbColumnList.Rows.Count; i++)
			{
				DataRow row = _dtbColumnList.Rows[i];

				fieldConvert += string.Format("         obj.{0} = {1};\n", row["COLUMN_NAME"], row["DATA_TYPE"].ToString().ToUpper() != "DATETIME" ? string.Format("{0}(data.{1})", DataTypeConvertMaping[row["DATA_TYPE"].ToString().ToUpper() + ""], row["COLUMN_NAME"]) : string.Format("data.{0} != null ? System.Convert.ToDateTime(data.{0}) : (DateTime?)null", row["Column_Name"]));
				genParameter += string.Format("                dao.CreateParameter(\"@{0}\", obj.{0}){1}\n", row["COLUMN_NAME"], i < _dtbColumnList.Rows.Count - 1 ? "," : "");
			}

			textStoreInsert.Append(string.Format(
@"using System;
using System.Collections.Generic;
using System.Data;
using Library.DataAccess;
using VCiStock.Data;
using VCiStock.Data.DataAccess;
using VCiStock.Services.Contracts.Managements.Data.Contract;

namespace VCiStock.Data.DataAccess.Impl
{{
	/// <summary>
	/// The {2}DomainObject implemented for Data Access Layer mapped table {0}.
	/// CODE:
	///     - Author:    BangDV
	///     - Generated Date:  {2}
	/// </summary>
	public class {1}DomainObject : I{1}
	{{

		#region Const Fields
		
		private const System.String SP_{3}_INSERT = ""[dbo].[{3}_INSERT]"";
		private const System.String SP_{3}_UPDATE = ""[dbo].[{3}_UPDATE]"";
		private const System.String SP_{3}_DELETE = ""[dbo].[{3}_DELETE]"";
		private const System.String SP_{3}_SELECT_BY_ID = ""[dbo].[{3}_SELECT_BYID]"";
		private const System.String SP_{3}_SELECT_ALL = ""[dbo].[{3}_SELECT_ALL]"";
		private const System.String SP_{3}_SELECT_DYNAMIC = ""[dbo].[{3}_SELECT_DYNAMIC]"";
		private const System.String SP_{3}_SELECT_TOP_DYNAMIC = ""[dbo].[{3}_SELECT_TOP_DYNAMIC]"";
		private const System.String SP_{3}_SELECT_COUNT = ""[dbo].[{3}_SELECT_COUNT]"";
		private const System.String SP_{3}_SELECT_PAGING = ""[dbo].[{3}_SELECT_PAGING]"";
		#endregion
		",
				   tableName,
				   RegenerateTableNameForStore(tableName),
				   DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"),
				   RegenerateTableNameForStore(tableName).ToUpper()));


			textStoreInsert.Append(@"
		#region Properties

		private System.String _ConnectionString = """";
		/// <summary>
		/// Connect to database
		/// </summary>
		public System.String ConnectionString
		{
			get {return _ConnectionString; }
			set {_ConnectionString = value; }
		}

		#endregion
");

			textStoreInsert.Append(string.Format(
@"
		#region Constructors

		public {0}DomainObject()
		{{
		}}

		public {0}DomainObject(System.String connectionString)
		{{
			this.ConnectionString = connectionString;
		}}

		#endregion

		#region Protected Methods

", RegenerateTableNameForStore(tableName)));

			textStoreInsert.Append(string.Format(
@"      protected virtual {0}Data Convert(DataRow row)
		{{
			dynamic data = new DynamicDataRow(row);

			{0}Data obj = new {0}Data();

", RegenerateTableNameForStore(tableName)));


			textStoreInsert.AppendLine(fieldConvert);

			textStoreInsert.Append(string.Format(
@"      
			return obj;
		}}

		#endregion
"));

			textStoreInsert.Append(string.Format(
@"      #region Pulbic Methods
		public virtual System.Int32 Add({1}Data obj)
		{{
			JDataAccess dao = new JDataAccess(ConnectionString);
			dao.SetCommandText(SP_{0}_INSERT, CommandType.StoredProcedure);
			dao.SetParameters(new IDataParameter[]{{
", RegenerateTableNameForStore(tableName).ToUpper(), RegenerateTableNameForStore(tableName)));

			textStoreInsert.Append(genParameter);

			textStoreInsert.Append(string.Format(
@"
			}});
			return dao.SubmitChange();
		}}

"));

			textStoreInsert.Append(string.Format(
@"      

		public virtual System.Int32 Change({1}Data obj)
		{{
			JDataAccess dao = new JDataAccess(ConnectionString);
			dao.SetCommandText(SP_{0}_UPDATE, CommandType.StoredProcedure);
			dao.SetParameters(new IDataParameter[]{{
", RegenerateTableNameForStore(tableName).ToUpper(), RegenerateTableNameForStore(tableName)));

			textStoreInsert.Append(genParameter);

			textStoreInsert.Append(string.Format(
@"
			}});
			return dao.SubmitChange();
		}}

"));

			textStoreInsert.Append(string.Format(
@"      
		public virtual System.Int32 Remove({1}Data obj)
		{{
			JDataAccess dao = new JDataAccess(ConnectionString);
			dao.SetCommandText(SP_{0}_DELETE, CommandType.StoredProcedure);
			dao.SetParameters(new IDataParameter[]{{
", RegenerateTableNameForStore(tableName).ToUpper(), RegenerateTableNameForStore(tableName)));

			textStoreInsert.Append(genParameter);

			textStoreInsert.Append(string.Format(
@"
			}});
			return dao.SubmitChange();
		}}

"));



			textStoreInsert.Append(string.Format(
@"      
		public virtual {1}Data Get{1}ByID(System.Int64 iD)
		{{
			JDataAccess dao = new JDataAccess(ConnectionString);
			dao.SetCommandText(SP_{0}_SELECT_BY_ID, CommandType.StoredProcedure);
			dao.SetParameters(new IDataParameter[]{{
				dao.CreateParameter(""@ID"", iD)
			}});

			DataTable table = dao.ExecuteQuery();
			if (table != null && table.Rows.Count > 0)
			{{
				return Convert(table.Rows[0]);
			}}

			return default({1}Data);
		}}


		public virtual IList<{1}Data> Get{1}s()
		{{
			JDataAccess dao = new JDataAccess(ConnectionString);
			dao.SetCommandText(SP_{0}_SELECT_ALL, CommandType.StoredProcedure);

			DataTable table = dao.ExecuteQuery();
			if (table != null && table.Rows.Count > 0)
			{{
				IList<{1}Data> list = new List<{1}Data>(table.Rows.Count);
				foreach (DataRow row in table.Rows)
				{{
					list.Add(Convert(row));
				}}

				return list;
			}}
			return new List<{1}Data>();
		}}

		public virtual IList<{1}Data> Get{1}s(System.String whereCondition)
		{{
			JDataAccess dao = new JDataAccess(ConnectionString);
			dao.SetCommandText(SP_{0}_SELECT_DYNAMIC, CommandType.StoredProcedure);
			dao.SetParameters(new IDataParameter[]{{
				dao.CreateParameter(""@WhereCondition"", whereCondition)
			}});

			DataTable table = dao.ExecuteQuery();
			if (table != null && table.Rows.Count > 0)
			{{
				IList<{1}Data> list = new List<{1}Data>(table.Rows.Count);
				foreach (DataRow row in table.Rows)
				{{
					list.Add(Convert(row));
				}}

				return list;
			}}
			return new List<{1}Data>();
		}}

		public virtual IList<{1}Data> Get{1}s(System.Int32 size, System.String whereCondition)
		{{
			JDataAccess dao = new JDataAccess(ConnectionString);
			dao.SetCommandText(SP_{0}_SELECT_TOP_DYNAMIC, CommandType.StoredProcedure);
			dao.SetParameters(new IDataParameter[]{{
				dao.CreateParameter(""@Size"", size),
				dao.CreateParameter(""@WhereCondition"", whereCondition)
			}});

			DataTable table = dao.ExecuteQuery();
			if (table != null && table.Rows.Count > 0)
			{{
				IList<{1}Data> list = new List<{1}Data>(table.Rows.Count);
				foreach (DataRow row in table.Rows)
				{{
					list.Add(Convert(row));
				}}

				return list;
			}}
			return new List<{1}Data>();
		}}

		public virtual System.Int32 Get{1}Count(System.String whereCondition)
		{{
			JDataAccess dao = new JDataAccess(ConnectionString);
			dao.SetCommandText(SP_{0}_SELECT_COUNT, CommandType.StoredProcedure);
			dao.SetParameters(new IDataParameter[]{{
				dao.CreateParameter(""@WhereCondition"", whereCondition)
			}});

			DataTable table = dao.ExecuteQuery();
			if (table != null && table.Rows.Count > 0)
			{{
				return System.Int32.Parse(table.Rows[0][0].ToString());
			}}
			return 0;
		}}

		public virtual IList<{1}Data> Get{1}Paging(System.String whereCondition, System.Int32 pageSize, System.Int32 currentPage, System.String sortByColumns)
		{{
			JDataAccess dao = new JDataAccess(ConnectionString);
			dao.SetCommandText(SP_{0}_SELECT_PAGING, CommandType.StoredProcedure);
			dao.SetParameters(new IDataParameter[]{{
				dao.CreateParameter(""@WhereCondition"", whereCondition),
				dao.CreateParameter(""@PageSize"", pageSize),
				dao.CreateParameter(""@CurrentPage"", currentPage),
				dao.CreateParameter(""@SortByColumns"", sortByColumns)
			}});

			DataTable table = dao.ExecuteQuery();
			if (table != null && table.Rows.Count > 0)
			{{
				IList<{1}Data> list = new List<{1}Data>(table.Rows.Count);
				foreach (DataRow row in table.Rows)
				{{
					list.Add(Convert(row));
				}}

				return list;
			}}
			return new List<{1}Data>();
		}}

		",
		 RegenerateTableNameForStore(tableName).ToUpper(),
		 RegenerateTableNameForStore(tableName)));


			textStoreInsert.Append(
			@"
		#endregion

	}
}
");
			txtCodeDomainObject.Text = textStoreInsert.ToString();
		}

		private void Gen_IService(string tableName)
		{
			// tab usp_Insert
			StringBuilder textStoreInsert = new StringBuilder();

			textStoreInsert.Append(string.Format(
@"using System;
using System.Collections.Generic;
using System.ServiceModel;
using VCiStock.Data;
using VCiStock.Services.Contracts.Managements.Data.Contract;

namespace VCiStock.Services.Contracts.Managements.Operation
{{
	/// <summary>
	/// I{2}Service interface for service layer mapped table {0}.
	/// CODE:
	///     - Author:    BangDV
	///     - Generated Date:  {1}
	/// </summary>
	[ServiceContract]
	public interface I{2}Service
	{{
		/// <summary>
		/// 
		/// </summary>
		/// <param name=""data""></param>
		/// <returns></returns>
		[OperationContract]
		System.Int32 Add{2}({2}Data data);

		/// <summary>
		/// 
		/// </summary>
		/// <param name=""data""></param>
		/// <returns></returns>
		[OperationContract]
		System.Int32 Change{2}({2}Data data);

		/// <summary>
		/// 
		/// </summary>
		/// <param name=""data""></param>
		/// <returns></returns>
		[OperationContract]
		System.Int32 Remove{2}({2}Data data);

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		[OperationContract]
		IList<{2}Data> Get{2}s();

		/// <summary>
		/// 
		/// </summary>
		/// <param name=""objId""></param>
		/// <returns></returns>
		[OperationContract]
		{2}Data Get{2}ByID(System.Int64 iD);

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		[OperationContract]
		IList<{2}Data> Get{2}ByCriteria(System.String whereCondition);

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		[OperationContract]
		IList<{2}Data> Get{2}BySizeCriteria(System.Int32 size, System.String whereCondition);

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		[OperationContract]
		System.Int32 Get{2}Count(System.String whereCondition);

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		[OperationContract]
		IList<{2}Data> Get{2}Paging(System.String whereCondition, System.Int32 pageSize, System.Int32 currentPage, System.String sortByColumns);
	}}
}}
",
				   tableName,
				   DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"),
				   RegenerateTableNameForStore(tableName)));

			txtCodeIService.Text = textStoreInsert.ToString();
		}

		private void Gen_Service(string tableName)
		{
			// tab usp_Insert
			StringBuilder textStoreInsert = new StringBuilder();

			textStoreInsert.Append(string.Format(
@"

		#region using

		using System;
		using System.Data;
		using System.Collections.Generic;
		using System.Linq;
		using System.Text;

		using Library.DataAccess;

		using HS.UI.Common;
		using HS.Server.Interfaces.DAO;
		using HS.Server.DA.Systems;
		using HS.Server.BR.Contracts.Systems;


		#endregion

		#region {0}

		public System.Int32 Add{0}({0}Data data)
		{{
			try
			{{
				var domain = new {0}DomainObject(ConnectionString);
				return domain.Add(data);
			}}
			catch (Exception ex)
			{{
				ErrorLog.Log(""[Add{0}]"", ex.Message);
			}}
			return -1;
		}}

		public System.Int32 Change{0}({0}Data data)
		{{
			try
			{{
				var domain = new {0}DomainObject(ConnectionString);
				return domain.Change(data);
			}}
			catch (Exception ex)
			{{
				ErrorLog.Log(""[Change{0}]"", ex.Message);
			}}
			return -1;
		}}

		public System.Int32 Remove{0}({0}Data data)
		{{
			try
			{{
				var domain = new {0}DomainObject(ConnectionString);
				return domain.Remove(data);
			}}
			catch (Exception ex)
			{{
				ErrorLog.Log(""[Remove{0}]"", ex.Message);
			}}
			return -1;
		}}

		public IList<{0}Data> Get{0}s()
		{{
			try
			{{
				var domain = new {0}DomainObject(ConnectionString);
				return domain.Get{0}s();
			}}
			catch (Exception ex)
			{{
				ErrorLog.Log(""[Get{0}s]"", ex.Message);
				return null;
			}}
		}}

		public {0}Data Get{0}ByID(System.Int64 iD)
		{{
			try
			{{
				var domain = new {0}DomainObject(ConnectionString);
				return domain.Get{0}ByID(iD);
			}}
			catch (Exception ex)
			{{
				ErrorLog.Log(""[Get{0}ByID]"", ex.Message);
				return null;
			}}
		}}

		public IList<{0}Data> Get{0}ByCriteria(System.String whereCondition)
		{{
			try
			{{
				var domain = new {0}DomainObject(ConnectionString);
				return domain.Get{0}s(whereCondition);
			}}
			catch (Exception ex)
			{{
				ErrorLog.Log(""[Get{0}ByCriteria]"", ex.Message);
				return null;
			}}
		}}

		public IList<{0}Data> Get{0}BySizeCriteria(System.Int32 size, System.String whereCondition)
		{{
			try
			{{
				var domain = new {0}DomainObject(ConnectionString);
				return domain.Get{0}s(size, whereCondition);
			}}
			catch (Exception ex)
			{{
				ErrorLog.Log(""[Get{0}BySizeCriteria]"", ex.Message);
				return null;
			}}
		}}

		public System.Int32 Get{0}Count(System.String whereCondition)
		{{
			try
			{{
				var domain = new {0}DomainObject(ConnectionString);
				return domain.Get{0}Count(whereCondition);
			}}
			catch (Exception ex)
			{{
				ErrorLog.Log(""[Get{0}Count]"", ex.Message);
			}}
			return -1;
		}}

		public IList<{0}Data> Get{0}Paging(System.String whereCondition, System.Int32 pageSize, System.Int32 currentPage, System.String sortByColumns)
		{{
			try
			{{
				var domain = new {0}DomainObject(ConnectionString);
				return domain.Get{0}Paging(whereCondition, pageSize, currentPage, sortByColumns);
			}}
			catch (Exception ex)
			{{
				ErrorLog.Log(""[Get{0}Paging]"", ex.Message);
				return new List<{0}Data>();
			}}
		}}
				
		#endregion",
				   RegenerateTableNameForStore(tableName)));

			txtCodeService.Text = textStoreInsert.ToString();
		}

		private void Gen_ClientWraper(string tableName)
		{
			// tab usp_Insert
			StringBuilder textStoreInsert = new StringBuilder();

			textStoreInsert.Append(string.Format(
@"
		 #region {0}

		public int Add{0}(Connection.VStock.{0}Data obj)
		{{
			return CallMethod<Connection.VStock.{0}Data, int>(Proxy.Add{0}, obj);
		}}

		public int Change{0}(Connection.VStock.{0}Data obj)
		{{
			return CallMethod<Connection.VStock.{0}Data, int>(Proxy.Change{0}, obj);
		}}

		public int Remove{0}(Connection.VStock.{0}Data obj)
		{{
			return CallMethod<Connection.VStock.{0}Data, int>(Proxy.Remove{0}, obj);
		}}

		public System.ComponentModel.BindingList<Connection.VStock.{0}Data> Get{0}s()
		{{
			return CallMethod<System.ComponentModel.BindingList<Connection.VStock.{0}Data>>(Proxy.Get{0}s);
		}}

		public Connection.VStock.{0}Data Get{0}ByID(long iD)
		{{
			return CallMethod<long, Connection.VStock.{0}Data>(Proxy.Get{0}ByID, iD);
		}}

		public System.ComponentModel.BindingList<Connection.VStock.{0}Data> Get{0}ByCriteria(string whereCondition)
		{{
			return CallMethod<string, System.ComponentModel.BindingList<Connection.VStock.{0}Data>>(Proxy.Get{0}ByCriteria, whereCondition);
		}}

		public System.ComponentModel.BindingList<Connection.VStock.{0}Data> Get{0}BySizeCriteria(int size,string whereCondition)
		{{
			return CallMethod<int, string, System.ComponentModel.BindingList<Connection.VStock.{0}Data>>(Proxy.Get{0}BySizeCriteria, size, whereCondition);
		}}

		public int Get{0}Count(string conditionWhere)
		{{
			return CallMethod<string, int>(Proxy.Get{0}Count, conditionWhere);
		}}

		public System.ComponentModel.BindingList<Connection.VStock.{0}Data> Get{0}Paging(string whereCondition, int pageSize, int currentPage, string sortByColumns)
		{{
			return CallMethod<string, int, int, string, System.ComponentModel.BindingList<Connection.VStock.{0}Data>>(Proxy.Get{0}Paging, whereCondition, pageSize, currentPage, sortByColumns);
		}}

		#endregion",
				   RegenerateTableNameForStore(tableName)));

			txtCodeClientService.Text = textStoreInsert.ToString();
		}

		private void Gen_FillProperties(string tableName)
		{
			// tab usp_Insert
			StringBuilder textStoreInsert = new StringBuilder();

			textStoreInsert.AppendLine("");
			textStoreInsert.AppendLine("");
			textStoreInsert.AppendLine("");
			for (int i = 0; i < _dtbColumnList.Rows.Count; i++)
			{
				DataRow row = _dtbColumnList.Rows[i];
				textStoreInsert.Append(string.Format("        RefData.{0} = data.{0};\n", row["COLUMN_NAME"]));
			}

			txtCode_Fill_Properties.Text = textStoreInsert.ToString();
		}


		#endregion

		#region Events

		private void cboDatabase_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cboDatabase.Items.Count > 0)
			{
				_CurentDB = cboDatabase.Text;
				try
				{
					_SqlConnection = new SqlConnection(string.Format(CONNECTION_STRING, txtServer.Text.Trim(), _CurentDB, txtUsername.Text.Trim(), txtPassword.Text));
					_SqlConnection.Open();
					_SqlConnection.Close();
				}
				catch (Exception)
				{
					MessageBox.Show("Bạn không có quyền truy cập Database này.");
					return;
				}

				InitialListTable();
			}
			else
			{

			}
		}

		private void lstTable_SelectedIndexChanged(object sender, EventArgs e)
		{
			GengerateCodeForCurrentTable();
		}

		private void txtFilterTable_TextChanged(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(txtFilterTable.Text))
			{
				sourceTableList.DataSource = _dtbTableList;
			}
			else
			{
				DataRow[] dtbTempFilter = _dtbTableList.Select(string.Format("TABLE_NAME LIKE '%{0}%'", txtFilterTable.Text));

				DataTable dtbTemp = _dtbTableList.Clone();

				foreach (var row in dtbTempFilter)
				{
					var rowAdd = dtbTemp.NewRow();

					foreach (DataColumn col in dtbTemp.Columns)
					{
						rowAdd[col.ColumnName] = row[col.ColumnName];
					}

					dtbTemp.Rows.Add(rowAdd);
				}

				sourceTableList.DataSource = dtbTemp;
				sourceTableList.MoveFirst();

				//GengerateCodeForCurrentTable();
			}
		}

		private void btnConnect_Click(object sender, EventArgs e)
		{
			_CurentDB = "master";

			InitialConnection();
		}

		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			//if (_SqlConnection != null && _SqlConnection.State != ConnectionState.Closed)
			//{
			//  _SqlConnection.Close();
			//}
		}

		#endregion

		#region DB Helper
		private DataTable SelectDB(string sqlString)
		{
			try
			{
				DataTable dts = new DataTable();

				using (SqlCommand command = _SqlConnection.CreateCommand())
				{
					command.CommandType = CommandType.Text;
					command.CommandText = sqlString;

					using (SqlDataAdapter sda = new SqlDataAdapter(command))
					{
						sda.Fill(dts);
					}
				}

				return dts;
			}
			catch (Exception)
			{
				throw;
			}
		}

		private void ExcuteSql(string sqlString)
		{
			try
			{
				_SqlConnection.Open();

				ServerConnection svrConnection = new ServerConnection(_SqlConnection);

				Server server = new Server(svrConnection);

				server.ConnectionContext.ExecuteNonQuery(sqlString);

				_SqlConnection.Close();
			}
			catch (Exception)
			{
				if (_SqlConnection.State != ConnectionState.Closed)
				{
					_SqlConnection.Close();
				}
				throw;
			}
		}
		#endregion

		#region TableName Helper
		private string RegenerateTableNameForStore(string tableName, string shortTableName = "")
		{
			string output = "";
			shortTableName = "";

			string[] names = tableName.Split("_".ToCharArray());

			foreach (string name in names)
			{
				string newName = name;

				//for (int i = 0; i < name.Length; i++)
				//{
				//    newName += (i == 0 ? name[i].ToString().ToUpper() : name[i].ToString().ToLower());

				//    if (i == 0)
				//    {
				//        shortTableName += name[i].ToString().ToLower();
				//    }
				//}

				shortTableName += name[0].ToString().ToLower();

				output += newName;
			}

			return output;
		}

		private string RegenerateShortTableNameForStore(string tableName)
		{
			string output = "";

			string[] names = tableName.Split("_".ToCharArray());

			foreach (string name in names)
			{
				if (string.IsNullOrEmpty(name)) continue;

				output += name[0].ToString().ToLower();
			}

			return output;
		}

		private void FormatTabName(string tableName)
		{

			// tab name
			foreach (TabPage page in tabGenerate.TabPages)
			{
				page.Text = string.Format(page.Tag.ToString(), RegenerateTableNameForStore(tableName));
			}

			// tab name
			foreach (TabPage page in tabStored.TabPages)
			{
				page.Text = string.Format(page.Tag.ToString(), RegenerateTableNameForStore(tableName));
			}

			// tab name
			foreach (TabPage page in tabEntity.TabPages)
			{
				page.Text = string.Format(page.Tag.ToString(), RegenerateTableNameForStore(tableName));
			}

			// tab name
			foreach (TabPage page in tabService.TabPages)
			{
				page.Text = string.Format(page.Tag.ToString(), RegenerateTableNameForStore(tableName));
			}

			// tab name
			foreach (TabPage page in tabIService.TabPages)
			{
				page.Text = string.Format(page.Tag.ToString(), RegenerateTableNameForStore(tableName));
			}

			// tab name
			foreach (TabPage page in tabCommonService.TabPages)
			{
				page.Text = string.Format(page.Tag.ToString(), RegenerateTableNameForStore(tableName));
			}
		}

		#endregion

		private void FormatTextBoxState(bool textboxReadonlyMode)
		{
			txtCode_usp_Delete.IsReadOnly =
			txtCode_usp_Insert.IsReadOnly =
			txtCode_usp_Select_All.IsReadOnly =
			txtCode_usp_Select_ByID.IsReadOnly =
			txtCode_usp_Select_Count.IsReadOnly =
			txtCode_usp_Select_Dynamic.IsReadOnly =
			txtCode_usp_Select_Top_Dynamic.IsReadOnly =
			txtCode_usp_Select_Paging.IsReadOnly =
			txtCode_usp_Update.IsReadOnly =
			txtCodeData.IsReadOnly =
			txtCodeDomainObject.IsReadOnly =
			txtCodeI.IsReadOnly =
			txtCodeService.IsReadOnly =
			txtCodeIService.IsReadOnly =
			txtCodeClientService.IsReadOnly =
			txtCode_Fill_Properties.IsReadOnly = textboxReadonlyMode;
		}

		private void btnExcCreate_Click(object sender, EventArgs e)
		{
			ChangeStore("CREATE");
		}

		private void btnExcAlter_Click(object sender, EventArgs e)
		{
			ChangeStore("ALTER");
		}

		private void ChangeStore(string type)
		{
			List<TabPage> tabApply = new List<TabPage>();

			if (chkApplyAll.Checked)
			{
				foreach (TabPage tab in tabStored.TabPages)
				{
					tabApply.Add(tab);
				}
			}
			else
			{
				tabApply.Add(tabStored.SelectedTab);
			}

			foreach (TabPage currentTab in tabApply)
			{
				var textPlace = currentTab.Controls[0] as ScintillaNET.Scintilla;

				textPlace.IsReadOnly = false;

				string findString = "";
				string replaceString = type;

				if (type == "CREATE")
				{
					findString = "ALTER";
				}
				else
				{
					findString = "CREATE";
				}

				textPlace.Text = textPlace.Text.Replace(findString, replaceString);

				textPlace.IsReadOnly = true;
			}
		}

		private void btnExcutePro_Click(object sender, EventArgs e)
		{
			try
			{
				List<TabPage> tabApply = new List<TabPage>();

				if (chkApplyAll.Checked)
				{
					foreach (TabPage tab in tabStored.TabPages)
					{
						tabApply.Add(tab);
					}
				}
				else
				{
					tabApply.Add(tabStored.SelectedTab);
				}

				string tabFalse = "";
				foreach (TabPage currentTab in tabApply)
				{
					var textPlace = currentTab.Controls[0] as ScintillaNET.Scintilla;
					string sqlString = textPlace.Text;

					try
					{
						ExcuteSql(sqlString);
					}
					catch (Exception ex)
					{
						tabFalse += " - " + currentTab + "\n";
					}
				}

				if (tabFalse == "")
				{
					MessageBox.Show("Done!");
				}
				else
				{
					MessageBox.Show("Done! Có vài Tab lỗi: \n" + tabFalse);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

	}
}
