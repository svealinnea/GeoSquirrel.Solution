using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace GeoSquirrelClient.Models
{
  public class Cache
  {
    public int CacheId { get; set; }
    public string Name{ get; set; }
    public decimal Latitude { get; set; }
    public decimal Longitude { get; set; }
    public DateTime DateCreated { get; set; }
    // public GeoLocation location { get; set; }
    public virtual ApplicationUser User { get; set; } 

    public static List<Cache> GetCaches()
    {
      var apiCallTask = ApiHelper.GetAll();
      Console.WriteLine(apiCallTask);
      var result = apiCallTask.Result;
      Console.WriteLine(result);
      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      Console.WriteLine(jsonResponse);
      List<Cache> cacheList = JsonConvert.DeserializeObject<List<Cache>>(jsonResponse.ToString());
      Console.WriteLine(cacheList);
      return cacheList;
    }

    public static Cache GetDetails(int id)
    {
      var apiCallTask = ApiHelper.Get(id);
      var result = apiCallTask.Result;

      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      Cache cache = JsonConvert.DeserializeObject<Cache>(jsonResponse.ToString());

      return cache;
    }

    public static void Post(Cache cache)
    {
      string jsonCache = JsonConvert.SerializeObject(cache);
      var apiCallTask = ApiHelper.Post(jsonCache);
    }

    public static void Put(Cache cache)
    {
      string jsonCache = JsonConvert.SerializeObject(cache);
      var apiCallTask = ApiHelper.Put(cache.CacheId, jsonCache);
    }

    public static void Delete(int id)
    {
      var apiCallTask = ApiHelper.Delete(id);
    }
  }
}