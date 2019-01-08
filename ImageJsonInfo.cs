using System;
using System.Collections.Generic;
using Newtonsoft.Json;
/*处理json数据，反序列化为类对象 */
namespace BingImage
{
    #region Image的Json数据
    public class ImageJs
    {
        public List<ImageJsonInfo> images { get; set; }
    }
    public class ImageJsonInfo
    {
        public string startdate { get; set; }
        public string fullstartdate { get; set; }
        public string enddate { get; set; }
        public string url { get; set; }
        public string urlbase { get; set; }
        public string copyright { get; set; }
        public string title { get; set; }
        public string quiz { get; set; }
        public string wp { get; set; }
        public string hsh { get; set; }
        public string drk { get; set; }
        public string top { get; set; }
        public string bot { get; set; }
    }
    #endregion
    #region 故事的json数据
    public class StoryJson
    {
        public string date { get; set; }
        public string title { get; set; }
        public string attribute { get; set; }
        public string para1 { get; set; }
        public string para2 { get; set; }
        //版权
        public string provider { get; set; }
        public string imageUrl { get; set; }
        public string primaryImageUrl { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        //经度
        public string Longitude { get; set; }
        //维度
        public string Latitude { get; set; }
        //大洲
        public string Continent { get; set; }
        public string CityInEnglish { get; set; }
        public string CountryCode{ get; set; }
   }
    #endregion
    public class DelJson
    {
        public ImageJs BingImageJsonStr { get; set; }
        public StoryJson BingStoryJson { get; set; }
        ///<>
        public void DelImgJson(string json)
        {
            this.BingImageJsonStr=JsonConvert.DeserializeObject<ImageJs>(json);
        }
        public void DelTextJson(string json)
        {           
            this.BingStoryJson=JsonConvert.DeserializeObject<StoryJson>(json);          
        }
    }
   
}