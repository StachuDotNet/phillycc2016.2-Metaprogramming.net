

namespace Poco2
{
    using System;
    using System.Data.Linq.Mapping;

    [Table]
    partial class Events
    {
    [Column (IsPrimaryKey = true)]
    public int Id {get;set;}

    [Column (IsPrimaryKey = false)]
    public string EventType {get;set;}

    [Column (IsPrimaryKey = false)]
    public int EventVersion {get;set;}

    [Column (IsPrimaryKey = false)]
    public string Payload {get;set;}

    [Column (IsPrimaryKey = false)]
    public int UserId {get;set;}

    [Column (IsPrimaryKey = false)]
    public DateTime ActionTime {get;set;}

    [Column (IsPrimaryKey = false)]
    public DateTime PostTime {get;set;}

    [Column (IsPrimaryKey = false)]
    public int LastFiredId {get;set;}


    }
    [Table]
    partial class AspNetRoles
    {
    [Column (IsPrimaryKey = true)]
    public string Id {get;set;}

    [Column (IsPrimaryKey = false)]
    public string Name {get;set;}


    }
    [Table]
    partial class AspNetUserRoles
    {
    [Column (IsPrimaryKey = true)]
    public string UserId {get;set;}

    [Column (IsPrimaryKey = true)]
    public string RoleId {get;set;}


    }
    [Table]
    partial class AspNetUsers
    {
    [Column (IsPrimaryKey = true)]
    public string Id {get;set;}

    [Column (IsPrimaryKey = false)]
    public string Email {get;set;}

    [Column (IsPrimaryKey = false)]
    public int EmailConfirmed {get;set;}

    [Column (IsPrimaryKey = false)]
    public string PasswordHash {get;set;}

    [Column (IsPrimaryKey = false)]
    public string SecurityStamp {get;set;}

    [Column (IsPrimaryKey = false)]
    public string PhoneNumber {get;set;}

    [Column (IsPrimaryKey = false)]
    public int PhoneNumberConfirmed {get;set;}

    [Column (IsPrimaryKey = false)]
    public int TwoFactorEnabled {get;set;}

    [Column (IsPrimaryKey = false)]
    public DateTime? LockoutEndDateUtc {get;set;}

    [Column (IsPrimaryKey = false)]
    public int LockoutEnabled {get;set;}

    [Column (IsPrimaryKey = false)]
    public int AccessFailedCount {get;set;}

    [Column (IsPrimaryKey = false)]
    public string UserName {get;set;}


    }
    [Table]
    partial class AspNetUserClaims
    {
    [Column (IsPrimaryKey = true)]
    public int Id {get;set;}

    [Column (IsPrimaryKey = false)]
    public string UserId {get;set;}

    [Column (IsPrimaryKey = false)]
    public string ClaimType {get;set;}

    [Column (IsPrimaryKey = false)]
    public string ClaimValue {get;set;}


    }
    [Table]
    partial class AspNetUserLogins
    {
    [Column (IsPrimaryKey = true)]
    public string LoginProvider {get;set;}

    [Column (IsPrimaryKey = true)]
    public string ProviderKey {get;set;}

    [Column (IsPrimaryKey = true)]
    public string UserId {get;set;}


    }
    [Table]
    partial class __MigrationHistory
    {
    [Column (IsPrimaryKey = true)]
    public string MigrationId {get;set;}

    [Column (IsPrimaryKey = true)]
    public string ContextKey {get;set;}

    [Column (IsPrimaryKey = false)]
    public byte[] Model {get;set;}

    [Column (IsPrimaryKey = false)]
    public string ProductVersion {get;set;}


    }
}

