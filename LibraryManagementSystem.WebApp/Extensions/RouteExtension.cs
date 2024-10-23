namespace LibraryManagementSystem.WebApp.Extensions
{
    public static class RouteExtension
    {
        public static IApplicationBuilder UseMyRoutes(this IApplicationBuilder app)
        {

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "booksIndexRoute",
                    pattern: "books/page/{pageNumber}",
                    defaults: new { controller = "Books", action = "Index" });

                endpoints.MapControllerRoute(
                    name: "booksCreateRoute",
                    pattern: "books/create",
                    defaults: new { controller = "Books", action = "Create" });

                endpoints.MapControllerRoute(
                    name: "booksUpdateRoute",
                    pattern: "books/update/{id}/{bookTitle}",
                    defaults: new { controller = "Books", action = "Update" });

                endpoints.MapControllerRoute(
                    name: "booksDetailRoute",
                    pattern: "books/detail/{id}/{bookTitle}",
                    defaults: new { controller = "Books", action = "Detail" });


                endpoints.MapDefaultControllerRoute();
            });

            return app;
        }
    }
}
