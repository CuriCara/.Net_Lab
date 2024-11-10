﻿using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entity;

[Table("Harvest")]
public class Harvest : BaseEntity
{
    public DateTime DateHarvest { get; set; }
    
    public int Quantity { get; set; }
    
    public int UserId { get; set; }
    
    [ForeignKey("UserId")]
    public User User { get; set; }
    
    public int ProductId { get; set; }
    
    [ForeignKey("ProductId")]
    public Product Product { get; set; }
    
    public List<Report> Reports { get; set; }
}