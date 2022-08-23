using Microsoft.AspNetCore.Mvc;
using NewsFeedAPI.Enums;
using NewsFeedAPI.Models;
using NewsFeedAPI.Repositories;

namespace NewsFeedAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly INewsRepo _newsRepo;
        public NewsController(INewsRepo newsRepo)
        {
            _newsRepo = newsRepo;
        }

        [HttpGet("GetAllNews")]
        public Task<ResponseModel> GetAllNews()
        {
            return _newsRepo.GetAllNews();
        }


        [HttpGet("GetSingleNews/{id}")]
        public Task<ResponseModel> GetSingleNews(int id)
        {
            return _newsRepo.GetSingleNews(id);
        }


        [HttpGet("GetTopNews")]
        public Task<ResponseModel> GetTopNews()
        {
            return _newsRepo.GetTopNews();
        }


        [HttpGet("GetTopNews/{id}")]
        public Task<ResponseModel> GetNewsByCategory(int id)
        {
            if (id == (int)NewsCategory.US)
            {
                return _newsRepo.GetUSNews();
            }
            else if (id == (int)NewsCategory.World)
            {
                return _newsRepo.GetWorldNews();
            }
            else if (id == (int)NewsCategory.Science)
            {
                return _newsRepo.GetScienceNews();
            }
            else if (id == (int)NewsCategory.Arts)
            {
                return _newsRepo.GetArtsNews();
            }
            else
            {
                return Task.FromResult(new ResponseModel(ResponseCode.Error, "404! Not Found", ""));
            }
        }


        [HttpPost("SaveOrUpdateNews")]
        public Task<ResponseModel> SaveOrUpdateNews([FromForm] News news)
        {
            if (news.NewsId > 0)
            {
                return _newsRepo.UpdateNews(news);
            }
            else
            {
                return _newsRepo.SaveNews(news);
            }
        }


        [HttpPost("DeleteNews")]
        public Task<ResponseModel> DeleteNews(News news)
        {
            return _newsRepo.DeleteNews(news);
        }


    }
}
