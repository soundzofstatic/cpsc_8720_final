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
public static class UserPayeeDb
{
    [DataObjectMethod(DataObjectMethodType.Select)]
    public static List<UserPayee> GetUserPayees(string UserId)
    {
        List<UserPayee> UserPayeeList = new List<UserPayee>();
        string sql = "SELECT * FROM UserPayees WHERE UserId = @UserId";
        using (SqlConnection con = new SqlConnection(GetConnectionString()))
        {
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("UserId", UserId);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                UserPayee userPayee;
                while (dr.Read())
                {
                    userPayee = new UserPayee();
                    userPayee.UserPayeeId = dr["UserPayeeId"].ToString();
                    userPayee.UserId = dr["UserId"].ToString();
                    userPayee.PayeeId = dr["PayeeId"].ToString();
                    userPayee.Nickname = dr["Nickname"].ToString();
                    userPayee.PayeeAccountNumber = dr["PayeeAccountNumber"].ToString();
                    UserPayeeList.Add(userPayee);
                }
                dr.Close();
            }
        }
        return UserPayeeList;
    }

    [DataObjectMethod(DataObjectMethodType.Select)]
    public static UserPayee GetUserPayeeById(string UserPayeeId)
    {
        UserPayee userPayee;
        string sql = "SELECT * FROM UserPayees WHERE UserPayeeId = @UserPayeeId";
        using (SqlConnection con = new SqlConnection(GetConnectionString()))
        {
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("UserPayeeId", UserPayeeId);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();

                userPayee = new UserPayee();
                userPayee.UserPayeeId = dr["UserPayeeId"].ToString();
                userPayee.UserId = dr["UserId"].ToString();
                userPayee.PayeeId = dr["PayeeId"].ToString();
                userPayee.Nickname = dr["Nickname"].ToString();
                userPayee.PayeeAccountNumber = dr["PayeeAccountNumber"].ToString();
                dr.Close();

            }
        }
        return userPayee;
    }

    [DataObjectMethod(DataObjectMethodType.Update)]
    public static int UpdateUserPayee(UserPayee original_userPayee,
        UserPayee userPayee)
    {
        int updateCount = 0;
        string sql = "UPDATE UserPayees SET "
            + "Nickname = @Nickname, "
            + "PayeeAccountNumber = @PayeeAccountNumber "
            + "WHERE UserPayeeId = @original_UserPayeeId ";
        using (SqlConnection con = new SqlConnection(GetConnectionString()))
        {
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("Nickname", userPayee.Nickname);
                cmd.Parameters.AddWithValue("PayeeAccountNumber", userPayee.PayeeAccountNumber);
                cmd.Parameters.AddWithValue("original_UserPayeeId", original_userPayee.UserPayeeId);
                con.Open();
                updateCount = cmd.ExecuteNonQuery();
            }
        }
        return updateCount;
    }

    [DataObjectMethod(DataObjectMethodType.Delete)]
    public static int DeleteUserPayee(UserPayee userPayee)
    {
        int deleteCount = 0;
        string sql = "DELETE FROM UserPayees "
            + "WHERE UserPayeeId = @UserPayeeId";
        using (SqlConnection con = new SqlConnection(GetConnectionString()))
        {
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("UserPayeeId", userPayee.UserPayeeId);
                con.Open();
                deleteCount = cmd.ExecuteNonQuery();
            }
        }
        return deleteCount;
    }

    [DataObjectMethod(DataObjectMethodType.Insert)]
    public static void InsertUserPayee(UserPayee userPayee)
    {
        string sql = "INSERT INTO UserPayees "
            + "(UserPayeeId, UserId, PayeeId, Nickname, PayeeAccountNumber) "
            + "VALUES (@UserPayeeId, @UserId, @PayeeId, @Nickname, @PayeeAccountNumber)";
        using (SqlConnection con = new SqlConnection(GetConnectionString()))
        {
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("UserPayeeId", userPayee.UserPayeeId);
                cmd.Parameters.AddWithValue("UserId", userPayee.UserId);
                cmd.Parameters.AddWithValue("PayeeId", userPayee.PayeeId);
                cmd.Parameters.AddWithValue("Nickname", userPayee.Nickname);
                cmd.Parameters.AddWithValue("PayeeAccountNumber", userPayee.PayeeAccountNumber);
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
