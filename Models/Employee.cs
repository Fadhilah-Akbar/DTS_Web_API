using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DTS_Web_Api.Models;

public partial class Employee
{
    public string Nik { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string? LastName { get; set; }

    public DateTime BirthDate { get; set; }

    public Gender Gender { get; set; }

    public DateTime HiringDate { get; set; }

    public string Email { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    [JsonIgnore]
    public virtual Account? TbMAccount { get; set; }

    [JsonIgnore]
    public virtual Profiling? TbMProfiling { get; set; }
}

public enum Gender
{
    Male,Female
}
