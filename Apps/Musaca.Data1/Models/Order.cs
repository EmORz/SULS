using System;
using System.Collections.Generic;

namespace Musaca.Data1.Models
{
    public class Order
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public StatusOrder Status { get; set; } =  StatusOrder.Active;

        public DateTime IssuedOn { get; set; }

        public List<OrderProduct> Products { get; set; } = new List<OrderProduct>();

        public string CashierId { get; set; }

        public User Cashier { get; set; }


        /*•	Id – a GUID String or an Integer
           •	Status – can be one of the following values ("Active", "Completed")
           •	Issued On – a Date object.
           •	Products – a collection of Product objects
           •	CashierId – a GUID foreign key (required)
           •	Cashier – a User object
           */

    }
}