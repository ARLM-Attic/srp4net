<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="srp4net._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>srp4net sample</title>
	<script type="text/javascript" src="js/jquery-1.3.2.js"></script>

    <!-- http://www.json.org/js.html -->
	<script type="text/javascript" src="js/json2.js"></script>

	<!-- http://plugins.jquery.com/project/Dump -->
	<script type="text/javascript" src="js/jquery.dump.js"></script>

    <!-- http://trainofthoughts.org/repo/getfile?f=jquery/jquery.debug.js&v=40 -->
	<script type="text/javascript" src="js/jquery.debug.js"></script>

	<!-- http://ats.oka.nu/titaniumcore/js/tools/binary.js -->
	<script type="text/javascript" src="js/binary.js"></script>
	
	<!-- http://www.leemon.com/crypto/BigInt.js -->
	<script type="text/javascript" src="js/BigInt.js"></script>

    <!-- http://ats.oka.nu/titaniumcore/js/crypto/jsSHA.js -->
	<script type="text/javascript" src="js/jsSHA.js"></script>
	
	<!-- http://ats.oka.nu/titaniumcore/js/crypto/SHA.js -->
	<script type="text/javascript" src="js/SHA.js"></script>


    <!-- http://code.google.com/p/srp4net/ -->
	<script type="text/javascript" src="js/crypto.js"></script>
	
	<!-- http://code.google.com/p/srp4net/ -->
	<script type="text/javascript" src="js/crypto-srp.js"></script>
	
	<!-- http://code.google.com/p/srp4net/ -->
	<script type="text/javascript" src="js/misc.js"></script>
</head>
<body>
    <span style="color:Red;">You should check your debug console (e.g. watch the Console tab in Firebug if using Firefox) to see what's going on</span>
    <script type="text/javascript">
        $(document).ready(function()
        {
            $u.crypto.srp.initialize(
                "<%= srp4net.Helpers.Crypto.SRP.NHex %>",
                "<%= srp4net.Helpers.Crypto.SRP.gHex %>",
                "<%= srp4net.Helpers.Crypto.SRP.kHex %>");
            $u.crypto.srp.demo();
        });
    </script>
</body>
</html>
