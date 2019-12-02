# ISVLicenseGenerator
This tool has been created to generate ISV licenses for Microsoft Dynamics 365 for Finance and Operations using a USB CSP eToken.

The [standard ISV licensing](https://docs.microsoft.com/en-us/dynamics365/fin-ops-core/dev-itpro/dev-tools/isv-licensing#certificate-import-and-export) only supports software PFX (PKCS #12) format certificates. In case you buy a certificate and you get a CSP token you won't be able to export the private key needed to sign the license.

# Usage
You need to install the drivers and management software of your USB token first. Execute the program and fill in the mandatory fields:

- Path: the path where you want to save your license file.
- License code: the name of your license code (from Microsoft Visual Studio).
- Customer tenant: the customer's tenant name (from the screen shot below).
- Serial number: the customer's tenant ID (labeled "Serial number" in the screen shot below).

Customer tenant and serial number fields 
![alt text][logo]

[customerinfo]: https://docs.microsoft.com/en-us/dynamics365/fin-ops-core/dev-itpro/dev-tools/media/isv15.png "Customer tenant and serial number fields"

THE SOFTWARE IS PROVIDED "AS IS" AND THE AUTHOR DISCLAIMS ALL WARRANTIES WITH REGARD TO THIS SOFTWARE INCLUDING ALL IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS. IN NO EVENT SHALL THE AUTHOR BE LIABLE FOR ANY SPECIAL, DIRECT, INDIRECT, OR CONSEQUENTIAL DAMAGES OR ANY DAMAGES WHATSOEVER RESULTING FROM LOSS OF USE, DATA OR PROFITS, WHETHER IN AN ACTION OF CONTRACT, NEGLIGENCE OR OTHER TORTIOUS ACTION, ARISING OUT OF OR IN CONNECTION WITH THE USE OR PERFORMANCE OF THIS SOFTWARE.
