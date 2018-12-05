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
public static class AddressDb
{
    [DataObjectMethod(DataObjectMethodType.Select)]
    public static List<Address> GetAddresses(string UserId)
    {
        List<Address> AddressList = new List<Address>();
        string sql = "SELECT * FROM Addresses WHERE UserId = @UserId";
        using (SqlConnection con = new SqlConnection(GetConnectionString()))
        {
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {

                cmd.Parameters.AddWithValue("UserId", UserId);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                Address address;
                while (dr.Read())
                {
                    address = new Address();
                    address.AddressId = dr["AddressId"].ToString();
                    address.UserId = dr["UserId"].ToString();
                    address.StreetAddress = dr["StreetAddress"].ToString();
                    address.Type = dr["Type"].ToString();
                    address.Number = dr["Number"].ToString();
                    address.City = dr["City"].ToString();
                    address.PostalCode = dr["PostalCode"].ToString();
                    address.Region = dr["Region"].ToString();
                    address.Country = dr["Country"].ToString();
                    AddressList.Add(address);
                }
                dr.Close();
            }
        }
        return AddressList;
    }


    [DataObjectMethod(DataObjectMethodType.Update)]
    public static int UpdateAddress(Address original_address,
        Address address)
    {
        int updateCount = 0;
        string sql = "UPDATE Addresses "
            + "SET StreetAddress = @StreetAddress, "
            + "Type = @Type, "
            + "Number = @Number, "
            + "City = @City, "
            + "PostalCode = @PostalCode, "
            + "Region = @Region, "
            + "Country = @Country "
            + "WHERE AddressId = @original_AddressId ";
        using (SqlConnection con = new SqlConnection(GetConnectionString()))
        {
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("StreetAddress", address.StreetAddress);
                cmd.Parameters.AddWithValue("Type", address.Type);
                cmd.Parameters.AddWithValue("Number", address.Number);
                cmd.Parameters.AddWithValue("PostalCode", address.PostalCode);
                cmd.Parameters.AddWithValue("Region", address.Region);
                cmd.Parameters.AddWithValue("City", address.City);
                cmd.Parameters.AddWithValue("Country", address.Country);
                cmd.Parameters.AddWithValue("original_AddressId", original_address.AddressId);
                con.Open();
                updateCount = cmd.ExecuteNonQuery();
            }
        }
        return updateCount;
    }

    [DataObjectMethod(DataObjectMethodType.Delete)]
    public static int DeleteAddress(Address address)
    {
        int deleteCount = 0;
        string sql = "DELETE FROM Addresses "
            + "WHERE AddressId = @AddressId";
        using (SqlConnection con = new SqlConnection(GetConnectionString()))
        {
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("AddressId", address.AddressId);
                con.Open();
                deleteCount = cmd.ExecuteNonQuery();
            }
        }
        return deleteCount;
    }

    [DataObjectMethod(DataObjectMethodType.Insert)]
    public static void InsertAddress(Address address)
    {
        string sql = "INSERT INTO Addresses "
            + "(AddressId, UserId, StreetAddress, Type, Number, City, PostalCode, Region, Country) "
            + "VALUES (@AddressId, @UserId, @StreetAddress, @Type, @Number, @City, @PostalCode, @Region, @Country)";
        using (SqlConnection con = new SqlConnection(GetConnectionString()))
        {
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("AddressId", address.AddressId);
                cmd.Parameters.AddWithValue("UserId", address.UserId);
                cmd.Parameters.AddWithValue("StreetAddress", address.StreetAddress);
                cmd.Parameters.AddWithValue("Type", address.Type);
                cmd.Parameters.AddWithValue("Number", address.Number);
                cmd.Parameters.AddWithValue("City", address.City);
                cmd.Parameters.AddWithValue("PostalCode", address.PostalCode);
                cmd.Parameters.AddWithValue("Region", address.Region);
                cmd.Parameters.AddWithValue("Country", address.Country);
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
