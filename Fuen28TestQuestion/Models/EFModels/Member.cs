﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Fuen28TestQuestion.Models.EFModels;

public partial class Member
{
    public int Id { get; set; }

    public string Username { get; set; }

    public string ImageName { get; set; }

    public virtual ICollection<MemberAnswer> MemberAnswers { get; set; } = new List<MemberAnswer>();

    public virtual ICollection<MemberGrade> MemberGrades { get; set; } = new List<MemberGrade>();
}