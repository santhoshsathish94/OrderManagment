using Newtonsoft.Json;

namespace OrderManagment.Application.Helpers
{
    public static class ExtensionHelpers
    {
        public static object? ConvertToObject(this string str)
        {
            try
            {
                return str != null ? JsonConvert.DeserializeObject(str) : default;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                // ignored
            }

            return default;
        }

        public static T? ConvertToModel<T>(this string obj)
        {
            try
            {
                return obj != null ? JsonConvert.DeserializeObject<T>(obj) : default(T);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                // ignored
            }

            return default(T);
        }

        public static string ToJsonString(this object obj)
        {
            return obj != null ? JsonConvert.SerializeObject(obj) : string.Empty;
        }

        public static bool IsNotNull(this object obj)
        {
            return obj != null;
        }

        public static string ToCommaSeperatedString(this List<int> list)
        {
            if (list == null || list.Count < 1)
            {
                return String.Empty;
            }
            return string.Join(",", list.Select(item => item.ToString()).ToArray());
        }
    }
}
