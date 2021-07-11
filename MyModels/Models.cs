using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pwaSepehr.MyModels
{
    public class MyApp
    {
        public string Company { get; set; }
        public string Year { get; set; }
    }
    public class UserLogin
    {
        public MyApp myapp { get; set; }
        //public string Company { get; set; } ////= "Aroos";
        //public string Year { get; set; }// = "1400";
        public string UserName { get; set; } //= "Admin";
        public string Password { get; set; } //= "123456";

    }
    public class myuser
    {
        public string Company { get; set; }
        public string Year { get; set; }
        [Required(ErrorMessage="نام کاربری الزامی است")]
        public string UserName { get; set; }
        [Required(ErrorMessage="کلمه عبور الزامی است")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string Password2 { get; set; }
        public string grant_type { get; set; }
    }
    public class MyAppWhere
    {
        public MyApp myapp { get; set; }
        public string Wheres { get; set; }
    }
    public class Company
    {
        public string CompanyID { get;set;}
        public string Name  {get;set;}
    }
    public class Year
    {
        public int FiYearID {get;set;}
        public string FinYear {get;set;}
        public string Description {get;set;}
        public string LastYear {get;set;}
    }
    //sefaresh pishfactor
    public class Orders_Details
    {
        /*
        getVal[i].Row, getVal[i].Merch_Code, getVal[i].Merch_Name, getVal[i].Descr,
                getVal[i].MajorUnit, getVal[i].MinorUnit, getVal[i].Major_Minor_Related,
                getVal[i].Price, getVal[i].Qty, getVal[i].MQty, getVal[i].Qty_Inv, getVal[i].MQty_Inv,
                getVal[i].Total, getVal[i].Discount, getVal[i].Discount_Price, getVal[i].ID
        */
        [Display(Name = "ردیف")]
        public int Row { get; set; }

        [Display(Name = "شماره سند")]
        public string Order_No { get; set; }
        // public virtual Orders_Doc Orders_Doc { get; set; }

        [Display(Name = "کد کالا")]
        public string Merch_Code { get; set; }
        [Display(Name = "نام کالا")]
        public string Merch_Name { get; set; }

        [Display(Name = "شرح ردیف")]
        public string Descr { get; set; }

        [Display(Name = "قیمت")]
        public decimal Price { get; set; }

        [Display(Name = "تعدا خرده")]
        public float Qty { get; set; }

        [Display(Name = "تعداد عمده")]
        public float MQty { get; set; }

        [Display(Name = "تعداد موجود در انبار")]
        public float Qty_Inv { get; set; }

        [Display(Name = "تعداد عمده انبار")]
        public float MQty_Inv { get; set; }

        [Display(Name = "جمع")]
        public decimal Total { get; set; }

        [Display(Name = "درصد تخفیف")]
        public int Discount { get; set; }

        [Display (Name = "مبلغ تخفیف")]
        public decimal Discount_Price { get; set; }

        public string MajorUnit { get; set; } 
        public string MinorUnit { get; set; } 
        public bool Major_Minor_Related { get; set; }

        public int ID { get; set; }
    }
    public class Orders_Doc
    {
        [Key]
        [Display (Name = "شماره سند")]
        public string Order_No { get; set; }

        [Display(Name = "تاریخ سند")]
        public string Order_Date { get; set; }

        [Display(Name = "شرح سند")]
        public string Order_Desc { get; set; }

        [Display(Name = "شماره پیش سفارش")]
        public string PreFactor_No { get; set; }

        [Display(Name = "کد مرکز")]
        public string Center_No { get; set; }

        [Display(Name = "عامل فروش")]
        public string Sales_Person_No { get; set; }

        [Display(Name = "تاریخ اعتبار" )]
        public string Expire_Date { get; set; }

        [Display(Name = "شرایط سفارش" )]
        public string Order_Condition { get; set; }

        [Display(Name = "تاریخ تحویل")]
        public string Order_Dlv_Date { get; set; }

        [Display(Name = "محل تحویل")]
        public string Order_Dlv_Place { get; set; }

        [Display(Name = "مدت اعتبار")]
        public string Order_Expire { get; set; }

        [Display(Name = "پایه مفتول مس")]
        public decimal Copper_Base { get; set; }

        [Display(Name = "نوع بسته بندی")]
        public string Packing { get; set; }

        [Display(Name = "حسابهای بانکی" )]
        public string BankAccounts { get; set; }

        [Display(Name = "اقدام کننده")]
        public string Followup_Person { get; set; }

        [Display(Name = "نام مشتری")]
        public string Customer_Name { get; set; }

        [Display(Name = "کد مشتری")]
        public string Acc_No { get; set; }

        [Display(Name = "کد تفصیلی 1" )]
        public string Tafsil_No1 { get; set; }

        [Display(Name = "کد تفصیلی 2")]
        public string Tafsil_No2 { get; set; }

        [Display(Name = "کد تفصیلی 3")]
        public string Tafsil_No3 { get; set; }

        [Display(Name = "شماره سفارش")]
        public string Factor_No { get; set; }

        [Display(Name = "شماره سند انبار")]
        public string SDoc_No { get; set; }

        [Display(Name = "شماره سند انبار خرید")]
        public string SDoc_NoP { get; set; }

        [Display(Name = "کد انبار")]
        public string Store_No { get; set; }

        [Display(Name = "درصد تخفیف")]
        public int Discount_Prcnt { get; set; }

        [Display(Name = "تخفیف")]
        public decimal Discount { get; set; }

        [Display(Name = "اضافه سایر")]
        public decimal Extra_Charge { get; set; }

        [Display(Name = "کسر سایر")]
        public decimal Extra_Costs { get; set; }

        [Display(Name = "تجمیع عوارض")]
        public decimal Toll { get; set; }

        [Display(Name = "مالیات بر ارزش افزوده")]
        public decimal VAT { get; set; }

        [Display(Name = "توضیحات")]
        public string Notes { get; set; }

        [Display(Name = "تعدا بسته ها")]
        public int Package_Qty { get; set; }

        [Display(Name = "نقدی")]
        public bool Cash { get; set; }

        [Display(Name = "اعتباری")]
        public bool Credit { get; set; }

        [Display(Name = "مبلغ نقدی")]
        public decimal Cash_Value { get; set; }

        [Display(Name = "شهرستان")]
        public bool County { get; set; }

        [Display(Name = "ثبت فروش")]
        public bool SalesMan { get; set; }

        [Display(Name = "ثبت انبارداری")]
        public bool Store_Keeper_Register { get; set; }

        [Display(Name = "ثبت")]
        public bool Register { get; set; }

        [Display(Name = "تسویه")]
        public bool Settle { get; set; }

        [Display(Name = "تاریخ تسویه")]
        public string Settle_Date { get; set; }

        [Display(Name = "تاریخ ایجاد")]
        public string timeCreate { get; set; }

        [Display(Name = "تاریخ آخرین تغییر")]
        public string timeUpdate { get; set; }

        public string UserCreate { get; set; }
        public string UserUpdate { get; set; }

        public bool Order_Cancel { get; set; }

        public int ID { get; set; }
    }
    public class Merchs
    {
        [Key]
        [Display(Name = "کد کالا")]
        public string Merch_Code { get; set; }

        [Display(Name = "نام کالا")]
        public string Merch_Name { get; set; }

        [Display(Name = "نام لاتین")]
        public string LMerch_Name { get; set; }

        [Display(Name = "شماره فنی")]
        public string Technical_No { get; set; }

        [Display(Name = "شماره تامین کننده")]
        public string Supplier_No { get; set; }

        [Display(Name = "شماره فنی تغییر کرده به")]
        public string Technical_No_ChangedTo { get; set; }

        [Display(Name = "شماره تامین کننده تغییر کرده به")]
        public string Supplier_No_ChangedTo { get; set; }

        [Display(Name = "شماره فنی تغییر یافته از")]
        public string Technical_No_ChangedFrom { get; set; }

        [Display(Name = "شماره تامین کننده تغییر یافته از")]
        public string Supplier_No_ChangedFrom { get; set; }

        [Display(Name = "بارکد")]
        public string Barcode_No { get; set; }

        [Display(Name = "نوع کالا محصول")]
        public bool Merch_Type1 { get; set; }

        [Display(Name = "نوع کالا مواد")]
        public bool Merch_Type2 { get; set; }

        [Display(Name = "نوع کالا در جزیان ساخت")]
        public bool Merch_Type3 { get; set; }

        [Display(Name = "نوع کالا ملزومات")]
        public bool Merch_Type4 { get; set; }

        [Display(Name = "نوع کالا قطعات یدکی")]
        public bool Merch_Type5 { get; set; }

        [Display(Name = "خدمات")]
        public bool Merch_Type6 { get; set; }

        [Display(Name = "ابزار آلات")]
        public bool Merch_Type7 { get; set; }

        [Display(Name = "اموال")]
        public bool Merch_Type8 { get; set; }

        [Display(Name = "ضایعات")]
        public bool Merch_Type9 { get; set; }

        [Display(Name = "بسته بندی")]
        public bool Merch_Type10 { get; set; }

        [Display(Name = "کالای سرمایه ای")]
        public bool Merch_Sarmayeh { get; set; }

        [Display(Name = "کالای مصرفی")]
        public bool Merch_Masrafi { get; set; }

        [Display(Name = "تاریخ مصرفی")]
        public bool Merch_Expirable { get; set; }

        [Display(Name = "واحد شمارش خرده")]
        public string MinorUnit { get; set; }

        [Display(Name = "واحد شمارش عمده")]
        public string MajorUnit { get; set; }

        [Display(Name = "تسبت واحد عمده به خرده")]
        public int Major_Minor_Rate { get; set; }

        [Display(Name = "عمده به خرده رابطه دارد")]
        public bool Major_Minor_Related { get; set; }

        [Display(Name = "وزن")]
        public int Weight { get; set; }

        [Display(Name = "نوع بسته بندی")]
        public string Packing { get; set; }

        [Display(Name = "زمان تامین کالا")]
        public int LeadTime { get; set; }

        [Display(Name = "ذخیره احتیاطی")]
        public int SafetyStock { get; set; }

        [Display(Name = "تعداد  حداقل")]
        public int Min_Qty { get; set; }

        [Display(Name = "تعداد  حداکثر")]
        public int Max_Qty { get; set; }

        [Display(Name = "تعدا عادی")]
        public int Normal_Qty { get; set; }

        [Display(Name = "ذخیره احتیاطی")]
        public int Safety_Stock { get; set; }

        [Display(Name = "حداقل سفارش")]
        public int Batch_Qty { get; set; }

        [Display(Name = "قیمت فروش")]
        public decimal Sales_Price { get; set; }

        [Display(Name = "قیمت فروش نمایندگی")]
        public decimal Sales_Price_DealerNet { get; set; }

        [Display(Name = "قیمت خرید")]
        public decimal Purchase_Price { get; set; }

        [Display(Name = "قیمت خرید نمایندگی")]
        public decimal Purchase_Price_DealerNet { get; set; }

        [Display(Name = "قیمت فروش")]
        public decimal Sales_Price1 { get; set; }

        [Display(Name = "قیمت فروش")]
        public decimal Sales_Price2 { get; set; }

        [Display(Name = "قیمت فروش")]
        public decimal Sales_Price3 { get; set; }

        [Display(Name = "قیمت فروش")]
        public decimal Sales_Price4 { get; set; }

        [Display(Name = "قیمت فروش")]
        public decimal Sales_Price5 { get; set; }

        [Display(Name = "قیمت فروش")]
        public decimal Sales_Price6 { get; set; }

        [Display(Name = "قیمت فروش")]
        public decimal Sales_Price7 { get; set; }

        [Display(Name = "قیمت فروش")]
        public decimal Sales_Price8 { get; set; }

        [Display(Name = "قیمت فروش")]
        public decimal Sales_Price9 { get; set; }

        [Display(Name = "قیمت فروش")]
        public decimal Sales_Price10 { get; set; }

        [Display(Name = "قیمت فروش")]
        public decimal Sales_Price11 { get; set; }

        [Display(Name = "قیمت فروش")]
        public decimal Sales_Price12 { get; set; }

        [Display(Name = "قیمت فروش")]
        public decimal Sales_Price13 { get; set; }

        [Display(Name = "قیمت فروش")]
        public decimal Sales_Price14 { get; set; }

        [Display(Name = "قیمت فروش")]
        public decimal Sales_Price15 { get; set; }

        [Display(Name = "آخرین قیمت خرید")]
        public decimal Last_Purchase_Price { get; set; }

        [Display(Name = "تاریخ آخرین قیمت خرید")]
        public string Last_Purchase_Date { get; set; }

        [Display(Name = "قیمت مصرف کننده")]
        public decimal Consumer_Price { get; set; }

        [Display(Name = "تعداد روز تسویه کالا")]
        public int Days_Settle { get; set; }

        [Display(Name = "درصد مالیات بر ارزش افزوده کالا")]
        public int VAT_Prcnt { get; set; }

        [Display(Name = "درصد عوارض کالا")]
        public int Toll_Prcnt { get; set; }

        [Display(Name = "محل در انبار")]
        public string Location { get; set; }

        [Display(Name = "آخرین کالا")]
        public bool Last_Merch { get; set; }

        [Display(Name = "قیمت تمام شده")]
        public decimal CostBasis { get; set; }

        [Display(Name = "تاریخ محاسبه قیمت تمام شده")]
        public string CostBasis_Date { get; set; }

        public bool Calc_Discount_Purchase { get; set; }
        public bool Calc_Discount_Sales { get; set; }
        public bool Calc_Discount_Person { get; set; }

        public int Discount_Purchase { get; set; }
        public int Discount_Sales { get; set; }
        public int Discount_Sales_DealerNet { get; set; }


        [Display(Name = "زمان استاندارد تولید")]
        public int Product_Time_Std { get; set; }

        [Display(Name = "زمان واقعی تولید")]
        public int Product_Time_Real { get; set; }

        [Display(Name = "بهای تمام شده تولید - استاندارد")]
        public decimal CostBasis_Std { get; set; }

        [Display(Name = "بهای تمام شده تولید - واقعی")]
        public decimal CostBasis_Real { get; set; }

        [Display(Name = "فعال")]
        public bool Active { get; set; }

        [Display(Name = "شماره حساب")]
        public string Acc_No { get; set; }

        [Display(Name = "شماره حساب تفصیلی")]
        public string Tafsil_No1 { get; set; }

        [Display(Name = "شرح کالا")]
        public string Merch_Descr { get; set; }

        [Display(Name = "پرمصرف")]
        public bool FastMoving { get; set; }

        [Display(Name = "متوسط مصرف")]
        public bool NormalMoving { get; set; }

        [Display(Name = "کم مصرف")]
        public bool SlowMoving { get; set; }

        [Display(Name = "راکد")]
        public bool NoMoving { get; set; }

        [Display(Name = "موجودی کادکس ماه 1")]
        public int Qty1_Card { get; set; }

        [Display(Name = "موجودی کادکس ماه 2")]
        public int Qty2_Card { get; set; }

        [Display(Name = "موجودی کادکس ماه 3")]
        public int Qty3_Card { get; set; }

        [Display(Name = "موجودی کادکس ماه 4")]
        public int Qty4_Card { get; set; }

        [Display(Name = "موجودی کادکس ماه 5")]
        public int Qty5_Card { get; set; }

        [Display(Name = "موجودی کادکس ماه 6")]
        public int Qty6_Card { get; set; }

        [Display(Name = "موجودی کادکس ماه 7")]
        public int Qty7_Card { get; set; }

        [Display(Name = "موجودی کادکس ماه 8")]
        public int Qty8_Card { get; set; }

        [Display(Name = "موجودی کادکس ماه 9")]
        public int Qty9_Card { get; set; }

        [Display(Name = "موجودی کادکس ماه 10")]
        public int Qty10_Card { get; set; }

        [Display(Name = "موجودی کادکس ماه 11")]
        public int Qty11_Card { get; set; }

        [Display(Name = "موجودی کادکس ماه 12")]
        public int Qty12_Card { get; set; }

        [Display(Name = "موجودی عینی ماه 1")]
        public int Qty1 { get; set; }

        [Display(Name = "موجودی عینی ماه 2")]
        public int Qty2 { get; set; }

        [Display(Name = "موجودی عینی ماه 3")]
        public int Qty3 { get; set; }

        [Display(Name = "موجودی عینی ماه 4")]
        public int Qty4 { get; set; }

        [Display(Name = "موجودی عینی ماه 5")]
        public int Qty5 { get; set; }

        [Display(Name = "موجودی عینی ماه 6")]
        public int Qty6 { get; set; }

        [Display(Name = "موجودی عینی ماه 7")]
        public int Qty7 { get; set; }

        [Display(Name = "موجودی عینی ماه 8")]
        public int Qty8 { get; set; }

        [Display(Name = "موجودی عینی ماه 9")]
        public int Qty9 { get; set; }

        [Display(Name = "موجودی عینی ماه 10")]
        public int Qty10 { get; set; }

        [Display(Name = "موجودی عینی ماه 11")]
        public int Qty11 { get; set; }

        [Display(Name = "موجودی عینی ماه 12")]
        public int Qty12 { get; set; }

        [Display(Name = "موجودی عینی ماه 1 شمارش دوم")]
        public int Qty1_2 { get; set; }

        [Display(Name = "موجودی عینی ماه 2 شمارش دوم")]
        public int Qty2_2 { get; set; }

        [Display(Name = "موجودی عینی ماه 3 شمارش دوم")]
        public int Qty3_2 { get; set; }

        [Display(Name = "موجودی عینی ماه 4 شمارش دوم")]
        public int Qty4_2 { get; set; }

        [Display(Name = "موجودی عینی ماه 5 شمارش دوم")]
        public int Qty5_2 { get; set; }

        [Display(Name = "موجودی عینی ماه 6 شمارش دوم")]
        public int Qty6_2 { get; set; }

        [Display(Name = "موجودی عینی ماه 7 شمارش دوم")]
        public int Qty7_2 { get; set; }

        [Display(Name = "موجودی عینی ماه 8 شمارش دوم")]
        public int Qty8_2 { get; set; }

        [Display(Name = "موجودی عینی ماه 9 شمارش دوم")]
        public int Qty9_2 { get; set; }

        [Display(Name = "موجودی عینی ماه 10 شمارش دوم")]
        public int Qty10_2 { get; set; }

        [Display(Name = "موجودی عینی ماه 11 شمارش دوم")]
        public int Qty11_2 { get; set; }

        [Display(Name = "موجودی عینی ماه 12 شمارش دوم")]
        public int Qty12_2 { get; set; }

        [Display(Name = "موجودی عینی ماه 1 شمارش سوم")]
        public int Qty1_3 { get; set; }

        [Display(Name = "موجودی عینی ماه 2 شمارش سوم")]
        public int Qty2_3 { get; set; }

        [Display(Name = "موجودی عینی ماه 3 شمارش سوم")]
        public int Qty3_3 { get; set; }

        [Display(Name = "موجودی عینی ماه 4 شمارش سوم")]
        public int Qty4_3 { get; set; }

        [Display(Name = "موجودی عینی ماه 5 شمارش سوم")]
        public int Qty5_3 { get; set; }

        [Display(Name = "موجودی عینی ماه 6 شمارش سوم")]
        public int Qty6_3 { get; set; }

        [Display(Name = "موجودی عینی ماه 7 شمارش سوم")]
        public int Qty7_3 { get; set; }

        [Display(Name = "موجودی عینی ماه 8 شمارش سوم")]
        public int Qty8_3 { get; set; }

        [Display(Name = "موجودی عینی ماه 9 شمارش سوم")]
        public int Qty9_3 { get; set; }

        [Display(Name = "موجودی عینی ماه 10 شمارش سوم")]
        public int Qty10_3 { get; set; }

        [Display(Name = "موجودی عینی ماه 11 شمارش سوم")]
        public int Qty11_3 { get; set; }

        [Display(Name = "موجودی عینی ماه 12 شمارش سوم")]
        public int Qty12_3 { get; set; }
        
        public int ID { get; set; }
    }
    public class Accounts
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "شماره حساب الزامی است")]
        [Display(Name = "شماره حساب")]
        public string Acc_No { get; set; }

        [Required(ErrorMessage = "نام حساب الزامی است")]
        [Display(Name = "نام حساب")]
        public string Acc_Name { get; set; }

        [Display(Name = "نام لاتین حساب")]
        public string LAcc_Name { get; set; }

        [Display(Name = "حساب نقدی")]
        public bool Cash { get; set; }

        [Display(Name = "حساب پايانه فروش")]
        public bool POS { get; set; }

        [Display(Name = "حساب فروش")]
        public bool Sales { get; set; }

        [Display(Name = "حساب برگشت از فروش")]
        public bool ReturnSales { get; set; }

        [Display(Name = "حساب خرید")]
        public bool Purchase { get; set; }

        [Display(Name = "حساب برگشت از خرید")]
        public bool ReturnPurchase { get; set; }

        [Display(Name = "حساب درآمد")]
        public bool Revenue { get; set; }

        [Display(Name = "حساب هزینه")]
        public bool Expense { get; set; }

        [Display(Name = "حساب بانک")]
        public bool Bank { get; set; }

        [Display(Name = "حساب اسناد بانک")]
        public bool InBank { get; set; }

        [Display(Name = "حساب سایر درآمد")]
        public bool Other_Revenue { get; set; }

        [Display(Name = "حساب سایر هزینه")]
        public bool Other_Expense { get; set; }

        [Display(Name = "حساب تخفیف فروش")]
        public bool Sales_Discount { get; set; }

        [Display(Name = "حساب تخفیف خرید")]
        public bool Purchase_Discount { get; set; }

        [Display(Name = "انحراف بهاي خريد")]
        public bool Purchase_Variance { get; set; }

        [Display(Name = "انحراف بهاي مصرف")]
        public bool Consume_Variance { get; set; }

        [Display(Name = "حساب اشخاص تجاری")]
        public bool Customer { get; set; }

        [Display(Name = "ويزيتور")]
        public bool Visitor { get; set; }

        [Display(Name = "حساب اسناد دریافتنی")]
        public bool Receivable_Acc { get; set; }

        [Display(Name = "حساب اسناد دریافتنی برگشتي")]
        public bool Receivable_Return_Acc { get; set; }

        [Display(Name = "حساب اسناد پرداختنی")]
        public bool Payable_Acc { get; set; }

        [Display(Name = "موجودی کالا محصول")]
        public bool Product_Acc { get; set; }

        [Display(Name = "موجودی کالا مواد")]
        public bool Raw_Acc { get; set; }

        [Display(Name = "موجودی کالا درجريان ساخت")]
        public bool InProgress_Acc { get; set; }

        [Display(Name = "موجودی کالا ملزومات")]
        public bool Supplies_Acc { get; set; }

        [Display(Name = "موجودی کالا قطعات يدكي")]
        public bool Parts_Acc { get; set; }

        [Display(Name = "موجودی کالا ابزار")]
        public bool Tools_Acc { get; set; }

        [Display(Name = "موجودی کالا اموال")]
        public bool Asset_Acc { get; set; }

        [Display(Name = "موجودی ضايعات")]
        public bool Pert_Acc { get; set; }

        [Display(Name = "موجودي بسته بندي")]
        public bool Packing_Acc { get; set; }

        [Display(Name = "موجودي كالاي اماني ديگران نزد ما")]
        public bool Deposit_Other_Acc { get; set; }

        [Display(Name = "حساب افتتاحیه")]
        public bool Open_Acc { get; set; }

        [Display(Name = "حساب اختتامیه")]
        public bool Close_Acc { get; set; }

        [Display(Name = "حساب سود و زيان")]
        public bool Loss_Profit { get; set; }

        [Display(Name = "قیمت تمام شده کالای فروخته شده")]
        public bool Cost_Basis { get; set; }

        [Display(Name = "قیمت تمام شده کالای ساخته شده")]
        public bool Cost_BasisP { get; set; }

        [Display(Name = "هزينه مستقيم / سربار جذب شده")]
        public bool CostsProduct { get; set; }

        [Display(Name = "تجميع عوارض")]
        public bool Tolls { get; set; }

        [Display(Name = "هزينه تجميع عوارض")]
        public bool Tolls_Cost { get; set; }

        [Display(Name = "ماليات ارزش افزوده")]
        public bool VAT { get; set; }

        [Display(Name = "ماليات بر ارزش افزوده خريد")]
        public bool VATP { get; set; }

        [Display(Name = "سود تحقق نيافته اقساطي")]
        public bool Profit_Ghesti { get; set; }

        [Display(Name = "آخرین حساب")]
        public bool Last_Acc { get; set; }

        [Display(Name = "مانده بدهکار")]
        public bool Rem_Debit { get; set; }

        [Display(Name = "مانده بستانکار")]
        public bool Rem_Credit { get; set; }

        [Display(Name = "مانده همواره بدهکار")]
        public bool Rem_Debit_All { get; set; }

        [Display(Name = "مانده همواره بستانکار")]
        public bool Rem_Credit_All { get; set; }

        [Display(Name = "ترازنامه اي")]
        public bool Balance { get; set; }

        [Display(Name = "سود و زياني")]
        public bool LoseProfit { get; set; }

        [Display(Name = "انتظامي")]
        public bool Other { get; set; }

        [Display(Name = "پيگيري")]
        public string Followup { get; set; }

        [Display(Name = "فعال")]
        public bool Active { get; set; }

        [Display(Name = "حساب انبار")]
        public bool Acc_Store { get; set; }

        [Display(Name = "حساب فروش")]
        public bool Acc_Sales { get; set; }

        [Display(Name = "حساب خزانه")]
        public bool Acc_PayRecv { get; set; }

        [Display(Name = "حساب حقوق و دستمزد")]
        public bool Acc_PayRoll { get; set; }

        [Display(Name = "حساب ارزي")]
        public bool Acc_Currency { get; set; }

        [Display(Name = "نوع ارز")]
        public string Currency_Type { get; set; }

        [Display(Name = "شرح حساب")]
        public string Notes { get; set; }
    }
    public class Tafsil_Group
    {
        
        [Required(ErrorMessage = "کد گروه تفصیلی الزامی است")]
        public string G_No { get; set; }

        [Display(Name = "نام گروه تفصیلی")]
        [Required(ErrorMessage = "نام گروه تفصیلی الزامی است")]
        public string G_Name { get; set; }

        [Display(Name = "اشخاص")]
        public bool People { get; set; }

        [Display(Name = "شرکتها")]
        public bool Cos { get; set; }

        [Display(Name = "صندوق / تنخواه گردانها")]
        public bool Cashes { get; set; }

        [Display(Name = "بانکها")]
        public bool Banks { get; set; }

        [Display(Name = "مراكز هزينه")]
        public bool CostCenters { get; set; }

        [Display(Name = "مراكز درآمد")]
        public bool ProfitCenters { get; set; }

        [Display(Name = "كالاها")]
        public bool Merchs { get; set; }

        [Display(Name = "كاركنان")]
        public bool Personal { get; set; }

        [Display(Name = "ويزيتور")]
        public bool Visitors { get; set; }

        [Display(Name = "ساير")]
        public bool Others { get; set; }
    }
    public class Tafsil
    {
        [Display(Name = "کد گروه تفصیلی")]
        public string G_No { get; set; }

        [Display(Name = "کد تفصیلی")]
        [Required(ErrorMessage = "کد تفصیلی الزامی است")]
        public string Tafsil_No { get; set; }

        [Display(Name = "نام تفصیلی")]
        [Required(ErrorMessage = "نام تفصیلی الزامی است")]
        public string Tafsil_Name { get; set; }

        [Display(Name = "نام لاتین تفصیلی")]
        public string LTafsil_Name { get; set; }

        [Display(Name = "عنوان")]
        public string Title { get; set; }

        [Display(Name = "نام")]
        public string First_Name { get; set; }

        [Display(Name = "نام خانوادگی")]
        public string Last_Name { get; set; }

        [Display(Name = "سمت")]
        public string Job_Title { get; set; }

        [Display(Name = "شرکت")]
        public string Company { get; set; }

        [Display(Name = "شماره اقتصادي")]
        public string Economic_Code { get; set; }

        [Display(Name = "كد ملي")]
        public string National_Code { get; set; }

        [Display(Name = "شناسه ملي")]
        public string National_ID { get; set; }

        [Display(Name = "مشخصات")]
        public string Info { get; set; }

        [Display(Name = "استان")]
        public string State { get; set; }

        [Display(Name = "شهر")]
        public string City { get; set; }

        [Display(Name = "شهر منطقه")]
        public string Town { get; set; }

        [Display(Name = "منظقه")]
        public string Region { get; set; }

        [Display(Name = "آدرس پستی 1")]
        public string post_Address { get; set; }

        [Display(Name = "آدرس پستی 2")]
        public string post_Address2 { get; set; }

        [Display(Name = "استان")]
        public string LState { get; set; }

        [Display(Name = "شهر")]
        public string LCity { get; set; }

        [Display(Name = "شهر منطقه")]
        public string LTown { get; set; }

        [Display(Name = "آدرس پستی 1")]
        public string Lpost_Address { get; set; }

        [Display(Name = "کد پستی")]
        public string Postal_Code { get; set; }

        [Display(Name = "کد پستی 2")]
        public string Postal_Code2 { get; set; }

        [Display(Name = "ایمیل")]
        public string Email { get; set; }

        [Display(Name = "شماره تلفن 1")]
        public string Tel_No1 { get; set; }

        [Display(Name = "شماره تلفن 2")]
        public string Tel_No2 { get; set; }

        [Display(Name = "شماره تلفن 3")]
        public string Tel_No3 { get; set; }

        [Display(Name = "شماره تلفن 4")]
        public string Tel_No4 { get; set; }

        [Display(Name = "شماره فکس")]
        public string Fax_No { get; set; }

        [Display(Name = "کلمه عبور")]
        public string Password { get; set; }

        [Display(Name = "شماره موبایل")]
        public string Mobile_no { get; set; }

        [Display(Name = "حداکثر اعتبار")]
        public decimal MaxCredit { get; set; }

        [Display(Name = "تعداد ماه عرف")]
        public int Orf_Month { get; set; }

        [Display(Name = "درصد تخفیف")]
        public Single Discount_Prcnt { get; set; }

        [Display(Name = "نمایندگی")]
        public bool DealerNet { get; set; }

        [Display(Name = "")]
        public int Sales_Price_No { get; set; }

        [Display(Name = "ويزيتور")]
        public bool Visitor { get; set; }

        [Display(Name = "درصد ويزيتوري")]
        public Single Visitor_Prcnt { get; set; }

        [Display(Name = "باربری")]
        public string Transporter { get; set; }

        [Display(Name = "هزينه حمل")]
        public decimal Freight_Charge { get; set; }

        [Display(Name = "شهرستان")]
        public bool County { get; set; }

        [Display(Name = "تهران")]
        public bool Tehran { get; set; }

        [Display(Name = "بازار")]
        public bool Bazar { get; set; }

        [Display(Name = "شوش")]
        public bool Shoosh { get; set; }

        [Display(Name = "فعال")]
        public bool Active { get; set; }

        [Display(Name = "حساب ارزي")]
        public bool Acc_Currency { get; set; }

        [Display(Name = "نوع ارز")]
        public string Currency_Type { get; set; }

        [Display(Name = "پيگيري")]
        public string Followup { get; set; }

        [Display(Name = "مانده بدهکار")]
        public bool Rem_Debit { get; set; }

        [Display(Name = "مانده بستانکار")]
        public bool Rem_Credit { get; set; }

        [Display(Name = "مانده همواره بدهکار")]
        public bool Rem_Debit_All { get; set; }

        [Display(Name = "مانده همواره بستانکار")]
        public bool Rem_Credit_All { get; set; }

        [Display(Name = "مانده حساب دفتري")]
        public decimal RemAcc { get; set; }

        [Display(Name = "اسناد دريافتني سررسيد نشده")]
        public decimal NotMatureRecvDocs { get; set; }

        [Display(Name = "چكهاي برگشتي")]
        public decimal ReturnedRecvDocs { get; set; }

        [Display(Name = "جمع فروش")]
        public decimal TotalSales { get; set; }

        [Display(Name = "مانده اعتبار")]
        public decimal RemCredit { get; set; }

        [Display(Name = "شماره كارت بانكي")]
        public string BankCard_No { get; set; }

        [Display(Name = "شماره شبا")]
        public string Sheba_No { get; set; }

        [Display(Name = "سیستم خرید")]
        public bool Purchase_Sys { get; set; }

        [Display(Name = "سیستم فروش")]
        public bool Sales_Sys { get; set; }

    }
    public class Acc_Tafsil
    {
        [Key]
        public int ID { get; set; }

        public string Acc_No { get; set; }

        public string G_No { get; set; }

        public string No_Tafsil { get; set; }
    }
    public class MyAppOrderDoc
    {
        public MyApp myapp { get; set; }
        public string Order_No { get; set; }
        public string Order_Date { get; set; }
        public string Order_Desc { get; set; }
        public string Customer_Name { get; set; }
        public string  Acc_No { get; set; }
        public string Tafsil_No1 { get; set; }
        public string Tafsil_No2 { get; set; }
        public string Tafsil_No3 { get; set; }
    }
    public class myOrderDoc 
    {
        public string Order_No { get; set; }
        [Required (ErrorMessage="تاریخ الزامی است")]
        public string Order_Date { get; set; }
        [Required (ErrorMessage="شرح الزامی است")]
        public string Order_Desc { get; set; }
        public string Customer_Name { get; set; }
        public string Acc_No { get; set; }
        [Required (ErrorMessage="نام مشتری الزامی است")]
        public string Tafsil_No1 { get; set; }
        public string Tafsil_No2 { get; set; }
        public string Tafsil_No3 { get; set; }
    }
    public class myOrderDetails
    {
        public string Order_No { get; set; }
        public int Row { get; set; }
        public string Merch_Code { get; set; }
        public string Merch_Name { get; set; }
        public string  Descr { get; set; }
        public float MQty { get; set; }
        public float Qty { get; set; }
        public decimal Price { get; set; }
        public decimal Total { get; set; }
        public int Discount { get; set; }
        public decimal Discount_Price { get; set; }

    }
    public class MyAppOrderDetails
    {
        public MyApp myapp { get; set; }
        public string Order_No { get; set; }
        public int Row { get; set; }
        public string Merch_Code { get; set; }
        public string Merch_Name { get; set; }
        public string  Descr { get; set; }
        public float MQty { get; set; }
        public float Qty { get; set; }
        public float Qty_Inv { get; set; }
        public float MQty_Inv { get; set; }
        public decimal Price { get; set; }
        public decimal Total { get; set; }
        public int Discount { get; set; }
        public decimal Discount_Price { get; set; }
        public bool Insert { get; set; }
    }
    public class mySearcOrders
    {
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string CustomerName { get; set; }
    }
}
