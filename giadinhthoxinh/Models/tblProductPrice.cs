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
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class tblProductPrice
    {
        //public int PK_iProductPriceID { get; set; }
        //public int FK_iProductID { get; set; }
        //public Nullable<double> fPrice { get; set; }
        //public Nullable<System.DateTime> dtStartDay { get; set; }
        //public Nullable<System.DateTime> dtEndDay { get; set; }

        [Display(Name = "Mã giá sản phẩm")]
        public int PK_iProductPriceID { get; set; }
        [Display(Name = "Mã sản phẩm")]
        public int FK_iProductID { get; set; }
        [Display(Name = "Giá bán")]
        [Required(ErrorMessage = "Vui lòng nhập giá bán")]
        public double fPrice { get; set; }
        [Display(Name = "Ngày bắt đầu")]
        public Nullable<System.DateTime> dtStartDay { get; set; }
        [Display(Name = "Ngày kết thúc")]
        public Nullable<System.DateTime> dtEndDay { get; set; }

        public virtual tblProduct tblProduct { get; set; }
    }
}
