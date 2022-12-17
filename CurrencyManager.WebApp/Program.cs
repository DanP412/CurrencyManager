using CurrencyManager.Logic.Services.CurrencyProvider;

namespace CurrencyManager.WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Razor - jedna z web�wkowych technologii Microsoftu, kt�ra umo�liwia wplatanie kodu C# w widoki HTMLowe (pliki nazywaj� si� cshtml)

            // wwwroot - folder w kt�rym umieszczamy wszystko co poleci w paczce do widok�w cshtml (czyli wszystkie css, js, biblioteki, itp...)

            // Akcja - metoda kontrolera, kt�ra ma zwr�ci� widok cshtml
            // (wydaje mi si�, �e) nazwa metody akcji b�dzie taka sama jak podstrona w adresie url

            // Metoda zapewniaj�ca zachowanie, �e w akcjach kontrolera po u�yciu metody View(), apka b�dzie szuka� po nazwie kontrolera odpowiedniego widoku
            // Np. Dla HomeController i akcji Index, b�dzie szuka� widoku Views/Home/Index.cshtml
            // Np. Dla CurrencyController i akcji ShowCurrencies, b�dzie szuka� widoku Views/Currency/ShowCurrencies.cshtml
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