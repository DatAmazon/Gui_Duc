﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace giadinhthoxinh.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class giadinhthoxinhEntities1 : DbContext
    {
        public giadinhthoxinhEntities1()
            : base("name=giadinhthoxinhEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tblCategory> tblCategories { get; set; }
        public virtual DbSet<tblCheckinDetail> tblCheckinDetails { get; set; }
        public virtual DbSet<tblCheckoutDetail> tblCheckoutDetails { get; set; }
        public virtual DbSet<tblImage> tblImages { get; set; }
        public virtual DbSet<tblImportMaterial> tblImportMaterials { get; set; }
        public virtual DbSet<tblImportOrder> tblImportOrders { get; set; }
        public virtual DbSet<tblMaterColor> tblMaterColors { get; set; }
        public virtual DbSet<tblMaterial> tblMaterials { get; set; }
        public virtual DbSet<tblMaterPriceImport> tblMaterPriceImports { get; set; }
        public virtual DbSet<tblMaterSize> tblMaterSizes { get; set; }
        public virtual DbSet<tblOrder> tblOrders { get; set; }
        public virtual DbSet<tblPermission> tblPermissions { get; set; }
        public virtual DbSet<tblProduct> tblProducts { get; set; }
        public virtual DbSet<tblProductColor> tblProductColors { get; set; }
        public virtual DbSet<tblProductPrice> tblProductPrices { get; set; }
        public virtual DbSet<tblProductSize> tblProductSizes { get; set; }
        public virtual DbSet<tblPromote> tblPromotes { get; set; }
        public virtual DbSet<tblReview> tblReviews { get; set; }
        public virtual DbSet<tblSupplier> tblSuppliers { get; set; }
        public virtual DbSet<tblUser> tblUsers { get; set; }
    
        public virtual ObjectResult<pro_getCategory_Result> pro_getCategory()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<pro_getCategory_Result>("pro_getCategory");
        }
    
        public virtual ObjectResult<pro_getProduct_Result> pro_getProduct()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<pro_getProduct_Result>("pro_getProduct");
        }
    
        public virtual ObjectResult<pro_getPromote_Result> pro_getPromote()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<pro_getPromote_Result>("pro_getPromote");
        }
    
        public virtual ObjectResult<pro_getReceiver_Result> pro_getReceiver()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<pro_getReceiver_Result>("pro_getReceiver");
        }
    
        public virtual ObjectResult<pro_getSupplier_Result> pro_getSupplier()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<pro_getSupplier_Result>("pro_getSupplier");
        }
    
        public virtual int proAddCategory(string sCategoryName)
        {
            var sCategoryNameParameter = sCategoryName != null ?
                new ObjectParameter("sCategoryName", sCategoryName) :
                new ObjectParameter("sCategoryName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("proAddCategory", sCategoryNameParameter);
        }
    
        public virtual int proAddCheckoutDetail(Nullable<int> fK_iOrderID, Nullable<int> fK_iProductID, Nullable<int> iQuantity, Nullable<int> iTotalMoney)
        {
            var fK_iOrderIDParameter = fK_iOrderID.HasValue ?
                new ObjectParameter("FK_iOrderID", fK_iOrderID) :
                new ObjectParameter("FK_iOrderID", typeof(int));
    
            var fK_iProductIDParameter = fK_iProductID.HasValue ?
                new ObjectParameter("FK_iProductID", fK_iProductID) :
                new ObjectParameter("FK_iProductID", typeof(int));
    
            var iQuantityParameter = iQuantity.HasValue ?
                new ObjectParameter("iQuantity", iQuantity) :
                new ObjectParameter("iQuantity", typeof(int));
    
            var iTotalMoneyParameter = iTotalMoney.HasValue ?
                new ObjectParameter("iTotalMoney", iTotalMoney) :
                new ObjectParameter("iTotalMoney", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("proAddCheckoutDetail", fK_iOrderIDParameter, fK_iProductIDParameter, iQuantityParameter, iTotalMoneyParameter);
        }
    
        public virtual int proAddPermission(string sPermissionName, Nullable<int> iState)
        {
            var sPermissionNameParameter = sPermissionName != null ?
                new ObjectParameter("sPermissionName", sPermissionName) :
                new ObjectParameter("sPermissionName", typeof(string));
    
            var iStateParameter = iState.HasValue ?
                new ObjectParameter("iState", iState) :
                new ObjectParameter("iState", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("proAddPermission", sPermissionNameParameter, iStateParameter);
        }
    
        public virtual int proAddPromote(string sPromoteName, Nullable<double> sPromoteRate, Nullable<System.DateTime> dtStartDay, Nullable<System.DateTime> dtEndDay)
        {
            var sPromoteNameParameter = sPromoteName != null ?
                new ObjectParameter("sPromoteName", sPromoteName) :
                new ObjectParameter("sPromoteName", typeof(string));
    
            var sPromoteRateParameter = sPromoteRate.HasValue ?
                new ObjectParameter("sPromoteRate", sPromoteRate) :
                new ObjectParameter("sPromoteRate", typeof(double));
    
            var dtStartDayParameter = dtStartDay.HasValue ?
                new ObjectParameter("dtStartDay", dtStartDay) :
                new ObjectParameter("dtStartDay", typeof(System.DateTime));
    
            var dtEndDayParameter = dtEndDay.HasValue ?
                new ObjectParameter("dtEndDay", dtEndDay) :
                new ObjectParameter("dtEndDay", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("proAddPromote", sPromoteNameParameter, sPromoteRateParameter, dtStartDayParameter, dtEndDayParameter);
        }
    
        public virtual int proAddReview(Nullable<int> fK_iProductID, Nullable<int> fK_iAccountID, Nullable<int> iStarRating, Nullable<System.DateTime> dtReviewTime)
        {
            var fK_iProductIDParameter = fK_iProductID.HasValue ?
                new ObjectParameter("FK_iProductID", fK_iProductID) :
                new ObjectParameter("FK_iProductID", typeof(int));
    
            var fK_iAccountIDParameter = fK_iAccountID.HasValue ?
                new ObjectParameter("FK_iAccountID", fK_iAccountID) :
                new ObjectParameter("FK_iAccountID", typeof(int));
    
            var iStarRatingParameter = iStarRating.HasValue ?
                new ObjectParameter("iStarRating", iStarRating) :
                new ObjectParameter("iStarRating", typeof(int));
    
            var dtReviewTimeParameter = dtReviewTime.HasValue ?
                new ObjectParameter("dtReviewTime", dtReviewTime) :
                new ObjectParameter("dtReviewTime", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("proAddReview", fK_iProductIDParameter, fK_iAccountIDParameter, iStarRatingParameter, dtReviewTimeParameter);
        }
    
        public virtual int proAddSupplier(string sSupplierName, string sPhone, string sEmail, string sAddress)
        {
            var sSupplierNameParameter = sSupplierName != null ?
                new ObjectParameter("sSupplierName", sSupplierName) :
                new ObjectParameter("sSupplierName", typeof(string));
    
            var sPhoneParameter = sPhone != null ?
                new ObjectParameter("sPhone", sPhone) :
                new ObjectParameter("sPhone", typeof(string));
    
            var sEmailParameter = sEmail != null ?
                new ObjectParameter("sEmail", sEmail) :
                new ObjectParameter("sEmail", typeof(string));
    
            var sAddressParameter = sAddress != null ?
                new ObjectParameter("sAddress", sAddress) :
                new ObjectParameter("sAddress", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("proAddSupplier", sSupplierNameParameter, sPhoneParameter, sEmailParameter, sAddressParameter);
        }
    
        public virtual int proAddUser(Nullable<int> fK_iPermissionID, string sEmail, string sPass, string sUserName, string sPhone, string sAddress, Nullable<int> iState)
        {
            var fK_iPermissionIDParameter = fK_iPermissionID.HasValue ?
                new ObjectParameter("FK_iPermissionID", fK_iPermissionID) :
                new ObjectParameter("FK_iPermissionID", typeof(int));
    
            var sEmailParameter = sEmail != null ?
                new ObjectParameter("sEmail", sEmail) :
                new ObjectParameter("sEmail", typeof(string));
    
            var sPassParameter = sPass != null ?
                new ObjectParameter("sPass", sPass) :
                new ObjectParameter("sPass", typeof(string));
    
            var sUserNameParameter = sUserName != null ?
                new ObjectParameter("sUserName", sUserName) :
                new ObjectParameter("sUserName", typeof(string));
    
            var sPhoneParameter = sPhone != null ?
                new ObjectParameter("sPhone", sPhone) :
                new ObjectParameter("sPhone", typeof(string));
    
            var sAddressParameter = sAddress != null ?
                new ObjectParameter("sAddress", sAddress) :
                new ObjectParameter("sAddress", typeof(string));
    
            var iStateParameter = iState.HasValue ?
                new ObjectParameter("iState", iState) :
                new ObjectParameter("iState", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("proAddUser", fK_iPermissionIDParameter, sEmailParameter, sPassParameter, sUserNameParameter, sPhoneParameter, sAddressParameter, iStateParameter);
        }
    
        public virtual ObjectResult<procSelectCheckinDeatailrByID_Result> procSelectCheckinDeatailrByID(Nullable<int> pK_iCheckinDetailID)
        {
            var pK_iCheckinDetailIDParameter = pK_iCheckinDetailID.HasValue ?
                new ObjectParameter("PK_iCheckinDetailID", pK_iCheckinDetailID) :
                new ObjectParameter("PK_iCheckinDetailID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<procSelectCheckinDeatailrByID_Result>("procSelectCheckinDeatailrByID", pK_iCheckinDetailIDParameter);
        }
    
        public virtual ObjectResult<procSelectImageByID_Result> procSelectImageByID(Nullable<int> pK_iImageID)
        {
            var pK_iImageIDParameter = pK_iImageID.HasValue ?
                new ObjectParameter("PK_iImageID", pK_iImageID) :
                new ObjectParameter("PK_iImageID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<procSelectImageByID_Result>("procSelectImageByID", pK_iImageIDParameter);
        }
    
        public virtual ObjectResult<procSelectImportOrderByID_Result> procSelectImportOrderByID(Nullable<int> pK_iImportOrderID)
        {
            var pK_iImportOrderIDParameter = pK_iImportOrderID.HasValue ?
                new ObjectParameter("PK_iImportOrderID", pK_iImportOrderID) :
                new ObjectParameter("PK_iImportOrderID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<procSelectImportOrderByID_Result>("procSelectImportOrderByID", pK_iImportOrderIDParameter);
        }
    
        public virtual ObjectResult<procSelectUserByID_Result> procSelectUserByID(Nullable<int> pK_iAccountID)
        {
            var pK_iAccountIDParameter = pK_iAccountID.HasValue ?
                new ObjectParameter("PK_iAccountID", pK_iAccountID) :
                new ObjectParameter("PK_iAccountID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<procSelectUserByID_Result>("procSelectUserByID", pK_iAccountIDParameter);
        }
    
        public virtual int proDeleteCategory(Nullable<int> sCategoryID)
        {
            var sCategoryIDParameter = sCategoryID.HasValue ?
                new ObjectParameter("sCategoryID", sCategoryID) :
                new ObjectParameter("sCategoryID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("proDeleteCategory", sCategoryIDParameter);
        }
    
        public virtual int proDeleteCheckinDetail(Nullable<int> pK_iCheckinDetailID)
        {
            var pK_iCheckinDetailIDParameter = pK_iCheckinDetailID.HasValue ?
                new ObjectParameter("PK_iCheckinDetailID", pK_iCheckinDetailID) :
                new ObjectParameter("PK_iCheckinDetailID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("proDeleteCheckinDetail", pK_iCheckinDetailIDParameter);
        }
    
        public virtual int proDeleteCheckoutDetail(Nullable<int> pK_iCheckoutDetailID)
        {
            var pK_iCheckoutDetailIDParameter = pK_iCheckoutDetailID.HasValue ?
                new ObjectParameter("PK_iCheckoutDetailID", pK_iCheckoutDetailID) :
                new ObjectParameter("PK_iCheckoutDetailID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("proDeleteCheckoutDetail", pK_iCheckoutDetailIDParameter);
        }
    
        public virtual int proDeleteImage(Nullable<int> pK_iImageID)
        {
            var pK_iImageIDParameter = pK_iImageID.HasValue ?
                new ObjectParameter("PK_iImageID", pK_iImageID) :
                new ObjectParameter("PK_iImageID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("proDeleteImage", pK_iImageIDParameter);
        }
    
        public virtual int proDeleteImportOrder(Nullable<int> pK_iImportOrderID)
        {
            var pK_iImportOrderIDParameter = pK_iImportOrderID.HasValue ?
                new ObjectParameter("PK_iImportOrderID", pK_iImportOrderID) :
                new ObjectParameter("PK_iImportOrderID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("proDeleteImportOrder", pK_iImportOrderIDParameter);
        }
    
        public virtual int proDeleteOrder(Nullable<int> pK_iOrderID)
        {
            var pK_iOrderIDParameter = pK_iOrderID.HasValue ?
                new ObjectParameter("PK_iOrderID", pK_iOrderID) :
                new ObjectParameter("PK_iOrderID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("proDeleteOrder", pK_iOrderIDParameter);
        }
    
        public virtual int proDeletePermission(Nullable<int> pK_iPermissionID)
        {
            var pK_iPermissionIDParameter = pK_iPermissionID.HasValue ?
                new ObjectParameter("PK_iPermissionID", pK_iPermissionID) :
                new ObjectParameter("PK_iPermissionID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("proDeletePermission", pK_iPermissionIDParameter);
        }
    
        public virtual int proDeleteProduct(Nullable<int> pK_iProductID)
        {
            var pK_iProductIDParameter = pK_iProductID.HasValue ?
                new ObjectParameter("PK_iProductID", pK_iProductID) :
                new ObjectParameter("PK_iProductID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("proDeleteProduct", pK_iProductIDParameter);
        }
    
        public virtual int proDeletePromote(Nullable<int> pK_iPromoteID)
        {
            var pK_iPromoteIDParameter = pK_iPromoteID.HasValue ?
                new ObjectParameter("PK_iPromoteID", pK_iPromoteID) :
                new ObjectParameter("PK_iPromoteID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("proDeletePromote", pK_iPromoteIDParameter);
        }
    
        public virtual int proDeleteSupplier(Nullable<int> pK_iSupplierID)
        {
            var pK_iSupplierIDParameter = pK_iSupplierID.HasValue ?
                new ObjectParameter("PK_iSupplierID", pK_iSupplierID) :
                new ObjectParameter("PK_iSupplierID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("proDeleteSupplier", pK_iSupplierIDParameter);
        }
    
        public virtual int proDeleteUser(Nullable<int> pK_iAccountID)
        {
            var pK_iAccountIDParameter = pK_iAccountID.HasValue ?
                new ObjectParameter("PK_iAccountID", pK_iAccountID) :
                new ObjectParameter("PK_iAccountID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("proDeleteUser", pK_iAccountIDParameter);
        }
    
        public virtual ObjectResult<proGetAllImageToDisplay_Result> proGetAllImageToDisplay()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<proGetAllImageToDisplay_Result>("proGetAllImageToDisplay");
        }
    
        public virtual ObjectResult<string> proGetImageByIDToDisplay(Nullable<int> sId)
        {
            var sIdParameter = sId.HasValue ?
                new ObjectParameter("sId", sId) :
                new ObjectParameter("sId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("proGetImageByIDToDisplay", sIdParameter);
        }
    
        public virtual ObjectResult<proPermissionNameDisplayUser_Result> proPermissionNameDisplayUser()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<proPermissionNameDisplayUser_Result>("proPermissionNameDisplayUser");
        }
    
        public virtual int proUpdateCategory(Nullable<int> sCategoryID, string sCategoryName)
        {
            var sCategoryIDParameter = sCategoryID.HasValue ?
                new ObjectParameter("sCategoryID", sCategoryID) :
                new ObjectParameter("sCategoryID", typeof(int));
    
            var sCategoryNameParameter = sCategoryName != null ?
                new ObjectParameter("sCategoryName", sCategoryName) :
                new ObjectParameter("sCategoryName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("proUpdateCategory", sCategoryIDParameter, sCategoryNameParameter);
        }
    
        public virtual int proUpdateImportOrder(Nullable<int> pK_iImportOrderID, Nullable<int> fK_iAccountID, Nullable<int> fK_iSupplierID, Nullable<System.DateTime> dtDateAdded, string sDeliver)
        {
            var pK_iImportOrderIDParameter = pK_iImportOrderID.HasValue ?
                new ObjectParameter("PK_iImportOrderID", pK_iImportOrderID) :
                new ObjectParameter("PK_iImportOrderID", typeof(int));
    
            var fK_iAccountIDParameter = fK_iAccountID.HasValue ?
                new ObjectParameter("FK_iAccountID", fK_iAccountID) :
                new ObjectParameter("FK_iAccountID", typeof(int));
    
            var fK_iSupplierIDParameter = fK_iSupplierID.HasValue ?
                new ObjectParameter("FK_iSupplierID", fK_iSupplierID) :
                new ObjectParameter("FK_iSupplierID", typeof(int));
    
            var dtDateAddedParameter = dtDateAdded.HasValue ?
                new ObjectParameter("dtDateAdded", dtDateAdded) :
                new ObjectParameter("dtDateAdded", typeof(System.DateTime));
    
            var sDeliverParameter = sDeliver != null ?
                new ObjectParameter("sDeliver", sDeliver) :
                new ObjectParameter("sDeliver", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("proUpdateImportOrder", pK_iImportOrderIDParameter, fK_iAccountIDParameter, fK_iSupplierIDParameter, dtDateAddedParameter, sDeliverParameter);
        }
    
        public virtual int proUpdatePermission(Nullable<int> pK_iPermissionID, string sPermissionName, Nullable<int> iState)
        {
            var pK_iPermissionIDParameter = pK_iPermissionID.HasValue ?
                new ObjectParameter("PK_iPermissionID", pK_iPermissionID) :
                new ObjectParameter("PK_iPermissionID", typeof(int));
    
            var sPermissionNameParameter = sPermissionName != null ?
                new ObjectParameter("sPermissionName", sPermissionName) :
                new ObjectParameter("sPermissionName", typeof(string));
    
            var iStateParameter = iState.HasValue ?
                new ObjectParameter("iState", iState) :
                new ObjectParameter("iState", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("proUpdatePermission", pK_iPermissionIDParameter, sPermissionNameParameter, iStateParameter);
        }
    
        public virtual int proUpdatePromote(Nullable<int> pK_iPromoteID, string sPromoteName, Nullable<double> sPromoteRate, Nullable<System.DateTime> dtStartDay, Nullable<System.DateTime> dtEndDay)
        {
            var pK_iPromoteIDParameter = pK_iPromoteID.HasValue ?
                new ObjectParameter("PK_iPromoteID", pK_iPromoteID) :
                new ObjectParameter("PK_iPromoteID", typeof(int));
    
            var sPromoteNameParameter = sPromoteName != null ?
                new ObjectParameter("sPromoteName", sPromoteName) :
                new ObjectParameter("sPromoteName", typeof(string));
    
            var sPromoteRateParameter = sPromoteRate.HasValue ?
                new ObjectParameter("sPromoteRate", sPromoteRate) :
                new ObjectParameter("sPromoteRate", typeof(double));
    
            var dtStartDayParameter = dtStartDay.HasValue ?
                new ObjectParameter("dtStartDay", dtStartDay) :
                new ObjectParameter("dtStartDay", typeof(System.DateTime));
    
            var dtEndDayParameter = dtEndDay.HasValue ?
                new ObjectParameter("dtEndDay", dtEndDay) :
                new ObjectParameter("dtEndDay", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("proUpdatePromote", pK_iPromoteIDParameter, sPromoteNameParameter, sPromoteRateParameter, dtStartDayParameter, dtEndDayParameter);
        }
    
        public virtual int proUpdateSupplier(Nullable<int> pK_iSupplierID, string sSupplierName, string sPhone, string sEmail, string sAddress)
        {
            var pK_iSupplierIDParameter = pK_iSupplierID.HasValue ?
                new ObjectParameter("PK_iSupplierID", pK_iSupplierID) :
                new ObjectParameter("PK_iSupplierID", typeof(int));
    
            var sSupplierNameParameter = sSupplierName != null ?
                new ObjectParameter("sSupplierName", sSupplierName) :
                new ObjectParameter("sSupplierName", typeof(string));
    
            var sPhoneParameter = sPhone != null ?
                new ObjectParameter("sPhone", sPhone) :
                new ObjectParameter("sPhone", typeof(string));
    
            var sEmailParameter = sEmail != null ?
                new ObjectParameter("sEmail", sEmail) :
                new ObjectParameter("sEmail", typeof(string));
    
            var sAddressParameter = sAddress != null ?
                new ObjectParameter("sAddress", sAddress) :
                new ObjectParameter("sAddress", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("proUpdateSupplier", pK_iSupplierIDParameter, sSupplierNameParameter, sPhoneParameter, sEmailParameter, sAddressParameter);
        }
    
        public virtual int proUpdateUser(Nullable<int> pK_iAccountID, Nullable<int> fK_iPermissionID, string sEmail, string sPass, string sUserName, string sPhone, string sAddress, Nullable<int> iState)
        {
            var pK_iAccountIDParameter = pK_iAccountID.HasValue ?
                new ObjectParameter("PK_iAccountID", pK_iAccountID) :
                new ObjectParameter("PK_iAccountID", typeof(int));
    
            var fK_iPermissionIDParameter = fK_iPermissionID.HasValue ?
                new ObjectParameter("FK_iPermissionID", fK_iPermissionID) :
                new ObjectParameter("FK_iPermissionID", typeof(int));
    
            var sEmailParameter = sEmail != null ?
                new ObjectParameter("sEmail", sEmail) :
                new ObjectParameter("sEmail", typeof(string));
    
            var sPassParameter = sPass != null ?
                new ObjectParameter("sPass", sPass) :
                new ObjectParameter("sPass", typeof(string));
    
            var sUserNameParameter = sUserName != null ?
                new ObjectParameter("sUserName", sUserName) :
                new ObjectParameter("sUserName", typeof(string));
    
            var sPhoneParameter = sPhone != null ?
                new ObjectParameter("sPhone", sPhone) :
                new ObjectParameter("sPhone", typeof(string));
    
            var sAddressParameter = sAddress != null ?
                new ObjectParameter("sAddress", sAddress) :
                new ObjectParameter("sAddress", typeof(string));
    
            var iStateParameter = iState.HasValue ?
                new ObjectParameter("iState", iState) :
                new ObjectParameter("iState", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("proUpdateUser", pK_iAccountIDParameter, fK_iPermissionIDParameter, sEmailParameter, sPassParameter, sUserNameParameter, sPhoneParameter, sAddressParameter, iStateParameter);
        }
    }
}