window.app.viewModel.loginViewModel = (function (webApi) {

    var loginViewModel = {
        create: create
    };
    return loginViewModel;

    function create() {
        var viewModel = {
            email: ko.observable("huy"),
            password: ko.observable(),
            group: ko.observable("vinhphat"),
            signInAction: function (model) {
                webApi.user.token({ user: model.email(), pass: model.password(), group: model.group() })
                    .done(function (token) {
                        window.localStorage.setItem(window.tokenKey, token);
                        window.app.view.mainView.show();
                        window.app.view.viewManager.loadCurrentView();
                    })
                    .fail(function (msg) {
                        console.log("fail: " + JSON.stringify(msg));
                    });
            },
            registerAction: function (model) {
                webApi.user.register({ user: model.email(), password: model.password() })
                    .done(function (msg) {
                        console.log(msg);
                    })
                    .fail(function (msg) {
                        console.log(msg);
                    });
            }
        };
        return viewModel;
    };
})(window.app.webApi);