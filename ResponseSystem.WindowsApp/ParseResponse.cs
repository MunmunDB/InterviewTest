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
            resulttxt.Text = _responseDetails.ParseResponse(ResponseTxt.Text).ToString();
        }

        
    }
}