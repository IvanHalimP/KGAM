using System;
using System.Windows.Forms;

namespace Klinik_Gigi_Ana_Medika
{
    interface TrxData
    {
        
    }
    public class TrxHeader : TrxData
    {
        private string trxID;
        private string DocID;
        private string patID;
        public TrxHeader(string t, string d, string p)
        {
            trxID = t;
            DocID = d;
            patID = p;
        }
        
    }

    public class TrxDetails : TrxData
    {
        private string trtID;
        private int qty;
        private int labPrice;
        private float disc;
        private string diagnosis;
        public TrxDetails(string trt, int q, int l, float d, string diag)
        {
            trtID = trt;
            qty = q;
            labPrice = l;
            disc = d;
            diagnosis = diag;
        }
        
    }
}
