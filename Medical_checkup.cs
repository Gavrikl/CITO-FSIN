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
    
    public partial class Medical_checkup
    {
        public int Id { get; set; }
        public int IdPrisoner { get; set; }
        public int IdEmployee { get; set; }
        public string Prs { get; set; }
        public string Preventive_medical_examination { get; set; }
    
        public virtual Prisoners Prisoners { get; set; }
        public virtual Staff_headquarters Staff_headquarters { get; set; }
    }
}
