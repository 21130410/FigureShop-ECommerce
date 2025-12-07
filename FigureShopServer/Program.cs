using FigureShopServer.Data;
using FigureShopServer.Responsitories;
using FigureShopSharedLibrary.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); //ui
//starting
builder.Services.AddDbContext<AppDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default") ?? throw new InvalidOperationException("ConnectString not found"));
}
);
builder.Services.AddScoped<IProduct, ProductReponsitory>();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseWebAssemblyDebugging();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseAuthorization();
app.UseBlazorFrameworkFiles();
app.MapRazorPages();

//Ánh xạ routes cho Razor Pages
//Ví dụ: / Login, / About, / Contact
app.MapControllers();
//Ánh xạ routes cho MVC Controllers
//Theo convention: /{ controller}/{ action}/{ id ?}
//Ví dụ: / Home / Index, / Products / Details / 5
app.MapFallbackToFile("index.html"); 
//Khi không tìm thấy route phù hợp với các endpoint đã định nghĩa

//Nó sẽ trả về file index.html thay vì lỗi 404

//Cho phép client-side routing xử lý các route còn lại

app.Run();
