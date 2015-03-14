using System.Web.Mvc;
using BlogIT.Utility;

namespace BlogIT.Web.Controllers
{
    public class EncryptionByAESController : Controller
    {
        private readonly IEncryptDecrypt _encryptDecrypt;

        //Need to implement wire via IoC (DI)
        public EncryptionByAESController()
        {
            _encryptDecrypt = new AESEncryption();
        }

        public EncryptionByAESController(IEncryptDecrypt encryptDecrypt)
        {
            _encryptDecrypt = encryptDecrypt;
        }

        public ActionResult Index()
        {
            ViewData["Encrypted"] = TempData["TEncrypted"];
            ViewData["Decrypted"] = TempData["TDecrypted"];
            return View();
        }

        [HttpPost]
        public ActionResult Encryption(string text, string key)
        {
            TempData["TEncrypted"] = _encryptDecrypt.EncryptedText(text, key);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Decryption(string text, string key)
        {
            TempData["TDecrypted"] = _encryptDecrypt.DecryptedText(text, key);
            return RedirectToAction("Index");
        }

    }
}