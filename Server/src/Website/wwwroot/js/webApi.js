window.app.webApi = (function () {
    var webApi = {
        log: window.huypq.log || function (text) { },
        info: console.log,
        user: {
            login: function (params) {
                return postParams(apiUrl("user", "login"), params);
            },
            accesstoken: function (params) {
                return postParams(apiUrl("user", "accesstoken"), params);
            },
            getgroups: function (params) {
                return postParams(apiUrl("user", "getgroups"), params);
            }
        },
        getData: getData,
        _cache: {}
    };
    return webApi;

    //function apiUrl(controller, action) { return "/" + controller + "/" + action; }
    function apiUrl(controller, action) { return "http://gaucon.net:5000/" + controller + "/" + action; }

    function getApiUrl(controller) { return apiUrl(controller, "get"); }

    function getData(controller, json) {
        var url = getApiUrl(controller);
        json = json || {};
        var jsonString = JSON.stringify(json);

        var deferred = new $.Deferred();

        var cacheKey = controller + '_' + jsonString;
        webApi.log("webApi cacheKey: " + cacheKey);

        var cacheData = webApi._cache[cacheKey];
        var versionNumber = 0;
        var serverStartTime = 0;
        if (cacheData !== undefined) {
            versionNumber = cacheData.versionNumber;
            serverStartTime = cacheData.serverStartTime;
            if (jsonString.length < 3) {
                jsonString = "{\"versionNumber\":" + versionNumber + ",\"serverStartTime\":" + serverStartTime + "}";
            } else {
                jsonString = "{\"versionNumber\":" + versionNumber + ",\"serverStartTime\":" + serverStartTime + "," + jsonString.substr(1);
            }
        }

        postJson(url, jsonString)
            .done(function (data, textStatus, jqXHR) {
                if (versionNumber === data.versionNumber && serverStartTime === data.serverStartTime) {
                    webApi.info("webApi cache hit " + controller + "   " + versionNumber);

                    deferred.resolve(JSON.parse(cacheData.jsonStringData), cacheData.textStatus, cacheData.jqXHR);
                } else {
                    webApi.info("webApi cache miss " + controller + "   " + data.versionNumber);
                    webApi._cache[cacheKey] = {
                        serverStartTime: data.serverStartTime,
                        versionNumber: data.versionNumber,
                        jsonStringData: JSON.stringify(data),
                        textStatus: textStatus,
                        jqXHR: jqXHR
                    };

                    deferred.resolve(data, textStatus, jqXHR);
                }
            })
            .fail(function (error) {
                deferred.reject(error);
            });

        return deferred;
    }

    function postJson(url, jsonString) {
        webApi.info("webApi postJson: " + url + " " + jsonString);
        var options = {
            dataType: "json",
            contentType: "application/json",
            cache: false,
            type: "post",
            data: jsonString
        };

        var token = window.localStorage.getItem(window.tokenKey);

        if (token) {
            options.headers = {
                'token': token
            };
        }
        return $.ajax(url, options);
    }

    function postParams(url, params) {
        webApi.info("webApi postParams: " + url + " " + JSON.stringify(params));
        var options = {
            dataType: "json",
            contentType: "application/x-www-form-urlencoded",
            cache: false,
            type: "post",
            data: params
        };

        var token = window.localStorage.getItem(window.tokenKey);

        if (token) {
            options.headers = {
                'token': token
            };
        }
        return $.ajax(url, options);
    }
})();