function AuthModel() {


    this.login = ko.observable();
    this.password = ko.observable();
    this.isRemember = ko.observable();

    this.authenticate = function () {
        $.ajax(
            {
                url: 'api/Authentication/Authenticate',
                type: 'POST',
                data: {
                    Login: this.login(),
                    Password: this.password(),
                    IsRemember: this.isRemember()
                },
                success: function(data) {
                    $('#signIn').modal('hide');
                    $("#loginForm").load(location.href + " #loginForm");
                    $("#logoutButton").click();
                }
            });
    };

    this.logOut = function () {
        $.ajax(
           {
               url: 'api/Authentication/SignOut',
               type: 'DELETE',
               success: function (data) {
                   $("#loginForm").load(location.href + " #loginForm");
                   $("#logoutButton").click();
               }
           });
    }
}

var authModel = new AuthModel();
ko.applyBindings(authModel);