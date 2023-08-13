using System.Transactions;
using Microsoft.Extensions.Logging;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;
using ResponseSystem.Business.Model;

namespace ResponseSystem.Business
{

    public class  ResponseDetails : IResponseDetails
    {
        IList<ResponseFormatDetail> formatDetails;
        IUtility _util;
        private readonly ILogger<ResponseDetails> _logger;
        string _responseText;
        int _alarmNo;
        int _serverNo;
        

        public int alarmNo { get { return _alarmNo; } }
        public int serverNo { get { return _serverNo; } }
        public ResponseDetails( ILogger<ResponseDetails> logger, IUtility util, string inputfile)
        {
            
            _logger = logger;
            _util = util;
            formatDetails = util.GetFormats(inputfile); // new List<ResponseFormatDetail>();

            //formatDetails.Add(new ResponseFormatDetail() {  serverNoIndex=0, alamNoIndex = 1, Format = "The alarm id from video server number * is *." });
            //formatDetails.Add(new ResponseFormatDetail() { serverNoIndex = 1, alamNoIndex = 0, Format = "Alarm id * has been received from video server number *." });
        }
      
       
        public bool ParseResponse( string inputresponse ) {
            try
            {
                bool isNum= false;
                var matchedFormat = ValidateFormat(inputresponse);
                if(matchedFormat is not null)
                {
                    var numberValueList = Regex.Split(inputresponse, @"\D+").Where(p => !string.IsNullOrEmpty(p)).Select(a => a);

                    isNum = int.TryParse(numberValueList.ElementAt(matchedFormat.alamNoIndex), out _alarmNo);
                    isNum = int.TryParse(numberValueList.ElementAt(matchedFormat.serverNoIndex), out _serverNo);
                }

                return isNum;
               
            }    
            catch ( Exception e ) {
                _logger.LogError(e.Message, nameof(ParseResponse));
                throw e;
            }
        
        }

        ResponseFormatDetail ValidateFormat(string responseText)
        {
            try
            {
                responseText =  Regex.Replace(responseText, @"\d{2,}", "*");
                responseText = Regex.Replace(responseText, @"\d", "*");
                var matchedFormat = formatDetails.Where(p=>p.Format == responseText).FirstOrDefault<ResponseFormatDetail>();
                return matchedFormat;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, nameof(ValidateFormat));
                throw e;
            }
        }
       
    }
}