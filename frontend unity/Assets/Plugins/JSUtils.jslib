 // Assets/Pluging/JSUtils.jslib
 mergeInto(LibraryManager.library, {
   OpenURLInExternalWindow: function (url) {
     window.open(Pointer_stringify(url), "_blank");
   },

   GetData: function(yourkey){
        if(localStorage.getItem(Pointer_stringify(yourkey))  !== ''){
            //loadData(Pointer_stringify(yourkey));
            console.log(localStorage.getItem(Pointer_stringify(yourkey)) + " " + "updated");
            var returnStr = localStorage.getItem(Pointer_stringify(yourkey));
            var buffer = _malloc(lengthBytesUTF8(returnStr) + 1);
            writeStringToMemory(returnStr, buffer);
            return buffer;
        } else {
            console.log("Key not available...");
            return "fail";
        }
    },

    SetData: function(yourkey, yourdata){
      //saveData(Pointer_stringify(yourkey), Pointer_stringify(yourdata));
      console.log(Pointer_stringify(yourkey) + " " + Pointer_stringify(yourdata));
      localStorage.setItem(Pointer_stringify(yourkey), Pointer_stringify(yourdata));
      console.log("Value saved now");
    },
 });

 

