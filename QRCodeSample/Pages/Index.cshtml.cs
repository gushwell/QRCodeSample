using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using QRCoder;

namespace sampleQRCode.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public string ImageSrc = string.Empty;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public IActionResult OnGet()
    {
        var text = "https://qiita.com/gushwell";
        var qrGenerator = new QRCodeGenerator();
        var qrCodeData = qrGenerator.CreateQrCode(text, QRCodeGenerator.ECCLevel.Q);
        var qrCode = new PngByteQRCode(qrCodeData);
        var bytes = qrCode.GetGraphic(10);
        var base64Str = Convert.ToBase64String(bytes);
        ImageSrc = String.Format("data:image/png;base64,{0}", base64Str);
        return Page();
    }
}
