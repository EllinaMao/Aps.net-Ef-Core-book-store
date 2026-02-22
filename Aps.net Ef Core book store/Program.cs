/*
 Разработайте веб-приложение для онлайн-магазина книг. Пользователи могут просматривать каталог книг и оставлять комментарии.
Функциональные требования:

1) Просмотр каталога книг: Пользователи могут просматривать каталог всех доступных книг с информацией о названии, авторе, жанре и цене.
2) Публикация комментария: Пользователи могут оставлять комментарии для любой из книг. Сами комментарии отображаются внизу страницы с книгой.
3) Взаимодействие с Entity Framework Core: Информации про книги и комментарии должных хранится в базе данных. Управление базой данных осуществляется через EF Core.

Для каждой книги, добавьте возможность загружать несколько изображений.
 */
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
