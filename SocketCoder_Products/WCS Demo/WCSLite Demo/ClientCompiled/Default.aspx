<%@ Page Language="C#" AutoEventWireup="true" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>SocketCoder.Com - Web Conferencing Demo</title>
    <style type="text/css">
    html, body {
	    height: 100%;
	    overflow: auto;
    }
    body {
	    padding: 0;
	    margin: 0;
    }
    </style>
</head>
<body>   
    <div id="silverlightControlHost" style="height: 100%;text-align:center;">
        <object id="xaml" data="data:application/x-silverlight-2," type="application/x-silverlight-2" width="100%" height="100%">
		  <param name="source" value="ClientBin/WebConferencingSystem.xap?ip=0.0.0.0"/>
		  <param name="onError" value="onSilverlightError" />
		  <param name="background" value="white" />
		  <param name="minRuntimeVersion" value="5.0.0.0" />
	          <%
              string currentCulture = System.Threading.Thread.CurrentThread.CurrentCulture.ToString();
              Response.Cookies.Add(new HttpCookie("WebConferencingSystem-culture", currentCulture));
	          %>
		  <param name="uiculture" value="<%= System.Threading.Thread.CurrentThread.CurrentCulture %>" />
		  <param name="autoUpgrade" value="true" />
		  <a href="http://www.microsoft.com/getsilverlight/handlers/getsilverlight.ashx" style="text-decoration:none">
 			  <img src="http://go.microsoft.com/fwlink/?LinkId=108181" alt="Get Microsoft Silverlight" style="border-style:none"/>
		  </a>
	    </object><iframe id="_sl_historyFrame" style="visibility:hidden;height:0px;width:0px;border:0px"></iframe></div>

</body>
</html>