﻿using System;
using System.ComponentModel.DataAnnotations;

public class PatientInfo
{
    [Key]
    public int PatientId { get; set; }

    [Required]
    [StringLength(50)]
    public string FirstName { get; set; }

    [Required]
    [StringLength(50)]
    public string LastName { get; set; }

    [Required]
    [DataType(DataType.Date)]
    public DateTime DateOfBirth { get; set; }

    [Required]
    [StringLength(10)]
    public string Gender { get; set; }

    [StringLength(100)]
    public string? Address { get; set; }

  
    public string? PhoneNumber { get; set; }

    public string? Email { get; set; }

    [Required]
    public string MedicalRecords { get; set; }

    public string? UserCreatedId { get; set; }
}
