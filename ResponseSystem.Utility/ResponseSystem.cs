using System.Transactions;
using Microsoft.Extensions.Logging;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

namespace ResponseSystemAPI.Business
{
    public static class ResponseFormat {
       static public string[] customFormat= { "The alarm id from video server number X is Y", "Alarm id Y has been received from video server number X" };
        public static string Identifier_Alarm = "alarm id";
        public static string Identifier_Server = "server number";

    }
    public class  ResponseSystem : IResponseSystem
    {
        public string[] customFormat = { "The alarm id from video server number X is Y", "Alarm id Y has been received from video server number X" };
        private readonly ILogger<ResponseSystem> _logger;
        string _responseText;
        int _alarmNo;
        int _serverNo;
        public ResponseSystem( ILogger<ResponseSystem> logger)
        {
            
            _logger = logger;
        }
        public ResponseSystem() { }

        public int GetAlarmNo() { return _alarmNo; }
        public int GetServerNo() { return  (_serverNo); }

        public bool ParseResponse( string inputresponse ) {
            try
            {
               
                string[] numbers = Regex.Split(inputresponse, @"\D+",RegexOptions.IgnorePatternWhitespace);
                
                var isFr1 = Regex.Match(inputresponse, string.Format("The alarm id from video server number {0} is {1}", numbers[1], numbers[2]));
                var isFr2 = Regex.Match(inputresponse, string.Format("Alarm id {0} has been received from video server number {1}", numbers[2], numbers[1]));
                _alarmNo = int.Parse( isFr1.Success ? numbers[2] : numbers[1]);
                _serverNo = int.Parse(isFr1.Success ? numbers[1] : numbers[2]);
                return isFr1.Success|| isFr2.Success;
            }    
            catch ( Exception e ) {
                _logger.LogError(e.Message, nameof(ParseResponse));
                throw e;
            }
        
        }

        protected void  ReadAlarmNo()
        {
            try
            {
                var alarmNo = int.Parse( _responseText );
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, new { _responseText } );
            }
        }
        protected void ReadServerNo()
        {
            try
            {
                var serveNo = int.Parse(_responseText);
                if (Regex.IsMatch(_responseText, "^Alarm id"))
                {
                    var StartText =  _responseText.Substring(("Alarm id").Length);
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, new { _responseText });
            }
        }
        public  string TakeFive(object input) => input switch
        {
            string { Length: >= 5 } s => s.Substring(0, 5),
            string s => s,
            ICollection<char> { Count: >= 5 } symbols => new string(symbols.Take(5).ToArray()),
            ICollection<char> symbols => new string(symbols.ToArray()),

            null => throw new ArgumentNullException(nameof(input)),
            _ => throw new ArgumentException("Not supported input type."),
        };
    }
}