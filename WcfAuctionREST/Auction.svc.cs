using System.Collections.Generic;
using System.ServiceModel;

namespace WcfAuctionREST
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class Auction : IAuction
    {
        private static List<Lot> _lots = new List<Lot>
        {
            new Lot
            {
                Id = 0,
                Title = "Title 0",
                Description = "Bla bla bla",
                BuyOutPrice = 100f,
                StartPrice = 0f,
                Bet = 0f
            }
        };

        public Auction()
        {
            if (_lots == null) _lots = new List<Lot>();
            _lots.Add(new Lot
            {
                Id = 1,
                Title = "Title 1",
                Description = "Bla bla bla",
                BuyOutPrice = 100f,
                StartPrice = 0f,
                Bet = 0f
            });
            _lots.Add(new Lot
            {
                Id = 2,
                Title = "Title 2",
                Description = "Bla bla bla",
                BuyOutPrice = 100f,
                StartPrice = 0f,
                Bet = 0f
            });
            _lots.Add(new Lot
            {
                Id = 3,
                Title = "Title 3",
                Description = "Bla bla bla",
                BuyOutPrice = 100f,
                StartPrice = 0f,
                Bet = 0f
            });
            _lots.Add(new Lot
            {
                Id = 4,
                Title = "Title 4",
                Description = "Bla bla bla",
                BuyOutPrice = 100f,
                StartPrice = 0f,
                Bet = 0f
            });
            _lots.Add(new Lot
            {
                Id = 5,
                Title = "Title 5",
                Description = "Bla bla bla",
                BuyOutPrice = 100f,
                StartPrice = 0f,
                Bet = 0f
            });
            _lots.Add(new Lot
            {
                Id = 6,
                Title = "Title 6",
                Description = "Bla bla bla",
                BuyOutPrice = 100f,
                StartPrice = 0f,
                Bet = 0f
            });
            _lots.Add(new Lot
            {
                Id = 7,
                Title = "Title 7",
                Description = "Bla bla bla",
                BuyOutPrice = 100f,
                StartPrice = 0f,
                Bet = 0f
            });
            _lots.Add(new Lot
            {
                Id = 8,
                Title = "Title 8",
                Description = "Bla bla bla",
                BuyOutPrice = 100f,
                StartPrice = 0f,
                Bet = 0f
            });
        }

        public List<Lot> GetAllLots()
        {
            return _lots;
        }

        public Lot GetLotById(string id)
        {
            return _lots.Find(l => l.Id == int.Parse(id));
        }

        public bool PutBetOnLot(Lot lot, string id)
        {
            var indx = _lots.FindIndex(l => l.Id == lot.Id);
            if (indx < 0) return false;
            if (_lots[indx].Bet >= lot.Bet) return false;
            //_lots.RemoveAt(indx);
            //_lots.Add(lot);
            _lots[indx].Bet = lot.Bet;
            return true;
        }

        public float BuyOutLot(string id)
        {
            var indx = _lots.FindIndex(l => l.Id == int.Parse(id));
            if (indx < 0 || _lots[indx].Bet >= _lots[indx].BuyOutPrice)
                return -1;
            var res = _lots[indx].BuyOutPrice;
            _lots.RemoveAt(indx);
            return res;
        }

        public bool AddLot(Lot lot)
        {
            if (lot == null) return false;
            _lots.Add(lot);
            return true;
        }
    }
}