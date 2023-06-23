using MercedesURLShortener.Core.IControllerHelpers;

namespace MercedesURLShortener.Core.ControllerHelpers
{
    public class UrlControllerHelper : IUrlControllerHelper
    {
        public string CreateRandomShortLink()
        {
            var randomUrl = Guid.NewGuid();
            return randomUrl.ToString()[..6];
        }
    }
}