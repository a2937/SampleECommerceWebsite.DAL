using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SampleECommerceWebsite.Models.Entities
{
    [Table("Customers", Schema = "Store")]
    public class Customer : IdentityUser<int>
    {
        [DataType(DataType.Text), MaxLength(50), Display(Name = "First Name")]
        public string FirstName { get; set; }

        [DataType(DataType.Text), MaxLength(50), Display(Name = "Last Name")]
        public string LastName { get; set; }

        [DataType(DataType.Text), MaxLength(1), Display(Name = "Middle Initial")]
        public string MiddleInitial { get; set; }

        [InverseProperty(nameof(Order.Customer))]
        public List<Order> Orders { get; set; } = new List<Order>();

        [InverseProperty(nameof(ShoppingCartRecord.Customer))]
        public virtual List<ShoppingCartRecord> ShoppingCartRecords { get; set; }
        = new List<ShoppingCartRecord>();
    }
}
