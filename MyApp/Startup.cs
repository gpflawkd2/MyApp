using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace MyApp
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

        // IServiceCollection: 컨테이너
        // 컨테이너에 services 를 추가함(의존성 주입:Defendency Injection)
        // 어플리케이션 어느곳에서든지 이 서비스를 간편한 방법으로 사용할 수 있음
        public void ConfigureServices(IServiceCollection services)
        {
            //Mvc 실행
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        // HTTP processing pipeline을 설정해주는 곳
        // 어떤 웹요청이 들어왔을 때 어떻게 듣고, 어떤 식으로 진행할 것인가를 정의해주는 곳
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            /*
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
            */

            //wwwroot의 Static File을 사용함
            app.UseStaticFiles();

            //라우팅 미들웨어 설정
            //id?로 표시해줌으로써 id값을 넣지 않아도 페이지 실행 가능
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    //template: "{controller}/{action}/{id?}"
                    //웹사이트 접속시 첫화면 설정(HomeController > Student 실행화면)
                    template: "{controller=Home}/{action=Student}/{id?}"
                    );
            });
        }
    }
}
