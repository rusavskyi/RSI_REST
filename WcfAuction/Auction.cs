using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfAuction
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Auction" in both code and config file together.
    public class Auction : IAuction
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public Lot GetDataUsingDataContract(Lot composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
