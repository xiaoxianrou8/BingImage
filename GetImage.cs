using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
/*图片下载类 */
namespace BingImage
{
    class GetImage
    {
        //图片网上地址信息
        public string ImageUrl { get; set; }
        //图片本地路径
        private string path;

        //网站根地址
        private string defaultUrl="http://cn.bing.com";
        //设置文件存储路径
        private void getImgSaveLoc()
        {
            //获取文件名
            string[] listStr=ImageUrl.Split('/');
            //获取文件名
            string fileName=listStr[listStr.Length-1];
            path="./Image/"+fileName;
        }
        #region 构造函数
        //自定义构造函数用于初始化:图片网址和图片地址
        public GetImage(string str)
        {
            ImageUrl=defaultUrl+str;
            getImgSaveLoc();
        }
        #endregion
       
        //获取图片字节信息
        public async Task<byte[]> GetImgbyte()
        {
          
            byte[] photo=null;
            //获取图片字节串
            using(var httpClient=new HttpClient())
            {
                byte[] bt=await httpClient.GetByteArrayAsync(ImageUrl);
                photo=bt;
            }
            return photo;
        }

        //保存图片到本地图库(./Image)
        public void SaveImg(byte[] photobt)
        {
            //查看图片是否已经下载
            if(File.Exists(path))
            {
                return;
            }
            //创造图片
            using(FileStream fileStream=new FileStream(path,FileMode.Create))
            {
                BinaryWriter binaryWriter=new BinaryWriter(fileStream);
                //写入图片信息
                binaryWriter.Write(photobt);
            }
        }
    }
}