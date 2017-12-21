using cnf;
using cnfWebApi.Models;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;

namespace cnf
{
    public class DBConnection
    {

        private string _lang;
        public string Lang
        {
            get { return this._lang; }
            set { this._lang = value; }
        }

        public DBConnection(string lang)
        {
            this._lang = lang;
        }

        private string cnfDBConnection
        {
            get { return ConfigurationManager.ConnectionStrings["cnf"].ToString(); }
        }
    
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="lang"></param>
        /// <returns></returns>
        public FoodGroup GetFoodGroupById(int id, string lang = "")
        {
            var foodGroup = new FoodGroup();
            //string commandText = "SELECT A.*, C.COMPANY_NAME FROM DPD_ONLINE_OWNER.WQRY_DRUG_PRODUCT A";
            //commandText += " , DPD_ONLINE_OWNER.WQRY_COMPANIES C";
            //if (status.Length > 0 && id > 0)
            //{
            //    commandText += " , DPD_ONLINE_OWNER.WQRY_STATUS B WHERE A.DRUG_CODE = " + id;
            //    commandText += "  AND A.DRUG_CODE = B.DRUG_CODE AND A.COMPANY_CODE = C.COMPANY_CODE AND B.EXTERNAL_STATUS_CODE = " + status;
            //}
            //else
            //{
            //    commandText += " WHERE A.COMPANY_CODE = C.COMPANY_CODE AND A.DRUG_CODE = " + id; 
            //}           

           
            //using (OracleConnection con = new OracleConnection(DpdDBConnection))
            //{
            //    OracleCommand cmd = new OracleCommand(commandText, con);
            //    try
            //    {
            //        con.Open();
            //        using (OracleDataReader dr = cmd.ExecuteReader())
            //        {
            //            if (dr.HasRows)
            //            {
            //                while (dr.Read())
            //                {
            //                    var item = new DrugProduct();
            //                    item.drug_code = dr["DRUG_CODE"] == DBNull.Value ? 0 : Convert.ToInt32(dr["DRUG_CODE"]);
            //                    //item.class_name = dr["CLASS"] == DBNull.Value ? string.Empty : dr["CLASS"].ToString().Trim();
            //                    item.drug_identification_number = dr["DRUG_IDENTIFICATION_NUMBER"] == DBNull.Value ? string.Empty : dr["DRUG_IDENTIFICATION_NUMBER"].ToString().Trim();
            //                    item.company_name = dr["COMPANY_NAME"] == DBNull.Value ? string.Empty : dr["COMPANY_NAME"].ToString().Trim();
            //                    if (lang.Equals("fr"))
            //                    {
            //                        item.descriptor = dr["DESCRIPTOR_F"] == DBNull.Value ? dr["DESCRIPTOR"].ToString().Trim() : dr["DESCRIPTOR_F"].ToString().Trim();
            //                        item.brand_name = dr["BRAND_NAME_F"] == DBNull.Value ? dr["BRAND_NAME"].ToString().Trim() : dr["BRAND_NAME_F"].ToString().Trim();
            //                        item.class_name = dr["CLASS_F"] == DBNull.Value ? dr["CLASS"].ToString().Trim() : dr["CLASS_F"].ToString().Trim();
            //                    }
            //                    else
            //                    {
            //                        item.descriptor = dr["DESCRIPTOR"] == DBNull.Value ? dr["DESCRIPTOR_F"].ToString().Trim() : dr["DESCRIPTOR"].ToString().Trim();
            //                        item.brand_name = dr["BRAND_NAME"] == DBNull.Value ? dr["BRAND_NAME_F"].ToString().Trim() : dr["BRAND_NAME"].ToString().Trim();
            //                        item.class_name = dr["CLASS"] == DBNull.Value ? dr["CLASS_F"].ToString().Trim() : dr["CLASS"].ToString().Trim();
            //                    }
            //                    item.number_of_ais = dr["NUMBER_OF_AIS"] == DBNull.Value ? string.Empty : Convert.ToString(dr["NUMBER_OF_AIS"]);
            //                    item.ai_group_no = dr["AI_GROUP_NO"] == DBNull.Value ? string.Empty : dr["AI_GROUP_NO"].ToString().Trim();
            //                    //companyCode = dr["COMPANY_CODE"] == DBNull.Value ? string.Empty : dr["COMPANY_CODE"].ToString().Trim();
            //                    //Company company = new Company();
            //                    //company = GetCompanyByCompanyCode(Int32.Parse(companyCode), lang);
            //                    //if (company != null)
            //                    //{
            //                    //    item.company = company;
            //                    //}
            //                    drugProduct = item;
            //                }
            //            }
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        string errorMessages = string.Format("DbConnection.cs - GetDrugProductByDrugCode()");
            //        ExceptionHelper.LogException(ex, errorMessages);
            //        Console.WriteLine(errorMessages);
            //    }
            //    finally
            //    {
            //        if (con.State == ConnectionState.Open)
            //            con.Close();
            //    }
            //}
            return foodGroup;
        }

  
        public List<FoodGroup> GetAllFoodGroup(string lang = "", string foodname = "")
        {
            
            var orderClause = "";
            var items = new List<FoodGroup>();
            //string commandText = "SELECT DISTINCT A.*, C.COMPANY_NAME FROM DPD_ONLINE_OWNER.WQRY_DRUG_PRODUCT A";
            //commandText += " , DPD_ONLINE_OWNER.WQRY_COMPANIES C";

            //if (status.Length > 0)
            //{
            //    commandText += " , DPD_ONLINE_OWNER.WQRY_STATUS B";
            //}
            
            //commandText += " WHERE A.COMPANY_CODE = C.COMPANY_CODE";
            //if (status.Length > 0)
            //{
            //    commandText += " AND A.DRUG_CODE = B.DRUG_CODE AND B.EXTERNAL_STATUS_CODE = " + status;
            //}
            //if (din.Length > 0)
            //{
            //    commandText += " AND A.DRUG_IDENTIFICATION_NUMBER like '" + din + "'";
            //}
            
            //if (brandname.Length > 0)
            //{
            //    commandText += " AND (UPPER(A.BRAND_NAME) like '%" + brandname.Trim().ToUpper() + "%'";
            //    commandText += " OR UPPER(A.BRAND_NAME_F) like '%" + brandname.Trim().ToUpper() + "%')";
            //}
            //commandText += " ORDER BY" + orderClause + " A.DRUG_IDENTIFICATION_NUMBER";

            //using (OracleConnection con = new OracleConnection(DpdDBConnection))
            //{
            //    OracleCommand cmd = new OracleCommand(commandText, con);
            //    try
            //    {
            //        con.Open();
            //        using (OracleDataReader dr = cmd.ExecuteReader())
            //        {
            //            if (dr.HasRows)
            //            {
            //                while (dr.Read())
            //                {
            //                    var item = new DrugProduct();
            //                    item.drug_code = dr["DRUG_CODE"] == DBNull.Value ? 0 : Convert.ToInt32(dr["DRUG_CODE"]);
            //                    //item.class_name = dr["CLASS"] == DBNull.Value ? string.Empty : dr["CLASS"].ToString().Trim();
            //                    item.drug_identification_number = dr["DRUG_IDENTIFICATION_NUMBER"] == DBNull.Value ? string.Empty : dr["DRUG_IDENTIFICATION_NUMBER"].ToString().Trim();
            //                    item.company_name = dr["COMPANY_NAME"] == DBNull.Value ? string.Empty : dr["COMPANY_NAME"].ToString().Trim();
            //                    if (lang.Equals("fr"))
            //                    {
            //                        item.descriptor = dr["DESCRIPTOR_F"] == DBNull.Value ? dr["DESCRIPTOR"].ToString().Trim() : dr["DESCRIPTOR_F"].ToString().Trim();
            //                        item.brand_name = dr["BRAND_NAME_F"] == DBNull.Value ? dr["BRAND_NAME"].ToString().Trim() : dr["BRAND_NAME_F"].ToString().Trim();
            //                        item.class_name = dr["CLASS_F"] == DBNull.Value ? dr["CLASS"].ToString().Trim() : dr["CLASS_F"].ToString().Trim();
            //                    }
            //                    else
            //                    {
            //                        item.descriptor = dr["DESCRIPTOR"] == DBNull.Value ? dr["DESCRIPTOR_F"].ToString().Trim() : dr["DESCRIPTOR"].ToString().Trim();
            //                        item.brand_name = dr["BRAND_NAME"] == DBNull.Value ? dr["BRAND_NAME_F"].ToString().Trim() : dr["BRAND_NAME"].ToString().Trim();
            //                        item.class_name = dr["CLASS"] == DBNull.Value ? dr["CLASS_F"].ToString().Trim() : dr["CLASS"].ToString().Trim();
            //                    }

            //                    item.number_of_ais = dr["NUMBER_OF_AIS"] == DBNull.Value ? string.Empty : Convert.ToString(dr["NUMBER_OF_AIS"]);
            //                    item.ai_group_no = dr["AI_GROUP_NO"] == DBNull.Value ? string.Empty : dr["AI_GROUP_NO"].ToString().Trim();
            //                    //companyCode = dr["COMPANY_CODE"] == DBNull.Value ? string.Empty : dr["COMPANY_CODE"].ToString().Trim();
            //                    //Company company = new Company();
            //                    //company = GetCompanyByCompanyCode(Int32.Parse(companyCode), lang);
            //                    //if (company != null)
            //                    //{
            //                    //    item.company = company;
            //                    //}
            //                    items.Add(item);
            //                }
            //            }
            //        }
            //    }

            //    catch (Exception ex)
            //    {
            //        string errorMessages = string.Format("DbConnection.cs - GetAllDrugProduct()");
            //        ExceptionHelper.LogException(ex, errorMessages);
            //        Console.WriteLine(errorMessages);
            //    }
            //    finally
            //    {
            //        if (con.State == ConnectionState.Open)
            //            con.Close();
            //    }
            //}
            return items;
        }
    }
}
