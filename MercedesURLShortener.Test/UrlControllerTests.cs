using AutoMapper;
using FakeItEasy;
using FluentAssertions;
using MercedesURLShortener.API.Controllers;
using MercedesURLShortener.Core.DTO;
using MercedesURLShortener.Core.DTOs;
using MercedesURLShortener.Core.IControllerHelpers;
using MercedesURLShortener.Core.IServices;
using MercedesURLShortener.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace MercedesURLShortener.Test
{
    public class UrlControllerTests
    {
        private readonly UrlController _urlController;
        private readonly IMapper _mapper;
        private readonly IUrlService _urlService;
        private readonly IUrlControllerHelper _urlControllerHelper;

        public UrlControllerTests()
        {
            // Arrange
            _mapper = A.Fake<IMapper>();
            _urlService = A.Fake<IUrlService>();
            _urlControllerHelper = A.Fake<IUrlControllerHelper>();
            _urlController = new UrlController(_urlService, _mapper, _urlControllerHelper);
        }

        [Fact]
        public async Task Save_WhenValidUrlDtoIsNull_ReturnsBadRequest()
        {
            // Arrange
            UrlDto dto = null;

            // Act
            var result = await _urlController.Save(dto);

            // Assert
            result.Should().BeOfType<BadRequestObjectResult>();
            var badRequestResult = result as BadRequestObjectResult;
            badRequestResult.StatusCode.Should().Be(400);
            badRequestResult.Value.Should().Be("Invalid URL data.");
        }

        [Fact]
        public async Task Save_WhenValidUrlDto_ReturnsCreatedResultWithShortUrl()
        {
            // Arrange
            var dto = new UrlDto
            {
                CurrentUrl = "https://www.mercedes-benz.com.tr/"
            };
            var shortUrl = "m-benz";
            A.CallTo(() => _urlControllerHelper.CreateRandomShortLink()).Returns(shortUrl);
           
            // Act
            var result = await _urlController.Save(dto);

            // Assert
            result.Should().BeOfType<CreatedResult>();
            var createdResult = result as CreatedResult;
            createdResult.StatusCode.Should().Be(201);
            var responseDto = createdResult.Value as CustomResponseDto<UrlDto>;
            responseDto.Data.Should().NotBeNull();
            responseDto.Data.CurrentUrl.Should().Be(dto.CurrentUrl);
        }
    }
}
