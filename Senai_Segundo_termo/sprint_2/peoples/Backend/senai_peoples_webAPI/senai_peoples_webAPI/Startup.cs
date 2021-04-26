using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_peoples_webAPI
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // define o uso de Controllers
            services.AddControllers();

            services
                // definindo a forma de autenticação JwtBearer
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = "JwtBearer";
                    options.DefaultChallengeScheme = "JwtBearer";
                })
                // define os parâmetros de validação do token
                .AddJwtBearer("JwtBearer", options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        // vamos validar quem está emitindo?
                        ValidateIssuer = true, // true = sim

                        // vamos validar quem está recebendo?
                        ValidateAudience = true, // true = sim

                        // vamos validar o tempo de expiração?
                        ValidateLifetime = true, // true = sim

                        // validação da forma de criptografia e a chave de autenticação?
                        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("peoples-chave-autenticacao")),

                        // qual foi o tempo de expiração do token?
                        ClockSkew = TimeSpan.FromMinutes(30), // olhando a diferença do tempo do token com o tempo atual, vai verificar se o tempo é maior que 30min, se for maior que 30min, o token expira

                        // nome do issuer, de onde está vindo?
                        ValidIssuer = "Peoples.webAPI",

                        // nome do audience, para onde está indo?
                        ValidAudience = "Peoples.webAPI"
                    };
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            // habilita a autenticação (ou tá logado ou não tá logado)
            app.UseAuthentication();

            // habilita a autorização
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                // define o mapeamento dos Controllers
                endpoints.MapControllers();
            });
        }
    }
}