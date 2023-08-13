
using Microsoft.Extensions.Logging;

namespace ResponseSystem.Business
{
   
    public class Utility :IUtility
    {
        private readonly ILogger _logger;
        private char alarm_Identifier = 'X';
        private char server_Identifier = 'Y';
        private char common_identifier = '*';
        private string _filepath;
        public Utility(ILogger<Utility> logger , string filepath) { _logger = logger; _filepath = filepath; }
        public Utility(ILogger<Utility> logger) { _logger = logger; _filepath = Path.Join(Directory.GetCurrentDirectory(), "\\ResourceFile\\Formats.csv"); }
        IList<string> ReadFormatFile(string filepath)
        {
            try
            {
                IList<string> strFormatLines
                    = new List<string>();
                using (var reader = new StreamReader(filepath))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        if (line is not null)
                            strFormatLines.Add(line);
                    }
                }
                return strFormatLines;
            }     
            catch (Exception e ) {
                _logger.LogError(e.Message, nameof(ReadFormatFile));
                throw e;
            }

}

        public IList<ResponseFormatDetail> GetFormats()
        {
            try { 
            var strline = ReadFormatFile(_filepath);
                int alarmno_index = 0;
                int serverNo_index = 0;
            IList<ResponseFormatDetail> returnList = new List<ResponseFormatDetail>();
            foreach( var  line in strline)
            {
                    /* Hardcoding the index , assuming there are 2 interger in the line , one is alarmno & other is server no*/
                    alarmno_index = line.IndexOf(alarm_Identifier)< line.IndexOf(server_Identifier) ? 1 :0;
                    serverNo_index = alarmno_index == 0 ? 1 : 0;
                    string lineformatted = line.Replace(alarm_Identifier.ToString(), common_identifier.ToString());
                    lineformatted = lineformatted.Replace(server_Identifier.ToString(), common_identifier.ToString());
                    if (alarmno_index >-1 && serverNo_index >-1)
                    { 
                        returnList.Add(new ResponseFormatDetail() { Format = lineformatted, alamNoIndex = alarmno_index, serverNoIndex = serverNo_index });
                    }
                
            }
            return returnList;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, nameof(GetFormats));
                throw e;
            }
        }
    }
}
