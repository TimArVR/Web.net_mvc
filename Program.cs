namespace WebNETFirstProj
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // добавляем поддержку контроллеров с представлениями ДО вызова()
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            //app.MapGet("/", () => "Hello World!");
            //Добавили страничку about, но это подходит только для чего то простого
            //app.MapGet("/about", () => "Myfirst App");    

            //Добавили функционал чтобы заработали статичные файлы
            app.UseStaticFiles();


            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}"
                );


            app.Run();
        }
    }
}
