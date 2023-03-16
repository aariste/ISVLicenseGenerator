# ISVLicenseGenerator

![Build](https://github.com/aariste/ISVLicenseGenerator/workflows/CI/badge.svg)

This tool has been created to generate ISV licenses for Microsoft Dynamics 365 for Finance and Operations using a USB CSP eToken. I'm using a modified version of the AXUtilLib assembly found in a MSDyn365FO VM packages bin folder to allow the usage of the USB token. This assembly is owned by Microsoft and I've only modified it with learning purposes.

The [standard ISV licensing](https://docs.microsoft.com/en-us/dynamics365/fin-ops-core/dev-itpro/dev-tools/isv-licensing#certificate-import-and-export) only supports software PFX (PKCS #12) format certificates. In case you buy a certificate and you get a CSP token you won't be able to export the private key needed to sign the license.

The latest version has been migrated to .NET 7.0.

# Transition to SHA265
The [SHA1 hashing algorithm will be deprecated in early 2021](https://docs.microsoft.com/en-us/dynamics365/fin-ops-core/dev-itpro/get-started/removed-deprecated-features-platform-updates#isv-licenses-created-by-using-the-sha1-hashing-algorithm). The SHA256 functionality is working and the SHA1 option has been removed in version 0.6. ISVLicenseGenerator will only create SHA256 signed licenses like the standard AXUtil is doing since PU35.

# Usage
You need to install the drivers and management software of your USB token first. Execute the program and fill in the mandatory fields:

- Path: the path where you want to save your license file.
- License code: the name of your license code (from Microsoft Visual Studio).
- Customer tenant: the customer's tenant name (from [this screenshot](https://docs.microsoft.com/en-us/dynamics365/fin-ops-core/dev-itpro/dev-tools/media/isv15.png)).
- Serial number: the customer's tenant ID (labeled "Serial number" in the screenshot linked in the previous line).

You can find a bit more information on [this blog](https://ariste.info/en/2019/12/create-an-isv-license-from-a-cryptographic-usb-token/) post about v0.1 and [this one](https://ariste.info/en/2020/08/isv-license-generator-sha-2-support/) about v0.2 on https://ariste.info

THE SOFTWARE IS PROVIDED "AS IS" AND THE AUTHOR DISCLAIMS ALL WARRANTIES WITH REGARD TO THIS SOFTWARE INCLUDING ALL IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS. IN NO EVENT SHALL THE AUTHOR BE LIABLE FOR ANY SPECIAL, DIRECT, INDIRECT, OR CONSEQUENTIAL DAMAGES OR ANY DAMAGES WHATSOEVER RESULTING FROM LOSS OF USE, DATA OR PROFITS, WHETHER IN AN ACTION OF CONTRACT, NEGLIGENCE OR OTHER TORTIOUS ACTION, ARISING OUT OF OR IN CONNECTION WITH THE USE OR PERFORMANCE OF THIS SOFTWARE.
