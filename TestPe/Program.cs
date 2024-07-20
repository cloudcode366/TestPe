using DataAccessObject;
using DataAccessObject.iml;
using DataModel;
using Repository;
using Repository.iml;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Thời gian hết hạn của Session
    options.Cookie.HttpOnly = true; // Cookie chỉ có thể truy cập qua HTTP
    options.Cookie.IsEssential = true; // Cookie cần thiết cho ứng dụng
}); builder.Services.AddDbContext<OilPaintingArt2024DbContext>();
builder.Services.AddScoped(typeof(IDAO<>), typeof(DAO<>));
builder.Services.AddScoped<IArtRepo, ArtRepo>();
builder.Services.AddScoped<IAccountRepo, AccountRepo>();
builder.Services.AddScoped<ISupplierRepo, SupplierRepo>();  
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseSession();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.MapGet("/", async context =>
{
    context.Response.Redirect("/login");
});
app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
