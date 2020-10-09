using System;

namespace FortyThreeLime.API.ViewModels
{
    public class ErrorViewModel : IViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
