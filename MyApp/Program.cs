using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace MyApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();

        //CreateDefaultBuilder()
        //웹어플리케이션을 실행시키기 위한 기본적인 것들을 구축하는 함수
        //App의 기초환경 설정, 로깅, 기본서버 셋팅 등

        //UseStartup<Startup>()
        //어떤 웹요청이 우리 서버로 들어왔을 때 Startup class 실행

    }
}
