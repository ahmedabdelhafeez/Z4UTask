using FizooHelper.Models;
using FizooHelper.Paginations;
using System.Linq.Dynamic.Core;
using System.Reflection;

namespace FizooHelper.MyFilters
{
    public static class MyFilters
    {
        public static IQueryable<T>Filter<T>(this IQueryable<T> source, SearchModel? model)
        {
            if (model == null)
                return source;
            string query = "";// $"ProductAmount.SeasionID== \"{model.SeasionId}\" ";
            if(model.filterItems!=null)
            {
                foreach(var item in model.filterItems)
                {
                    var res = 0;
                    if (item.IsNum && !int.TryParse(item.Value, out  res))
                        continue;
                    query += query == "" ? "" :GetLogic(item.Logic);
                    query += $"{item.Field} {GetOperator(item.Operator)} \"{(item.IsNum?res:item.Value)}\" " ;
                }
            }
            if (!string.IsNullOrEmpty(model.Text))
            {
                string searchQuery = "";
                Type type = typeof(T);
                PropertyInfo[] properties = type.GetProperties();
                for (int z = 0; z < properties.Length; z++)
                {
                    if (properties[z].PropertyType == typeof(string) && properties[z].GetSetMethod() != null)
                    {
                        searchQuery += searchQuery != "" ? "||" : "";
                        searchQuery += $"{properties[z].Name}.Contains(\"{model.Text}\")";
                    }
                    else if(properties[z].PropertyType == typeof(int) && properties[z].GetSetMethod() != null)
                    {
                        searchQuery += searchQuery != "" ? "||" : "";
                        searchQuery += $"{properties[z].Name}.Contains(\"{model.Text}\")";
                    }
                }
                if (searchQuery != "")
                {
                    query += query == "" ? "" : "&&";
                    query += "(" + searchQuery + ")";
                }
            }
            return (query != "")? source.Where(query):source;
            
        }     
        public static IQueryable<T>ContainsString<T>(this IQueryable<T> source,string? Search)
        {
            if (string.IsNullOrEmpty(Search))
                return source;
            string query = "";
            Type type = typeof(T); 
            PropertyInfo[] properties = type.GetProperties();
            for (int z = 0; z < properties.Length; z++)
            {
                if (properties[z].PropertyType == typeof(string) && properties[z].GetSetMethod()!=null)
                {
                    query += query != "" ? "||" : "";
                    query += $"{properties[z].Name}.Contains(\"{Search}\")";
                }
            }
            return (query != "")? source.Where(query):source;
            
        }

   
        public static List<T>Filter<T>(this IQueryable<T> source,FilterModel? model)
        {
            if (model == null)
                return source.ToList();
            return source.Filter(model.Search).ToPagedList(model.PageInfo);
        }
        private static string GetOperator(Operators op)
        {
            switch(op)
             {
                case Operators.equal:
                    return "==";
                case Operators.notEqual:
                    return "!=";
                case Operators.lessThan:
                    return "<";
                case Operators.lessThanOrEqual:
                    return "<=";
                case Operators.greaterThan:
                    return ">";
                case Operators.greaterThanOrEqual:
                    return ">=";
                default:
                    return "";
             }
        }
        public static string GetLogic(Logic logic)
        {
            if (logic == Logic.and)
                return "&&";
            else return "||";
        }
    }
}
