using Meta.MainPanel.Models.Shared;
using Meta.SharedModels;
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;

namespace Meta.MainPanel.Models.Communication;

[ServiceContract(Name = "IMainServer", SessionMode = SessionMode.Required)]
public interface IMainServer
{
    [OperationContract(Name = "Create")]
    Task<byte[]> Create(BuildParams buildParams);

    [OperationContract(Name = "Init")]
    Task<bool> Init(string arg1, string arg2);

    [OperationContract(Name = "MergeFiles")]
    Task<byte[]> MergeFiles(List<MergeFile> files, ClientData client);

    [OperationContract(Name = "ScanFile")]
    Task<string> ScanFile(byte[] file, ClientData client);

    [OperationContract(Name = "GetPartnersPosts")]
    Task<List<AdvertItem>> GetPartnersPosts();

    [OperationContract(Name = "CheckConnect")]
    Task<string> CheckConnect(ClientData client, string ip);

    [OperationContract(Name = "Connect")]
    Task<string> Connect(string arg1, string arg2, string arg3);

    [OperationContract(Name = "CheckExpire")]
    Task<DateTime> CheckExpire(string login);

    [OperationContract]
    Task<bool> IsAlive();
}
