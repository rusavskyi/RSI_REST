using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfAuction
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IAuction" in both code and config file together.
    [ServiceContract]
    public interface IAuction
    {
        [OperationContract]
        List<Lot> GetAllLots();

        [OperationContract]
        List<Lot> GetAllLotsJson();

        [OperationContract]
        Lot GetLotById(string id);

        [OperationContract]
        Lot GetLotByIdJson(string id);

        [OperationContract]
        bool PutBetOnLot(float value);

        [OperationContract]
        float BuyOutLot();

        [OperationContract]
        bool AddLot(Lot lot);
    }

    [DataContract]
    public class Lot
    {
        [DataMember] public int Id { get; set; } = 0;
        [DataMember] public string Title { get; set; } = string.Empty;
        [DataMember] public string Description { get; set; } = string.Empty;
        [DataMember] public float BuyOutPrice { get; set; } = 0f;
        [DataMember] public float StartPrice { get; set; } = 0f;
        [DataMember] public float Bet { get; set; } = 0f;
    }
}
