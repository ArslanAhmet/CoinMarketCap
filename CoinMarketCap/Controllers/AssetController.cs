using CoinMarketCap.Core.Entities;
using CoinMarketCap.Core.Models;
using CoinMarketCap.Infrastructure.Data;
using CoinMarketCap.Infrastructure.Helpers;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace CoinMarketCap.Controllers
{
    [ApiController]
    [Route("api/assets")]
    public class AssetController : ControllerBase
    {
        public IAssetRepository _assetRepository;
        private ILogger<AssetController> _logger;
        IAsyncMapper<IEnumerable<Asset>, IEnumerable<AssetDto>> _assetDtoListMapper;
        IAsyncMapper<Asset, AssetDto> _assetDtoMapper;
        IMapper<AssetForCreationDto, Asset> _assetCreationMapper;
        public AssetController(IAssetRepository assetRepository,
            ILogger<AssetController> logger,
            IAsyncMapper<IEnumerable<Asset>, IEnumerable<AssetDto>> assetDtoListMapper,
            IAsyncMapper<Asset, AssetDto> assetDtoMapper,
            IMapper<AssetForCreationDto, Asset> assetCreationMapper)
        {
            _assetRepository = assetRepository ?? throw new ArgumentNullException(nameof(assetRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _assetDtoListMapper = assetDtoListMapper ?? throw new ArgumentNullException(nameof(assetDtoListMapper));
            _assetDtoMapper = assetDtoMapper ?? throw new ArgumentNullException(nameof(assetDtoMapper));
            _assetCreationMapper = assetCreationMapper ?? throw new ArgumentNullException(nameof(assetCreationMapper));
        }

        [HttpGet(Name = "GetAssets")]
        public async Task<IActionResult> GetAssetsAsync([FromQuery] AssetsResourceParameters assetsResourceParameters)
        {
            List<Asset> assetsFromRepo = await _assetRepository.GetAssets(assetsResourceParameters);

            var assets = await _assetDtoListMapper.MapAsync(assetsFromRepo);

            return Ok(assets);

        }


        [HttpPost]
        public async Task<IActionResult> CreateAsset([FromBody] AssetForCreationDto assetForCreationDto)
        {
            if (assetForCreationDto == null)
            {
                return BadRequest();
            }

            var assetEntity = _assetCreationMapper.Map(assetForCreationDto);

            _assetRepository.AddAsset(assetEntity);

            await _assetRepository.SaveChangesAsync();

            var assetToReturn = await _assetDtoMapper.MapAsync(assetEntity);

            return CreatedAtRoute("GetAsset", new { Id = assetToReturn.Id }, assetToReturn);
        }

        [HttpGet("{Id}", Name = "GetAsset")]
        public async Task<IActionResult> GetAssetAsync( int Id)
        {

            var assetFromRepo = await _assetRepository.GetAssetAsync(Id);
            if (assetFromRepo == null)
            {
                return NotFound();
            }

            var assetToReturn = _assetDtoMapper.MapAsync(assetFromRepo);

            return Ok(assetToReturn);
        }

    }
}