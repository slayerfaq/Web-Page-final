//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Disciplina
    {
        public Disciplina()
        {
            this.Ratings = new HashSet<Ratings>();
        }
    
        public int Id { get; set; }
        public string Title { get; set; }
    
        public virtual Teacher Teacher { get; set; }
        public virtual ICollection<Ratings> Ratings { get; set; }
    }
}