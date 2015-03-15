Sample project that demonstrates the SRP authentication protocol in JavaScript/C# .NET

Library:		srp4net
Version:		1.0
Implementation:	SRP variant 6a with SHA2 digest (instead of SHA1 from the original specification) on 512 bits
Description:	Secure Remote Password protocol implementation in JavaScript and C#
RFC:			http://www.ietf.org/rfc/rfc2945.txt
Details:		http://srp.stanford.edu/ndss.html
Author:			Sorin Ostafiev (http://code.google.com/p/srp4net/)
License:		GPL v3 (http://www.gnu.org/licenses/gpl-3.0.txt)

The most important libraries used by this project:
     - jsSHA.js - A JavaScript implementation of the SHA family of hashes, as defined in FIPS PUB 180-2
             originally written by Brian Turek http://jssha.sourceforge.net/
             changed by Atsushi Oka (http://ats.oka.nu/titaniumcore/js/crypto/jsSHA.js, several functions taken from Paul Johnson)
             changed by Sorin Ostafiev (http://code.google.com/p/srp4net/)
     - SHA.js - SHA class that calculates various SHA hash values
             by Atsushi Oka (http://ats.oka.nu/titaniumcore/js/crypto/SHA.js)
             special thanks to Mr. Brian Turek (http://sourceforge.net/users/caligatio)
     - BigInt.js - Big Integer Library
             by Leemon Baird (http: //www.leemon.com/crypto/BigInt.js)
     - binary.js - Tools for creating, modifying binary data
             by Atsushi Oka (http://ats.oka.nu/titaniumcore/js/tools/binary.js)
     - jquery-1.3.2.js - jQuery - a new kind of JavaScript Library
             by the jQuery team (http://docs.jquery.com/Contributors)


Title:
    A Javascript/C# .NET library for implementing the SRP authentication protocol

Description:
    SRP is a secure password-based authentication and key-exchange protocol. It solves the problem of authenticating clients to servers securely, in cases where the user of the client software must memorize a small secret (like a password) and carries no other secret information, and where the server carries a verifier for each user, which allows it to authenticate the client but which, if compromised, would not allow the attacker to impersonate the client. In addition, SRP exchanges a cryptographically-strong secret as a byproduct of successful authentication, which enables the two parties to communicate securely.
    srp4net is a library that implements the SRP authentication protocol for a Javascript client against a C# webservice. 

Tags:
    srp, authentication, javascript, csharp, cryptography, secure, privacy, ajax, .net

License:
    GNU GPL v3


