//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CITO_FSIN
{
    using System;
    using System.Collections.Generic;
    
    public partial class StaffHolidays
    {
        public int ID { get; set; }
        public int IdStaff { get; set; }
        public System.DateTime DateFrom { get; set; }
        public System.DateTime DateTo { get; set; }
    
        public virtual Staff_headquarters Staff_headquarters { get; set; }
    }
}