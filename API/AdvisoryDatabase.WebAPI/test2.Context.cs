﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AdvisoryDatabase.WebAPI
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class AdvisoryDatabaseEntities3 : DbContext
    {
        public AdvisoryDatabaseEntities3()
            : base("name=AdvisoryDatabaseEntities3")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
    
        public virtual ObjectResult<ExcelForClarizen_Result> ExcelForClarizen(Nullable<int> operation)
        {
            var operationParameter = operation.HasValue ?
                new ObjectParameter("Operation", operation) :
                new ObjectParameter("Operation", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ExcelForClarizen_Result>("ExcelForClarizen", operationParameter);
        }
    
        public virtual ObjectResult<ExcelForClarizen1_Result> ExcelForClarizen1(Nullable<int> operation)
        {
            var operationParameter = operation.HasValue ?
                new ObjectParameter("Operation", operation) :
                new ObjectParameter("Operation", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ExcelForClarizen1_Result>("ExcelForClarizen1", operationParameter);
        }
    }
}