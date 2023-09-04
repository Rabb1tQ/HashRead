using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace hash
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(@"                                                                                                                 
          /@@                      *@@@@@]*         ,@@^     /@@        ,@\             ,/@@]                    
          =@`                       @@  =@^         *@/      =@`                /@    ,@/  =@^                   
         ,@@@\@^ ,\@/`\@/`         =@^ /@[ ,//[\@`  /@@/@@* ,@@@\@^  ,[\@^   ,[@@[[[ =@/   /@^                   
         @@  *@@  =@^/@           ,@/=@^    ,]]/@* =@^  =@^ @@  *@@   ,@/     =@^   ,@@   =@/                    
        =@`  /@*  =@@/            @@ =@^ ,@@* =@^ *@/  ,@^ =@`  /@*   @@     *@/    =@@@@\@/                     
       ,@@\/@`    =@`           ,/@\*=@\`,@\]@@@/ /@@]@/* ,@@\/@`  ,]/@\]    ,@\@[   \@/@/*                      
               =@@/                                                                    *[[                       
                                                                                                        ");
            string strNotice = "使用cmd打开，格式：hash.exe md5|sha1|sha256|空（显示所有类型hash值） 文件路径";
            if (args == null || args.Length == 0||args.Length>2) {
                Console.WriteLine(strNotice);
                return;
            }
            if (args.Length == 1) {
                if (File.Exists(args[0]))
                {
                    GetAll(args[0]);
                    return;
                }
                else {
                    Console.WriteLine(strNotice);
                    return;
                }
            }
            switch (args[0])
            {
                case "all":
                    GetAll(args[1]);
                    break;
                case "md5":
                    GetMD5(args[1]);
                    break;
                case "sha1":
                    GetSHA1(args[1]);
                    break;
                case "sha256":
                    GetSHA256(args[1]);
                    break;
                default:
                    Console.WriteLine("使用cmd打开，格式：hash.exe all|md5|sha1|sha256 文件路径");
                    break;
            }
        }

        private static void GetAll(string path)
        {
            GetMD5(path);
            GetSHA1(path);
            GetSHA256(path);
        }
        private static void GetMD5(string path)
        {
            var hash = MD5.Create();
            var stream = new FileStream(path, FileMode.Open);
            byte[] hashByte = hash.ComputeHash(stream);
            stream.Close();
            Console.WriteLine("md5:" + BitConverter.ToString(hashByte).Replace("-", ""));
        }
        private static void GetSHA256(string path)
        {
            var hash = SHA256.Create();
            var stream = new FileStream(path, FileMode.Open);
            byte[] hashByte = hash.ComputeHash(stream);
            stream.Close();
            Console.WriteLine("sha256:" + BitConverter.ToString(hashByte).Replace("-", ""));
        }
        private static void GetSHA1(string path)
        {
            var hash = SHA1.Create();
            var stream = new FileStream(path, FileMode.Open);
            byte[] hashByte = hash.ComputeHash(stream);
            stream.Close();
            Console.WriteLine("sha1:" + BitConverter.ToString(hashByte).Replace("-", ""));
        }
    }
}
