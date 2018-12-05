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
public static class PayeeDb
{
    [DataObjectMethod(DataObjectMethodType.Select)]
    public static List<Payee> GetAllPayees()
    {
        List<Payee> PayeeList = new List<Payee>();
        string sql = "SELECT * FROM Payees";
        using (SqlConnection con = new SqlConnection(GetConnectionString()))
        {
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                Payee payee;
                while (dr.Read())
                {
                    payee = new Payee();
                    payee.PayeeId = dr["PayeeId"].ToString();
                    payee.DefaultName = dr["DefaultName"].ToString();
                    payee.DefaultStreetAddress = dr["DefaultStreetAddress"].ToString();
                    payee.DefaultStreetAddressTwo = dr["DefaultStreetAddressTwo"].ToString();
                    payee.DefaultCity = dr["DefaultCity"].ToString();
                    payee.DefaultRegion = dr["DefaultRegion"].ToString();
                    payee.DefaultCountry = dr["DefaultCountry"].ToString();
                    payee.DefaultPostalCode = dr["DefaultPostalCode"].ToString();
                    PayeeList.Add(payee);
                }
                dr.Close();
            }
        }
        return PayeeList;
    }

    [DataObjectMethod(DataObjectMethodType.Select)]
    public static List<Payee> GetPayeeByName(string SearchQuery)
    {
        List<Payee> PayeeList = new List<Payee>();
        string sql = "SELECT * FROM Payees WHERE DefaultName LIKE @SearchQuery";
        using (SqlConnection con = new SqlConnection(GetConnectionString()))
        {
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("SearchQuery", '%' + SearchQuery + '%');
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                Payee payee;
                while (dr.Read())
                {
                    payee = new Payee();
                    payee.PayeeId = dr["PayeeId"].ToString();
                    payee.DefaultName = dr["DefaultName"].ToString();
                    payee.DefaultStreetAddress = dr["DefaultStreetAddress"].ToString();
                    payee.DefaultStreetAddressTwo = dr["DefaultStreetAddressTwo"].ToString();
                    payee.DefaultCity = dr["DefaultCity"].ToString();
                    payee.DefaultRegion = dr["DefaultRegion"].ToString();
                    payee.DefaultCountry = dr["DefaultCountry"].ToString();
                    payee.DefaultPostalCode = dr["DefaultPostalCode"].ToString();
                    PayeeList.Add(payee);
                }
                dr.Close();
            }
        }
        return PayeeList;
    }

    [DataObjectMethod(DataObjectMethodType.Select)]
    public static Payee GetPayeeById(string PayeeId)
    {
        Payee payee;
        string sql = "SELECT * FROM Payees WHERE PayeeId = @PayeeId";
        using (SqlConnection con = new SqlConnection(GetConnectionString()))
        {
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("PayeeId", PayeeId);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();

                payee = new Payee();
                payee.PayeeId = dr["PayeeId"].ToString();
                payee.DefaultName = dr["DefaultName"].ToString();
                payee.DefaultStreetAddress = dr["DefaultStreetAddress"].ToString();
                payee.DefaultStreetAddressTwo = dr["DefaultStreetAddressTwo"].ToString();
                payee.DefaultCity = dr["DefaultCity"].ToString();
                payee.DefaultRegion = dr["DefaultRegion"].ToString();
                payee.DefaultCountry = dr["DefaultCountry"].ToString();
                payee.DefaultPostalCode = dr["DefaultPostalCode"].ToString();
                dr.Close();
                
            }
        }
        return payee;
    }

    [DataObjectMethod(DataObjectMethodType.Update)]
    public static int UpdatePayee(Payee original_payee,
        Payee payee)
    {
        int updateCount = 0;
        string sql = "UPDATE Payees SET "
            + "DefaultName = @DefaultName, "
            + "DefaultStreetAddress = @DefaultStreetAddress, "
            + "DefaultStreetAddressTwo = @DefaultStreetAddressTwo "
            + "DefaultCity = @DefaultCity "
            + "DefaultRegion = @DefaultRegion "
            + "DefaultCountry = @DefaultCountry "
            + "DefaultPostalCode = @DefaultPostalCode "
            + "WHERE PayeeId = @original_PayeeId ";
        using (SqlConnection con = new SqlConnection(GetConnectionString()))
        {
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("DefaultName", payee.DefaultName);
                cmd.Parameters.AddWithValue("DefaultStreetAddress", payee.DefaultStreetAddress);
                cmd.Parameters.AddWithValue("DefaultStreetAddressTwo", payee.DefaultStreetAddressTwo);
                cmd.Parameters.AddWithValue("DefaultCity", payee.DefaultCity);
                cmd.Parameters.AddWithValue("DefaultRegion", payee.DefaultRegion);
                cmd.Parameters.AddWithValue("DefaultCountry", payee.DefaultCountry);
                cmd.Parameters.AddWithValue("DefaultPostalCode", payee.DefaultPostalCode);
                cmd.Parameters.AddWithValue("original_PayeeId", original_payee.PayeeId);
                con.Open();
                updateCount = cmd.ExecuteNonQuery();
            }
        }
        return updateCount;
    }

    [DataObjectMethod(DataObjectMethodType.Delete)]
    public static int DeletePayee(Payee payee)
    {
        int deleteCount = 0;
        string sql = "DELETE FROM Payees "
            + "WHERE PayeeId = @PayeeId";
        using (SqlConnection con = new SqlConnection(GetConnectionString()))
        {
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("PayeeId", payee.PayeeId);
                con.Open();
                deleteCount = cmd.ExecuteNonQuery();
            }
        }
        return deleteCount;
    }

    [DataObjectMethod(DataObjectMethodType.Insert)]
    public static void InsertPayee(Payee payee)
    {
        string sql = "INSERT INTO Payees "
            + "(PayeeId, DefaultName, DefaultStreetAddress, DefaultStreetAddressTwo, DefaultCity, DefaultRegion, DefaultCountry, DefaultPostalCode) "
            + "VALUES (@PayeeId, @DefaultName, @DefaultStreetAddress, @DefaultStreetAddressTwo, @DefaultCity, @DefaultRegion, @DefaultCountry, @DefaultPostalCode)";
        using (SqlConnection con = new SqlConnection(GetConnectionString()))
        {
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("PayeeId", payee.PayeeId);
                cmd.Parameters.AddWithValue("DefaultName", payee.DefaultName);
                cmd.Parameters.AddWithValue("DefaultStreetAddress", payee.DefaultStreetAddress);
                cmd.Parameters.AddWithValue("DefaultStreetAddressTwo", payee.DefaultStreetAddressTwo);
                cmd.Parameters.AddWithValue("DefaultCity", payee.DefaultCity);
                cmd.Parameters.AddWithValue("DefaultRegion", payee.DefaultRegion);
                cmd.Parameters.AddWithValue("DefaultCountry", payee.DefaultCountry);
                cmd.Parameters.AddWithValue("DefaultPostalCode", payee.DefaultPostalCode);
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
