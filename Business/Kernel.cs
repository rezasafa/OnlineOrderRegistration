using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Blazored.SessionStorage;
using pwaSepehr.MyModels;
using System.Net.Http;
using System.Net.Http.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace pwaSepehr.Business
{
    public class Kernel
    {
        //public readonly string IpAddress = "http://192.168.165.165:81";
        public readonly string IpAddress = "http://192.168.1.6:82";
        //public readonly string IpAddress = "http://localhost:82";
        public async Task<string> getToken(myuser myUser)
        {
            string Result = "";
            var mu = new List<KeyValuePair<string, string>>();
            mu.Add(new KeyValuePair<string, string>("company", myUser.Company));
            mu.Add(new KeyValuePair<string, string>("year", myUser.Year));
            mu.Add(new KeyValuePair<string, string>("UserName", myUser.UserName));
            mu.Add(new KeyValuePair<string, string>("Password", myUser.Password));
            mu.Add(new KeyValuePair<string, string>("grant_type", "password"));
            var http = new HttpClient();
            var requestMessage = new HttpRequestMessage()
            {
                Method = new HttpMethod("POST"),
                RequestUri = new Uri(IpAddress + "/Token"),
                Content = new FormUrlEncodedContent(mu)
            };
            
            try
            {
                var response = await http.SendAsync(requestMessage);
                var responseStatusCode = response.StatusCode;

                var responseBody = await response.Content.ReadAsStringAsync();

                Result = responseBody;
                JObject X = JObject.Parse(Result);
                if (Result.IndexOf("error")>=0)
                {
                    Result = "";
                }
                else
                {
                    Result=X["access_token"].ToString();
                }
                
                /*
                "access_token": "i426i0uJ4E1qCjAVleTDQKVjRUbKMXY3R2488CDPD1j8DI56egzlbGiq38_V__14oM0z3IhTs5FCmo62c-JD-tXMoti3V_75Tu3k_vqx-h4gie0hwqjvZERGRNDp7iWYWkoIzPVbtz14lOBDcMyxA6XqCvi8OA9DEMTkX8a01SW2fauY6WIwAvBfcZmpZm1Ho9So5M0itbd3V3FvA_jfIoN6IOkA8pUn5wZGfQw5FUd3dJcrJ5j05VH3l0ySpQG56IfGIVcMbAcPC3u48xec_jBVJHovfg-leuTcmLS_Tyc",
                "token_type": "bearer",
                "expires_in": 86399
                */
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            return Result;
        }
        public async Task<bool> CheckUserPass(myuser myUser)
        {
            if(String.IsNullOrEmpty(myUser.Company)) return false;
            if(String.IsNullOrEmpty(myUser.Year)) return false;
            var lcompany = new List<Company>();
            lcompany = await GetCompany();
            var co = lcompany.Where(m => m.CompanyID == myUser.Company).FirstOrDefault();
            string Result = "";
            bool retval = false;
            var mu = new List<KeyValuePair<string, string>>();
            mu.Add(new KeyValuePair<string, string>("myapp.company", co.Name));
            mu.Add(new KeyValuePair<string, string>("myapp.year", myUser.Year));
            mu.Add(new KeyValuePair<string, string>("UserName", myUser.UserName));
            mu.Add(new KeyValuePair<string, string>("Password", myUser.Password));
            var http = new HttpClient();
            var requestMessage = new HttpRequestMessage()
            {
                Method = new HttpMethod("POST"),
                RequestUri = new Uri(IpAddress + "/api/myws/login"),
                Content = new FormUrlEncodedContent(mu)
            };
            
            try
            {
                var response = await http.SendAsync(requestMessage);
                var responseStatusCode = response.StatusCode;

                var responseBody = await response.Content.ReadAsStringAsync();

                Result = responseBody;

                // Console.WriteLine(Result);

                if(Result == "[]")
                {
                    retval = false;   
                }
                else
                {
                    retval = true;
                }
                // JObject X = JObject.Parse(Result);
                // if (Result.IndexOf("error")>=0)
                // {
                //     Result = "";
                // }
                // else
                // {
                //     Result=X["access_token"].ToString();
                // }
                
                /*
                "access_token": "i426i0uJ4E1qCjAVleTDQKVjRUbKMXY3R2488CDPD1j8DI56egzlbGiq38_V__14oM0z3IhTs5FCmo62c-JD-tXMoti3V_75Tu3k_vqx-h4gie0hwqjvZERGRNDp7iWYWkoIzPVbtz14lOBDcMyxA6XqCvi8OA9DEMTkX8a01SW2fauY6WIwAvBfcZmpZm1Ho9So5M0itbd3V3FvA_jfIoN6IOkA8pUn5wZGfQw5FUd3dJcrJ5j05VH3l0ySpQG56IfGIVcMbAcPC3u48xec_jBVJHovfg-leuTcmLS_Tyc",
                "token_type": "bearer",
                "expires_in": 86399
                */
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            return retval;
        }
        public async Task<List<Company>> GetCompany()
        {
            string Result = "";
            var lcom = new List<Company>();
            var http = new HttpClient();
            var requestMessage = new HttpRequestMessage()
            {
                Method = new HttpMethod("GET"),
                RequestUri = new Uri(IpAddress + "/api/myws/Get_Company"),
            };
            
            try
            {
                var response = await http.SendAsync(requestMessage);
                var responseStatusCode = response.StatusCode;
                var responseBody = await response.Content.ReadAsStringAsync();
                Result = responseBody;
                JArray j = JArray.Parse(Result);
                var X = j.ToList();
                
                for (int i =0 ;i<X.Count;i++)
                {
                    var com = new Company();
                    com.CompanyID =X[i]["CompanyID"].ToString();
                    com.Name =X[i]["Name"].ToString();

                    lcom.Add(com);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            return lcom;
        }
        public async Task<List<Year>> GetYears(string CompanyID)
        {
            string Result = "";
            var lyear = new List<Year>();
            var http = new HttpClient();
            var requestMessage = new HttpRequestMessage()
            {
                Method = new HttpMethod("GET"),
                RequestUri = new Uri(IpAddress + "/api/myws/Get_FinYear?FinCompany="+ CompanyID),
            };
            
            try
            {
                var response = await http.SendAsync(requestMessage);
                var responseStatusCode = response.StatusCode;
                var responseBody = await response.Content.ReadAsStringAsync();
                Result = responseBody;
                JArray j = JArray.Parse(Result);
                var X = j.ToList();
                
                for (int i =0 ;i<X.Count;i++)
                {
                    var year = new Year();
                    year.FiYearID =int.Parse(X[i]["FiYearID"].ToString());
                    year.FinYear =X[i]["FinYear"].ToString();
                    year.Description =X[i]["Description"].ToString();
                    year.LastYear =X[i]["LastYear"].ToString();

                    lyear.Add(year);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            return lyear;
        }
        public async Task<List<Orders_Doc>> GetOrders(MyAppWhere m,string mytoken)
        {
            var lod = new List<Orders_Doc>();
            string Result = "";
            var mu = new List<KeyValuePair<string, string>>();
            mu.Add(new KeyValuePair<string, string>("myapp.company", m.myapp.Company));
            mu.Add(new KeyValuePair<string, string>("myapp.year", m.myapp.Year));
            mu.Add(new KeyValuePair<string, string>("Wheres", m.Wheres));
            var http = new HttpClient();
            http.DefaultRequestHeaders.Add("Authorization", "Bearer " + mytoken);
            var requestMessage = new HttpRequestMessage()
            {
                Method = new HttpMethod("POST"),
                RequestUri = new Uri(IpAddress + "/api/myws/Get_OrderDoc"),
                Content = new FormUrlEncodedContent(mu)
            };
            
            try
            {
                var response = await http.SendAsync(requestMessage);
                var responseStatusCode = response.StatusCode;

                var responseBody = await response.Content.ReadAsStringAsync();

                Result = responseBody;

                JArray j = JArray.Parse(Result);
                var X = j.ToList();
                
                for (int i =0 ;i<X.Count;i++)
                {
                    var od = new Orders_Doc();
                    od.Order_No =X[i]["Order_No"].ToString();
                    od.Order_Date =X[i]["Order_Date"].ToString();
                    od.Order_Desc =X[i]["Order_Desc"].ToString();
                    od.Tafsil_No1 =X[i]["Tafsil_No1"].ToString();
                    od.Customer_Name =X[i]["Customer_Name"].ToString();

                    lod.Add(od);
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            return lod.OrderByDescending(m => m.Order_No).ToList();
        }
        public async Task<List<Orders_Details>> GetOrder_Detailss(MyAppWhere m,string mytoken)
        {
            var lod = new List<Orders_Details>();
            string Result = "";
            var mu = new List<KeyValuePair<string, string>>();
            mu.Add(new KeyValuePair<string, string>("myapp.company", m.myapp.Company));
            mu.Add(new KeyValuePair<string, string>("myapp.year", m.myapp.Year));
            mu.Add(new KeyValuePair<string, string>("Wheres", m.Wheres));
            var http = new HttpClient();
            http.DefaultRequestHeaders.Add("Authorization", "Bearer " + mytoken);
            var requestMessage = new HttpRequestMessage()
            {
                Method = new HttpMethod("POST"),
                RequestUri = new Uri(IpAddress + "/api/myws/Get_OrderDetails"),
                Content = new FormUrlEncodedContent(mu)
            };
            
            try
            {
                var response = await http.SendAsync(requestMessage);
                var responseStatusCode = response.StatusCode;

                var responseBody = await response.Content.ReadAsStringAsync();

                Result = responseBody;

                JArray j = JArray.Parse(Result);
                var X = j.ToList();
                
                for (int i =0 ;i<X.Count;i++)
                {
                    var od = new Orders_Details();

                    od.Order_No =X[i]["Order_No"].ToString();
                    od.Row =int.Parse( X[i]["Row"].ToString());
                    od.Merch_Code =X[i]["Merch_Code"].ToString();
                    od.Merch_Name =X[i]["Merch_Name"].ToString();
                    od.Descr = X[i]["Descr"].ToString();
                    od.Qty = float.Parse(X[i]["Qty"].ToString());
                    od.Qty_Inv = float.Parse(X[i]["Qty_Inv"].ToString());
                    od.MQty = float.Parse(X[i]["MQty"].ToString());
                    od.MQty_Inv = float.Parse(X[i]["MQty_Inv"].ToString());
                    od.Discount = int.Parse(X[i]["Discount"].ToString());
                    od.Discount_Price = decimal.Parse(X[i]["Discount_Price"].ToString());
                    od.Price = decimal.Parse(X[i]["Price"].ToString());
                    od.Total = decimal.Parse(X[i]["Total"].ToString());
                    od.MajorUnit = X[i]["MajorUnit"].ToString();
                    od.MinorUnit = X[i]["MinorUnit"].ToString();
                    od.Major_Minor_Related = bool.Parse(X[i]["Major_Minor_Related"].ToString());

                    lod.Add(od);
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            return lod.OrderBy(m => m.Row).ToList();
        }
        public async Task<string> Insert_OrderDoc(MyAppOrderDoc m,string mytoken)
        {
            //"/api/myws/Insert_OrderDoc";
            /*
                coname, year, 
                Order_No, Order_Date, Order_Desc, PreFactor_No, Center_No, Sales_Person_No,
                Expire_Date, Customer_Name, Acc_No, Tafsil_No1, Tafsil_No2, Tafsil_No3,
                Cash, Credit, County, SalesMan, Store_Keeper_Register, Register, Settle, Order_Cancel
            */
            string x = "";
            var mu = new List<KeyValuePair<string, string>>();
            mu.Add(new KeyValuePair<string, string>("myapp.company", m.myapp.Company));
            mu.Add(new KeyValuePair<string, string>("myapp.year", m.myapp.Year));
            mu.Add(new KeyValuePair<string, string>("Order_Date", m.Order_Date));
            mu.Add(new KeyValuePair<string, string>("Order_Desc", m.Order_Desc));
            mu.Add(new KeyValuePair<string, string>("Tafsil_No1", m.Tafsil_No1));
            mu.Add(new KeyValuePair<string, string>("Customer_Name", m.Customer_Name));
            var http = new HttpClient();
            http.DefaultRequestHeaders.Add("Authorization", "Bearer " + mytoken);
            var requestMessage = new HttpRequestMessage()
            {
                Method = new HttpMethod("POST"),
                RequestUri = new Uri(IpAddress + "/api/myws/Insert_OrderDoc"),
                Content = new FormUrlEncodedContent(mu)
            };
            
            try
            {   
                var response =  await http.SendAsync(requestMessage);
                var responseStatusCode = response.StatusCode;

                var responseBody = await response.Content.ReadAsStringAsync();
                x = responseBody.ToString();
                
                //"{\"result\":\"OK\",\"order_no\":\"00913\",\"id\":10737}"
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            //Console.WriteLine(x);
            var xx = x.Replace(@"\","");
            //Console.WriteLine(xx);
            //Console.WriteLine(xx.Substring(xx.IndexOf("order_no")));
            //Console.WriteLine(xx.Substring(xx.IndexOf("order_no")).Replace("order_no\":\"",""));
            var x_order = (xx.Substring(xx.IndexOf("order_no")).Replace("order_no\":\"",""));
            string myval = (x_order.Substring(0,x_order.IndexOf("\"")));
            
            //Console.WriteLine(myval);
            return myval;
        }
        public async Task<string> Save_OrderDetails(MyAppOrderDetails m,string mytoken)
        {
            //"/api/myws/Save_OrderDetails";
            /*
                coname, year,
                Order_No, Row, Merch_Code, Descr, Price,
                Qty, MQty, Qty_Inv, MQty_Inv, Total,
                Discount, Discount_Price, Insert
            */
            string Result = "";
            var mu = new List<KeyValuePair<string, string>>();
            mu.Add(new KeyValuePair<string, string>("myapp.company", m.myapp.Company));
            mu.Add(new KeyValuePair<string, string>("myapp.year", m.myapp.Year));
            mu.Add(new KeyValuePair<string, string>("Order_No", m.Order_No));
            mu.Add(new KeyValuePair<string, string>("Row", m.Row.ToString()));
            mu.Add(new KeyValuePair<string, string>("Merch_Code", m.Merch_Code));
            mu.Add(new KeyValuePair<string, string>("Descr", m.Descr));
            mu.Add(new KeyValuePair<string, string>("Price", m.Price.ToString()));
            mu.Add(new KeyValuePair<string, string>("Qty", m.Qty.ToString()));
            mu.Add(new KeyValuePair<string, string>("MQty", m.MQty.ToString()));
            mu.Add(new KeyValuePair<string, string>("Qty_Inv", m.Qty_Inv.ToString()));
            mu.Add(new KeyValuePair<string, string>("MQty_Inv", m.MQty_Inv.ToString()));
            mu.Add(new KeyValuePair<string, string>("Total", m.Total.ToString()));
            mu.Add(new KeyValuePair<string, string>("Discount", m.Discount.ToString()));
            mu.Add(new KeyValuePair<string, string>("Discount_Price", m.Discount_Price.ToString()));
            mu.Add(new KeyValuePair<string, string>("Insert", m.Insert.ToString().ToLower()));
            var http = new HttpClient();
            http.DefaultRequestHeaders.Add("Authorization", "Bearer " + mytoken);
            var requestMessage = new HttpRequestMessage()
            {
                Method = new HttpMethod("POST"),
                RequestUri = new Uri(IpAddress + "/api/myws/Save_OrderDetails"),
                Content = new FormUrlEncodedContent(mu)
            };
            
            try
            {
                var response = await http.SendAsync(requestMessage);
                var responseStatusCode = response.StatusCode;

                var responseBody = await response.Content.ReadAsStringAsync();
                Result = responseBody.ToString();
                
                //"OK"

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Result = ex.Message;
            }
            var maw = new MyAppWhere();
            maw.myapp= m.myapp;
            maw.Wheres = m.Order_No;
            await Sort_OrderDetails(maw,mytoken);
            return Result;
        }
        public async Task<string> Delete_OrderDetails(MyAppWhere m,string mytoken)
        {
            string Result = "";
            var mu = new List<KeyValuePair<string, string>>();
            mu.Add(new KeyValuePair<string, string>("myapp.company", m.myapp.Company));
            mu.Add(new KeyValuePair<string, string>("myapp.year", m.myapp.Year));
            mu.Add(new KeyValuePair<string, string>("Wheres", m.Wheres));
            var http = new HttpClient();
            http.DefaultRequestHeaders.Add("Authorization", "Bearer " + mytoken);
            var requestMessage = new HttpRequestMessage()
            {
                Method = new HttpMethod("POST"),
                RequestUri = new Uri(IpAddress + "/api/myws/Del_OrderDetail"),
                Content = new FormUrlEncodedContent(mu)
            };
            
            try
            {
                var response = await http.SendAsync(requestMessage);
                var responseStatusCode = response.StatusCode;

                var responseBody = await response.Content.ReadAsStringAsync();
                Result = responseBody.ToString();
                
                //"OK"

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Result = ex.Message;
            }
            
            return Result;
        }
        public async Task<string> Sort_OrderDetails(MyAppWhere m,string mytoken)
        {
            /*
                scon, m.myapp.company, m.myapp.year,
                m.OrderNo, m.type,
            */
            string Result = "";
            var mu = new List<KeyValuePair<string, string>>();
            mu.Add(new KeyValuePair<string, string>("myapp.company", m.myapp.Company));
            mu.Add(new KeyValuePair<string, string>("myapp.year", m.myapp.Year));
            mu.Add(new KeyValuePair<string, string>("OrderNo", m.Wheres));
            mu.Add(new KeyValuePair<string, string>("type", "Row"));
            var http = new HttpClient();
            http.DefaultRequestHeaders.Add("Authorization", "Bearer " + mytoken);
            var requestMessage = new HttpRequestMessage()
            {
                Method = new HttpMethod("POST"),
                RequestUri = new Uri(IpAddress + "/api/myws/Sort_OrderDetails_Row"),
                Content = new FormUrlEncodedContent(mu)
            };
            
            try
            {
                var response = await http.SendAsync(requestMessage);
                var responseStatusCode = response.StatusCode;

                var responseBody = await response.Content.ReadAsStringAsync();
                Result = responseBody.ToString();
                
                //"OK"

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Result = ex.Message;
            }
            
            return Result;
        }
        public async Task<string> Delete_Order(MyAppWhere m,string mytoken)
        {
            string Result = "";
            var mu = new List<KeyValuePair<string, string>>();
            mu.Add(new KeyValuePair<string, string>("myapp.company", m.myapp.Company));
            mu.Add(new KeyValuePair<string, string>("myapp.year", m.myapp.Year));
            mu.Add(new KeyValuePair<string, string>("Wheres", m.Wheres));
            var http = new HttpClient();
            http.DefaultRequestHeaders.Add("Authorization", "Bearer " + mytoken);
            var requestMessage = new HttpRequestMessage()
            {
                Method = new HttpMethod("POST"),
                RequestUri = new Uri(IpAddress + "/api/myws/Delete_Order"),
                Content = new FormUrlEncodedContent(mu)
            };
            
            try
            {
                var response = await http.SendAsync(requestMessage);
                var responseStatusCode = response.StatusCode;

                var responseBody = await response.Content.ReadAsStringAsync();
                Result = responseBody.ToString();
                
                //"OK"

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Result = ex.Message;
            }
            
            return Result;
        }
        public async Task<string> UpdateOrders(MyAppOrderDoc m,string mytoken)
        {
            /*
            /api/myws/Update_OrderDoc
                scon, m.myapp.company, m.myapp.year, 
                m.Order_No,m.Order_Date,m.Order_Desc,m.PreFactor_No,m.Center_No,m.Sales_Person_No,
                m.Expire_Date,m.Customer_Name,m.Acc_No,m.Tafsil_No1,m.Tafsil_No2,m.Tafsil_No3,
                m.Cash,m.Credit,m.County,m.SalesMan,m.Store_Keeper_Register,m.Register,m.Settle,m.Order_Cancel,
                m.Order_Condition, m.Order_Dlv_Date, m.Order_Dlv_Place, m.Order_Expire,
                m.Copper_Base, m.Packing, m.BankAccounts, m.Followup_Person, m.Factor_No,
                m.SDoc_No, m.SDoc_NoP, m.Store_No, m.Discount_Prcnt, m.Discount,
                m.Extra_Charge, m.Extra_Costs, m.Toll, m.VAT, m.Notes, m.Package_Qty,
                m.Cash_Value, m.Settle_Date
            */
            string Result = "";
            var mu = new List<KeyValuePair<string, string>>();
            mu.Add(new KeyValuePair<string, string>("myapp.company", m.myapp.Company));
            mu.Add(new KeyValuePair<string, string>("myapp.year", m.myapp.Year));
            mu.Add(new KeyValuePair<string, string>("Order_No", m.Order_No));
            mu.Add(new KeyValuePair<string, string>("Order_Date", m.Order_Date));
            mu.Add(new KeyValuePair<string, string>("Order_Desc", m.Order_Desc));
            mu.Add(new KeyValuePair<string, string>("Tafsil_No1", m.Tafsil_No1));
            mu.Add(new KeyValuePair<string, string>("Customer_Name", m.Customer_Name));
            mu.Add(new KeyValuePair<string, string>("Copper_Base", "0"));//
            
            var http = new HttpClient();
            http.DefaultRequestHeaders.Add("Authorization", "Bearer " + mytoken);
            var requestMessage = new HttpRequestMessage()
            {
                Method = new HttpMethod("POST"),
                RequestUri = new Uri(IpAddress + "/api/myws/Update_OrderDoc"),
                Content = new FormUrlEncodedContent(mu)
            };
            
            try
            {
                var response = await http.SendAsync(requestMessage);
                var responseStatusCode = response.StatusCode;

                var responseBody = await response.Content.ReadAsStringAsync();
                Result = responseBody.ToString();
                //Console.WriteLine(Result);
                //"OK"

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Result = ex.Message;
            }
            
            return Result;
        }
        public async Task<List<Accounts>> GetAccounts(MyAppWhere m,string mytoken)
        {
            var lAcc = new List<Accounts>();
            string Result = "";
            var mu = new List<KeyValuePair<string, string>>();
            mu.Add(new KeyValuePair<string, string>("myapp.company", m.myapp.Company));
            mu.Add(new KeyValuePair<string, string>("myapp.year", m.myapp.Year));
            mu.Add(new KeyValuePair<string, string>("Wheres", m.Wheres));
            var http = new HttpClient();
            http.DefaultRequestHeaders.Add("Authorization", "Bearer " + mytoken);
            var requestMessage = new HttpRequestMessage()
            {
                Method = new HttpMethod("POST"),
                RequestUri = new Uri(IpAddress + "/api/myws/Get_Account"),
                Content = new FormUrlEncodedContent(mu)
            };
            
            try
            {
                var response = await http.SendAsync(requestMessage);
                var responseStatusCode = response.StatusCode;

                var responseBody = await response.Content.ReadAsStringAsync();

                Result = responseBody;

                JArray j = JArray.Parse(Result);
                var X = j.ToList();
                
                for (int i =0 ;i<X.Count;i++)
                {
                    var acc = new Accounts();
                    acc.Acc_No =X[i]["Acc_No"].ToString();
                    acc.Acc_Name =X[i]["Acc_Name"].ToString();
                    
                    lAcc.Add(acc);
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            return lAcc.OrderBy(m => m.Acc_Name).ToList();
        }
        public async Task<List<Tafsil>> GetTafsil(MyAppWhere m,string mytoken)
        {
            var lTaf = new List<Tafsil>();
            string Result = "";
            var mu = new List<KeyValuePair<string, string>>();
            mu.Add(new KeyValuePair<string, string>("myapp.company", m.myapp.Company));
            mu.Add(new KeyValuePair<string, string>("myapp.year", m.myapp.Year));
            mu.Add(new KeyValuePair<string, string>("Wheres", m.Wheres));
            var http = new HttpClient();
            http.DefaultRequestHeaders.Add("Authorization", "Bearer " + mytoken);
            var requestMessage = new HttpRequestMessage()
            {
                Method = new HttpMethod("POST"),
                RequestUri = new Uri(IpAddress + "/api/myws/Get_Tafsil"),
                Content = new FormUrlEncodedContent(mu)
            };
            
            try
            {
                var response = await http.SendAsync(requestMessage);
                var responseStatusCode = response.StatusCode;

                var responseBody = await response.Content.ReadAsStringAsync();

                Result = responseBody;

                JArray j = JArray.Parse(Result);
                var X = j.ToList();
                
                for (int i =0 ;i<X.Count;i++)
                {
                    var taf = new Tafsil();
                    taf.Tafsil_No =X[i]["Tafsil_No"].ToString();
                    taf.Tafsil_Name =X[i]["Tafsil_Name"].ToString();
                    taf.G_No =X[i]["G_No"].ToString();

                    lTaf.Add(taf);
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            return lTaf.OrderBy(m => m.Tafsil_No).ToList();
        }
        public async Task<List<Acc_Tafsil>> GetAcc_Tafsil(MyAppWhere m,string mytoken)
        {
            var lAccTaf = new List<Acc_Tafsil>();
            string Result = "";
            var mu = new List<KeyValuePair<string, string>>();
            mu.Add(new KeyValuePair<string, string>("myapp.company", m.myapp.Company));
            mu.Add(new KeyValuePair<string, string>("myapp.year", m.myapp.Year));
            mu.Add(new KeyValuePair<string, string>("Wheres", m.Wheres));
            var http = new HttpClient();
            http.DefaultRequestHeaders.Add("Authorization", "Bearer " + mytoken);
            var requestMessage = new HttpRequestMessage()
            {
                Method = new HttpMethod("POST"),
                RequestUri = new Uri(IpAddress + "/api/myws/Get_Acc_Tafsil"),
                Content = new FormUrlEncodedContent(mu)
            };
            
            try
            {
                var response = await http.SendAsync(requestMessage);
                var responseStatusCode = response.StatusCode;

                var responseBody = await response.Content.ReadAsStringAsync();

                Result = responseBody;

                JArray j = JArray.Parse(Result);
                var X = j.ToList();
                
                for (int i =0 ;i<X.Count;i++)
                {
                    var AccTaf = new Acc_Tafsil();
                    AccTaf.Acc_No =X[i]["Acc_No"].ToString();
                    AccTaf.G_No =X[i]["G_No"].ToString();
                    AccTaf.No_Tafsil =X[i]["No_Tafsil"].ToString();

                    lAccTaf.Add(AccTaf);
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            return lAccTaf.OrderBy(m => m.Acc_No).ToList();
        }
        public async Task<List<Tafsil_Group>> GetTafsil_Group(MyAppWhere m,string mytoken)
        {
            var lGT = new List<Tafsil_Group>();
            string Result = "";
            var mu = new List<KeyValuePair<string, string>>();
            mu.Add(new KeyValuePair<string, string>("myapp.company", m.myapp.Company));
            mu.Add(new KeyValuePair<string, string>("myapp.year", m.myapp.Year));
            mu.Add(new KeyValuePair<string, string>("Wheres", m.Wheres));
            var http = new HttpClient();
            http.DefaultRequestHeaders.Add("Authorization", "Bearer " + mytoken);
            var requestMessage = new HttpRequestMessage()
            {
                Method = new HttpMethod("POST"),
                RequestUri = new Uri(IpAddress + "/api/myws/Get_Tafsil_Group"),
                Content = new FormUrlEncodedContent(mu)
            };
            
            try
            {
                var response = await http.SendAsync(requestMessage);
                var responseStatusCode = response.StatusCode;

                var responseBody = await response.Content.ReadAsStringAsync();

                Result = responseBody;

                JArray j = JArray.Parse(Result);
                var X = j.ToList();
                
                for (int i =0 ;i<X.Count;i++)
                {
                    var gt = new Tafsil_Group();
                    gt.G_No =X[i]["G_No"].ToString();
                    gt.G_Name =X[i]["G_Name"].ToString();
                    gt.Banks        =bool.Parse(X[i]["Banks"].ToString());
                    gt.Cashes       =bool.Parse(X[i]["Cashes"].ToString());
                    gt.Cos          =bool.Parse(X[i]["Cos"].ToString());
                    gt.CostCenters  =bool.Parse(X[i]["CostCenters"].ToString());
                    gt.Merchs       =bool.Parse(X[i]["Merchs"].ToString());
                    gt.Others       =bool.Parse(X[i]["Others"].ToString());
                    gt.People       =bool.Parse(X[i]["People"].ToString());
                    gt.Personal     =bool.Parse(X[i]["Personal"].ToString());
                    gt.ProfitCenters=bool.Parse(X[i]["ProfitCenters"].ToString());
                    gt.Visitors     =bool.Parse(X[i]["Visitors"].ToString());

                    lGT.Add(gt);
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            return lGT.OrderBy(m => m.G_Name).ToList();
        }        
        public async Task<List<Merchs>> GetMerchs(MyAppWhere m,string mytoken)
        {
            var lm = new List<Merchs>();
            string Result = "";
            var mu = new List<KeyValuePair<string, string>>();
            mu.Add(new KeyValuePair<string, string>("myapp.company", m.myapp.Company));
            mu.Add(new KeyValuePair<string, string>("myapp.year", m.myapp.Year));
            mu.Add(new KeyValuePair<string, string>("query", m.Wheres));
            var http = new HttpClient();
            http.DefaultRequestHeaders.Add("Authorization", "Bearer " + mytoken);
            var requestMessage = new HttpRequestMessage()
            {
                Method = new HttpMethod("POST"),

                //RequestUri = new Uri(IpAddress+ "/api/myws/Get_Merchs"),
                RequestUri = new Uri(IpAddress+ "/api/myws/Get_Select_Query"),
                
                Content = new FormUrlEncodedContent(mu)
            };
            
            try
            {
                var response = await http.SendAsync(requestMessage);
                var responseStatusCode = response.StatusCode;

                var responseBody = await response.Content.ReadAsStringAsync();

                Result = responseBody;

                JArray j = JArray.Parse(Result);
                var X = j.ToList();

                for (int i =0 ;i<X.Count;i++)
                {
                    var merchs = new Merchs();
                    
                    //Console.WriteLine(X[i]["Merch_Code"].ToString());
                    //(obj.Tafsil_No != null) ? obj.Tafsil_No.ToString() : "",

                    merchs.Merch_Code = X[i]["Merch_Code"].ToString();
                    merchs.Merch_Name = X[i]["Merch_Name"].ToString();
                    merchs.LMerch_Name = X[i]["LMerch_Name"].ToString();

                    merchs.MinorUnit = X[i]["MinorUnit"].ToString();
                    merchs.MajorUnit = X[i]["MajorUnit"].ToString();
                    
                    merchs.Major_Minor_Rate = int.Parse(X[i]["Major_Minor_Rate"].ToString());
                    merchs.Major_Minor_Related = bool.Parse(X[i]["Major_Minor_Related"].ToString());
                    merchs.Min_Qty = int.Parse(X[i]["Min_Qty"].ToString());
                    merchs.Max_Qty = int.Parse(X[i]["Max_Qty"].ToString());
                    merchs.Normal_Qty = int.Parse(X[i]["Normal_Qty"].ToString());
                    merchs.Safety_Stock = int.Parse(X[i]["Safety_Stock"].ToString());
                    
                    merchs.Sales_Price = decimal.Parse(X[i]["Sales_Price"].ToString());
                    merchs.Last_Merch = bool.Parse(X[i]["Last_Merch"].ToString());
                    merchs.Active = bool.Parse(X[i]["Active"].ToString());
                    merchs.Acc_No = X[i]["Acc_No"].ToString();
                    merchs.Tafsil_No1 = X[i]["Tafsil_No1"].ToString();
                    
                    merchs.Merch_Descr = X[i]["Merch_Descr"].ToString();
                    merchs.FastMoving = bool.Parse(X[i]["FastMoving"].ToString());
                    merchs.NormalMoving = bool.Parse(X[i]["NormalMoving"].ToString());
                    merchs.SlowMoving = bool.Parse(X[i]["SlowMoving"].ToString());
                    merchs.NoMoving = bool.Parse(X[i]["NoMoving"].ToString());
                    merchs.ID = int.Parse(X[i]["ID"].ToString());
                    
                    lm.Add(merchs);
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("error:");
                Console.WriteLine(ex.Message);
            }
            
            return lm.OrderBy(m => m.Merch_Code).ToList();
        }
        public async Task<string> ChangePassword(myuser myUser,string mytoken)
        {
            /*
            /api/myws/ChangePassword
                scon, myapplogin.myapp.company, myapplogin.myapp.year, myapplogin.Username, myapplogin.Password
            */
            string Result = "";
            var mu = new List<KeyValuePair<string, string>>();
            mu.Add(new KeyValuePair<string, string>("myapp.company", myUser.Company));
            mu.Add(new KeyValuePair<string, string>("myapp.year", myUser.Year));
            mu.Add(new KeyValuePair<string, string>("UserName", myUser.UserName));
            mu.Add(new KeyValuePair<string, string>("Password", myUser.Password));
            
            var http = new HttpClient();
            http.DefaultRequestHeaders.Add("Authorization", "Bearer " + mytoken);
            var requestMessage = new HttpRequestMessage()
            {
                Method = new HttpMethod("POST"),
                RequestUri = new Uri(IpAddress + "/api/myws/ChangePassword"),
                Content = new FormUrlEncodedContent(mu)
            };
            
            try
            {
                var response = await http.SendAsync(requestMessage);
                var responseStatusCode = response.StatusCode;

                var responseBody = await response.Content.ReadAsStringAsync();
                Result = responseBody.ToString();
                //Console.WriteLine(Result);
                //"OK"

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Result = ex.Message;
            }
            
            return Result;
        }
        public async Task<List<myuser>> UsersList(MyAppWhere m,string mytoken)
        {
            var LUser = new List<myuser>();
            string Result = "";
            var mu = new List<KeyValuePair<string, string>>();
            mu.Add(new KeyValuePair<string, string>("myapp.company", m.myapp.Company));
            mu.Add(new KeyValuePair<string, string>("myapp.year", m.myapp.Year));
            mu.Add(new KeyValuePair<string, string>("Wheres", m.Wheres));
            var http = new HttpClient();
            http.DefaultRequestHeaders.Add("Authorization", "Bearer " + mytoken);
            var requestMessage = new HttpRequestMessage()
            {
                Method = new HttpMethod("GET"),
                RequestUri = new Uri(IpAddress + "/api/myws/UsersList"),
                Content = new FormUrlEncodedContent(mu)
            };
            
            try
            {
                var response = await http.SendAsync(requestMessage);
                var responseStatusCode = response.StatusCode;

                var responseBody = await response.Content.ReadAsStringAsync();

                Result = responseBody;

                JArray j = JArray.Parse(Result);
                var X = j.ToList();
                
                for (int i =0 ;i<X.Count;i++)
                {
                    var user = new myuser();
                    user.Company =m.myapp.Company;
                    user.Year =m.myapp.Year;
                    user.UserName =X[i]["username"].ToString();
                    user.Password =X[i]["password"].ToString();
                    user.grant_type = "";
                    
                    LUser.Add(user);
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            return LUser.OrderBy(m => m.UserName).ToList();
        }
        
    }
    /*
        merchs.Technical_No = X[i]["Technical_No"].ToString();
        merchs.Supplier_No = X[i]["Supplier_No"].ToString();
        merchs.Technical_No_ChangedTo = X[i]["Technical_No_ChangedTo"].ToString();
        merchs.Supplier_No_ChangedTo = X[i]["Supplier_No_ChangedTo"].ToString();
        merchs.Technical_No_ChangedFrom = X[i]["Technical_No_ChangedFrom"].ToString();
        merchs.Supplier_No_ChangedFrom = X[i]["Supplier_No_ChangedFrom"].ToString();
        merchs.Barcode_No = X[i]["Barcode_No"].ToString();
        merchs.Merch_Type1 = bool.Parse(X[i]["Merch_Type1"].ToString());
        merchs.Merch_Type2 = bool.Parse(X[i]["Merch_Type2"].ToString());
        merchs.Merch_Type3 = bool.Parse(X[i]["Merch_Type3"].ToString());
        merchs.Merch_Type4 = bool.Parse(X[i]["Merch_Type4"].ToString());
        merchs.Merch_Type5 = bool.Parse(X[i]["Merch_Type5"].ToString());
        merchs.Merch_Type6 = bool.Parse(X[i]["Merch_Type6"].ToString());
        merchs.Merch_Type7 = bool.Parse(X[i]["Merch_Type7"].ToString());
        merchs.Merch_Type8 = bool.Parse(X[i]["Merch_Type8"].ToString());
        merchs.Merch_Type9 = bool.Parse(X[i]["Merch_Type9"].ToString());
        merchs.Merch_Type10 = bool.Parse(X[i]["Merch_Type10"].ToString());
        merchs.Merch_Sarmayeh = bool.Parse(X[i]["Merch_Sarmayeh"].ToString());
        merchs.Merch_Masrafi = bool.Parse(X[i]["Merch_Masrafi"].ToString());
        merchs.Merch_Expirable = bool.Parse(X[i]["Merch_Expirable"].ToString());
        merchs.Weight = int.Parse(X[i]["Weight"].ToString());
        merchs.Packing = X[i]["Packing"].ToString();
        merchs.LeadTime = int.Parse(X[i]["LeadTime"].ToString());
        merchs.SafetyStock = int.Parse(X[i]["SafetyStock"].ToString());
        merchs.Sales_Price_DealerNet = decimal.Parse(X[i]["Sales_Price_DealerNet"].ToString());
        merchs.Purchase_Price = decimal.Parse(X[i]["Purchase_Price"].ToString());
        merchs.Purchase_Price_DealerNet = decimal.Parse(X[i]["Purchase_Price_DealerNet"].ToString());
        merchs.Sales_Price1 = decimal.Parse(X[i]["Sales_Price1"].ToString());
        merchs.Sales_Price2 = decimal.Parse(X[i]["Sales_Price2"].ToString());
        merchs.Sales_Price3 = decimal.Parse(X[i]["Sales_Price3"].ToString());
        merchs.Sales_Price4 = decimal.Parse(X[i]["Sales_Price4"].ToString());
        merchs.Sales_Price5 = decimal.Parse(X[i]["Sales_Price5"].ToString());
        merchs.Sales_Price6 = decimal.Parse(X[i]["Sales_Price6"].ToString());
        merchs.Sales_Price7 = decimal.Parse(X[i]["Sales_Price7"].ToString());
        merchs.Sales_Price8 = decimal.Parse(X[i]["Sales_Price8"].ToString());
        merchs.Sales_Price9 = decimal.Parse(X[i]["Sales_Price9"].ToString());
        merchs.Sales_Price10 = decimal.Parse(X[i]["Sales_Price10"].ToString());
        merchs.Sales_Price11 = decimal.Parse(X[i]["Sales_Price11"].ToString());
        merchs.Sales_Price12 = decimal.Parse(X[i]["Sales_Price12"].ToString());
        merchs.Sales_Price13 = decimal.Parse(X[i]["Sales_Price13"].ToString());
        merchs.Sales_Price14 = decimal.Parse(X[i]["Sales_Price14"].ToString());
        merchs.Sales_Price15 = decimal.Parse(X[i]["Sales_Price15"].ToString());
        merchs.Last_Purchase_Price = decimal.Parse(X[i]["Last_Purchase_Price"].ToString());
        merchs.Last_Purchase_Date = X[i]["Last_Purchase_Date"].ToString();
        merchs.Consumer_Price = decimal.Parse(X[i]["Consumer_Price"].ToString());
        merchs.Days_Settle = int.Parse(X[i]["Days_Settle"].ToString());
        merchs.VAT_Prcnt = int.Parse(X[i]["VAT_Prcnt"].ToString());
        merchs.Toll_Prcnt = int.Parse(X[i]["Toll_Prcnt"].ToString());
        merchs.Location = X[i]["Location"].ToString();
        merchs.CostBasis = decimal.Parse(X[i]["Last_Purchase_Price"].ToString());
        merchs.CostBasis_Date = X[i]["CostBasis_Date"].ToString();
        merchs.Calc_Discount_Purchase = bool.Parse(X[i]["Calc_Discount_Purchase"].ToString()); 
        merchs.Calc_Discount_Sales = bool.Parse(X[i]["Calc_Discount_Sales"].ToString());
        merchs.Calc_Discount_Person = bool.Parse(X[i]["Calc_Discount_Person"].ToString());
        merchs.Discount_Purchase = int.Parse(X[i]["Discount_Purchase"].ToString());
        merchs.Discount_Sales = int.Parse(X[i]["Discount_Sales"].ToString());
        merchs.Discount_Sales_DealerNet = int.Parse(X[i]["Discount_Sales_DealerNet"].ToString());
        merchs.Product_Time_Std = int.Parse(X[i]["Product_Time_Std"].ToString());
        merchs.Product_Time_Real = int.Parse(X[i]["Product_Time_Real"].ToString());
        merchs.CostBasis_Std = int.Parse(X[i]["CostBasis_Std"].ToString());
        merchs.CostBasis_Real = int.Parse(X[i]["CostBasis_Real"].ToString());
        merchs.Qty1_Card = int.Parse(X[i]["Qty1_Card"].ToString());
        merchs.Qty2_Card = int.Parse(X[i]["Qty2_Card"].ToString());
        merchs.Qty3_Card = int.Parse(X[i]["Qty3_Card"].ToString());
        merchs.Qty4_Card = int.Parse(X[i]["Qty4_Card"].ToString());
        merchs.Qty5_Card = int.Parse(X[i]["Qty5_Card"].ToString());
        merchs.Qty6_Card = int.Parse(X[i]["Qty6_Card"].ToString());
        merchs.Qty7_Card = int.Parse(X[i]["Qty7_Card"].ToString());
        merchs.Qty8_Card = int.Parse(X[i]["Qty8_Card"].ToString());
        merchs.Qty9_Card = int.Parse(X[i]["Qty9_Card"].ToString());
        merchs.Qty10_Card = int.Parse(X[i]["Qty10_Card"].ToString());
        merchs.Qty11_Card = int.Parse(X[i]["Qty11_Card"].ToString());
        merchs.Qty12_Card = int.Parse(X[i]["Qty12_Card"].ToString());
        merchs.Qty1 = int.Parse(X[i]["Qty1"].ToString());
        merchs.Qty2 = int.Parse(X[i]["Qty2"].ToString());
        merchs.Qty3 = int.Parse(X[i]["Qty3"].ToString());
        merchs.Qty4 = int.Parse(X[i]["Qty4"].ToString());
        merchs.Qty5 = int.Parse(X[i]["Qty5"].ToString());
        merchs.Qty6 = int.Parse(X[i]["Qty6"].ToString());
        merchs.Qty7 = int.Parse(X[i]["Qty7"].ToString());
        merchs.Qty8 = int.Parse(X[i]["Qty8"].ToString());
        merchs.Qty9 = int.Parse(X[i]["Qty9"].ToString());
        merchs.Qty10 = int.Parse(X[i]["Qty10"].ToString());
        merchs.Qty11 = int.Parse(X[i]["Qty11"].ToString());
        merchs.Qty12 = int.Parse(X[i]["Qty12"].ToString());
        merchs.Qty1_2 = int.Parse(X[i]["Qty1_2"].ToString());
        merchs.Qty2_2 = int.Parse(X[i]["Qty2_2"].ToString());
        merchs.Qty3_2 = int.Parse(X[i]["Qty3_2"].ToString());
        merchs.Qty4_2 = int.Parse(X[i]["Qty4_2"].ToString());
        merchs.Qty5_2 = int.Parse(X[i]["Qty5_2"].ToString());
        merchs.Qty6_2 = int.Parse(X[i]["Qty6_2"].ToString());
        merchs.Qty7_2 = int.Parse(X[i]["Qty7_2"].ToString());
        merchs.Qty8_2 = int.Parse(X[i]["Qty8_2"].ToString());
        merchs.Qty9_2 = int.Parse(X[i]["Qty9_2"].ToString());
        merchs.Qty10_2 = int.Parse(X[i]["Qty10_2"].ToString());
        merchs.Qty11_2 = int.Parse(X[i]["Qty11_2"].ToString());
        merchs.Qty12_2 = int.Parse(X[i]["Qty12_2"].ToString());
        merchs.Qty1_3 = int.Parse(X[i]["Qty1_3"].ToString());
        merchs.Qty2_3 = int.Parse(X[i]["Qty2_3"].ToString());
        merchs.Qty3_3 = int.Parse(X[i]["Qty3_3"].ToString());
        merchs.Qty4_3 = int.Parse(X[i]["Qty4_3"].ToString());
        merchs.Qty5_3 = int.Parse(X[i]["Qty5_3"].ToString());
        merchs.Qty6_3 = int.Parse(X[i]["Qty6_3"].ToString());
        merchs.Qty7_3 = int.Parse(X[i]["Qty7_3"].ToString());
        merchs.Qty8_3 = int.Parse(X[i]["Qty8_3"].ToString());
        merchs.Qty9_3 = int.Parse(X[i]["Qty9_3"].ToString());
        merchs.Qty10_3 = int.Parse(X[i]["Qty10_3"].ToString());
        merchs.Qty11_3 = int.Parse(X[i]["Qty11_3"].ToString());
        merchs.Qty12_3 = int.Parse(X[i]["Qty12_3"].ToString());
    */
}
// ** hame factor ha beshan sefareshat
// ** relation jadvale order ba order details
// ** tafsili ha ke tike sherkat o ashkhas khordeh biad
// ** hatman bayad name moshtari biad
