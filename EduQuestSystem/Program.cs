using Common.Jwt;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using XiaoYuJi.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

#region 跨域配置
builder.Services.AddCors(options =>
{
    options.AddPolicy("Cors", config =>
    {
        config.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
    });
});

#endregion

#region WebApi项目配置
builder.Services.AddDbContext<SqlDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("strConn"));
});

#endregion

#region 依赖注入配置

#region 仓储依赖注入
#endregion



#endregion

#region Jwt授权认证配置

//读取Jwt配置信息
var jwtSection = builder.Configuration.GetSection("TokenManagement");
//Jwt配置信息，注入配置中
builder.Services.Configure<TokenManagement>(jwtSection);

TokenManagement tokenManagement = jwtSection.Get<TokenManagement>();

//Jwt鉴权配置
builder.Services.AddAuthorization(options =>
{

})
    .AddAuthentication(options =>
    {
        //2.1【认证】、core自带官方JWT认证
        // 开启Bearer认证
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    }).AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,    //是否验证SecurityKey
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(tokenManagement.Secret)),    //这里的key要进行加密
            //验证发布者Issuer
            ValidateIssuer = true,
            ValidIssuer = tokenManagement.Issuer,   //Token颁发机构
            //验证接收者
            ValidateAudience = true,
            ValidAudience = tokenManagement.Audience,   //颁发给谁   
            ValidateLifetime = true,    //验证token过期时间
            ClockSkew = TimeSpan.FromSeconds(30),    //时钟缓冲相位差
            RequireExpirationTime = true,   //token需要设置过期时间
        };
        options.Events = new JwtBearerEvents
        {
            OnAuthenticationFailed = context =>
            {
                // 如果过期，则把<是否过期>添加到，返回头信息中
                if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                {
                    context.Response.Headers.Add("Token-Expired", "true");
                }
                return Task.CompletedTask;
            }
        };
    });


#endregion

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

app.UseCors("Cors");

app.UseStaticFiles();   //静态文件资源

app.UseAuthentication();    //启用身份认证

app.UseAuthorization(); //授权

app.MapControllers();

app.Run();
