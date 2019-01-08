using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace BingImage
{
    //发送Get请求，并获取json数据
    class BingJson
    {
        public async Task<string> GetJsonData(string APILoc)
        {
            string responseBody=null;
            Uri APIUri=new Uri(APILoc);
            using(var httpClient=new HttpClient())
            {
                TimeSpan timeOut = new TimeSpan(0, 0, 30);
                httpClient.Timeout = timeOut;
                responseBody= await httpClient.GetStringAsync(APIUri);
            }
            return responseBody;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string ImageJsonStr=null;
            string TextJsonStr=null;
            string ImageUri="http://cn.bing.com/HPImageArchive.aspx?format=js&idx=0&n=1";
            string StoryUri="https://cn.bing.com/cnhp/coverstory";
            //图片下载地址
            string ImageUrlStr=null;
            //获取图片的json文本
            BingJson bingJson=new BingJson();
            ImageJsonStr= bingJson.GetJsonData(ImageUri).Result;
            //获取文本的json文本
            TextJsonStr=bingJson.GetJsonData(StoryUri).Result;
            //将json数据转化为对象
            DelJson delJson=new DelJson();
            delJson.DelTextJson(TextJsonStr);
            delJson.DelImgJson(ImageJsonStr);
            //下载每日图片
            ImageUrlStr=delJson.BingImageJsonStr.images[0].url;
            GetImage getImage=new GetImage(ImageUrlStr);
            //等待图片下载
            byte[] pt= getImage.GetImgbyte().Result;
            //存储图片
            getImage.SaveImg(pt);
            Console.WriteLine(delJson.BingImageJsonStr);
        }
    }
}
