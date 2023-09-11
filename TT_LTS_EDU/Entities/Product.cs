﻿using System;

namespace TT_LTS_EDU.Entities
{
    public class Product : BaseEntity
    {
        public int ProductTypeID { get; set; }
        public string NameProduct { get; set; } = string.Empty;
        public double Price { get; set; }
        public string AvatarImageProduct { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public int Discount { get; set; }
        public int Status { get; set; }
        public int NumberOfViews { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public ProductType? ProductType { get; set; }
        public List<ProductImage>? ListProductImage { get; set; }
        public List<ProductReview>? ListProductReview { get; set; }
        public List<CartItem>? ListCartItem { get; set; }
        public List<OrderDetail>? ListOrderDetail { get; set; }
    }
}
