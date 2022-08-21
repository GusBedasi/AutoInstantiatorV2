using PaymentMethodAutoInstantiator;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IPaymentService, PaymentService>();

builder.Services.AddScoped<IPaymentMethod, CreditCard>();
builder.Services.AddScoped<IPaymentMethod, DebitCard>();
builder.Services.AddScoped<IPaymentMethod, Voucher>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
