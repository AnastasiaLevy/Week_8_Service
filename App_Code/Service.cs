using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]

public class Service : System.Web.Services.WebService
{
    public Service () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public bool CheckTheLogIn(string username, string password)
        {
            bool check = false;
            SqlConnection sqlConnection = new SqlConnection("data source=.;initial catalog=ClassProjectDataBase;integrated security=True");
            String SQLQuery = "SELECT * FROM people WHERE username = @userName and password = @password";
            SqlCommand command = new SqlCommand(SQLQuery, sqlConnection);
            command.Parameters.Add(new SqlParameter("@userName", username));
            command.Parameters.Add(new SqlParameter("@password", password));
            sqlConnection.Open();
            DataTable person = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(person);
            da.Dispose();
            sqlConnection.Close();
            if (person.Rows.Count > 0)
                check = true;
          
            return check;
        }


    }
    
