using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace WcfAuctionREST
{
    [ServiceContract]
    public interface IAuction
    {
        [OperationContract]
        [WebGet(UriTemplate = "/alllots", ResponseFormat = WebMessageFormat.Json)]
        List<Lot> GetAllLots();

        [OperationContract]
        [WebGet(UriTemplate = "/alllots/{id}", ResponseFormat = WebMessageFormat.Json)]
        Lot GetLotById(string id);

        [OperationContract]
        [WebInvoke(UriTemplate = "/alllots/{id}", Method = "PUT", RequestFormat = WebMessageFormat.Json)]
        bool PutBetOnLot(Lot lot, string id);

        [OperationContract]
        [WebInvoke(UriTemplate = "/alllots/{id}/buyout", Method = "PUT", RequestFormat = WebMessageFormat.Json)]
        float BuyOutLot(string id);

        [OperationContract]
        [WebInvoke(UriTemplate = "/alllots", Method = "PUT", RequestFormat = WebMessageFormat.Json)]
        bool AddLot(Lot lot);
    }

    [DataContract]
    public class Lot
    {
        [DataMember] public int Id { get; set; }
        [DataMember] public string Title { get; set; } = string.Empty;
        [DataMember] public string Description { get; set; } = string.Empty;
        [DataMember] public float BuyOutPrice { get; set; }
        [DataMember] public float StartPrice { get; set; }
        [DataMember] public float Bet { get; set; }
    }
}