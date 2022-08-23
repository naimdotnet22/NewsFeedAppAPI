using Microsoft.EntityFrameworkCore;
using NewsFeedAPI.Context;
using NewsFeedAPI.Enums;
using NewsFeedAPI.Models;

namespace NewsFeedAPI.Repositories
{
    public class NewsRepo : INewsRepo
    {
        private readonly AppDbContext _context;
        public NewsRepo(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> GetAllNews()
        {
            try
            {
                var data = await _context.News.ToListAsync();
                return await Task.FromResult(new ResponseModel(ResponseCode.OK, "All News Data", data));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(new ResponseModel(ResponseCode.Error, ex.Message, ""));
            }
        }


        public async Task<ResponseModel> GetTopNews()
        {
            try
            {
                var data = await _context.News.Take(9)
                .OrderByDescending(c => c.PublishedAt).ToListAsync();
                return await Task.FromResult(new ResponseModel(ResponseCode.OK, "Top 9 Data", data));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(new ResponseModel(ResponseCode.Error, ex.Message, ""));
            }
        }


        public async Task<ResponseModel> GetUSNews()
        {
            try
            {
                var data = await _context.News
                    .Where(c=>c.Category == NewsCategory.US).ToListAsync();
                return await Task.FromResult(new ResponseModel(ResponseCode.OK, "US Data List", data));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(new ResponseModel(ResponseCode.Error, ex.Message, ""));
            }
        }


        public async Task<ResponseModel> GetWorldNews()
        {
            try
            {
                var data = await _context.News
                    .Where(c => c.Category == NewsCategory.World).ToListAsync();
                return await Task.FromResult(new ResponseModel(ResponseCode.OK, "World Data List", data));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(new ResponseModel(ResponseCode.Error, ex.Message, ""));
            }
        }


        public async Task<ResponseModel> GetScienceNews()
        {
            try
            {
                var data = await _context.News
                    .Where(c => c.Category == NewsCategory.Science).ToListAsync();
                return await Task.FromResult(new ResponseModel(ResponseCode.OK, "Science Data List", data));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(new ResponseModel(ResponseCode.Error, ex.Message, ""));
            }
        }


        public async Task<ResponseModel> GetArtsNews()
        {
            try
            {
                var data = await _context.News
                    .Where(c => c.Category == NewsCategory.Arts).ToListAsync();
                return await Task.FromResult(new ResponseModel(ResponseCode.OK, "Arts Data List", data));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(new ResponseModel(ResponseCode.Error, ex.Message, ""));
            }
        }


        public async Task<ResponseModel> GetSingleNews(int id)
        {
            try
            {
                var data = _context.News.Where(c => c.NewsId == id);
                return await Task.FromResult(new ResponseModel(ResponseCode.OK, "News based on Id", data));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(new ResponseModel(ResponseCode.Error, ex.Message, ""));
            }
        }


        public async Task<ResponseModel> SaveNews(News news)
        {
            try
            {
                if (news != null)
                {
                    await _context.News.AddAsync(news);
                    await _context.SaveChangesAsync();
                    return await Task.FromResult(new ResponseModel(ResponseCode.OK, "Saved Successfully!", news));
                }
                return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Save Failed!", ""));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(new ResponseModel(ResponseCode.Error, ex.Message, ""));
            }
        }


        public async Task<ResponseModel> UpdateNews(News news)
        {
            try
            {
                if (news != null)
                {
                    _context.Entry(news).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    return await Task.FromResult(new ResponseModel(ResponseCode.OK, "Updated Successfully!", news));
                }
                return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Update Failed!", ""));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(new ResponseModel(ResponseCode.Error, ex.Message, ""));
            }
        }


        public async Task<ResponseModel> DeleteNews(News news)
        {
            try
            {
                if (news != null)
                {
                    _context.Entry(news).State = EntityState.Deleted;
                    await _context.SaveChangesAsync();
                    return await Task.FromResult(new ResponseModel(ResponseCode.OK, "Deleted Successfully!", ""));
                }
                return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Delete Failed! Object is Null.", ""));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(new ResponseModel(ResponseCode.Error, ex.Message, ""));
            }
        }

    }
}
