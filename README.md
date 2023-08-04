# minashigo_AssetDL
Use to download ミナシゴノシゴトR (Minashigo) resources [DMM ver.]

Can download most of the files in ミナシゴノシゴトR, exclude files info from story/readStory.

## decrypt resource.json and calc assets url
You can just use the final json file I provide in release.
```
function loadJs(jsUrl){
    let scriptTag = document.createElement('script');
    scriptTag.src = jsUrl;
    document.getElementsByTagName('head')[0].appendChild(scriptTag);
};

// load CryptoJS
loadJs('https://cdn.bootcdn.net/ajax/libs/crypto-js/4.1.1/crypto-js.min.js');

function decrypt(t) {
var e = CryptoJS.SHA256("#mnsg#manifest"), i = CryptoJS.enc.Base64.stringify(e).substr(0, 32), n = {
iv: "BFA4332ECFDCB3D1DA2633B5AB509094",
mode: CryptoJS.mode.CTR
}, o = CryptoJS.AES.decrypt(t, i, n);
return CryptoJS.enc.Utf8.stringify(o);}

// [Step1] Modify this by yourself
str = "text in resource.json"

// [Step2] Now, copy the out and paste it back
out = decrypt(str)

// [Step3] Because CryptoJS problem, search file name contains "%" and modify it, https://onlineutf8tools.com/convert-hexadecimal-to-utf8
out = "text in resource.json (edited)"

d = function(t) {
return [ t.substring(0, 2), t.substring(4, 6) ];
}, h = function(t) {
return [ t.substring(2, 4), t.substring(6, 8), t.substring(0, 2) ];
}, p = function(t) {
return [ t.substring(4, 6), t.substring(0, 2), t.substring(6, 8), t.substring(2, 4) ];
}, _ = function(t) {
return [ t.substring(6, 8), t.substring(2, 4), t.substring(4, 6), t.substring(0, 2) ];
}, f = {
0: d,
1: d,
2: d,
3: d,
4: h,
5: h,
6: h,
7: h,
8: p,
9: p,
a: p,
b: p,
c: _,
d: _,
e: _,
f: _
};
function g(t) {
if ("." === t[0]) return "";
var e = t[0];
return f[e](t).join("/");
};
function convertMD5Path(t) {
var e = CryptoJS.MD5(t).toString(CryptoJS.enc.Hex), i = t.substr(0, t.lastIndexOf(".")), s = g(CryptoJS.MD5(i).toString(CryptoJS.enc.Hex));return e+"/"+s;}

resource = JSON.parse(out)

var all = '{"version":' + JSON.stringify(resource.version) + ',"assets":{';
for(path in resource.assets){
    var value = resource.assets[path]
    if (value.hasOwnProperty("3")){
        md5 = value["3"].md5
    }
    else {
        md5 = value["0"].md5
    }
    all += JSON.stringify(path) + ':"'+ convertMD5Path(path) + "/" + JSON.stringify(md5).replace('"', '') + ","
}
all += "}}"

// [Step4] copy the result of all
```

## decrypt mnsg data
1. No idea how to getStoryId(), getSessionId(), so I give up.
2. For 寝室CG files you can get from here [nyaa](https://sukebei.nyaa.si/view/3913196), but no voice files inside.
```
function encrypt(t, e) {
var i = CryptoJS.SHA256(e + "one-deep"), n = i.toString(CryptoJS.enc.Base64).substr(0, 32), o = {
iv: (i = CryptoJS.SHA256(e.substr(0, 16))).toString(CryptoJS.enc.Base64).substr(0, 16),
mode: CryptoJS.mode.CTR
};
return CryptoJS.AES.encrypt(t, n, o).toString();
},
function decrypt(t, e) {
var i = CryptoJS.SHA256(e + "one-deep"), n = i.toString(CryptoJS.enc.Base64).substr(0, 32), o = {
iv: (i = CryptoJS.SHA256(e.substr(0, 16))).toString(CryptoJS.enc.Base64).substr(0, 16),
mode: CryptoJS.mode.CTR
};
return CryptoJS.AES.decrypt(t, n, o).toString(CryptoJS.enc.Utf8);
}
```
