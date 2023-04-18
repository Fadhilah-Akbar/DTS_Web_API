using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DTS_Web_Api.Models;

public partial class Role
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    [JsonIgnore]
    public virtual ICollection<AccountRole>? TbMAccountRoles { get; set; } = new List<AccountRole>();
}
