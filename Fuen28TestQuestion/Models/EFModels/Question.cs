﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Fuen28TestQuestion.Models.EFModels;

public partial class Question
{
    public int Id { get; set; }

    public string QuestionText { get; set; }

    public string Answer { get; set; }

    public int TitleId { get; set; }

    public virtual Title Title { get; set; }
}