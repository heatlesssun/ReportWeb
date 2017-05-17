using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using System.Data;
using System.Data.SqlClient;

namespace ReportWeb.ReportViewer
{
    public partial class ReportViewer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Page_Init(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                // Set the processing mode for the ReportViewer to Local  
                /*
                reportViewer.ProcessingMode = ProcessingMode.Local;
                LocalReport localReport = reportViewer.LocalReport;
                localReport.ReportPath = "Reports/Sales_Order_Detail_2008R2.rdlc";
                DataSet dataset = new DataSet("Sales Order Detail");
                string salesOrderNumber = "SO43661";
                GetSalesOrderData1(salesOrderNumber, ref dataset);

                ReportDataSource dsSalesOrder = new ReportDataSource();
                dsSalesOrder.Name = "SalesOrders";
                dsSalesOrder.Value = dataset.Tables["SalesOrder"];
                localReport.DataSources.Add(dsSalesOrder);
                */

                reportViewer.ProcessingMode = ProcessingMode.Remote; //ProcessingMode.Local;
                reportViewer.ShowParameterPrompts = false;
                //LocalReport localReport = reportViewer.LocalReport;
                //localReport.ReportPath = "Reports/Person02.rdlc";
                ServerReport serverReport = reportViewer.ServerReport;
                // Set the report server URL and report path  
                serverReport.ReportServerUrl = new Uri("http://localhost/reportserver");
                serverReport.ReportPath = "/ReportProject01/Person02";

                //DataSet dataset = new DataSet("DataSet");
                //string salesOrderNumber = "SO43661";

                List<Microsoft.Reporting.WebForms.ReportParameter> reportParameters = new List<Microsoft.Reporting.WebForms.ReportParameter>();
                https://msdn.microsoft.com/en-us/library/6sh2ey19(v=vs.110).aspx?cs-save-lang=1&cs-lang=csharp#code-snippet-3

                reportParameters.Add(new Microsoft.Reporting.WebForms.ReportParameter("LastName", "s"));
                reportParameters.Add(new Microsoft.Reporting.WebForms.ReportParameter("FirstName", "c"));

                //Microsoft.Reporting.WebForms.ReportParameter[] reportParameters = null;
                //reportParameters = new Microsoft.Reporting.WebForms.ReportParameter[2];
                //reportParameters[0] = new Microsoft.Reporting.WebForms.ReportParameter("LastName", "s");
                //reportParameters[1] = new Microsoft.Reporting.WebForms.ReportParameter("FirstName", "c");
                try
                {
                    serverReport.SetParameters(reportParameters);
                }
                catch (Microsoft.Reporting.WebForms.ReportServerException ex)
                {
                    Response.Redirect("~/Error.aspx");
                }


                /*
                GetPersonData(ref dataset);

                ReportDataSource dsData = new ReportDataSource();
                dsData.Name = "DataSet";
                dsData.Value = dataset.Tables["DataSet"];
                localReport.DataSources.Add(dsData);
                //localReport.SetParameters(new ReportParameter("LastName", " "));
                //localReport.SetParameters(new ReportParameter("FirstName", "s"));
                */


                //DataSet dataset = new DataSet("Sales Order Detail");
                //string salesOrderNumber = "SO43661";
                //GetSalesOrderData(salesOrderNumber, ref dataset);
                //ReportDataSource dsSalesOrder = new ReportDataSource();
                //dsSalesOrder.Name = "SalesOrder";
                //dsSalesOrder.Value = dataset.Tables["SalesOrder"];
                //localReport.DataSources.Add(dsSalesOrder);
                //GetSalesOrderDetailData(salesOrderNumber, ref dataset);
                //ReportDataSource dsSalesOrderDetail = new ReportDataSource();
                //dsSalesOrderDetail.Name = "SalesOrderDetail";
                //dsSalesOrderDetail.Value = dataset.Tables["SalesOrderDetail"];
                //localReport.DataSources.Add(dsSalesOrderDetail);
                // Create the sales order number report parameter 

                //                ReportParameter rpSalesOrderNumber = new ReportParameter();
                //                rpSalesOrderNumber.Name = "SalesOrderNumber";
                //                rpSalesOrderNumber.Values.Add("SO43661");
                //                // Set the report parameters for the report  
                //                localReport.SetParameters(
                //new ReportParameter[] { rpSalesOrderNumber });
            }
        }

        private void GetSalesOrderData1(string salesOrderNumber,
                                   ref DataSet dsSalesOrder)
        {
            string sqlSalesOrder = "uspGetSalesOrder";
            SqlConnection connection = new
                    SqlConnection("Data Source=(local); " +
                                  "Initial Catalog=AdventureWorks2012; " +
                                  "Integrated Security=SSPI");
            SqlCommand command =
                    new SqlCommand(sqlSalesOrder, connection);
            command.CommandType = CommandType.StoredProcedure;

            
            command.Parameters.Add(
                    new SqlParameter("@SalesOrderIDStart",
                    43659));

            command.Parameters.Add(
                    new SqlParameter("@SalesOrderIDEnd",
                    43677));

            SqlDataAdapter salesOrderAdapter = new
                    SqlDataAdapter(command);
            salesOrderAdapter.Fill(dsSalesOrder, "SalesOrder");
        }


        private void GetPersonData(ref DataSet dsData)
        {
            string sqlString = "uspGetPerson";
            SqlConnection connection = new
                    SqlConnection("Data Source=(local); " +
                                  "Initial Catalog=AdventureWorks2012; " +
                                  "Integrated Security=SSPI");
            SqlCommand command =
                    new SqlCommand(sqlString, connection);
            command.CommandType = CommandType.StoredProcedure;


            command.Parameters.Add(
                    new SqlParameter("@FirstName",
                    ""));

            command.Parameters.Add(
                    new SqlParameter("@LastName",
                    "s"));

            SqlDataAdapter dataAdapter = new
                    SqlDataAdapter(command);
            dataAdapter.Fill(dsData, "DataSet");
        }


        private void GetSalesOrderData(string salesOrderNumber,
                                   ref DataSet dsSalesOrder)
        {
            string sqlSalesOrder =
                "SELECT SOH.SalesOrderNumber, S.Name AS Store,        SOH.OrderDate, C.FirstName AS SalesFirstName,        C.LastName AS SalesLastName, E.JobTitle AS        SalesTitle, SOH.PurchaseOrderNumber,        SM.Name AS ShipMethod, BA.AddressLine1        AS BillAddress1, BA.AddressLine2 AS        BillAddress2, BA.City AS BillCity,        BA.PostalCode AS BillPostalCode, BSP.Name        AS BillStateProvince, BCR.Name AS        BillCountryRegion, SA.AddressLine1 AS        ShipAddress1, SA.AddressLine2 AS        ShipAddress2, SA.City AS ShipCity,        SA.PostalCode AS ShipPostalCode, SSP.Name        AS ShipStateProvince, SCR.Name AS        ShipCountryRegion, CC.MiddleName AS CustPhone,        CC.FirstName AS CustFirstName, CC.LastName        AS CustLastName FROM   Person.Address SA INNER JOIN        Person.StateProvince SSP ON        SA.StateProvinceID = SSP.StateProvinceID        INNER JOIN Person.CountryRegion SCR ON        SSP.CountryRegionCode = SCR.CountryRegionCode        RIGHT OUTER JOIN Sales.SalesOrderHeader SOH " +
                "LEFT OUTER JOIN Person.Person CC ON SOH.SalesOrderID = CC.BusinessEntityID LEFT OUTER JOIN Person.Address BA INNER JOIN        Person.StateProvince BSP ON BA.StateProvinceID = BSP.StateProvinceID        INNER JOIN Person.CountryRegion BCR ON BSP.CountryRegionCode = BCR.CountryRegionCode ON SOH.BillToAddressID = BA.AddressID ON SA.AddressID = SOH.ShipToAddressID LEFT OUTER JOIN Person.Person C RIGHT OUTER JOIN HumanResources.Employee E ON C.BusinessEntityID = E.BusinessEntityID ON SOH.CustomerID = E.BusinessEntityID LEFT OUTER JOIN Purchasing.ShipMethod SM ON SOH.ShipMethodID = SM.ShipMethodID LEFT OUTER JOIN Sales.Store S ON SOH.CustomerID = S.BusinessEntityID " +
                "WHERE  (SOH.SalesOrderNumber = @SalesOrderNumber)";
            SqlConnection connection = new
                    SqlConnection("Data Source=(local); " +
                                  "Initial Catalog=AdventureWorks2012; " +
                                  "Integrated Security=SSPI");
            SqlCommand command =
                    new SqlCommand(sqlSalesOrder, connection);
            command.Parameters.Add(
                    new SqlParameter("SalesOrderNumber",
                    salesOrderNumber));
            SqlDataAdapter salesOrderAdapter = new
                    SqlDataAdapter(command);
            salesOrderAdapter.Fill(dsSalesOrder, "SalesOrder");
        }
        private void GetSalesOrderDetailData(string salesOrderNumber,
                               ref DataSet dsSalesOrder)
        {
            string sqlSalesOrderDetail =
                "SELECT  SOD.SalesOrderDetailID, SOD.OrderQty, " +
                "        SOD.UnitPrice, CASE WHEN " +
                "        SOD.UnitPriceDiscount IS NULL THEN 0 " +
                "        ELSE SOD.UnitPriceDiscount END AS " +
                "        UnitPriceDiscount, SOD.LineTotal, " +
                "        SOD.CarrierTrackingNumber, " +
                "        SOD.SalesOrderID, P.Name, P.ProductNumber " +
                "FROM    Sales.SalesOrderDetail SOD INNER JOIN " +
                "        Production.Product P ON SOD.ProductID = " +
                "        P.ProductID INNER JOIN " +
                "        Sales.SalesOrderHeader SOH ON " +
                "        SOD.SalesOrderID = SOH.SalesOrderID " +
                "WHERE   (SOH.SalesOrderNumber = @SalesOrderNumber) " +
                "ORDER BY SOD.SalesOrderDetailID";
            using (SqlConnection connection = new
                    SqlConnection("Data Source=(local); " +
                                  "Initial Catalog=AdventureWorks2012; " +
                                  "Integrated Security=SSPI"))
            {
                SqlCommand command =
                            new SqlCommand(sqlSalesOrderDetail, connection);
                command.Parameters.Add(
                            new SqlParameter("SalesOrderNumber",
                            salesOrderNumber));
                SqlDataAdapter salesOrderDetailAdapter = new
                            SqlDataAdapter(command);
                salesOrderDetailAdapter.Fill(dsSalesOrder,
                            "SalesOrderDetail");
            }
        }

    }
}
 