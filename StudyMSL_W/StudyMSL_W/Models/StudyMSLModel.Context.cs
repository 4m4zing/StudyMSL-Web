﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StudyMSL_W.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class studymsl_dbEntities : DbContext
    {
        public studymsl_dbEntities()
            : base("name=studymsl_dbEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<feedback> feedbacks { get; set; }
        public virtual DbSet<learn> learns { get; set; }
        public virtual DbSet<login> logins { get; set; }
        public virtual DbSet<progress> progresses { get; set; }
        public virtual DbSet<question> questions { get; set; }
        public virtual DbSet<spellingquestion> spellingquestions { get; set; }
        public virtual DbSet<userupload> useruploads { get; set; }
    }
}
