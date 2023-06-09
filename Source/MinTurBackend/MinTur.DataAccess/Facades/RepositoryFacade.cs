﻿using Microsoft.EntityFrameworkCore;
using MinTur.DataAccess.Repositories;
using MinTur.DataAccessInterface.Facades;
using MinTur.Domain.BusinessEntities;
using System.Collections.Generic;
using System;
using System.Diagnostics.CodeAnalysis;

namespace MinTur.DataAccess.Facades
{
    [ExcludeFromCodeCoverage]
    public class RepositoryFacade : IRepositoryFacade
    {
        private readonly RegionRepository _regionRepository;
        private readonly TouristPointRepository _touristPointRepository;
        private readonly CategoryRepository _categoryRepository;
        private readonly ChargingSpotRepository _chargingSpotRepository;
        private readonly ResortRepository _resortRepository;
        private readonly ReservationRepository _reservationRepository;
        private readonly AuthenticationTokenRepository _authenticationTokenRepository;
        private readonly AdministratorRepository _administratorRepository;
        private readonly ReviewRepository _reviewRepository;

        public RepositoryFacade(DbContext context)
        {
            _regionRepository = new RegionRepository(context);
            _touristPointRepository = new TouristPointRepository(context);
            _categoryRepository = new CategoryRepository(context);
            _chargingSpotRepository = new ChargingSpotRepository(context);
            _resortRepository = new ResortRepository(context);
            _reservationRepository = new ReservationRepository(context);
            _authenticationTokenRepository = new AuthenticationTokenRepository(context);
            _administratorRepository = new AdministratorRepository(context);
            _reviewRepository = new ReviewRepository(context);
        }

        public List<Category> GetAllCategories()
        {
            return _categoryRepository.GetAllCategories();
        }

        public Category GetCategoryById(int categoryId)
        {
            return _categoryRepository.GetCategoryById(categoryId);
        }

        public List<Region> GetAllRegions()
        {
            return _regionRepository.GetAllRegions();
        }

        public Region GetRegionById(int regionId)
        {
            return _regionRepository.GetRegionById(regionId);
        }

        public Resort GetResortById(int resortId)
        {
            return _resortRepository.GetResortById(resortId);
        }

        public Guid StoreReservation(Reservation reservation)
        {
            return _reservationRepository.StoreReservation(reservation);
        }

        public Reservation GetReservationById(Guid reservationId)
        {
            return _reservationRepository.GetReservationById(reservationId);
        }

        public List<Reservation> GetAllReservations()
        {
            return _reservationRepository.GetAllReservations();
        }

        public TouristPoint GetTouristPointById(int touristPointId)
        {
            return _touristPointRepository.GetTouristPointById(touristPointId);
        }

        public AuthorizationToken GetAuthenticationTokenById(Guid tokenId)
        {
            return _authenticationTokenRepository.GetAuthenticationTokenById(tokenId);
        }

        public Guid CreateNewAuthorizationTokenFor(Administrator administrator)
        {
            return _authenticationTokenRepository.CreateNewAuthorizationTokenFor(administrator);
        }

        public int StoreTouristPoint(TouristPoint touristPoint)
        {
            return _touristPointRepository.StoreTouristPoint(touristPoint);
        }

        public List<Administrator> GetAllAdministrators()
        {
            return _administratorRepository.GetAllAdministrators();
        }

        public int StoreResort(Resort resort)
        {
            return _resortRepository.StoreResort(resort);
        }

        public void DeleteResort(Resort resort)
        {
            _resortRepository.DeleteResort(resort);
        }

        public void UpdateReservationState(Guid reservationId, ReservationState reservationState)
        {
            _reservationRepository.UpdateReservationState(reservationId, reservationState);
        }

        public void DeleteAdministratorById(int administratorId)
        {
            _administratorRepository.DeleteAdministratorById(administratorId);
        }

        public int StoreAdministrator(Administrator administrator)
        {
            return _administratorRepository.StoreAdministrator(administrator);
        }

        public void UpdateAdministrator(Administrator administrator)
        {
            _administratorRepository.UpdateAdministrator(administrator);
        }
        public Administrator GetAdministratorById(int administratorId)
        {
            return _administratorRepository.GetAdministratorById(administratorId);
        }

        public List<TouristPoint> GetAllTouristPointsByMatchingCriteria(Func<TouristPoint, bool> criteria)
        {
            return _touristPointRepository.GetAllTouristPointsByMatchingCriteria(criteria);
        }

        public List<Resort> GetAllResortsByMatchingCriteria(Func<Resort, bool> criteria)
        {
            return _resortRepository.GetAllResortsByMatchingCriteria(criteria);
        }

        public void UpdateResort(Resort resort)
        {
            _resortRepository.UpdateResort(resort);
        }

        public int StoreReview(Review review)
        {
            return _reviewRepository.StoreReview(review);
        }

        public Review GetReviewById(int reviewId)
        {
            return _reviewRepository.GetReviewById(reviewId);
        }

        public void DeleteChargingSpotById(int chargingSpotId){
            _chargingSpotRepository.DeleteChargingSpotById(chargingSpotId);
        }

        public int StoreChargingSpot(ChargingSpot chargingSpot)
        {
            return _chargingSpotRepository.StoreChargingSpot(chargingSpot);
        }

        public ChargingSpot GetChargingSpotById(int chargingSpotId)
        {
            return _chargingSpotRepository.GetChargingSpotById(chargingSpotId);
        }

        public List<ChargingSpot> GetAllChargingSpots()
        {
            return _chargingSpotRepository.GetAllChargingSpots();
        }
    }
}
