using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// be sure to include these using directives
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;
using OnlineBillPay.Models;

[DataObject(true)]
public static class UserContextDb
{

    [DataObjectMethod(DataObjectMethodType.Select)]
    public static List<UserContext> GetSystemUsers()
    {
        List<UserContext> UserContextList = new List<UserContext>();
        string sql = "SELECT P.*, R.Name, R.Id AS RoleId " +
            "FROM AspNetUsers P " +
            "LEFT OUTER JOIN AspNetUserRoles U " +
            "ON P.Id = U.UserId " +
            "LEFT OUTER JOIN AspNetRoles R " +
            "ON U.RoleId = R.Id " +
            "ORDER BY P.LastName ASC";

        using (SqlConnection con = new SqlConnection(GetConnectionString()))
        {
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                UserContext userContext;
                while (dr.Read())
                {
                    userContext = new UserContext();
                    userContext.UserId = dr["Id"].ToString();
                    userContext.UserName = dr["UserName"].ToString();
                    userContext.Email = dr["Email"].ToString();
                    userContext.FirstName = dr["FirstName"].ToString();
                    userContext.LastName = dr["LastName"].ToString();
                    userContext.DisplayName = dr["DisplayName"].ToString();
                    userContext.AccountState = dr["AccountState"].ToString();
                    userContext.RoleId = dr["RoleId"].ToString();
                    userContext.Role = dr["Name"].ToString();
                    UserContextList.Add(userContext);
                }
                dr.Close();
            }
        }
        return UserContextList;
    }

    [DataObjectMethod(DataObjectMethodType.Select)]
    public static UserContext GetUserContext(string UserId)
    {
        UserContext userContext;
        string sql = "SELECT P.*, R.Name, R.Id AS RoleId " +
            "FROM AspNetUsers P " +
            "LEFT OUTER JOIN AspNetUserRoles U " +
            "ON P.Id = U.UserId " +
            "LEFT OUTER JOIN AspNetRoles R " +
            "ON U.RoleId = R.Id " +
            "WHERE P.Id = @UserId";
        using (SqlConnection con = new SqlConnection(GetConnectionString()))
        {
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("UserId", UserId);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();

                userContext = new UserContext();
                userContext.UserId = dr["Id"].ToString();
                userContext.UserName = dr["UserName"].ToString();
                userContext.Email = dr["Email"].ToString();
                userContext.FirstName = dr["FirstName"].ToString();
                userContext.LastName = dr["LastName"].ToString();
                userContext.DisplayName = dr["DisplayName"].ToString();
                userContext.AccountState = dr["AccountState"].ToString();
                userContext.RoleId = dr["RoleId"].ToString();
                userContext.Role = dr["Name"].ToString();
                dr.Close();

            }
        }
        return userContext;
    }

    [DataObjectMethod(DataObjectMethodType.Update)]
    public static int UpdateUserContext(UserContext original_userContext,
        UserContext userContext)
    {
        int updateCount = 0;
        string sql = "UPDATE AspNetUsers SET "
            + "DisplayName = @DisplayName, "
            + "FirstName = @FirstName, "
            + "LastName = @LastName "
            + "WHERE Id = @original_UserId ";
        using (SqlConnection con = new SqlConnection(GetConnectionString()))
        {
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("DisplayName", userContext.DisplayName);
                cmd.Parameters.AddWithValue("FirstName", userContext.FirstName);
                cmd.Parameters.AddWithValue("LastName", userContext.LastName);
                cmd.Parameters.AddWithValue("original_UserId", original_userContext.UserId);
                con.Open();
                updateCount = cmd.ExecuteNonQuery();
            }
        }
        return updateCount;
    }

    public static int ToggleUserAccountState(UserContext userContext)
    {
        int updateCount = 0;
        string sql = "UPDATE AspNetUsers SET "
            + "AccountState = @AccountState "
            + "WHERE Id = @UserId ";
        using (SqlConnection con = new SqlConnection(GetConnectionString()))
        {
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("AccountState", userContext.AccountState);
                cmd.Parameters.AddWithValue("UserId", userContext.UserId);
                con.Open();
                updateCount = cmd.ExecuteNonQuery();
            }
        }
        return updateCount;
    }

    [DataObjectMethod(DataObjectMethodType.Delete)]
    public static int DeleteUser(UserContext userContext)
    {
        int deleteCount = 0;
        string sql = "DELETE FROM AspNetUser "
            + "WHERE Id = @UserId";
        using (SqlConnection con = new SqlConnection(GetConnectionString()))
        {
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("UserId", userContext.UserId);
                con.Open();
                deleteCount = cmd.ExecuteNonQuery();
            }
        }
        return deleteCount;
    }

    [DataObjectMethod(DataObjectMethodType.Delete)]
    public static int DeleteUserRole(UserContext userContext)
    {
        int deleteCount = 0;
        string sql = "DELETE FROM AspNetUserRoles "
            + "WHERE UserId = @UserId "
            + "AND RoleId = @RoleId ";
        using (SqlConnection con = new SqlConnection(GetConnectionString()))
        {
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("UserId", userContext.UserId);
                cmd.Parameters.AddWithValue("RoleId", userContext.RoleId);
                con.Open();
                deleteCount = cmd.ExecuteNonQuery();
            }
        }
        return deleteCount;
    }

  /*
     * 
     *System.Data.SqlClient.SqlException
  HResult=0x80131904
  Message=The parameterized query '(@UserId nvarchar(36),@RoleId nvarchar(4000))DELETE FROM AspNetU' expects the parameter '@RoleId', which was not supplied.
  Source=.Net SqlClient Data Provider
  StackTrace:
   at UserContextDb.DeleteUserRole(UserContext userContext) in C:\Users\Demo1\Desktop\scratch\OnlineBillPay\OnlineBillPay\OnlineBillPay\Models\UserContextDb.cs:line 170
   at OnlineBillPay.Account.Admin.Default.GridView2_UserResultCommand(Object sender, GridViewCommandEventArgs e) in C:\Users\Demo1\Desktop\scratch\OnlineBillPay\OnlineBillPay\OnlineBillPay\Account\Admin\Default.aspx.cs:line 95

     */


    [DataObjectMethod(DataObjectMethodType.Insert)]
    public static void AddUserRole(UserContext userContext)
    {
        string sql = "INSERT INTO AspNetUserRoles "
            + "(UserId, RoleId) "
            + "VALUES(@UserId, @RoleId) ";
        using (SqlConnection con = new SqlConnection(GetConnectionString()))
        {
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("UserId", userContext.UserId);
                cmd.Parameters.AddWithValue("RoleId", userContext.RoleId);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }

    private static string GetConnectionString()
    {
        return ConfigurationManager.ConnectionStrings
            ["DefaultConnection"].ConnectionString;
    }

}
