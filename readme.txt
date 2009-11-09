Sample project that demonstrates the SRP authentication protocol in Javascript/C# .NET

Library:		srp4net
Version:		1.0
Implementation:	SRP variant 6a with SHA2 digest (instead of SHA1 from the original specification) on 512 bits
Description:	Secure Remote Password protocol implementation in Javascript and C#
RFC:			http://www.ietf.org/rfc/rfc2945.txt
Details:		http://srp.stanford.edu/ndss.html
Author:			Sorin Ostafiev (http://code.google.com/p/srp4net/)
License:		LGPL v3 (http://www.gnu.org/licenses/lgpl-3.0.txt)

The most important libraries used by this project:
     - jsSHA.js - A JavaScript implementation of the SHA family of hashes, as defined in FIPS PUB 180-2
             originally written by Brian Turek http://jssha.sourceforge.net/
             changed by Atsushi Oka (http://ats.oka.nu/titaniumcore/js/crypto/jsSHA.js, several functions taken from Paul Johnson)
             changed by me (http://code.google.com/p/srp4net/)
     - SHA.js - SHA class that calculates various SHA hash values
             by Atsushi Oka (http://ats.oka.nu/titaniumcore/js/crypto/SHA.js)
             special thanks to Mr. Brian Turek (http://sourceforge.net/users/caligatio)
     - BigInt.js - Big Integer Library
             by Leemon Baird (http: //www.leemon.com/crypto/BigInt.js)
     - binary.js - Tools for creating, modifying binary data
             by Atsushi Oka (http://ats.oka.nu/titaniumcore/js/tools/binary.js)
     - jquery-1.3.2.js - jQuery - a new kind of JavaScript Library
             by the jQuery team (http://docs.jquery.com/Contributors)
