window.app.viewModel.loginViewModel = (function (webApi) {

    var loginViewModel = {
        create: create
    };
    return loginViewModel;

    function create() {
        var viewModel = {
            email: ko.observable("huy"),
            password: ko.observable(),
            groupList: ko.observableArray(),
            group: ko.observable(),
            loginAction: function (model) {
                webApi.user.login({ user: model.email(), pass: model.password() })
                    .done(function (token) {
                        window.localStorage.setItem(window.tokenKey, token);
                        webApi.user.getgroups({ user: model.email() })
                        .done(function (text) {
                            var t = text.split("*&*");
                            var arr = [];
                            for (var i = 0; i < t.length - 1; i++) {
                                arr.push({ text: t[i] });
                            }
                            model.groupList(arr);
                            model.group(t[0]);
                        })
                        .fail(function (msg) {
                            console.log("fail: " + JSON.stringify(msg));
                        });
                    })
                    .fail(function (msg) {
                        console.log("fail: " + JSON.stringify(msg));
                    });
            },
            okAction: function (model) {
                webApi.user.accesstoken({ group: model.group() })
                    .done(function (token) {
                        window.localStorage.setItem(window.tokenKey, token);
                        window.app.view.mainView.show();
                    })
                    .fail(function (msg) {
                        console.log("fail: " + JSON.stringify(msg));
                    });
            }
        };
        return viewModel;
    }
})(window.app.webApi);