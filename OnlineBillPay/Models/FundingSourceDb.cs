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
public static class FundingSourceDb
{
    [DataObjectMethod(DataObjectMethodType.Select)]
    public static List<FundingSource> GetFundingSources(string UserId)
    {
        List<FundingSource> FundingSourceList = new List<FundingSource>();
        string sql = "SELECT * FROM FundingSources WHERE UserId = @UserId";
        using (SqlConnection con = new SqlConnection(GetConnectionString()))
        {
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {

                cmd.Parameters.AddWithValue("UserId", UserId);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                FundingSource fundingSource;
                while (dr.Read())
                {
                    fundingSource = new FundingSource();
                    fundingSource.FundingSourceId = dr["FundingSourceId"].ToString();
                    fundingSource.UserId = dr["UserId"].ToString();
                    fundingSource.Type = dr["Type"].ToString();
                    fundingSource.Nickname = dr["Nickname"].ToString();
                    fundingSource.AccountNumber = dr["AccountNumber"].ToString();
                    FundingSourceList.Add(fundingSource);
                }
                dr.Close();
            }
        }
        return FundingSourceList;
    }


    [DataObjectMethod(DataObjectMethodType.Update)]
    public static int UpdateFundingSource(FundingSource original_fundingSource,
        FundingSource fundingSource)
    {
        int updateCount = 0;
        string sql = "UPDATE FundingSources SET "
            + "Type = @Type, "
            + "Nickname = @Nickname, "
            + "AccountNumber = @AccountNumber "
            + "WHERE FundingSourceId = @original_FundingSourceId ";
        using (SqlConnection con = new SqlConnection(GetConnectionString()))
        {
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("Type", fundingSource.Type);
                cmd.Parameters.AddWithValue("Nickname", fundingSource.Nickname);
                cmd.Parameters.AddWithValue("AccountNumber", fundingSource.AccountNumber);
                cmd.Parameters.AddWithValue("original_FundingSourceId", original_fundingSource.FundingSourceId);
                con.Open();
                updateCount = cmd.ExecuteNonQuery();
            }
        }
        return updateCount;
    }

    [DataObjectMethod(DataObjectMethodType.Delete)]
    public static int DeleteFundingSource(FundingSource fundingSource)
    {
        int deleteCount = 0;
        string sql = "DELETE FROM FundingSources "
            + "WHERE FundingSourceId = @FundingSourceId";
        using (SqlConnection con = new SqlConnection(GetConnectionString()))
        {
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("FundingSourceId", fundingSource.FundingSourceId);
                con.Open();
                deleteCount = cmd.ExecuteNonQuery();
            }
        }
        return deleteCount;
    }

    [DataObjectMethod(DataObjectMethodType.Insert)]
    public static void InsertFundingSource(FundingSource fundingSource)
    {
        string sql = "INSERT INTO FundingSources "
            + "(FundingSourceId, UserId, AccountNumber, Nickname, Type) "
            + "VALUES (@FundingSourceId, @UserId, @AccountNumber, @Nickname, @Type)";
        using (SqlConnection con = new SqlConnection(GetConnectionString()))
        {
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("FundingSourceId", fundingSource.FundingSourceId);
                cmd.Parameters.AddWithValue("UserId", fundingSource.UserId);
                cmd.Parameters.AddWithValue("Type", fundingSource.Type);
                cmd.Parameters.AddWithValue("Nickname", fundingSource.Nickname);
                cmd.Parameters.AddWithValue("AccountNumber", fundingSource.AccountNumber);
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
