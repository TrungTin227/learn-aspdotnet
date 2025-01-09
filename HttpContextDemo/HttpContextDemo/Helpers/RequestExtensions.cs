namespace HttpContextDemo.Helpers
{
    //Viết 1 hàm chuyên để viết các Extension method thì phải dùng static class
    public static class RequestExtensions
    {
        public static string GetDebugInfo(this HttpRequest request)
        {
            return $"{request.Scheme}://{request.Host}";
        }
    }
}
