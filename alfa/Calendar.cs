//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace alfa
{
    using System;
    using System.Collections.Generic;
    
    public partial class Calendar
    {
        public int ID { get; set; }
        public Nullable<int> ID_Employee { get; set; }
        public Nullable<int> ID_Mark { get; set; }
        public System.DateTime Date { get; set; }
    
        public virtual Employee Employee { get; set; }
        public virtual Marks Marks { get; set; }
    }
}