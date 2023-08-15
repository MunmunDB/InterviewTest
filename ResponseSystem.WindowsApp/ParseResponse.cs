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
            // initialse object instances from Business layer & Logger
            _logger = logger;
            _responseDetails = responseDetails;

            InitializeComponent();
        }
        /// <summary>
        /// The event handler for Parse button in the ParseResponse Window. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void parsebtn_Click(object sender, EventArgs e)
        {
            try
            {

                var parsedresponseObj = _responseDetails.ParseResponse(ResponseTxt.Text);
                if (parsedresponseObj != null)                {

                    resulttxt.Text = (parsedresponseObj.serverNo is null || parsedresponseObj.alamNo is null) ? 
                        parsedresponseObj.message : string.Join(',', "Alarm No: ", parsedresponseObj.alamNo, "Server No: ", parsedresponseObj.serverNo);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, nameof(ParseResponse));
                resulttxt.Text = "Error in WinApp";

            }
        }


    }
}