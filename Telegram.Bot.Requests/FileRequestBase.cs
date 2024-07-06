using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Telegram.Bot.Helpers;
using Telegram.Bot.Types.InputFiles;

namespace Telegram.Bot.Requests;

[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public abstract class FileRequestBase<TResponse> : RequestBase<TResponse>
{
    public class NewContent
    {
        public string Name { get; set; }

        public StringContent Content { get; set; }
    }

    protected FileRequestBase(string methodName)
        : base(methodName)
    {
    }

    protected FileRequestBase(string methodName, HttpMethod method)
        : base(methodName, method)
    {
    }

    protected MultipartFormDataContent ToMultipartFormDataContent(string fileParameterName, InputFileStream inputFile)
    {
        MultipartFormDataContent multipartFormDataContent = GenerateMultipartFormDataContent(fileParameterName);
        multipartFormDataContent.smethod_1(inputFile.Content, fileParameterName, inputFile.FileName);
        return multipartFormDataContent;
    }

    protected MultipartFormDataContent GenerateMultipartFormDataContent(params string[] exceptPropertyNames)
    {
        MultipartFormDataContent multipartFormDataContent = new MultipartFormDataContent(Guid.NewGuid().ToString() + DateTime.UtcNow.Ticks);
        foreach (NewContent item in from prop in JObject.FromObject(this).Properties().Where(delegate (JProperty prop)
            {
                string[] array = exceptPropertyNames;
                return array != null && !array.Contains<string>(prop.Name);
            })
                                    select new NewContent
                                    {
                                        Name = prop.Name,
                                        Content = new StringContent(prop.Value.ToString())
                                    })
        {
            multipartFormDataContent.Add(item.Content, item.Name);
        }
        return multipartFormDataContent;
    }

    [Obsolete]
    protected HttpContent GetMultipartContent(IDictionary<string, object> parameters)
    {
        throw new NotImplementedException();
    }
}
