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
public static class PhoneNumberDb
{
    [DataObjectMethod(DataObjectMethodType.Select)]
    public static List<PhoneNumber> GetPhoneNumbers(string UserId)
    {
        List<PhoneNumber> PhoneNumberList = new List<PhoneNumber>();
        string sql = "SELECT * FROM PhoneNumbers WHERE UserId = @UserId";
        using (SqlConnection con = new SqlConnection(GetConnectionString()))
        {
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {

                cmd.Parameters.AddWithValue("UserId", UserId);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                PhoneNumber phoneNumber;
                while (dr.Read())
                {
                    phoneNumber = new PhoneNumber();
                    phoneNumber.PhoneNumberId = dr["PhoneNumberId"].ToString();
                    phoneNumber.UserId = dr["UserId"].ToString();
                    phoneNumber.Type = dr["Type"].ToString();
                    phoneNumber.Number = dr["Number"].ToString();
                    phoneNumber.Extension = dr["Extension"].ToString();
                    PhoneNumberList.Add(phoneNumber);
                }
                dr.Close();
            }
        }
        return PhoneNumberList;
    }


    [DataObjectMethod(DataObjectMethodType.Update)]
    public static int UpdatePhoneNumber(PhoneNumber original_phoneNumber,
        PhoneNumber phoneNumber)
    {
        int updateCount = 0;
        string sql = "UPDATE PhoneNumbers SET "
            + "Type = @Type, "
            + "Number = @Number, "
            + "Extension = @Extension "
            + "WHERE PhoneNumberId = @original_PhoneNumberId ";
        using (SqlConnection con = new SqlConnection(GetConnectionString()))
        {
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("Type", phoneNumber.Type);
                cmd.Parameters.AddWithValue("Number", phoneNumber.Number);
                cmd.Parameters.AddWithValue("Extension", phoneNumber.Extension);
                cmd.Parameters.AddWithValue("original_PhoneNumberId", original_phoneNumber.PhoneNumberId);
                con.Open();
                updateCount = cmd.ExecuteNonQuery();
            }
        }
        return updateCount;
    }

    [DataObjectMethod(DataObjectMethodType.Delete)]
    public static int DeletePhoneNumber(PhoneNumber phoneNumber)
    {
        int deleteCount = 0;
        string sql = "DELETE FROM PhoneNumbers "
            + "WHERE PhoneNumberId = @PhoneNumberId";
        using (SqlConnection con = new SqlConnection(GetConnectionString()))
        {
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("PhoneNumberId", phoneNumber.PhoneNumberId);
                con.Open();
                deleteCount = cmd.ExecuteNonQuery();
            }
        }
        return deleteCount;
    }

    [DataObjectMethod(DataObjectMethodType.Insert)]
    public static void InsertPhoneNumber(PhoneNumber phoneNumber)
    {
        string sql = "INSERT INTO PhoneNumbers "
            + "(PhoneNumberId, UserId, Type, Number, Extension) "
            + "VALUES (@PhoneNumberId, @UserId, @Type, @Number, @Extension)";
        using (SqlConnection con = new SqlConnection(GetConnectionString()))
        {
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("PhoneNumberId", phoneNumber.PhoneNumberId);
                cmd.Parameters.AddWithValue("UserId", phoneNumber.UserId);
                cmd.Parameters.AddWithValue("Type", phoneNumber.Type);
                cmd.Parameters.AddWithValue("Number", phoneNumber.Number);
                cmd.Parameters.AddWithValue("Extension", phoneNumber.Extension);
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
