    mergeInto(LibraryManager.library, {  
        openWindow: function(link)  
        {  
            var url = Pointer_stringify(link);  
            document.onmouseup = function()  
            {  
                window.open(url);  
                document.onmouseup = null;  
                document.ontouchend = null;  
            }  
            document.ontouchend = function()  
            {  
                window.open(url);  
                document.onmouseup = null;  
                document.ontouchend = null;  
            }  
        },  
        clipboardWriteText: function(str)  
        {  
            var text = Pointer_stringify(str);  
            navigator.clipboard.writeText(text);  
        },  
    });  