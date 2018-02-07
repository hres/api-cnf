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
        /// 

        //BEGIN OF Food
        public List<Food> GetFoodById(int id, string lang = "")
        {
            var items = new List<Food>();
            string commandText = "SELECT * FROM CNFWEBADM.WEB_FOOD_SEARCH WHERE FOOD_C =" + id;
            using (OracleConnection con = new OracleConnection(cnfDBConnection))
            {
                OracleCommand cmd = new OracleCommand(commandText, con);
                try
                {
                    con.Open();
                    using (OracleDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                var item = new Food();

                                item.food_c = dr["FOOD_C"] == DBNull.Value ? 0 : Convert.ToInt32(dr["FOOD_C"]);
                               
                                if (lang.Equals("fr"))
                                {
                                    item.food_desc = dr["FOOD_DESC_F"] == DBNull.Value ? dr["FOOD_DESC"].ToString().Trim() : dr["FOOD_DESC_F"].ToString().Trim();
                                }
                                else
                                {
                                    item.food_desc = dr["FOOD_DESC"] == DBNull.Value ? string.Empty : dr["FOOD_DESC"].ToString().Trim();
                                }                            

                                items.Add(item);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    string errorMessages = string.Format("DbConnection.cs - GetFoodById()");
                    ExceptionHelper.LogException(ex, errorMessages);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                        con.Close();
                }
            }
            return items;
        }

        public List<Food> GetAllFood(string lang = "", string refusename = "")
        {
            var items = new List<Food>();

            string commandText = "SELECT FOOD_C, FOOD_DESC, FOOD_DESC_F FROM CNFWEBADM.WEB_FOOD_SEARCH";
            using (OracleConnection con = new OracleConnection(cnfDBConnection))
            {
                OracleCommand cmd = new OracleCommand(commandText, con);
                try
                {
                    con.Open();
                    using (OracleDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                var item = new Food();

                                item.food_c = dr["FOOD_C"] == DBNull.Value ? 0 : Convert.ToInt32(dr["FOOD_C"]);
                                if (lang.Equals("fr"))
                                {
                                    item.food_desc = dr["FOOD_DESC_F"] == DBNull.Value ? dr["FOOD_DESC"].ToString().Trim() : dr["FOOD_DESC_F"].ToString().Trim();
                                }
                                else
                                {
                                    item.food_desc = dr["FOOD_DESC"] == DBNull.Value ? string.Empty : dr["FOOD_DESC"].ToString().Trim();
                                }

                                items.Add(item);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    string errorMessages = string.Format("DbConnection.cs - GetAllFood()");
                    ExceptionHelper.LogException(ex, errorMessages);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                        con.Close();
                }
            }
            return items;
        }
        //END OF Food
        //BEGIN OF NutrientAmount
        public List<NutrientAmount> GetNutrientAmountById(int id, string lang = "")
        {
            var items = new List<NutrientAmount>();
            string commandText = "SELECT FOOD_C, NUTR_VALUE, STD_ERROR, NUM_OBSER, NUTR_C, NUTR_WEB_NAME_E, NUTR_WEB_NAME_F, UNIT, NUTR_DECIMAL_PLACE, NUTR_WEB_ORDER, SOURCE_C, NRD_REF, SOURCE_DESC, SOURCE_DESC_F FROM CNFWEBADM.WEB_NUTRIENT_LIST WHERE FOOD_C =" + id;
            using (OracleConnection con = new OracleConnection(cnfDBConnection))
            {
                OracleCommand cmd = new OracleCommand(commandText, con);
                try
                {
                    con.Open();
                    using (OracleDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                var item = new NutrientAmount();

                                item.food_c = dr["FOOD_C"] == DBNull.Value ? 0 : Convert.ToInt32(dr["FOOD_C"]);
                                item.nutr_value = dr["NUTR_VALUE"] == DBNull.Value ? 0 : Convert.ToDouble(dr["NUTR_VALUE"]);
                                item.std_error = dr["STD_ERROR"] == DBNull.Value ? 0 : Convert.ToInt32(dr["STD_ERROR"]);
                                item.num_obser = dr["NUM_OBSER"] == DBNull.Value ? 0 : Convert.ToInt32(dr["NUM_OBSER"]);
                                item.nutr_c = dr["NUTR_C"] == DBNull.Value ? 0 : Convert.ToInt32(dr["NUTR_C"]);
                                item.unit = dr["UNIT"] == DBNull.Value ? string.Empty : dr["UNIT"].ToString().Trim();
                                item.nutr_decimal_place = dr["NUTR_DECIMAL_PLACE"] == DBNull.Value ? 0 : Convert.ToInt32(dr["NUTR_DECIMAL_PLACE"]);
                                item.nutr_web_order = dr["NUTR_WEB_ORDER"] == DBNull.Value ? 0 : Convert.ToInt32(dr["NUTR_WEB_ORDER"]);
                                item.source_c = dr["SOURCE_C"] == DBNull.Value ? 0 : Convert.ToInt32(dr["SOURCE_C"]);
                                item.nrd_ref = dr["NRD_REF"] == DBNull.Value ? 0 : Convert.ToInt32(dr["NRD_REF"]);
                                
                                if (lang.Equals("fr"))
                                {
                                    item.nutr_web_name = dr["NUTR_WEB_NAME_F"] == DBNull.Value ? dr["NUTR_WEB_NAME_E"].ToString().Trim() : dr["NUTR_WEB_NAME_F"].ToString().Trim();
                                    item.source_desc   = dr["SOURCE_DESC_F"]   == DBNull.Value ? dr["SOURCE_DESC"].ToString().Trim() : dr["SOURCE_DESC_F"].ToString().Trim();

                                }
                                else
                                {
                                    item.nutr_web_name = dr["NUTR_WEB_NAME_E"] == DBNull.Value ? string.Empty : dr["NUTR_WEB_NAME_E"].ToString().Trim();
                                    item.source_desc   = dr["SOURCE_DESC"]     == DBNull.Value ? string.Empty : dr["SOURCE_DESC"].ToString().Trim();
                                }

                                items.Add(item);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    string errorMessages = string.Format("DbConnection.cs - GetNutrientAmountById()");
                    ExceptionHelper.LogException(ex, errorMessages);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                        con.Close();
                }
            }
            return items;
        }

        public List<NutrientAmount> GetAllNutrientAmount(string lang = "", string nutrientamount = "")
        {
            var items = new List<NutrientAmount>();

            //NOTE: The SQL statement below is currently hardcoded at the end with "FROM CNFWEBADM.WEB_NUTRIENT_LIST WHERE FOOD_C =20" for test purposes.
            //      The results returned are large and cause "OutOfMemoryException: Exception of type 'System.OutOfMemoryException' to be thrown."
            //string commandText = "SELECT FOOD_C, NUTR_VALUE, STD_ERROR, NUM_OBSER, NUTR_C, NUTR_WEB_NAME_E, NUTR_WEB_NAME_F, UNIT, NUTR_DECIMAL_PLACE, NUTR_WEB_ORDER, SOURCE_C, NRD_REF, SOURCE_DESC, SOURCE_DESC_F FROM CNFWEBADM.WEB_NUTRIENT_LIST WHERE FOOD_C =20";
            string commandText = "SELECT FOOD_C, NUTR_VALUE, STD_ERROR, NUM_OBSER, NUTR_C, NUTR_WEB_NAME_E, NUTR_WEB_NAME_F, UNIT, NUTR_DECIMAL_PLACE, NUTR_WEB_ORDER, SOURCE_C, NRD_REF, SOURCE_DESC, SOURCE_DESC_F FROM CNFWEBADM.WEB_NUTRIENT_LIST";
            using (OracleConnection con = new OracleConnection(cnfDBConnection))
            {
                OracleCommand cmd = new OracleCommand(commandText, con);
                try
                {
                    con.Open();
                    using (OracleDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                var item = new NutrientAmount();

                                item.food_c     = dr["FOOD_C"] == DBNull.Value ? 0 : Convert.ToInt32(dr["FOOD_C"]);
                                item.nutr_value = dr["NUTR_VALUE"] == DBNull.Value ? 0 : Convert.ToDouble(dr["NUTR_VALUE"]);
                                item.std_error  = dr["STD_ERROR"] == DBNull.Value ? 0 : Convert.ToInt32(dr["STD_ERROR"]);
                                item.num_obser  = dr["NUM_OBSER"] == DBNull.Value ? 0 : Convert.ToInt32(dr["NUM_OBSER"]);
                                item.nutr_c     = dr["NUTR_C"] == DBNull.Value ? 0 : Convert.ToInt32(dr["NUTR_C"]);
                                item.unit               = dr["UNIT"] == DBNull.Value ? string.Empty : dr["UNIT"].ToString().Trim();
                                item.nutr_decimal_place = dr["NUTR_DECIMAL_PLACE"] == DBNull.Value ? 0 : Convert.ToInt32(dr["NUTR_DECIMAL_PLACE"]);
                                item.nutr_web_order     = dr["NUTR_WEB_ORDER"] == DBNull.Value ? 0 : Convert.ToInt32(dr["NUTR_WEB_ORDER"]);
                                item.source_c           = dr["SOURCE_C"] == DBNull.Value ? 0 : Convert.ToInt32(dr["SOURCE_C"]);
                                item.nrd_ref            = dr["NRD_REF"] == DBNull.Value ? 0 : Convert.ToInt32(dr["NRD_REF"]);

                                if (lang.Equals("fr"))
                                {
                                    item.nutr_web_name = dr["NUTR_WEB_NAME_F"] == DBNull.Value ? dr["NUTR_WEB_NAME_E"].ToString().Trim() : dr["NUTR_WEB_NAME_F"].ToString().Trim();
                                    item.source_desc = dr["SOURCE_DESC_F"] == DBNull.Value ? dr["SOURCE_DESC"].ToString().Trim() : dr["SOURCE_DESC_F"].ToString().Trim();

                                }
                                else
                                {
                                    item.nutr_web_name = dr["NUTR_WEB_NAME_E"] == DBNull.Value ? string.Empty : dr["NUTR_WEB_NAME_E"].ToString().Trim();
                                    item.source_desc = dr["SOURCE_DESC"] == DBNull.Value ? string.Empty : dr["SOURCE_DESC"].ToString().Trim();
                                }

                                items.Add(item);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    string errorMessages = string.Format("DbConnection.cs - GetAllNutrientAmount()");
                    ExceptionHelper.LogException(ex, errorMessages);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                        con.Close();
                }
            }
            return items;
        }
        //END OF NutrientAmount
        //BEGIN OF NutrientGroup
        public List<NutrientGroup> GetNutrientGroupById(int id, string lang = "")
        {
            var items = new List<NutrientGroup>();
            string commandText = "SELECT * FROM CNFWEBADM.NUTRIENT_GROUP WHERE NUTRIENT_GROUP_ID =" + id;
            using (OracleConnection con = new OracleConnection(cnfDBConnection))
            {
                OracleCommand cmd = new OracleCommand(commandText, con);
                try
                {
                    con.Open();
                    using (OracleDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                var item = new NutrientGroup();

                                item.nutrient_group_id     = dr["NUTRIENT_GROUP_ID"]     == DBNull.Value ? 0 : Convert.ToInt32(dr["NUTRIENT_GROUP_ID"]);
                                item.nutrient_group_order  = dr["NUTRIENT_GROUP_ORDER"]  == DBNull.Value ? 0 : Convert.ToInt32(dr["NUTRIENT_GROUP_ORDER"]);

                                if (lang.Equals("fr"))
                                {
                                    item.nutrient_group_name = dr["NUTRIENT_GROUP_NAME_F"] == DBNull.Value ? dr["NUTRIENT_GROUP_NAME_E"].ToString().Trim() : dr["NUTRIENT_GROUP_NAME_F"].ToString().Trim();
                                }
                                else
                                {
                                    item.nutrient_group_name = dr["NUTRIENT_GROUP_NAME_E"] == DBNull.Value ? string.Empty : dr["NUTRIENT_GROUP_NAME_E"].ToString().Trim();
                                }

                                items.Add(item);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    string errorMessages = string.Format("DbConnection.cs - GetNutrientGroupById()");
                    ExceptionHelper.LogException(ex, errorMessages);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                        con.Close();
                }
            }
            return items;
        }

        public List<NutrientGroup> GetAllNutrientGroup(string lang = "", string nutrientgroup = "")
        {
            var items = new List<NutrientGroup>();

            string commandText = "SELECT NUTRIENT_GROUP_ID, NUTRIENT_GROUP_NAME_E, NUTRIENT_GROUP_NAME_F, NUTRIENT_GROUP_ORDER FROM CNFWEBADM.NUTRIENT_GROUP";

            using (OracleConnection con = new OracleConnection(cnfDBConnection))
            {
                OracleCommand cmd = new OracleCommand(commandText, con);
                try
                {
                    con.Open();
                    using (OracleDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                var item = new NutrientGroup();

                                item.nutrient_group_id = dr["NUTRIENT_GROUP_ID"] == DBNull.Value ? 0 : Convert.ToInt32(dr["NUTRIENT_GROUP_ID"]);
                                item.nutrient_group_order = dr["NUTRIENT_GROUP_ORDER"] == DBNull.Value ? 0 : Convert.ToInt32(dr["NUTRIENT_GROUP_ORDER"]);

                                if (lang.Equals("fr"))
                                {
                                    item.nutrient_group_name = dr["NUTRIENT_GROUP_NAME_F"] == DBNull.Value ? dr["NUTRIENT_GROUP_NAME_E"].ToString().Trim() : dr["NUTRIENT_GROUP_NAME_F"].ToString().Trim();
                                }
                                else
                                {
                                    item.nutrient_group_name = dr["NUTRIENT_GROUP_NAME_E"] == DBNull.Value ? string.Empty : dr["NUTRIENT_GROUP_NAME_E"].ToString().Trim();
                                }
                                items.Add(item);

                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    string errorMessages = string.Format("DbConnection.cs - GetAllNutrientGroup()");
                    ExceptionHelper.LogException(ex, errorMessages);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                        con.Close();
                }
            }
            return items;
        }
        //END OF NutrientGroup
        //BEGIN OF NutrientName
        public NutrientName GetNutrientNameById(int id, string lang = "")
        {
            var nutrientname = new NutrientName();

            string commandText = "SELECT NUTR_C, NUTR_SYMBOL, UNIT, NUTR_NAME, NUTR_NAME_F, TAGNAME, NUTR_DECIMAL_PLACE, NUTR_WEB_ORDER, NUTR_WEB_NAME_E, NUTR_WEB_NAME_F, NUTRIENT_GROUP_ID  FROM CNFWEBADM.NUTR_NAME WHERE NUTR_C =" + id;

            using (OracleConnection con = new OracleConnection(cnfDBConnection))
            {
                OracleCommand cmd = new OracleCommand(commandText, con);
                try
                {
                    con.Open();
                    using (OracleDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                nutrientname.nutr_c = dr["NUTR_C"] == DBNull.Value ? 0 : Convert.ToInt32(dr["NUTR_C"]);
                                nutrientname.nutr_symbol = dr["NUTR_SYMBOL"] == DBNull.Value ? string.Empty : dr["NUTR_SYMBOL"].ToString().Trim();
                                nutrientname.unit = dr["UNIT"] == DBNull.Value ? string.Empty : dr["UNIT"].ToString().Trim();
                                nutrientname.tagname = dr["TAGNAME"] == DBNull.Value ? string.Empty : dr["TAGNAME"].ToString().Trim();
                                nutrientname.nutr_decimal_place = dr["NUTR_DECIMAL_PLACE"] == DBNull.Value ? 0 : Convert.ToInt32(dr["NUTR_DECIMAL_PLACE"]);
                                nutrientname.nutr_web_order = dr["NUTR_WEB_ORDER"] == DBNull.Value ? 0 : Convert.ToInt32(dr["NUTR_WEB_ORDER"]);
                                nutrientname.nutrient_group_id = dr["NUTRIENT_GROUP_ID"] == DBNull.Value ? 0 : Convert.ToInt32(dr["NUTRIENT_GROUP_ID"]);

                                if (lang.Equals("fr"))
                                {
                                    nutrientname.nutr_name    = dr["NUTR_NAME_F"] == DBNull.Value ? dr["NUTR_NAME"].ToString().Trim() : dr["NUTR_NAME_F"].ToString().Trim();
                                    nutrientname.nutr_web_name = dr["NUTR_WEB_NAME_F"] == DBNull.Value ? dr["NUTR_WEB_NAME_E"].ToString().Trim() : dr["NUTR_WEB_NAME_F"].ToString().Trim();
                                }
                                else
                                {
                                    nutrientname.nutr_name     = dr["NUTR_NAME"] == DBNull.Value ? string.Empty : dr["NUTR_NAME"].ToString().Trim();
                                    nutrientname.nutr_web_name = dr["NUTR_WEB_NAME_E"] == DBNull.Value ? string.Empty : dr["NUTR_WEB_NAME_E"].ToString().Trim();                                  
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    string errorMessages = string.Format("DbConnection.cs - GetNutrientNameById()");
                    ExceptionHelper.LogException(ex, errorMessages);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                        con.Close();

                }
            }
            return nutrientname;
        }

        public List<NutrientName> GetAllNutrientName(string lang = "", string nutrientname = "")
        {
            var items = new List<NutrientName>();

            string commandText = "SELECT NUTR_C, NUTR_SYMBOL, UNIT, NUTR_NAME, NUTR_NAME_F, TAGNAME, NUTR_DECIMAL_PLACE, NUTR_WEB_ORDER, NUTR_WEB_NAME_E, NUTR_WEB_NAME_F, NUTRIENT_GROUP_ID  FROM CNFWEBADM.NUTR_NAME";

            using (OracleConnection con = new OracleConnection(cnfDBConnection))
            {
                OracleCommand cmd = new OracleCommand(commandText, con);
                try
                {
                    con.Open();
                    using (OracleDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                var item = new NutrientName();

                                item.nutr_c = dr["NUTR_C"] == DBNull.Value ? 0 : Convert.ToInt32(dr["NUTR_C"]);
                                item.nutr_symbol = dr["NUTR_SYMBOL"] == DBNull.Value ? string.Empty : dr["NUTR_SYMBOL"].ToString().Trim();
                                item.unit = dr["UNIT"] == DBNull.Value ? string.Empty : dr["UNIT"].ToString().Trim();
                                item.tagname = dr["TAGNAME"] == DBNull.Value ? string.Empty : dr["TAGNAME"].ToString().Trim();
                                item.nutr_decimal_place = dr["NUTR_DECIMAL_PLACE"] == DBNull.Value ? 0 : Convert.ToInt32(dr["NUTR_DECIMAL_PLACE"]);
                                item.nutr_web_order = dr["NUTR_WEB_ORDER"] == DBNull.Value ? 0 : Convert.ToInt32(dr["NUTR_WEB_ORDER"]);
                                item.nutrient_group_id = dr["NUTRIENT_GROUP_ID"] == DBNull.Value ? 0 : Convert.ToInt32(dr["NUTRIENT_GROUP_ID"]);

                                if (lang.Equals("fr"))
                                {
                                    item.nutr_name     = dr["NUTR_NAME_F"]    == DBNull.Value ? dr["NUTR_NAME"].ToString().Trim() : dr["NUTR_NAME_F"].ToString().Trim();
                                    item.nutr_web_name = dr["NUTR_WEB_NAME_F"] == DBNull.Value ? dr["NUTR_WEB_NAME_E"].ToString().Trim() : dr["NUTR_WEB_NAME_F"].ToString().Trim();
                                }
                                else
                                {
                                    item.nutr_name    = dr["NUTR_NAME"]       == DBNull.Value ? string.Empty : dr["NUTR_NAME"].ToString().Trim();
                                    item.nutr_web_name = dr["NUTR_WEB_NAME_E"] == DBNull.Value ? string.Empty : dr["NUTR_WEB_NAME_E"].ToString().Trim();
                                }

                                items.Add(item);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    string errorMessages = string.Format("DbConnection.cs - GetAllNutrientName()");
                    ExceptionHelper.LogException(ex, errorMessages);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                        con.Close();
                }
            }
            return items;
        }
        //END OF NutrientName
        //BEGIN OF NutrientSource
        public NutrientSource GetNutrientSourceById(int id, string lang = "")
        {
            var nutrientsource = new NutrientSource();

            string commandText = "SELECT * FROM CNFWEBADM.NUTR_SOURCE WHERE NUTR_SOURCE_C =" + id;

            using (OracleConnection con = new OracleConnection(cnfDBConnection))
            {
                OracleCommand cmd = new OracleCommand(commandText, con);
                try
                {
                    con.Open();
                    using (OracleDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                nutrientsource.nutr_source_c = dr["NUTR_SOURCE_C"] == DBNull.Value ? 0 : Convert.ToInt32(dr["NUTR_SOURCE_C"]);                          
                                nutrientsource.nrd_ref       = dr["NRD_REF"]       == DBNull.Value ? 0 : Convert.ToInt32(dr["NRD_REF"]);

                                if (lang.Equals("fr"))
                                {
                                    nutrientsource.source_desc = dr["SOURCE_DESC_F"] == DBNull.Value ? dr["SOURCE_DESC"].ToString().Trim() : dr["SOURCE_DESC_F"].ToString().Trim();
                                }
                                else
                                {
                                    nutrientsource.source_desc = dr["SOURCE_DESC"]   == DBNull.Value ? string.Empty : dr["SOURCE_DESC"].ToString().Trim();
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    string errorMessages = string.Format("DbConnection.cs - GetNutrientSourceById()");
                    ExceptionHelper.LogException(ex, errorMessages);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                        con.Close();

                }
            }
            return nutrientsource;
        }

        public List<NutrientSource> GetAllNutrientSource(string lang = "", string nutrientsource = "")
        {
            var items = new List<NutrientSource>();

            string commandText = "SELECT * FROM CNFWEBADM.NUTR_SOURCE";

            using (OracleConnection con = new OracleConnection(cnfDBConnection))
            {
                OracleCommand cmd = new OracleCommand(commandText, con);
                try
                {
                    con.Open();
                    using (OracleDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                var item = new NutrientSource();
                                item.nutr_source_c = dr["NUTR_SOURCE_C"] == DBNull.Value ? 0 : Convert.ToInt32(dr["NUTR_SOURCE_C"]);
                                item.nrd_ref       = dr["NRD_REF"]       == DBNull.Value ? 0 : Convert.ToInt32(dr["NRD_REF"]);

                                if (lang.Equals("fr"))
                                {
                                    item.source_desc = dr["SOURCE_DESC_F"] == DBNull.Value ? dr["SOURCE_DESC"].ToString().Trim() : dr["SOURCE_DESC_F"].ToString().Trim();
                                }
                                else
                                {
                                    item.source_desc = dr["SOURCE_DESC"] == DBNull.Value ? string.Empty : dr["SOURCE_DESC"].ToString().Trim();
                                }

                                items.Add(item);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    string errorMessages = string.Format("DbConnection.cs - GetAllNutrientSource()");
                    ExceptionHelper.LogException(ex, errorMessages);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                        con.Close();
                }
            }
            return items;
        }
        //END OF NutrientSource
        //BEGIN OF RefuseAmount
        public List<RefuseAmount> GetRefuseAmountById(int id, string lang = "")
        {
            var items = new List<RefuseAmount>();
            string commandText = "SELECT * FROM CNFWEBADM.WEB_SERVING_SIZE WHERE MEASURE_TYPE ='R' AND FOOD_C =" + id;
            using (OracleConnection con = new OracleConnection(cnfDBConnection))
            {
                OracleCommand cmd = new OracleCommand(commandText, con);
                try
                {
                    con.Open();
                    using (OracleDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                var item = new RefuseAmount();
                                item.conv_factor    = dr["CONV_FACTOR"]    == DBNull.Value ? 0 : Convert.ToDouble(dr["CONV_FACTOR"]);
                                item.food_c         = dr["FOOD_C"]         == DBNull.Value ? 0 : Convert.ToInt32(dr["FOOD_C"]);
                                item.measure_type   = dr["MEASURE_TYPE"]   == DBNull.Value ? string.Empty : dr["MEASURE_TYPE"].ToString().Trim();

                                if (lang.Equals("fr"))
                                {
                                    item.food_desc    = dr["FOOD_DESC_F"]    == DBNull.Value ? dr["FOOD_DESC"].ToString().Trim() : dr["FOOD_DESC_F"].ToString().Trim();
                                    item.measure_desc = dr["MEASURE_DESC_F"] == DBNull.Value ? dr["MEASURE_DESC"].ToString().Trim() : dr["MEASURE_DESC_F"].ToString().Trim();
                                }
                                else
                                {
                                    item.food_desc    = dr["FOOD_DESC"]    == DBNull.Value ? string.Empty : dr["FOOD_DESC"].ToString().Trim();
                                    item.measure_desc = dr["MEASURE_DESC"] == DBNull.Value ? string.Empty : dr["MEASURE_DESC"].ToString().Trim();
                                }

                                items.Add(item);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    string errorMessages = string.Format("DbConnection.cs - GetRefuseAmountById()");
                    ExceptionHelper.LogException(ex, errorMessages);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                        con.Close();
                }
            }
            return items;
        }

        public List<RefuseAmount> GetAllRefuseAmount(string lang = "", string refusename = "")
        {
            var items  = new List<RefuseAmount>();
            string commandText = "SELECT * FROM CNFWEBADM.WEB_SERVING_SIZE WHERE MEASURE_TYPE ='R'";
            using (OracleConnection con = new OracleConnection(cnfDBConnection))
            {
                OracleCommand cmd = new OracleCommand(commandText, con);
                try
                {
                    con.Open();
                    using (OracleDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                var item = new RefuseAmount();
                                item.conv_factor    = dr["CONV_FACTOR"]    == DBNull.Value ? 0 : Convert.ToDouble(dr["CONV_FACTOR"]);
                                item.food_c         = dr["FOOD_C"]         == DBNull.Value ? 0 : Convert.ToInt32(dr["FOOD_C"]);
                                item.measure_type   = dr["MEASURE_TYPE"]   == DBNull.Value ? string.Empty : dr["MEASURE_TYPE"].ToString().Trim();

                                if (lang.Equals("fr"))
                                {
                                    item.food_desc = dr["FOOD_DESC_F"] == DBNull.Value ? dr["FOOD_DESC"].ToString().Trim() : dr["FOOD_DESC_F"].ToString().Trim();
                                    item.measure_desc = dr["MEASURE_DESC_F"] == DBNull.Value ? dr["MEASURE_DESC"].ToString().Trim() : dr["MEASURE_DESC_F"].ToString().Trim();
                                }
                                else
                                {
                                    item.food_desc = dr["FOOD_DESC"] == DBNull.Value ? string.Empty : dr["FOOD_DESC"].ToString().Trim();
                                    item.measure_desc = dr["MEASURE_DESC"] == DBNull.Value ? string.Empty : dr["MEASURE_DESC"].ToString().Trim();
                                }
                                items.Add(item);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    string errorMessages = string.Format("DbConnection.cs - GetAllRefuseAmount()");
                    ExceptionHelper.LogException(ex, errorMessages);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                        con.Close();
                }
            }
            return items;
         }
        //END OF RefuseAmount
        //BEGIN OF ServingSize
        public List<ServingSize> GetServingSizeById(int id, string lang = "")
        {
            var items = new List<ServingSize>();
            string commandText = "SELECT * FROM CNFWEBADM.WEB_SERVING_SIZE WHERE MEASURE_TYPE ='U' AND FOOD_C =" + id;
            using (OracleConnection con = new OracleConnection(cnfDBConnection))
            {
                OracleCommand cmd = new OracleCommand(commandText, con);
                try
                {
                    con.Open();
                    using (OracleDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                var item = new ServingSize();
                                item.conv_factor  = dr["CONV_FACTOR"]  == DBNull.Value ? 0 : Convert.ToDouble(dr["CONV_FACTOR"]);
                                item.food_c       = dr["FOOD_C"]       == DBNull.Value ? 0 : Convert.ToInt32(dr["FOOD_C"]);
                                item.measure_type = dr["MEASURE_TYPE"] == DBNull.Value ? string.Empty : dr["MEASURE_TYPE"].ToString().Trim();

                                if (lang.Equals("fr"))
                                {
                                    item.food_desc    = dr["FOOD_DESC_F"]    == DBNull.Value ? dr["FOOD_DESC"].ToString().Trim() : dr["FOOD_DESC_F"].ToString().Trim();
                                    item.measure_desc = dr["MEASURE_DESC_F"] == DBNull.Value ? dr["MEASURE_DESC"].ToString().Trim() : dr["MEASURE_DESC_F"].ToString().Trim();
                                }
                                else
                                {
                                    item.food_desc    = dr["FOOD_DESC"]    == DBNull.Value ? string.Empty : dr["FOOD_DESC"].ToString().Trim();
                                    item.measure_desc = dr["MEASURE_DESC"] == DBNull.Value ? string.Empty : dr["MEASURE_DESC"].ToString().Trim();
                                }
                                items.Add(item);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    string errorMessages = string.Format("DbConnection.cs - GetServingSizeById()");
                    ExceptionHelper.LogException(ex, errorMessages);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                        con.Close();
                }
            }
            return items;
        }

        public List<ServingSize> GetAllServingSize(string lang = "", string servingsize = "")
        {
            var items = new List<ServingSize>();
            string commandText = "SELECT * FROM CNFWEBADM.WEB_SERVING_SIZE WHERE MEASURE_TYPE ='U'";
            using (OracleConnection con = new OracleConnection(cnfDBConnection))
            {
                OracleCommand cmd = new OracleCommand(commandText, con);
                try
                {
                    con.Open();
                    using (OracleDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                var item = new ServingSize();
                                item.conv_factor  = dr["CONV_FACTOR"]  == DBNull.Value ? 0 : Convert.ToDouble(dr["CONV_FACTOR"]);
                                item.food_c       = dr["FOOD_C"]       == DBNull.Value ? 0 : Convert.ToInt32(dr["FOOD_C"]);
                                item.measure_type = dr["MEASURE_TYPE"] == DBNull.Value ? string.Empty : dr["MEASURE_TYPE"].ToString().Trim();

                                if (lang.Equals("fr"))
                                {
                                    item.food_desc    = dr["FOOD_DESC_F"]    == DBNull.Value ? dr["FOOD_DESC"].ToString().Trim() : dr["FOOD_DESC_F"].ToString().Trim();
                                    item.measure_desc = dr["MEASURE_DESC_F"] == DBNull.Value ? dr["MEASURE_DESC"].ToString().Trim() : dr["MEASURE_DESC_F"].ToString().Trim();
                                }
                                else
                                {
                                    item.food_desc    = dr["FOOD_DESC"]    == DBNull.Value ? string.Empty : dr["FOOD_DESC"].ToString().Trim();
                                    item.measure_desc = dr["MEASURE_DESC"] == DBNull.Value ? string.Empty : dr["MEASURE_DESC"].ToString().Trim();
                                }
                                items.Add(item);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    string errorMessages = string.Format("DbConnection.cs - GetAllServingSize()");
                    ExceptionHelper.LogException(ex, errorMessages);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                        con.Close();
                }
            }
            return items;
        }
        //END OF ServingSize
        //BEGIN OF YieldAmount
        public List<YieldAmount> GetYieldAmountById(int id, string lang = "")
        {
            var items = new List<YieldAmount>();
            string commandText = "SELECT * FROM CNFWEBADM.WEB_SERVING_SIZE WHERE MEASURE_TYPE ='Y' AND FOOD_C =" + id;
            using (OracleConnection con = new OracleConnection(cnfDBConnection))
            {
                OracleCommand cmd = new OracleCommand(commandText, con);
                try
                {
                    con.Open();
                    using (OracleDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                var item = new YieldAmount();
                                item.conv_factor  = dr["CONV_FACTOR"]  == DBNull.Value ? 0 : Convert.ToDouble(dr["CONV_FACTOR"]);
                                item.food_c       = dr["FOOD_C"]       == DBNull.Value ? 0 : Convert.ToInt32(dr["FOOD_C"]);
                                item.measure_type = dr["MEASURE_TYPE"] == DBNull.Value ? string.Empty : dr["MEASURE_TYPE"].ToString().Trim();

                                if (lang.Equals("fr"))
                                {
                                    item.food_desc    = dr["FOOD_DESC_F"]    == DBNull.Value ? dr["FOOD_DESC"].ToString().Trim() : dr["FOOD_DESC_F"].ToString().Trim();
                                    item.measure_desc = dr["MEASURE_DESC_F"] == DBNull.Value ? dr["MEASURE_DESC"].ToString().Trim() : dr["MEASURE_DESC_F"].ToString().Trim();
                                }
                                else
                                {
                                    item.food_desc    = dr["FOOD_DESC"]    == DBNull.Value ? string.Empty : dr["FOOD_DESC"].ToString().Trim();
                                    item.measure_desc = dr["MEASURE_DESC"] == DBNull.Value ? string.Empty : dr["MEASURE_DESC"].ToString().Trim();
                                }
                                items.Add(item);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    string errorMessages = string.Format("DbConnection.cs - GetYieldAmountById()");
                    ExceptionHelper.LogException(ex, errorMessages);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                        con.Close();
                }
            }
            return items;
        }
        public List<YieldAmount> GetAllYieldAmount(string lang = "", string yieldname = "")
        {
            var items = new List<YieldAmount>();
            string commandText = "SELECT * FROM CNFWEBADM.WEB_SERVING_SIZE WHERE MEASURE_TYPE ='Y'";
            using (OracleConnection con = new OracleConnection(cnfDBConnection))
            {
                OracleCommand cmd = new OracleCommand(commandText, con);
                try
                {
                    con.Open();
                    using (OracleDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                var item = new YieldAmount();
                                item.conv_factor    = dr["CONV_FACTOR"]    == DBNull.Value ? 0 : Convert.ToDouble(dr["CONV_FACTOR"]);
                                item.food_c         = dr["FOOD_C"]         == DBNull.Value ? 0 : Convert.ToInt32(dr["FOOD_C"]);
                                item.measure_type   = dr["MEASURE_TYPE"]   == DBNull.Value ? string.Empty : dr["MEASURE_TYPE"].ToString().Trim();

                                if (lang.Equals("fr"))
                                {
                                    item.food_desc    = dr["FOOD_DESC_F"]    == DBNull.Value ? dr["FOOD_DESC"].ToString().Trim() : dr["FOOD_DESC_F"].ToString().Trim();
                                    item.measure_desc = dr["MEASURE_DESC_F"] == DBNull.Value ? dr["MEASURE_DESC"].ToString().Trim() : dr["MEASURE_DESC_F"].ToString().Trim();
                                }
                                else
                                {
                                    item.food_desc    = dr["FOOD_DESC"]    == DBNull.Value ? string.Empty : dr["FOOD_DESC"].ToString().Trim();
                                    item.measure_desc = dr["MEASURE_DESC"] == DBNull.Value ? string.Empty : dr["MEASURE_DESC"].ToString().Trim();
                                }
                                items.Add(item);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    string errorMessages = string.Format("DbConnection.cs - GetAllYieldAmount()");
                    ExceptionHelper.LogException(ex, errorMessages);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                        con.Close();
                }
            }
            return items;
        }
        //END OF YieldAmount

        //BEGIN OF FoodGroup 
        //NOTE: As of 20180206 FoodGroup is not currently part of this release but will potentinally in the future.
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
        //END OF FoodGroup

        public List<FoodGroup> GetAllFoodGroup(string lang = "", string foodname = "")
        {

            //var orderClause = "";
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
