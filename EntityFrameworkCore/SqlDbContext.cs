using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Model.SysEntitys;
using Model.BusEntitys;

namespace XiaoYuJi.EntityFrameworkCore;
public class SqlDbContext : DbContext
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="options">数据库连接字符串</param>
    public SqlDbContext(DbContextOptions options)
        : base(options)
    {

    }

    #region 系统表
    public virtual DbSet<SysUser> SysUsers { get; set; }    //用户表
    public virtual DbSet<SysMenu> SysMenus { get; set; }    //菜单权限表
    public virtual DbSet<SysRole> SysRoles { get; set; }    //角色表
    public virtual DbSet<SysRoleMenu> SysRoleMenus { get; set; }    //角色菜单对应关系表



    #endregion

    #region 业务表
    public virtual DbSet<Exam> Exams { get; set; }    //考试表
    public virtual DbSet<KnowledgePoints> KnowledgePoints { get; set; }    //知识点表
    public virtual DbSet<Major> Majors { get; set; }    //专业表
    public virtual DbSet<Option> Options { get; set; }    //选项表
    public virtual DbSet<Paper> Papers { get; set; }    //试卷表
    public virtual DbSet<PaperQuestion> PaperQuestions { get; set; }    //题库表
    public virtual DbSet<QuestionType> QuestionTypes { get; set; }    //题型表
    public virtual DbSet<Subject> Subjects { get; set; }    //科目表
    public virtual DbSet<Term> Terms { get; set; }    //学期表
    public virtual DbSet<ExamRecord> ExamRecords { get; set; }    //考试记录表


    #endregion

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //全局关闭EF Core数据跟踪
        optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

        base.OnConfiguring(optionsBuilder);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SysUser>(entity =>
        {
            entity.HasKey(c => c.Id);
            entity.HasOne(c => c.SysRole).WithMany().HasForeignKey(c => c.UserId);
        });
        modelBuilder.Entity<SysRole>(entity =>
        {
            entity.HasKey(c => c.Id);
        });
        modelBuilder.Entity<SysMenu>(entity =>
        {
            entity.HasKey(c => c.Id);
        });
        modelBuilder.Entity<SysRoleMenu>(entity =>
        {
            entity.HasKey(c => c.Id);
            entity.HasOne<SysRole>().WithMany().HasForeignKey(c => c.RoleId);
            entity.HasOne<SysMenu>().WithMany().HasForeignKey(c => c.MenuId);
        });
        modelBuilder.Entity<SysRoleMenu>(entity =>
        {
            entity.HasKey(c => c.Id);
            entity.HasOne<SysRole>().WithMany().HasForeignKey(c => c.RoleId);
            entity.HasOne<SysMenu>().WithMany().HasForeignKey(c => c.MenuId);
        });
        modelBuilder.Entity<Exam>(entity =>
        {
            entity.HasKey(c => c.Id);
            entity.HasOne(c => c.Paper).WithMany();
          entity.HasOne(c=>c.Term).WithMany(c=>c.exams);
        });
        modelBuilder.Entity<KnowledgePoints>(entity =>
        {
            entity.HasKey(c => c.Id);
            entity.HasMany(c=>c.PaperQuestions).WithMany(c=>c.KnowledgePoints);
            entity.HasOne(c=>c.Subject).WithMany(c=>c.KnowledgePoints);

        });
        modelBuilder.Entity<Major>(entity =>
        {
            entity.HasKey(c => c.Id);
            entity.HasMany(c=>c.sysUsers).WithOne(c=>c.Major).HasForeignKey(c=>c.MajorId);
        });
        modelBuilder.Entity<Option>(entity =>
        {
            entity.HasKey(c => c.Id);
            entity.HasOne(c=>c.PaperQuestion).WithMany(c=>c.Options).HasForeignKey(c=>c.QuestionId);

        });
        modelBuilder.Entity<Paper>(entity =>
        {
            entity.HasKey(c => c.Id);
            entity.HasMany(c => c.paperQuestions).WithMany(c => c.Papers);
            entity.HasOne(c => c.Subject).WithMany(c => c.Papers);
            entity.HasOne(c=>c.Student).WithMany(c=>c.Papers).HasForeignKey(c=>c.StudentId);

        });
        modelBuilder.Entity<PaperQuestion>(entity =>
        {
            entity.HasKey(c => c.Id);
            entity.HasOne(c => c.QuestionType).WithMany(c => c.PaperQuestions);
        });
        modelBuilder.Entity<QuestionType>(entity =>
        {
            entity.HasKey(c => c.Id);

        });
        modelBuilder.Entity<Subject>(entity =>
        {
            entity.HasKey(c => c.Id);
            entity.HasMany(c=>c.Users).WithMany(c=>c.Subjects);

        });
        modelBuilder.Entity<Term>(entity =>
        {
            entity.HasKey(c => c.Id);

        });
        modelBuilder.Entity<ExamRecord>(entity =>
        {
            entity.HasKey(c => c.Id);
            entity.HasOne(c=>c.Exam).WithMany(c=>c.ExamRecords).HasForeignKey(c=>c.ExamId);
        });

        base.OnModelCreating(modelBuilder);
    }

}
