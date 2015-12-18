function AuthModel() {
    var self = this;
    self.login = ko.observable();
    self.password = ko.observable();
    self.isRemember = ko.observable();
    self.isAuthenticated = ko.observable();
    var isAuth = false;

    $.ajax({
        url: '/api/Authentication/IsAuthenticated',
        type: 'GET',
        contentType: "text/json",
        dataType: "json",
        success: function(data) {
            isAuth = data;
            self.isAuthenticated(isAuth);
        }
    });

    self.authenticate = function () {
        $.ajax(
            {
                url: '/api/Authentication/Authenticate',
                type: 'POST',
                data: {
                    Login: self.login(),
                    Password: self.password(),
                    IsRemember: self.isRemember()
                },
                success: function(data) {
                    $('#signIn').modal('hide');
                    self.isAuthenticated(true);
                }
            });
    };

    self.logOut = function () {
        $.ajax(
           {
               url: '/api/Authentication/SignOut',
               type: 'DELETE',
               success: function (data) {
                   self.isAuthenticated(false);
               }
           });
    }
}

var authModel = new AuthModel();
var elem = document.getElementById("auth-data");
ko.cleanNode(elem);
ko.applyBindings(authModel, elem);