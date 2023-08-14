using Microsoft.Extensions.Logging;
using ResponseSystem.Business;

namespace ResponseSystem.WindowsApp
{
    public partial class ParseResponse : Form
    {
        private readonly IResponseDetails _responseDetails;
        private readonly ILogger _logger;
        public ParseResponse(ILogger<ResponseDetails> logger, IResponseDetails responseDetails)
        {
            _logger = logger;
            _responseDetails = responseDetails;

            InitializeComponent();
        }

        private void parsebtn_Click(object sender, EventArgs e)
        {
            try
            {

                var parsedresponseObj = _responseDetails.ParseResponse(ResponseTxt.Text);

                resulttxt.Text = parsedresponseObj is null ? string.Empty : string.Join(',', "Alarm No: ", parsedresponseObj.alamNo, "Server No: ", parsedresponseObj.serverNo);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, nameof(ParseResponse));

            }
        }


    }
}