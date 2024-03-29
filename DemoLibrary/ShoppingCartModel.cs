﻿using System;
using System.Collections.Generic;
using System.Linq;


namespace DemoLibrary
{
    public class ShoppingCartModel
    {
        public delegate void MentionDiscount(decimal subTotal);
        public List<ProductModel> Items { get; set; } = new List<ProductModel>();

        public decimal GenerateTotal(MentionDiscount mentionSubTotal,
            Func<List<ProductModel>, decimal, decimal> calculateDiscountedTotal,
            Action<string> tellUserWeAreDiscouting)
        {
            decimal subTotal = Items.Sum(x => x.Price);

            mentionSubTotal(subTotal);

            tellUserWeAreDiscouting("We are applying your discount!");

            return calculateDiscountedTotal(Items, subTotal);
        }
    }
}
