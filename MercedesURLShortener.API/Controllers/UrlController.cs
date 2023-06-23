using AutoMapper;
using MercedesURLShortener.Core.DTO;
using MercedesURLShortener.Core.DTOs;
using MercedesURLShortener.Core.IControllerHelpers;
using MercedesURLShortener.Core.IServices;
using MercedesURLShortener.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace MercedesURLShortener.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrlController : CustomBaseController
    {
        private readonly IUrlService _urlService;
        private readonly IMapper _mapper;
        private readonly IUrlControllerHelper _urlControllerHelper;

        public UrlController(IUrlService urlService, IMapper mapper, IUrlControllerHelper urlControllerHelper)
        {
            _urlService = urlService;
            _mapper = mapper;
            _urlControllerHelper = urlControllerHelper;
        }

        [HttpPost]
        public async Task<IActionResult> Save(UrlDto dto)
        {
            if (dto != null)
            {
                UrlModel urlInfo;
                if (!string.IsNullOrEmpty(dto.ShortUrl) && dto.ShortUrl.Length <= 6)
                {
                    var existingUrl = await _urlService.GetCurrentUrlByShortUrl(dto.ShortUrl);
                    if (existingUrl != null)
                    {
                        return BadRequest("This URL is already in use.");
                    }
                    else
                    {
                        urlInfo = await _urlService.AddAsync(_mapper.Map<UrlModel>(dto));
                    }
                }

                else
                {
                    var shortUrl = _urlControllerHelper.CreateRandomShortLink();
                    while (_urlService.Where(x => x.ShortUrl == shortUrl).Any())
                    {
                        shortUrl = _urlControllerHelper.CreateRandomShortLink();
                    }
                    dto.ShortUrl = shortUrl;
                    urlInfo = await _urlService.AddAsync(_mapper.Map<UrlModel>(dto));

                }
                return CreateActionResult(CustomResponseDto<UrlDto>.Success(201, _mapper.Map<UrlDto>(urlInfo)));
            }
            else
            {
                return BadRequest("Invalid URL data.");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetCurrentUrlByShortUrlName(string shortUrl)
        {
            var urlInfo = await _urlService.GetCurrentUrlByShortUrl(shortUrl);
            return CreateActionResult(CustomResponseDto<UrlDto>.Success(201, _mapper.Map<UrlDto>(urlInfo)));
        }
    }
}
