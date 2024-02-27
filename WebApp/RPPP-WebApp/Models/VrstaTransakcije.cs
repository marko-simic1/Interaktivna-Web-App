﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RPPP_WebApp.Models;

/// <summary>
/// Tablica "vrstaTransakcije" iz baze podataka.
/// </summary>
[Table("vrstaTransakcije")]
public partial class VrstaTransakcije
{
    /// <summary>
    /// Ime vrste transakcije.
    /// </summary>
    [Required]
    [Column("imeVrste", TypeName = "varchar(50)")]
    public string ImeVrste { get; set; }

    /// <summary>
    /// ID vrste transakcije.
    /// </summary>
    [Key]
    [Column("idVrste")]
    public int IdVrste { get; set; }

    /// <summary>
    /// Transakcije koje su vezane uz vrstu transakcije.
    /// </summary>
    [InverseProperty("IdVrsteNavigation")]
    public virtual ICollection<Transakcija> Transakcija { get; set; } = new List<Transakcija>();
}