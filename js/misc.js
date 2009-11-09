// srp4net 1.0
// SRP for .NET - A Javascript/C# .NET library for implementing the SRP authentication protocol
// by Sorin Ostafiev (http://code.google.com/p/srp4net/)
// License: LGPL v3 (http://www.gnu.org/licenses/lgpl-3.0.txt)

(function($)
{
    $.extend({
        toJSON: function(object)
        {
            return JSON.stringify(object);
        }
    });
})(jQuery);



function compareTo(big1, big2)
{
    // -1 daca big1 < big2
    // 1 daca big1 > big2
    //0 daca sunt egale
    if (greater(big1, big2))
    {
        return 1;
    }
    else
    {
        if (equals(big1, big2))
        {
            return 0;
        }
    }
    return -1;
}

function WS(fnServer, data, fnSuccess)
{
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        async: false,
        url: "ws.asmx/" + fnServer,
        data: $.toJSON(data),
        dataType: "json",

        success: function(msg)
        {
            fnSuccess(msg.d);
        },

        error: function(xhr, msg, error)
        {
            var err = eval("(" + xhr.responseText + ")");
            $.log(err.Message + "\n" + err.StackTrace);
        }
    })
}