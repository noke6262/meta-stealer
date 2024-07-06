using System.ServiceModel;
using System.Threading.Tasks;

namespace Meta.SharedModels;

[ServiceContract(Name = "example", SessionMode = SessionMode.Required)]
public interface IRemoteEndpoint
{
    [OperationContract(Name = "Field1")]
    Task<bool> CheckConnect();

    [OperationContract(Name = "Field2")]
    Task<ClientSettings> OnGetSettings();

    [OperationContract(Name = "Field3")]
    Task VerifyScanRequest(UserLog user);
}
