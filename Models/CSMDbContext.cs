using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CSMAPI.Models
{
    public partial class CSMDbContext : DbContext
    {
        public CSMDbContext()
        {
        }

        public CSMDbContext(DbContextOptions<CSMDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AllTask> AllTask { get; set; } = null!;
        public virtual DbSet<Csmproblem> Csmproblem { get; set; } = null!;
        public virtual DbSet<ProblemData> ProblemData { get; set; } = null!;
        public virtual DbSet<ProblemType> ProblemType { get; set; } = null!;
        public virtual DbSet<Project> Project { get; set; } = null!;
        public virtual DbSet<SubTask1> SubTask1 { get; set; } = null!;
        public virtual DbSet<SubTask2> SubTask2 { get; set; } = null!;
        public virtual DbSet<SubTask3> SubTask3 { get; set; } = null!;
        public virtual DbSet<SubTask4> SubTask4 { get; set; } = null!;
        public virtual DbSet<SubTask5> SubTask5 { get; set; } = null!;
        public virtual DbSet<tempcsmno> Tempcsmno { get; set; } = null!;
        public virtual DbSet<Unit> Unit { get; set; } = null!;
        public virtual DbSet<User> User { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=localhost;user=SA;password=Maprang210801;database=CSM");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AllTask>(entity =>
            {
                entity.ToTable("AllTask", "default_schema");

                entity.Property(e => e.AlltaskId)
                    .HasMaxLength(24)
                    .IsUnicode(false)
                    .HasColumnName("alltask_id")
                    .IsFixedLength();

                entity.Property(e => e.FromSubtask1Id)
                    .HasMaxLength(24)
                    .IsUnicode(false)
                    .HasColumnName("from_subtask1_id")
                    .IsFixedLength();

                entity.Property(e => e.FromSubtask2Id)
                    .HasMaxLength(24)
                    .IsUnicode(false)
                    .HasColumnName("from_subtask2_id")
                    .IsFixedLength();

                entity.Property(e => e.FromSubtask3Id)
                    .HasMaxLength(24)
                    .IsUnicode(false)
                    .HasColumnName("from_subtask3_id")
                    .IsFixedLength();

                entity.Property(e => e.FromSubtask4Id)
                    .HasMaxLength(24)
                    .IsUnicode(false)
                    .HasColumnName("from_subtask4_id")
                    .IsFixedLength();

                entity.Property(e => e.FromSubtask5Id)
                    .HasMaxLength(24)
                    .IsUnicode(false)
                    .HasColumnName("from_subtask5_Id")
                    .IsFixedLength();

                entity.HasOne(d => d.FromSubtask1)
                    .WithMany(p => p.AllTask)
                    .HasForeignKey(d => d.FromSubtask1Id)
                    .HasConstraintName("AllTask_SubTask1_subtask_id_fk");

                entity.HasOne(d => d.FromSubtask2)
                    .WithMany(p => p.AllTask)
                    .HasForeignKey(d => d.FromSubtask2Id)
                    .HasConstraintName("AllTask_SubTask2_null_fk");

                entity.HasOne(d => d.FromSubtask3)
                    .WithMany(p => p.AllTask)
                    .HasForeignKey(d => d.FromSubtask3Id)
                    .HasConstraintName("AllTask_SubTask3_null_fk");

                entity.HasOne(d => d.FromSubtask4)
                    .WithMany(p => p.AllTask)
                    .HasForeignKey(d => d.FromSubtask4Id)
                    .HasConstraintName("AllTask_SubTask4_null_fk");

                entity.HasOne(d => d.FromSubtask5)
                    .WithMany(p => p.AllTask)
                    .HasForeignKey(d => d.FromSubtask5Id)
                    .HasConstraintName("AllTask_SubTask5_null_fk");
            });

            modelBuilder.Entity<Csmproblem>(entity =>
            {
                entity.HasKey(e => e.CsmId)
                    .HasName("PK__CSMprobl__C86A7F93C1E94BD9");

                entity.ToTable("CSMproblem", "default_schema");

                entity.Property(e => e.CsmId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("csm_id")
                    .IsFixedLength();

                entity.Property(e => e.AvaiDate1)
                    .HasColumnType("date")
                    .HasColumnName("avai_date_1");

                entity.Property(e => e.AvaiDate2)
                    .HasColumnType("date")
                    .HasColumnName("avai_date_2");

                entity.Property(e => e.AvaiDate3)
                    .HasColumnType("date")
                    .HasColumnName("avai_date_3");

                entity.Property(e => e.FromTaskId)
                    .HasMaxLength(24)
                    .IsUnicode(false)
                    .HasColumnName("from_task_id")
                    .IsFixedLength();

                entity.Property(e => e.FromUnitId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("from_unit_id")
                    .IsFixedLength();

                entity.Property(e => e.NameReport)
                    .HasMaxLength(100)
                    .HasColumnName("name_report");

                entity.Property(e => e.PhoneNum)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("phone_num")
                    .IsFixedLength();

                entity.HasOne(d => d.FromTask)
                    .WithMany(p => p.Csmproblem)
                    .HasForeignKey(d => d.FromTaskId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CSMproblem_AllTask_null_fk");

                entity.HasOne(d => d.FromUnit)
                    .WithMany(p => p.Csmproblem)
                    .HasForeignKey(d => d.FromUnitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CSMproblem_Unit_null_fk");
            });

            modelBuilder.Entity<ProblemData>(entity =>
            {
                entity.HasKey(e => e.PdId)
                    .HasName("PK__ProblemD__F7562CCFD64C8D79");

                entity.ToTable("ProblemData", "default_schema");

                entity.Property(e => e.PdId)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("pd_id")
                    .IsFixedLength();

                entity.Property(e => e.PdDesc)
                    .HasMaxLength(255)
                    .HasColumnName("pd_desc");

                entity.Property(e => e.PtId)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("pt_id")
                    .IsFixedLength();

                entity.HasOne(d => d.Pt)
                    .WithMany(p => p.ProblemData)
                    .HasForeignKey(d => d.PtId)
                    .HasConstraintName("FK__ProblemDa__pt_id__2DE6D218");
            });

            modelBuilder.Entity<ProblemType>(entity =>
            {
                entity.HasKey(e => e.PtId)
                    .HasName("PK__ProblemT__5630B1205ECE2968");

                entity.ToTable("ProblemType", "default_schema");

                entity.Property(e => e.PtId)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("pt_id")
                    .IsFixedLength();

                entity.Property(e => e.Probtype)
                    .HasMaxLength(100)
                    .HasColumnName("probtype")
                    .IsFixedLength();
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.HasKey(e => e.ProjId)
                    .HasName("PK__project__A04A0C2D609B201B");

                entity.ToTable("Project", "default_schema");

                entity.Property(e => e.ProjId)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("proj_id")
                    .IsFixedLength();

                entity.Property(e => e.ProjName)
                    .HasMaxLength(255)
                    .HasColumnName("proj_name");
            });

            modelBuilder.Entity<SubTask1>(entity =>
            {
                entity.HasKey(e => e.SubtaskId)
                    .HasName("PK__SubTask___BE05A13F47264715");

                entity.ToTable("SubTask1", "default_schema");

                entity.Property(e => e.SubtaskId)
                    .HasMaxLength(24)
                    .IsUnicode(false)
                    .HasColumnName("subtask_id")
                    .IsFixedLength();

                entity.Property(e => e.Description)
                    .HasColumnType("ntext")
                    .HasColumnName("description");

                entity.Property(e => e.Pbcode)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("pbcode")
                    .IsFixedLength();

                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("status")
                    .IsFixedLength();

                entity.HasOne(d => d.PbcodeNavigation)
                    .WithMany(p => p.SubTask1)
                    .HasForeignKey(d => d.Pbcode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("SubTask_1_ProblemData_null_fk");
            });

            modelBuilder.Entity<SubTask2>(entity =>
            {
                entity.HasKey(e => e.SubtaskId)
                    .HasName("PK__SubTask2__C2AC5F056E18E4CB");

                entity.ToTable("SubTask2", "default_schema");

                entity.Property(e => e.SubtaskId)
                    .HasMaxLength(24)
                    .IsUnicode(false)
                    .HasColumnName("subtask_id")
                    .IsFixedLength();

                entity.Property(e => e.Description)
                    .HasColumnType("ntext")
                    .HasColumnName("description");

                entity.Property(e => e.Pbcode)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("pbcode")
                    .IsFixedLength();

                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("status")
                    .IsFixedLength();

                entity.HasOne(d => d.PbcodeNavigation)
                    .WithMany(p => p.SubTask2)
                    .HasForeignKey(d => d.Pbcode)
                    .HasConstraintName("FK__SubTask2__pbcode__6DCC4D03");
            });

            modelBuilder.Entity<SubTask3>(entity =>
            {
                entity.HasKey(e => e.SubtaskId)
                    .HasName("PK__SubTask3__C2AC5F0529E0E6C9");

                entity.ToTable("SubTask3", "default_schema");

                entity.Property(e => e.SubtaskId)
                    .HasMaxLength(24)
                    .IsUnicode(false)
                    .HasColumnName("subtask_id")
                    .IsFixedLength();

                entity.Property(e => e.Description)
                    .HasColumnType("ntext")
                    .HasColumnName("description");

                entity.Property(e => e.Pbcode)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("pbcode")
                    .IsFixedLength();

                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("status")
                    .IsFixedLength();

                entity.HasOne(d => d.PbcodeNavigation)
                    .WithMany(p => p.SubTask3)
                    .HasForeignKey(d => d.Pbcode)
                    .HasConstraintName("FK__SubTask3__pbcode__70A8B9AE");
            });

            modelBuilder.Entity<SubTask4>(entity =>
            {
                entity.HasKey(e => e.SubtaskId)
                    .HasName("PK__SubTask4__C2AC5F05C03D85C4");

                entity.ToTable("SubTask4", "default_schema");

                entity.Property(e => e.SubtaskId)
                    .HasMaxLength(24)
                    .IsUnicode(false)
                    .HasColumnName("subtask_id")
                    .IsFixedLength();

                entity.Property(e => e.Description)
                    .HasColumnType("ntext")
                    .HasColumnName("description");

                entity.Property(e => e.Pbcode)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("pbcode")
                    .IsFixedLength();

                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("status")
                    .IsFixedLength();

                entity.HasOne(d => d.PbcodeNavigation)
                    .WithMany(p => p.SubTask4)
                    .HasForeignKey(d => d.Pbcode)
                    .HasConstraintName("FK__SubTask4__pbcode__73852659");
            });

            modelBuilder.Entity<SubTask5>(entity =>
            {
                entity.HasKey(e => e.SubtaskId)
                    .HasName("PK__SubTask5__C2AC5F058077A1F0");

                entity.ToTable("SubTask5", "default_schema");

                entity.Property(e => e.SubtaskId)
                    .HasMaxLength(24)
                    .IsUnicode(false)
                    .HasColumnName("subtask_id")
                    .IsFixedLength();

                entity.Property(e => e.Description)
                    .HasColumnType("ntext")
                    .HasColumnName("description");

                entity.Property(e => e.Pbcode)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("pbcode")
                    .IsFixedLength();

                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("status")
                    .IsFixedLength();

                entity.HasOne(d => d.PbcodeNavigation)
                    .WithMany(p => p.SubTask5)
                    .HasForeignKey(d => d.Pbcode)
                    .HasConstraintName("FK__SubTask5__pbcode__6AEFE058");
            });

            modelBuilder.Entity<tempcsmno>(entity =>
            {
                entity.HasKey(e => e.csmdate)
                    .HasName("PK__tempcsmn__3748F299CDD397C3");

                entity.ToTable("tempcsmno", "default_schema");

                entity.Property(e => e.csmdate)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("csmdate")
                    .IsFixedLength();

                entity.Property(e => e.count).HasColumnName("count");
            });

            modelBuilder.Entity<Unit>(entity =>
            {
                entity.ToTable("Unit", "default_schema");

                entity.Property(e => e.UnitId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("unit_id")
                    .IsFixedLength();

                entity.Property(e => e.Address).HasColumnName("address");

                entity.Property(e => e.BelongToProj)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("belong_to_proj")
                    .IsFixedLength();

                entity.Property(e => e.BelongToUser)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("belong_to_user")
                    .IsFixedLength();

                entity.HasOne(d => d.BelongToProjNavigation)
                    .WithMany(p => p.Unit)
                    .HasForeignKey(d => d.BelongToProj)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Unit_Project_null_fk");

                entity.HasOne(d => d.BelongToUserNavigation)
                    .WithMany(p => p.Unit)
                    .HasForeignKey(d => d.BelongToUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Unit_User_null_fk");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User", "default_schema");

                entity.Property(e => e.UserId)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("user_id")
                    .IsFixedLength();

                entity.Property(e => e.FName)
                    .HasMaxLength(255)
                    .HasColumnName("f_name");

                entity.Property(e => e.LName)
                    .HasMaxLength(255)
                    .HasColumnName("l_name");

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.PhoneNum)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("phone_num")
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}