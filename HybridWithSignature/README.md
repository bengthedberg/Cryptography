# Hybrid Encryption with Digital Signatures

This example combines the benefits with symmetric encryption, asymmetric encryption and hash-based message authentication code when transmitting sensitive information.

The principle is that the message is encrypted using symmetric encryption; **AES 256 bit encryption with a random initialization vector, (iv)**. 

The advantage of this is that AES is **fast** and **secure**.   
The disadvatage is that symmetric encryption uses the same key to encrypt/decrypt so both sender and receiver need to share the key.   
To avoid manage and keep this shared key safe the sender will **generate a unique session key** and incorporate that key as part of the encrypted message object. 

1 - Generate a unique session key, AES 256 bit encryption.  
2 - Generate a random 128 bit initialization vector.  
3 - Encrypt the message using the Session Key and the IV.  
4 - Create a HMAC using the session key as the authentication code and HASH the encrypted message.
5 - Use the senders private key to sign the HMAC Hash.  

The hybrid solution will use asymmetric encryption to protect the session key above. 

This will give us the advantage of private/public key as we can **easily distribute the public key**. 
And only the holder of the private key can decrypt the session key and using it to decrypt the whole message.

So finally the sender must use the receivers **public key to encrypt the session key**.

6 - Use the **RSA 2046 bit public key** to encrypt the AES 256 bit session key. 

Now the sender can transmit the encrypted data:

* Encrypted Message
* Encrypted Session Key
* IV
* HMAC 
* Signature

The receiver will process the message in the following order:

1 - Decrypt the session key by using their private key.  
2 - Create a HMAC using the decrypted session key and HASH the encrypted data. If its not the same as the received HMAC value then the data has been corrupted.   
3 - Verify the signature by using the senders public key.
3 - If HMACs are identical and the signature is valid then the receiver can decrypt the encrypted message using the session key and the provided IV.

The hybrid solution combines the convinience of the assymtric key sharing model with the efficiency of the symmetric encryption model. 

* Key encryption scheme  
* Data encapsulation scheme  

We also added message integrity validation:

* HMAC involving a cryptographic hash function and a secret cryptographic key.

And finally we added a signature to verify that the message originates from a specific origin, i.e. its non-repudiation.

This example supports the four principles of cryptograhy : 

- Confidentiality  
- Integrity
- Non-Repudiation
- Authentication
