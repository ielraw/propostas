using Infra.Queue;
using Contratacao.Consumer.Handlers;
using Domain.Dto;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddQueueServices(options =>
{
    builder.Configuration.GetSection("RabbitMQ").Bind(options);
});
builder.Services.AddQueueConsumer<ContratacaoResponseDto, ContratacaoMessageHandler>("contratacoes");
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
