using FakeItEasy;
using FluentAssertions;
using FluentValidation;
using MarketPlace.Controllers;
using MarketPlace.Data;
using MarketPlace.Dto_s;
using MarketPlace.Entityes;
using MarketPlace.Repository;
using MarketPlace.Service.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MarketPlaceTest.Controller
{
    internal class FoodControllerTest
    {
        private readonly IFoodService _foodService;
        private readonly FoodRepository _foodRepository;
        private readonly IValidator<FoodDto> _validator;
        public FoodControllerTest()
        {
            _foodService = A.Fake<IFoodService>();
            _foodRepository = A.Fake<FoodRepository>();
            _validator = A.Fake < IValidator<FoodDto>>();


        }
        [Fact]
        public void FoodController_GetFood()
        {
            //Arrange
            var food = A.Fake<ICollection<FoodDto>>();
            var foodlis = A.Fake<ICollection<FoodDto>>();
            A.CallTo(() => _foodService.GetAllfood());
            var controller = (_foodService, _validator, _foodRepository);

            //Act
            var result = controller._foodService.GetAllfood();
            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }
    }
}
