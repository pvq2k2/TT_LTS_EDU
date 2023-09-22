﻿using TT_LTS_EDU.Entities;
using TT_LTS_EDU.Handle.DTOs;

namespace TT_LTS_EDU.Handle.Converter
{
    public class ProductReviewConverter
    {
        public ProductReviewDTO EntityProductReviewToDTO(ProductReview productReview)
        {
            return new ProductReviewDTO
            {
                ContentRated = productReview.ContentRated,
                PointEvaluation = productReview.PointEvaluation,
                ContentSeen = productReview.ContentSeen,
                Status = productReview.Status,
            };
        }

        public List<ProductReviewDTO> ListProductReviewToDTO(List<ProductReview> listProductReview)
        {
            var listProductReviewDTO = new List<ProductReviewDTO>();
            foreach (var item in listProductReview)
            {
                listProductReviewDTO.Add(EntityProductReviewToDTO(item));
            }

            return listProductReviewDTO;
        }
    }
}
