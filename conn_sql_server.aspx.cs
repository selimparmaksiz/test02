using System.Data.SqlClient;
 
namespace Eth4You{
 
public partial class miner_test : System.Web.UI.Page{
    
  public void test()
  {
    string connString = "Server=tcp:sunucu01.database.windows.net,1433;Initial Catalog=veritabani01;Persist Security Info=False;User ID=yonetici;Password={your_password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

    /* if your using Windows Authentication, use the code below
    string connString = "Server=PCNAME\\SQLEXPRESS;Database=DB_name;Integrated Security=SSPI;";
    
    // I first opened and created the connection to the server */
    
    SqlConnection conn = new SqlConnection(connString);
    conn.Open();

    //Then create and bind the sql command through the connection
    
    string cmdString = "SELECT TOP (1000) * FROM [SalesLT].[Customer]";
    SqlCommand cmd = new SqlCommand(cmdString, conn);
    cmd.CommandType = System.Data.CommandType.Text;
    cmd.Connection = conn;

    //test if the connection can read and write the data in the table
    
    var tempStr = "";
    SqlDataReader reader = cmd.ExecuteReader();
    
    while (reader.Read()) //while there is data being read
    {
       tempStr += "<br>IIDD:";
       tempStr += reader["IIDD"].ToString(); // store the string to tempStr
       tempStr += "<br>name:";
       tempStr += reader["name"].ToString(); // store the string to tempStr
       tempStr += "<br /><br>"; // store a space to break data
    }
    
    //Output the data to the ID=Label in miner_test.aspx
    temp.Text = tempStr;
  }
  
}
}