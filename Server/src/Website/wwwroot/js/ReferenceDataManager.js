window.app.referenceDataManager = (function (webApi) {
    var log = window.huypq.log || function (text) { };
    //var log = console.log;
    var info = console.log;

    var referenceDataManager = {
        _cache: {}
    };

    referenceDataManager.get = function (name, filter) {
        var deferred = new $.Deferred();

        var cacheData = referenceDataManager._cache[name];
        if (cacheData !== undefined) {
            info("referenceDataManager cache hit: " + name);
            deferred.resolve(cacheData.data, cacheData.textStatus, cacheData.jqXHR);
        } else {
            webApi.getData(name, filter)
                .done(function (data, textStatus, jqXHR) {
                    info("referenceDataManager cache miss: " + name);
                    referenceDataManager._cache[name] = {
                        data: data,
                        textStatus: textStatus,
                        jqXHR: jqXHR
                    };
                    deferred.resolve(data, textStatus, jqXHR);
                })
                .fail(function (error) {
                    deferred.reject(error);
                });
        }

        return deferred;
    }

    return referenceDataManager;
})(window.app.webApi);