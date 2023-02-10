using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Notissimus_test.BLL;
using Notissimus_test.BLL.Interfaces;
using Notissimus_test.DAL;
using Notissimus_test.DAL.Interfaces;
using Notissimus_test.Options;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

string connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<OfferDbContext>(options => options.UseSqlServer(connection));

builder.Services.AddScoped<IOfferRepository, OfferRepository>();

var url = new Uri(builder.Configuration["RemoteOfferStorage:Url"]);
var prov = System.Text.CodePagesEncodingProvider.Instance;
var codePage = int.Parse(builder.Configuration["RemoteOfferStorage:Encoding"]);
var enc = prov.GetEncoding(codePage);

builder.Services.AddSingleton<IOfferWebProvider>(serv => new OfferWebProvider(url, enc, (ILogger<OfferWebProvider>) serv.GetRequiredService(typeof(ILogger<OfferWebProvider>))));
builder.Services.AddScoped<IOfferService, OfferService>();

var mapperConfig = new MapperConfiguration(mc =>
{
	mc.AddProfile(new MappingProfile());
});
var mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id:long?}");

app.Run();
