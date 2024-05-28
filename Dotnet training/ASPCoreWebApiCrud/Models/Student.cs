using System;
using System.Collections.Generic;

namespace ASPCoreWebApiCrud.Models;

public partial class Student
{
    public int StudentId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public DateOnly BirthDate { get; set; }

    public string? Gender { get; set; }

    public string Email { get; set; } = null!;
}
