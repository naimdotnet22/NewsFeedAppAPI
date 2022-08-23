using NewsFeedAPI.Models;

namespace NewsFeedAPI.Repositories
{
    public interface INewsRepo
    {
        Task<ResponseModel> DeleteNews(News news);
        Task<ResponseModel> GetAllNews();
        Task<ResponseModel> GetSingleNews(int id);
        Task<ResponseModel> GetTopNews();
        Task<ResponseModel> GetUSNews();
        Task<ResponseModel> GetWorldNews();
        Task<ResponseModel> GetScienceNews();
        Task<ResponseModel> GetArtsNews();
        Task<ResponseModel> SaveNews(News news);
        Task<ResponseModel> UpdateNews(News news);
    }
}