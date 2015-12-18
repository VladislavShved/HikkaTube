function ThreadModel() {
    var self = this;
    self.isVisible = ko.observable(false);
    self.commentText = ko.observable();

    self.showField = function () {
        var value = self.isVisible();
        self.isVisible(!value);
    }

    self.sendComment = function() {
        var threadId = window.location.pathname.split('/')[3];
        var model = {
            Text: self.commentText(),
            ThreadId: threadId
        };

        $.ajax({
            url: '/api/Comment/AddComment',
            method: 'POST',
            data: model,
            success: function(result) {
                
            }
        });
    }
}

var threadModel = new ThreadModel();
var elem = document.getElementById("thread-data");
ko.cleanNode(elem);
ko.applyBindings(threadModel, elem);