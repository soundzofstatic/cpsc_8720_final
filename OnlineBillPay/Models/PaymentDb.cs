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
public static class PaymentDb
{
    [DataObjectMethod(DataObjectMethodType.Select)]
    public static List<Payment> GetPaymentsByPayee(string UserPayeeId)
    {
        List<Payment> PaymentList = new List<Payment>();
        string sql = "SELECT * FROM Payments WHERE UserPayeeId = @UserPayeeId";
        using (SqlConnection con = new SqlConnection(GetConnectionString()))
        {
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("UserPayeeId", UserPayeeId);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                Payment payment;
                while (dr.Read())
                {
                    payment = new Payment();
                    payment.PaymentId = dr["PaymentId"].ToString();
                    payment.UserPayeeId = dr["UserPayeeId"].ToString();
                    payment.FundingSourceId = dr["FundingSourceId"].ToString();
                    payment.UserId = dr["UserId"].ToString();
                    payment.Amount = (float)dr["Amount"];
                    payment.DateCreated = (DateTime)dr["DateCreated"];
                    payment.Currency = dr["Currency"].ToString();
                    payment.Status = dr["Status"].ToString();
                    PaymentList.Add(payment);
                }
                dr.Close();
            }
        }
        return PaymentList;
    }

    [DataObjectMethod(DataObjectMethodType.Select)]
    public static List<PaymentDetail> GetPayments(string UserId, string sort)
    {
        List<PaymentDetail> PaymentDetailList = new List<PaymentDetail>();
        string sql = "SELECT P.*, U.PayeeId, U.Nickname, U.PayeeAccountNumber " +
            "FROM Payments P " +
            "INNER JOIN UserPayees U " +
            "ON P.UserPayeeId = U.UserPayeeId " +
            "WHERE P.UserId = @UserId " + 
            "ORDER BY P.DateCreated ASC";
        using (SqlConnection con = new SqlConnection(GetConnectionString()))
        {
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("UserId", UserId);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                PaymentDetail paymentDetail;
                while (dr.Read())
                {
                    paymentDetail = new PaymentDetail();
                    paymentDetail.PaymentId = dr["PaymentId"].ToString();
                    paymentDetail.UserPayeeId = dr["UserPayeeId"].ToString();
                    paymentDetail.FundingSourceId = dr["FundingSourceId"].ToString();
                    paymentDetail.UserId = dr["UserId"].ToString();
                    //payment.Amount = (float)dr.GetFloat(4);//float.Parse(dr["Amount"].GetDouble());
                    paymentDetail.Amount = (float)Convert.ChangeType(dr["Amount"], typeof(float));
                    paymentDetail.DateCreated = (DateTime)dr["DateCreated"];
                    paymentDetail.Currency = dr["Currency"].ToString();
                    paymentDetail.Status = dr["Status"].ToString();
                    paymentDetail.PayeeId = dr["Payeeid"].ToString();
                    paymentDetail.Nickname = dr["Nickname"].ToString();
                    paymentDetail.PayeeAccountNumber = dr["PayeeAccountNumber"].ToString();
                    PaymentDetailList.Add(paymentDetail);
                }
                dr.Close();
            }
        }

        switch(sort)
        {
            case "DateCreated DESC":
                return PaymentDetailList.OrderByDescending(p => p.DateCreated).ToList();
            default:
                return PaymentDetailList;


        }
    }

    public static List<PaymentDetail> GetPaymentsLatest(string UserId)
    {
        List<PaymentDetail> PaymentDetailList = new List<PaymentDetail>();
        string sql = "SELECT TOP 5 P.*, U.PayeeId, U.Nickname, U.PayeeAccountNumber " + 
            "FROM Payments P " +
            "INNER JOIN UserPayees U " +
            "ON P.UserPayeeId = U.UserPayeeId " +
            "WHERE P.UserId = @UserId " +
            "ORDER BY P.DateCreated DESC";
        using (SqlConnection con = new SqlConnection(GetConnectionString()))
        {
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("UserId", UserId);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                PaymentDetail paymentDetail;
                while (dr.Read())
                {
                    paymentDetail = new PaymentDetail();
                    paymentDetail.PaymentId = dr["PaymentId"].ToString();
                    paymentDetail.UserPayeeId = dr["UserPayeeId"].ToString();
                    paymentDetail.FundingSourceId = dr["FundingSourceId"].ToString();
                    paymentDetail.UserId = dr["UserId"].ToString();
                    //payment.Amount = (float)dr.GetFloat(4);//float.Parse(dr["Amount"].GetDouble());
                    paymentDetail.Amount = (float)Convert.ChangeType(dr["Amount"], typeof(float));
                    paymentDetail.DateCreated = (DateTime)dr["DateCreated"];
                    paymentDetail.Currency = dr["Currency"].ToString();
                    paymentDetail.Status = dr["Status"].ToString();
                    paymentDetail.PayeeId = dr["Payeeid"].ToString();
                    paymentDetail.Nickname = dr["Nickname"].ToString();
                    paymentDetail.PayeeAccountNumber = dr["PayeeAccountNumber"].ToString();
                    PaymentDetailList.Add(paymentDetail);
                }
                dr.Close();
            }
        }

        return PaymentDetailList;
    }

    /*
    [DataObjectMethod(DataObjectMethodType.Update)]
    public static int UpdatePayment(Payment original_payment,
        Payment payment)
    {
        int updateCount = 0;
        string sql = "UPDATE Payments SET "
            + "Nickname = @Nickname, "
            + "PayeeAccountNumber = @PayeeAccountNumber "
            + "WHERE PaymentId = @original_PaymentId ";
        using (SqlConnection con = new SqlConnection(GetConnectionString()))
        {
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("Nickname", payment.Nickname);
                cmd.Parameters.AddWithValue("PayeeAccountNumber", payment.PayeeAccountNumber);
                cmd.Parameters.AddWithValue("original_PaymentId", original_payment.PaymentId);
                con.Open();
                updateCount = cmd.ExecuteNonQuery();
            }
        }
        return updateCount;
    }*/

    /*
    [DataObjectMethod(DataObjectMethodType.Delete)]
    public static int DeletePayment(Payment payment)
    {
        int deleteCount = 0;
        string sql = "DELETE FROM Payments "
            + "WHERE PaymentId = @PaymentId";
        using (SqlConnection con = new SqlConnection(GetConnectionString()))
        {
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("PaymentId", payment.PaymentId);
                con.Open();
                deleteCount = cmd.ExecuteNonQuery();
            }
        }
        return deleteCount;
    }*/

    [DataObjectMethod(DataObjectMethodType.Insert)]
    public static void InsertPayment(Payment payment)
    {
        string sql = "INSERT INTO Payments "
            + "(PaymentId, UserPayeeId, FundingSourceId, UserId, Amount, DateCreated, Currency, Status) "
            + "VALUES (@PaymentId, @UserPayeeId, @FundingSourceId, @UserId, @Amount, @DateCreated, @Currency, @Status)";
        using (SqlConnection con = new SqlConnection(GetConnectionString()))
        {
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("PaymentId", payment.PaymentId);
                cmd.Parameters.AddWithValue("UserPayeeId", payment.UserPayeeId);
                cmd.Parameters.AddWithValue("FundingSourceId", payment.FundingSourceId);
                cmd.Parameters.AddWithValue("UserId", payment.UserId);
                cmd.Parameters.AddWithValue("Amount", payment.Amount);
                cmd.Parameters.AddWithValue("DateCreated", payment.DateCreated);
                cmd.Parameters.AddWithValue("Currency", payment.Currency);
                cmd.Parameters.AddWithValue("Status", payment.Status);
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
