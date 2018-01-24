using System;
using System.Security.Cryptography;
using System.Security.Cryptography.Xml;
using System.Xml;

namespace CRG08.Util
{
    public class Crypto
    {
        /// <summary>
        /// Método para criptografia
        /// </summary>
        /// <param name="doc">XML documento</param>
        /// <param name="tagToEncrypt">Tag para criptografia</param>
        /// <param name="encryptionElementId">Tag de identificação da criptografia</param>
        /// <param name="alg">RSA</param>
        /// <param name="keyName">chave para criptografia</param>
        public static void Encrypt(XmlDocument doc, string tagToEncrypt, string encryptionElementId, RSA alg, string keyName)
        {
            if (doc == null)
                throw new ArgumentNullException("doc");
            if (tagToEncrypt == null)
                throw new ArgumentNullException("ElementToEncrypt");
            if (encryptionElementId == null)
                throw new ArgumentNullException("encryptionElementId");
            if (alg == null)
                throw new ArgumentNullException("alg");
            if (keyName == null)
                throw new ArgumentNullException("keyName");

            ////////////////////////////////////////////////
            // Find the specified element in the XmlDocument
            // object and create a new XmlElemnt object.
            ////////////////////////////////////////////////
            XmlElement elementToEncrypt = doc.GetElementsByTagName(tagToEncrypt)[0] as XmlElement;

            // Throw an XmlException if the element was not found.
            if (elementToEncrypt == null)
            {
                throw new XmlException("The specified element was not found");
            }
            RijndaelManaged sessionKey = null;

            try
            {
                //////////////////////////////////////////////////
                // Create a new instance of the EncryptedXml class
                // and use it to encrypt the XmlElement with the
                // a new random symmetric key.
                //////////////////////////////////////////////////

                // Create a 256 bit Rijndael key.
                sessionKey = new RijndaelManaged();
                sessionKey.KeySize = 256;

                EncryptedXml eXml = new EncryptedXml();

                byte[] encryptedElement = eXml.EncryptData(elementToEncrypt, sessionKey, false);
                ////////////////////////////////////////////////
                // Construct an EncryptedData object and populate
                // it with the desired encryption information.
                ////////////////////////////////////////////////

                EncryptedData edElement = new EncryptedData();
                edElement.Type = EncryptedXml.XmlEncElementUrl;
                edElement.Id = encryptionElementId;
                // Create an EncryptionMethod element so that the
                // receiver knows which algorithm to use for decryption.

                edElement.EncryptionMethod = new EncryptionMethod(EncryptedXml.XmlEncAES256Url);
                // Encrypt the session key and add it to an EncryptedKey element.
                EncryptedKey ek = new EncryptedKey();

                byte[] encryptedKey = EncryptedXml.EncryptKey(sessionKey.Key, alg, false);

                ek.CipherData = new CipherData(encryptedKey);

                ek.EncryptionMethod = new EncryptionMethod(EncryptedXml.XmlEncRSA15Url);

                // Create a new DataReference element
                // for the KeyInfo element.  This optional
                // element specifies which EncryptedData
                // uses this key.  An XML document can have
                // multiple EncryptedData elements that use
                // different keys.
                DataReference dRef = new DataReference();

                // Specify the EncryptedData URI.
                dRef.Uri = "#" + encryptionElementId;

                // Add the DataReference to the EncryptedKey.
                ek.AddReference(dRef);
                // Add the encrypted key to the
                // EncryptedData object.

                edElement.KeyInfo.AddClause(new KeyInfoEncryptedKey(ek));
                // Set the KeyInfo element to specify the
                // name of the RSA key.


                // Create a new KeyInfoName element.
                KeyInfoName kin = new KeyInfoName();

                // Specify a name for the key.
                kin.Value = keyName;

                // Add the KeyInfoName element to the
                // EncryptedKey object.
                ek.KeyInfo.AddClause(kin);
                // Add the encrypted element data to the
                // EncryptedData object.
                edElement.CipherData.CipherValue = encryptedElement;
                ////////////////////////////////////////////////////
                // Replace the element from the original XmlDocument
                // object with the EncryptedData element.
                ////////////////////////////////////////////////////
                EncryptedXml.ReplaceElement(elementToEncrypt, edElement, false);
            }
            catch (Exception e)
            {
                // re-throw the exception.
                throw e;
            }
            finally
            {
                if (sessionKey != null)
                {
                    sessionKey.Clear();
                }

            }

        }

        /// <summary>
        /// Método para descriptografia
        /// </summary>
        /// <param name="doc">arquivo XML</param>
        /// <param name="alg">RSA</param>
        /// <param name="keyName">chave</param>
        public static void Decrypt(XmlDocument doc, RSA alg, string keyName)
        {
            // Check the arguments.  
            if (doc == null)
                throw new ArgumentNullException("doc");
            if (alg == null)
                throw new ArgumentNullException("alg");
            if (keyName == null)
                throw new ArgumentNullException("keyName");

            // Create a new EncryptedXml object.
            EncryptedXml exml = new EncryptedXml(doc);

            // Add a key-name mapping.
            // This method can only decrypt documents
            // that present the specified key name.
            exml.AddKeyNameMapping(keyName, alg);

            // Decrypt the element.
            exml.DecryptDocument();

        }
    }
}
