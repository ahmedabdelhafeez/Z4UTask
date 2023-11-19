
using FizooHelper.Models;
namespace FizooHelper.Paginations
{
    public static class Paginator
    {
        public static List<T>ToPagedList<T>(this IQueryable<T> query,PageInfo pageInfo)
        {
            if (pageInfo == null||pageInfo.Page<1)
                return query.ToList();
            return query.Skip((pageInfo.Page - 1) * pageInfo.PageSize).Take(pageInfo.PageSize).ToList();
        }
    }
}
