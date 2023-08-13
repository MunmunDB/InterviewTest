using System.Transactions;
using Microsoft.Extensions.Logging;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

namespace ResponseSystemAPI.Business
{
    public class ResponseFormatDetail
    {
        public string Format { get; set; }
        public  int alamNoIndex {  get; set; }
        public int serverNoIndex {  get; set; }
    }
     public class  ResponseSystem : IResponseSystem
    {
        IList<ResponseFormatDetail> formatDetails;
        public string[] customFormat = { "The alarm id from video server number X is Y", "Alarm id Y has been received from video server number X" };
        private readonly ILogger<ResponseSystem> _logger;
        string _responseText;
        int _alarmNo;
        int _serverNo;
        public int alarmNo { get { return _alarmNo; } }
        public int serverNo { get { return _serverNo; } }
        public ResponseSystem( ILogger<ResponseSystem> logger)
        {
            
            _logger = logger;

            formatDetails=new List<ResponseFormatDetail>();
            formatDetails.Add(new ResponseFormatDetail() {  serverNoIndex=0, alamNoIndex = 1, Format = "The alarm id from video server number * is *." });
            formatDetails.Add(new ResponseFormatDetail() { serverNoIndex = 1, alamNoIndex = 0, Format = "Alarm id * has been received from video server number *." });
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