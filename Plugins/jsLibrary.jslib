mergeInto(LibraryManager.library, {
    loadData: function(yourkey){
        var returnStr = "";

        if(localStorage.getItem(UTF8ToString(yourkey)) !==null)
        {
            returnStr = localStorage.getItem(UTF8ToString(yourkey));
        }

        var bufferSize = lengthBytesUTF8(returnStr) + 1;
        var buffer = _malloc(bufferSize);
        stringToUTF8(returnStr, buffer, bufferSize);
        return buffer;
    },
    saveData: function(yourkey, yourdata){
        localStorage.setItem(UTF8ToString(yourkey), UTF8ToString(yourdata));
    },
    deleteKey: function(yourkey){
        localStorage.removeItem(UTF8ToString(yourkey));
    },
    deleteAllKeys: function(prefix){
        var len = localStorage.length;
        for (var i = 0; i < len; i++ ) {
            var key = localStorage.key(i);
            if(key != null && key.startsWith(UTF8ToString(prefix))){
                localStorage.removeItem(key);
                i--;
            }
        }
    }
});
