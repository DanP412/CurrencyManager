using CurrencyManager.Logic.Services.CurrencyProvider;

namespace CurrencyManager.WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Razor - jedna z webówkowych technologii Microsoftu, która umo¿liwia wplatanie kodu C# w widoki HTMLowe (pliki nazywaj¹ siê cshtml)

            // wwwroot - folder w którym umieszczamy wszystko co poleci w paczce do widoków cshtml (czyli wszystkie css, js, biblioteki, itp...)

            // Akcja - metoda kontrolera, która ma zwróciæ widok cshtml
            // (wydaje mi siê, ¿e) nazwa metody akcji bêdzie taka sama jak podstrona w adresie url

            // Metoda zapewniaj¹ca zachowanie, ¿e w akcjach kontrolera po u¿yciu metody View(), apka bêdzie szukaæ po nazwie kontrolera odpowiedniego widoku
            // Np. Dla HomeController i akcji Index, bêdzie szukaæ widoku Views/Home/Index.cshtml
            // Np. Dla CurrencyController i akcji ShowCurrencies, bêdzie szukaæ widoku Views/Currency/ShowCurrencies.cshtml
            builder.Services.AddControllersWithViews();
            builder.Services.AddTransient<ICurrencyProviderService, ApiCurrencyProviderService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            // Ustalanie paternu mapowania adresu url na kontrolery, akcje i argumenty 
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Currency}/{action=Index}/{id?}");

            app.Run();
        }
    }
}