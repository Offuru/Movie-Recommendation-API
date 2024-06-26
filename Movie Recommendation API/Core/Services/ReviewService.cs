﻿using Core.Mapping;
using Database.Dtos.Request;
using Database.Dtos.Response;
using Database.Entities;
using Database.Repositories;

namespace Core.Services
{
    public class ReviewService
    {
        ReviewsRepository ReviewsRepository { get; set; }
        UsersRepository UsersRepository { get; set; }
        MovieRepository MovieRepository { get; set; }

        public ReviewService(ReviewsRepository reviewRepository, UsersRepository usersRepository, MovieRepository movieRepository)
        {
            ReviewsRepository = reviewRepository;
            UsersRepository = usersRepository;
            MovieRepository = movieRepository;
        }

        public void AddReview(AddReviewRequest payload)
        {
            var review = payload.ToEntity();

            review.User = UsersRepository.GetUserById(review.UserId);
            review.Movie = MovieRepository.GetMovieById(review.MovieId);
            review.Movie.Reviews.Add(review);

            UpdateMovieRating(review.Movie);

            ReviewsRepository.AddReview(review);
        }

        public void DeleteReview(int reviewId)
        {
            var review = ReviewsRepository.GetReviewById(reviewId);

            ReviewsRepository.DeleteReview(review);
        }

        public GetReviewDetailsResponse GetReviewDetailsById(int reviewId)
        {
            var review = ReviewsRepository.GetReviewById(reviewId);
            var result = review.ToReviewDto();

            return result;
        }

        public void EditReview(int reviewId, EditReviewRequest payload)
        {
            var review = ReviewsRepository.GetReviewById(reviewId);

            review.User = UsersRepository.GetUserById(review.UserId);
            review.Movie = MovieRepository.GetMovieById(review.MovieId);
            UpdateMovieRating(review.Movie);

            ReviewsRepository.EditReview(review, payload);
        }

        private void UpdateMovieRating(Movie movie)
        {
            movie.UserRating = movie.Reviews.Where(r => r.User.Role == "User").Sum(r => r.Rating);

            movie.CriticRating = movie.Reviews.Where(r => r.User.Role == "Admin").Sum(r => r.Rating);

            movie.Rating = (movie.UserRating + movie.CriticRating) / 2;
        }
    }
}
