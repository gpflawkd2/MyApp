using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyApp.Data;
using MyApp.Data.Repositories;

namespace MyApp
{
    // This method gets called by the runtime. Use this method to add services to the container.
    public class Startup
    {
        private readonly IConfiguration _config;

        //ctor + Tab 2번 -> 생성자 생성
        //IConfiguration 서비스를 통해 appsettings.json 파일을 불러올 수 있음
        public Startup(IConfiguration config)
        {
            _config = config;
        }
        // IServiceCollection: 컨테이너
        // 컨테이너에 services 를 추가함(의존성 주입:Defendency Injection)
        // 어플리케이션 어느곳에서든지 이 서비스를 간편한 방법으로 사용할 수 있음
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<MyAppContext>(options =>
            {
                //GetConnectionString: MyAppConnection의 Value값을 불러옴
                options.UseSqlServer(_config.GetConnectionString("MyAppConnection"));
            });

            /*
            Transient() 함수는 필요할 때마다 생성되는 서비스
            http 요청이 있을 때마다 새로운 instance를 매번 생성하는 생명주기를 가지고 있음
            캐시 내에 머물러있지 않고 보존되지 않는 형태   
            DbSeeder는 웹어플리케이션의 생명주기에서 딱 한번만 필요한 서비스이므로 Transient() 함수가 적합함
            */
            services.AddTransient<DbSeeder>();

            /*
            Scoped() 함수는 첫 번째 파라미터(ITeacherRepository)를 필요로 하는 곳에서 http 요청이 있을 때마다
            instance를 생성하고 생성된 instance를 http 요청 안에서 계속 재사용하는 생명주기를 가지고 있음
            데이터 접근 컴포넌트에서 많이 쓰임
            */

            //첫 번째 파라미터(ITeacherRepository)는 앞으로 서비스로서 Application 안에서 쓸 수 있게 하고 TeacherRepository는 ITeacherRepository에 구현화된 클래스로서 사용하라는 의미
            services.AddScoped<ITeacherRepository, TeacherRepository>();

            /*
            Singleton() 함수는 Application의 생명주기동안 단 한번만 instance를 생성하고 http 요청이 있을 때마다 생성된 instance를 계속 재사용함
            주로 속성이 변하지 않는 정적인 데이터를 메모리 내에 저장해서 의존성주입이 필요할 때마다 쓰임
            */
            //services.AddSingleton<>();


            //Mvc 실행
            services.AddMvc();
        }

        // HTTP processing pipeline을 설정해주는 곳
        // 어떤 웹요청이 들어왔을 때 어떻게 듣고, 어떤 식으로 진행할 것인가를 정의해주는 곳
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, DbSeeder seeder)
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

            /*
            Routing MiddleWare Setting
            Mvc에서는 Url의 패턴을 보고 Routing을 결정함
            매개변수 뒤에 ?를 추가함으로써 선택적인 매개변수가 됨
            ex. /Home/Student, /Home/Student/2 모두 가능
            */
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    //template: "{controller}/{action}/{id?}"
                    //웹사이트 접속시 첫화면 설정(HomeController > Index 실행화면)
                    template: "{controller=Home}/{action=Index}/{id?}"
                    );
            });

            seeder.SeedDatabase().Wait();
        }
    }
}
