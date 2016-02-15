using System.Data.Entity;
using System.Reflection.Emit;
using DAL.Entities.Models;
using DAL.Entities.Mapping;

namespace CoordinationDB
{
    public partial class CoordinationContext : DbContext
    {
        static CoordinationContext()
        {
            Database.SetInitializer<CoordinationContext>(null);
        }

        public CoordinationContext(string connString)
            : base(connString)
        {
        }

        public CoordinationContext()
            : base("Name=CoordinationContext")
        {
        }

        public DbSet<Document> Documents { get; set; }
        public DbSet<DocumentType> DocumentTypes { get; set; }
        public DbSet<EmployeeAlternate> EmployeeAlternates { get; set; }
        public DbSet<EmployeeRole> EmployeeRoles { get; set; }
        public DbSet<employee> employees { get; set; }
        public DbSet<WfwDocumentExecution> WfwDocumentExecutions { get; set; }
        public DbSet<WfwDocumentTypeSchem> WfwDocumentTypesSchems { get; set; }
        public DbSet<WfwEventResult> WfwEventsResults { get; set; }
        public DbSet<WfwExecutionEvent> WfwExecutionEvents { get; set; }
        public DbSet<WfwScheme> WfwSchemes { get; set; }
        public DbSet<WfwSchemeStage> WfwSchemeStages { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new DocumentMap());
            modelBuilder.Configurations.Add(new DocumentTypeMap());
            modelBuilder.Configurations.Add(new EmployeeAlternateMap());
            modelBuilder.Configurations.Add(new EmployeeRoleMap());
            modelBuilder.Configurations.Add(new employeeMap());
            modelBuilder.Configurations.Add(new WfwDocumentExecutionMap());
            modelBuilder.Configurations.Add(new WfwDocumentTypeSchemMap());
            modelBuilder.Configurations.Add(new WfwEventResultMap());
            modelBuilder.Configurations.Add(new WfwExecutionEventMap());
            modelBuilder.Configurations.Add(new WfwSchemeMap());
            modelBuilder.Configurations.Add(new WfwSchemeStageMap());
        }
    }
}
