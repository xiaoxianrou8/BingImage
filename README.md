# BingImage
##### 获取必应每日一图及故事
---
+ 获取图片api:http://cn.bing.com/HPImageArchive.aspx?format=js&idx=0&n=1
  * idx参数：指获取图片的时间，0（指获取当天图片），1（获取昨天照片），2（获取前天的图片），最多可获取8天前的照片。 
  * n参数：指获取图片的数量，n=1，指获取一张图片。
  * （也可以通过别的接口，比如：[Bing 壁纸 API](https://github.com/xCss/bing)
+ 如何将json数据转化为对象见：[c# getpost](https://github.com/xiaoxianrou8/GetPost)
+ 访问此url后返回的json数据如下：
```json
{
  "images":
  [
    {"startdate":"20190107",
      "fullstartdate":"201901071600",
      "enddate":"20190108",
      "url":"/az/hprichbg/rb/RainierDawn_ZH-CN9182470816_1920x1080.jpg",
      "urlbase":"/az/hprichbg/rb/RainierDawn_ZH-CN9182470816",
      "copyright":"瑞尼尔山国家公园，美国华盛顿州 (© Stephen Matera/Tandem Stills + Motion)",
      "copyrightlink":"http://www.bing.com/search?q=%E5%9B%BD%E5%AE%B6%E5%85%AC%E5%9B%AD&form=hpcapt&mkt=zh-cn",
      "title":"",
      "quiz":"/search?q=Bing+homepage+quiz&filters=WQOskey:%22HPQuiz_20190107_RainierDawn%22&FORM=HPQUIZ",
      "wp":false,
      "hsh":"c295f026b64b45e57248218481629f4e",
      "drk":1,
      "top":1,
      "bot":1,
      "hs":[]
      }],
      "tooltips":
      {
        "loading":"正在加载...",
        "previous":"上一个图像",
        "next":"下一个图像",
        "walle":"此图片不能下载用作壁纸。",
        "walls":"下载今日美图。仅限用作桌面壁纸。"
        }
      }
 ``` 
+ 图片的地址即为：必应地址+image[0].url(本例为：http://cn.bing.com/az/hprichbg/rb/RainierDawn_ZH-CN9182470816_1920x1080.jpg)
+ 获取图片,并保存至本地。 
  * 这里使用HttpClient类的GetByteArrayAsync方法。将图片存储为字节数组文件。
  ```csharp
  byte[] photo=null;
  //获取图片字节串
  using(var httpClient=new HttpClient())
  {
      byte[] bt=await httpClient.GetByteArrayAsync(ImageUrl);
      photo=bt;
  }
   ```
  * 将字节数组存储为文件。也可参照帖子[C# Stream 和 byte[] 之间的转换(文件流的应用)
](https://www.cnblogs.com/sunxuchu/p/5635473.html)
  ```csharp
  public void SaveImg(byte[] photobt)
  {
      //查看图片是否已经下载，path为路径
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
   ```
   这就是下载图片的步骤。
---
+ 获取故事：https://cn.bing.com/cnhp/coverstory
+ 返回的json数据：
   ```json
   {
  "date":"January 08",
  "title":"一个国家的灵魂之地",
  "attribute":"美国，瑞尼尔山国家公园",
  "para1":"大多数人选择在温暖舒适的天气里来这儿，但冬天的凌冽和雪景会给这里带来另一种惊人的美。
  在华盛顿州的瑞尼尔山国家公园(Mount Rainier National Park)，冬天是享受休闲冰雪活动的好时机。
  冬季的额外好处是，这时的国家公园没有夏季那样拥挤的人群。在大提顿山脉的雪地上，你很容易就能看
  到成群的麋鹿和其他野生动物。或者漫步在布赖斯峡谷白雪皑皑的峰顶(高耸的红色岩石尖顶)，此刻的你
  可能会觉得冬天才是参观这个国家公园的最佳时间。今天的壁纸便是我们拍到的公园中透过云层的日出。",
  "para2":"",
  "provider":"© Stephen Matera/Tandem Stills + Motion",
  "imageUrl":"http://hpimges.blob.core.chinacloudapi.cn/coverstory/watermark_rainierdawn_zh-cn9182470816_1920x1080.jpg",
  "primaryImageUrl":"http://hpimges.blob.core.chinacloudapi.cn/coverstory/watermark_rainierdawn_zh-cn9182470816_1920x1080.jpg",
  "Country":"美国",
  "City":"瑞尼尔山国家公园",
  "Longitude":"-121.759415",
  "Latitude":"46.853148",
  "Continent":"北美洲",
  "CityInEnglish":"Mount Rainier National Park",
  "CountryCode":"US"
}
 ```
 + 反序列化处理即可，json数据处理见：[如何用API获取天气信息](https://github.com/xiaoxianrou8/GetPost)
 ---
 详细请看代码。:blush:
