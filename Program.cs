namespace WebNETFirstProj
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // ��������� ��������� ������������ � ��������������� �� ������()
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            //app.MapGet("/", () => "Hello World!");
            //�������� ��������� about, �� ��� �������� ������ ��� ���� �� ��������
            //app.MapGet("/about", () => "Myfirst App");    

            //�������� ���������� ����� ���������� ��������� �����
            app.UseStaticFiles();


            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}"
                );


            app.Run();
        }
    }
}
