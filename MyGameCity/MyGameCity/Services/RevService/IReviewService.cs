﻿using MyGameCity.DAL.DTO;
using MyGameCity.DAL.Entities;

namespace MyGameCity.Services.RevService
{
    public interface IReviewService
    {
        ReviewEntity GetReviewById(Guid id);

        List<ReviewEntity> GetbyGameId(Guid game_id);
        //ReviewEntity GetGameById(Guid id);

        ReviewEntity AddReview(ReviewDTO review);

        ReviewEntity UpdateReview(ReviewDTO review);

        ReviewEntity DeleteReview(Guid id);
    }
}
